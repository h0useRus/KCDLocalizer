using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public partial class ModsForm : Form
    {
        private const string DataFolder = "Data";
        private const string LocalizationFolder = "Localization";

        private readonly string _title;
        private readonly TreeNode _dataNode = new TreeNode(DataFolder, 0, 0) { Tag = NodeTag.Root };
        private readonly TreeNode _localizationNode = new TreeNode(LocalizationFolder, 1, 1) { Tag = NodeTag.Root };

        private ModManifest _manifest;

        public ModsForm(string title)
        {
            InitializeComponent();
            _title = title;
            UpdateControls();
            modTree.Nodes.Add(_dataNode);
            modTree.Nodes.Add(_localizationNode);
            _localizationNode.ContextMenuStrip = cmsLocalization;
        }

        private void UpdateControls()
        {
            Text = _title + (!string.IsNullOrWhiteSpace(_manifest?.Info?.Name) ? $" | {_manifest.Info.Name}" : string.Empty);
            gpModInfo.Enabled = modTree.Enabled = !string.IsNullOrWhiteSpace(tbModFolder.Text);
            GpModInfo_Resize(this, EventArgs.Empty);
        }

        private void BtnOpenMod_Click(object sender, EventArgs e)
        {
            openModFolder.Description = Resources.Caption_Select_mod_folder;
            openModFolder.ShowNewFolderButton = false;
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                ClearAll();
                tbModFolder.Text = openModFolder.SelectedPath;
                _manifest = LoadModManifest(openModFolder.SelectedPath);
                tbModInfoName.Text = _manifest.Info.Name;
                tbModInfoDesc.Text = _manifest.Info.Description;
                tbModInfoAuthor.Text = _manifest.Info.Author;
                tbModInfoVersion.Text = _manifest.Info.Version ?? "1.0.0.0";
                tbModInfoCreated.Text = _manifest.Info.CreatedOn ?? DateTime.Today.ToString("d");
                lbModInfoDependencies.DataSource = _manifest.Info.Dependencies;
                lbModInfoGameVersions.DataSource = _manifest.Supports;
                LoadModStructure(openModFolder.SelectedPath, _dataNode, false);
                LoadModStructure(openModFolder.SelectedPath, _localizationNode, true);
                UpdateControls();
            }
        }

        private ModManifest LoadModManifest(string modRootPath)
        {
            ModManifest manifest = null;
            var manifestFileName = Path.Combine(modRootPath, "mod.manifest");
            if (File.Exists(manifestFileName))
            {
                using (var stream = File.OpenRead(manifestFileName))
                {
                    var serializer = new XmlSerializer(typeof(ModManifest));
                    manifest = serializer.Deserialize(stream) as ModManifest;
                }
            }

            if (manifest == null)
            {
                var pathParts = modRootPath.Split('\\');
                manifest = new ModManifest { Info = new ModManifestInfo { Name = pathParts[pathParts.Length - 1] } };
            }

            return manifest;
        }

        private void LoadModStructure(string rootPath, TreeNode structureNode, bool addFileNode, bool checkConflicts = false)
        {
            modTree.BeginUpdate();
            try
            {
                var structureFolder = Path.Combine(rootPath, structureNode.Text);
                if (Directory.Exists(structureFolder))
                {
                    var files = Directory.GetFiles(structureFolder, "*.pak");
                    foreach (var fileName in files)
                    {
                        var root = structureNode;
                        Language language = null;
                        if (addFileNode)
                        {
                            root = CreateFileNode(structureNode, fileName, checkConflicts, out language);
                        }
                        ReadPackage(fileName, root, language, checkConflicts);
                    }
                }
                structureNode.Expand();
            }
            catch
            {
                structureNode.Nodes.Clear();
                MessageBox.Show(Resources.Unable_to_read_mod_packages, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                modTree.EndUpdate();
            }
        }

        private static TreeNode CreateFileNode(TreeNode parentNode, string fileName, bool checkConflicts, out Language language)
        {
            var key = Path.GetFileName(fileName).ToLower();
            language = Language.Supported.FirstOrDefault(l => string.Equals(key, l.FileName, StringComparison.OrdinalIgnoreCase));
            TreeNode root;
            if (parentNode.Nodes.ContainsKey(key))
            {
                root = parentNode.Nodes[key];
            }
            else
            {
                root = parentNode.Nodes.Add(key, Path.GetFileName(fileName), 1, 1);
                root.Tag = NodeTag.CreatePackage(fileName, language);
                if (checkConflicts)
                    root.ForeColor = Color.Green;
            }

            return root;
        }

        private void ReadPackage(string pakFileName, TreeNode rootNode, Language localization, bool checkConflicts)
        {
            using (var pakFile = ZipFile.OpenRead(pakFileName))
            {
                foreach (var entry in pakFile.Entries.OrderBy(n=>n.Name))
                {
                    var parent = rootNode;
                    if (!Path.HasExtension(entry.FullName))
                        continue;
                    var fileTag = string.Join(":", Path.GetFileNameWithoutExtension(pakFileName), entry.FullName);
                    var names = entry.FullName.Split('/');
                    for (var i = 0; i < names.Length; i++)
                    {
                        var key = names[i].ToLower();
                        var imageIndex = GetNodeImageIndex(names[i], out var isFile);
                        if (!parent.Nodes.ContainsKey(key))
                        {
                            var node = parent.Nodes.Add(key, names[i], imageIndex, imageIndex);
                            if (isFile)
                            {
                                node.Tag = NodeTag.CreateFile(fileTag, localization, false);
                                if (checkConflicts)
                                {
                                    node.ForeColor = Color.Green;
                                    ExpandFullNode(parent);
                                }
                            }
                            else
                            {
                                node.Tag = NodeTag.Folder;
                            }
                            parent = node;
                        }
                        else
                        {
                            parent = parent.Nodes[key];
                            if (isFile)
                            {
                                var tag = (NodeTag)parent.Tag;
                                tag.Sources.Add(fileTag);
                                if (tag.Sources.Count > 1)
                                {
                                    parent.ForeColor = Color.Red;
                                    ExpandFullNode(parent);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static int GetNodeImageIndex(string name, out bool isFile)
        {
            isFile = true;
            var ext = Path.GetExtension(name);
            if (string.IsNullOrEmpty(ext))
            {
                isFile = false;
                return 2;
            }

            switch (ext)
            {
                case ".xml": return 3;
                case ".lua": return 6;
                case ".jpg":
                case ".png":
                case ".dds": return 5;
                default: return 4;
            }
        }

        private static void ExpandFullNode(TreeNode treeNode)
        {
            var node = treeNode;
            while (node != null)
            {
                node.Expand();
                node = node.Parent;
            }
        }

        private void ClearAll()
        {
            _localizationNode.Nodes.Clear();
            _dataNode.Nodes.Clear();
            tbModInfoName.Text =
                tbModInfoDesc.Text =
                    tbModInfoAuthor.Text =
                        tbModInfoVersion.Text =
                            tbModInfoCreated.Text = null;
            lbModInfoDependencies.DataSource = null;
            lbModInfoGameVersions.DataSource = null;
        }

        private void CmsLocalizationAddLanguage_Click(object sender, EventArgs e)
        {
            var languages = new List<Language>();
            foreach (TreeNode node in _localizationNode.Nodes)
            {
                if(node.Tag is NodeTag tag && tag.Language != null)
                    languages.Add(tag.Language);
            }

            if (languages.Count < Language.Supported.Length)
                using (var form = new LocalizationAddForm(languages))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (form.Result.IsLocal)
                        {
                            form.Result.PackageFileName = Path.Combine(tbModFolder.Text, LocalizationFolder, form.Result.PackageFileName);
                        }

                        using (var dlg = new LocalizationCreateForm(form.Result, Path.Combine(tbModFolder.Text, LocalizationFolder)))
                        {
                            dlg.ShowDialog(this);
                            if (dlg.DialogResult == DialogResult.OK)
                            {
                                modTree.BeginUpdate();
                                var node = CreateFileNode(_localizationNode, dlg.PakFileName, false, out var language);
                                ReadPackage(dlg.PakFileName, node, language, false);
                                modTree.EndUpdate();
                            }
                        }
                    }
                }
        }

        private void GpModInfo_Resize(object sender, EventArgs e)
        {
            var fullSize = (gpModInfo.Size.Width - 20) / 2;
            lbModInfoDependencies.Width = fullSize;
            
            lbModInfoGameVersions.Location = new Point(lbModInfoDependencies.Location.X + lbModInfoDependencies.Width + 7, lbModInfoGameVersions.Location.Y);
            lbModInfoGameVersions.Width = fullSize;

            label8.Location = new Point(lbModInfoDependencies.Location.X + lbModInfoDependencies.Width + 7, label8.Location.Y);
        }

        private async void ModTree_DoubleClick(object sender, EventArgs e)
        {
            var selectedNode = modTree.SelectedNode;
            if (selectedNode?.Tag is NodeTag tag)
            {
                switch (tag.Type)
                {
                    case NodeType.Root:
                        break;
                    case NodeType.Package:
                        break;
                    case NodeType.Folder:
                        break;
                    case NodeType.File:
                        if (tag.Language != null)
                        {
                            var fileLink = tag.Sources[0].Split(':');
                            if(fileLink.Length!=2) return;
                            var packageFile = Path.Combine(tbModFolder.Text, LocalizationFolder, fileLink[0] + ".pak");
                            var fileEntry = fileLink[1];
                            if (MessageBox.Show($"Do you want edit '{fileEntry}' file?", $"{tag.Language} Localization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (FileHelpers.TryExtractTemp(packageFile, fileEntry, out var tempFile))
                                    using (var form = new LocalizationForm(tag.Language, fileEntry))
                                    {
                                        await form.LoadAsync(tempFile, tag.IsNew);
                                        if (form.ShowDialog(this) == DialogResult.OK)
                                        {
                                            if (PackLocalization(form.SourceFileName, fileEntry, tag.Language.FileName, out var pakFilePath))
                                            {
                                                selectedNode.ForeColor = modTree.ForeColor;
                                                selectedNode.Tag = NodeTag.CreateFile(string.Join(":", Path.GetFileNameWithoutExtension(tag.Language.FileName), fileEntry), tag.Language, false);
                                                selectedNode.Parent.ForeColor = modTree.ForeColor;
                                            }
                                            else
                                            {
                                                MessageBox.Show(this, $"Can't place '{fileEntry}' into '{tag.Language.FileName}'!", Resources.Caption_Error,
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        File.Delete(form.SourceFileName);
                                    }
                            }
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private bool PackLocalization(string sourceFileName, string fileEntry, string pakFileName, out string pakFilePath)
        {
            try
            {
                pakFilePath = Path.Combine(tbModFolder.Text, LocalizationFolder, pakFileName);
                var exists = File.Exists(pakFilePath);

                if (exists)
                    FileHelpers.TryCreateBackup(pakFilePath, false, out _);

                using (var pakFile = ZipFile.Open(pakFilePath, exists ? ZipArchiveMode.Update : ZipArchiveMode.Create))
                {
                    try
                    {
                        var entry = pakFile.GetEntry(fileEntry);
                        entry?.Delete();
                    } 
                    catch{}
                    pakFile.CreateEntryFromFile(sourceFileName, fileEntry);
                }

                return true;
            }
            catch
            {
                pakFilePath = null;
                return false;
            }
        }
    }
}
