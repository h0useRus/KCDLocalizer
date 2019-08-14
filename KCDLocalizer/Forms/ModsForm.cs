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
                        var key = Path.GetFileName(fileName).ToLower();
                        var root = structureNode;
                        var currentLocalization = LocalizationLanguage.Supported.FirstOrDefault(l => string.Equals(key, l.FileName, StringComparison.OrdinalIgnoreCase));
                        if (addFileNode)
                        {
                            if (structureNode.Nodes.ContainsKey(key))
                            {
                                root = structureNode.Nodes[key];
                            }
                            else
                            {
                                root = structureNode.Nodes.Add(key, Path.GetFileName(fileName), 1, 1);
                                root.Tag = NodeTag.CreatePackage(fileName, currentLocalization);
                                if (checkConflicts)
                                    root.ForeColor = Color.Green;
                            }
                        }
                        ReadPackage(fileName, root, currentLocalization, checkConflicts);
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

        private void ReadPackage(string pakFileName, TreeNode rootNode, LocalizationLanguage localization, bool checkConflicts)
        {
            using (var pakFile = ZipFile.OpenRead(pakFileName))
            {
                foreach (var entry in pakFile.Entries)
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
            var languages = new List<LocalizationLanguage>();
            foreach (TreeNode node in _localizationNode.Nodes)
            {
                if(node.Tag is NodeTag tag && tag.Localization != null)
                    languages.Add(tag.Localization);
            }

            using (var form = new SelectLanguageForm(languages))
            {
                form.Text = Resources.Caption_Add_Localization;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.SelectedLanguage != null)
                    {
                        modTree.BeginUpdate();
                        var node = _localizationNode.Nodes.Add(form.SelectedLanguage.FileName.ToLower(), form.SelectedLanguage.FileName, 1, 1);
                        node.ForeColor = Color.Blue;
                        node.Tag = NodeTag.CreateFile(form.SelectedLanguage.FileName, form.SelectedLanguage, true);

                        var sourceLanguage = languages.FirstOrDefault(l => l.Name == "English");
                        if (sourceLanguage == null && languages.Count > 0)
                            sourceLanguage = languages[0];

                        var sourceNode = FindLanguageNode(sourceLanguage);
                        if (sourceNode != null)
                            foreach (TreeNode sourceFileNode in sourceNode.Nodes)
                            {
                                var fileNode = node.Nodes.Add(sourceFileNode.Name, sourceFileNode.Text, sourceFileNode.ImageIndex, sourceFileNode.SelectedImageIndex);
                                if (sourceFileNode.Tag is NodeTag tag)
                                {
                                    fileNode.Tag = NodeTag.CreateFile(tag.Sources[0], form.SelectedLanguage, true);
                                }
                                fileNode.ForeColor = Color.Blue;
                            }
                        modTree.EndUpdate();
                        ExpandFullNode(node);
                    }
                }
            }
        }

        private TreeNode FindLanguageNode(LocalizationLanguage findLanguage)
        {
            if(findLanguage!=null)
                foreach (TreeNode node in _localizationNode.Nodes)
                {
                    if(node.Tag is NodeTag tag && tag.Localization != null)
                        if (tag.Localization.Name == findLanguage.Name)
                            return node;
                }
            return null;
        }

        private void GpModInfo_Resize(object sender, EventArgs e)
        {
            var fullsize = (gpModInfo.Size.Width - 20) / 2;
            lbModInfoDependencies.Width = fullsize;
            
            lbModInfoGameVersions.Location = new Point(lbModInfoDependencies.Location.X + lbModInfoDependencies.Width + 7, lbModInfoGameVersions.Location.Y);
            lbModInfoGameVersions.Width = fullsize;

            label8.Location = new Point(lbModInfoDependencies.Location.X + lbModInfoDependencies.Width + 7, label8.Location.Y);
        }

        private void ModTree_DoubleClick(object sender, EventArgs e)
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
                        if (tag.Localization != null)
                        {
                            var fileLink = tag.Sources[0].Split(':');
                            var packageFile = Path.Combine(tbModFolder.Text, LocalizationFolder, fileLink[0] + ".pak");
                            var fileName = fileLink[1];
                            if (MessageBox.Show($"Do you want to open '{fileName}'?", $"{tag.Localization.Name} Localization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if(FileHelpers.TryExtractTemp(packageFile, fileName, out var tempFile ))
                                    using (var form = new LocalizationForm(tempFile, tag.IsNew, tag.Localization, fileName))
                                    {
                                        if (form.ShowDialog(this) != DialogResult.Cancel)
                                        {

                                        }
                                        File.Delete(tempFile);
                                    }
                            }
                        }
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
