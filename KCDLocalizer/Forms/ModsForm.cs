using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public partial class ModsForm : Form
    {
        private const string DataFolder = "Data";
        private const string LocalizationFolder = "Localization";

        private readonly string _title;
        private readonly TreeNode _dataNode = new TreeNode(DataFolder, 0, 0);
        private readonly TreeNode _localizationNode = new TreeNode(LocalizationFolder, 1, 1);

        private string _primaryModFolder;
        private string _secondaryModFolder;
        private int _conflicts = 0;
        private int _new = 0;

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
            Text = _title + (!string.IsNullOrWhiteSpace(_primaryModFolder) ? $"| {_primaryModFolder}" : string.Empty);
            modTree.Enabled = !string.IsNullOrWhiteSpace(_primaryModFolder);
            menuSaveMerge.Enabled = !string.IsNullOrWhiteSpace(_secondaryModFolder) && _conflicts == 0;
            menuOpenModMerge.Enabled = !string.IsNullOrWhiteSpace(_primaryModFolder) && string.IsNullOrWhiteSpace(_secondaryModFolder);
        }

        private void MenuOpenMod_Click(object sender, EventArgs e)
        {
            openModFolder.Description = Resources.Caption_Select_mod_folder;
            openModFolder.ShowNewFolderButton = false;
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                ClearAll();
                _primaryModFolder = openModFolder.SelectedPath;
                LoadModStructure(_primaryModFolder, _dataNode, false);
                LoadModStructure(_primaryModFolder, _localizationNode, true);
                UpdateControls();
            }
        }

        private void MenuOpenModMerge_Click(object sender, EventArgs e)
        {
            openModFolder.Description = Resources.Caption_Select_mod_folder;
            openModFolder.ShowNewFolderButton = false;
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                _secondaryModFolder = openModFolder.SelectedPath;
                LoadModStructure(_secondaryModFolder, _dataNode, false, true);
                LoadModStructure(_secondaryModFolder, _localizationNode, true, true);
                UpdateControls();
            }
        }

        private void MenuSaveMerge_Click(object sender, EventArgs e)
        {
            openModFolder.Description = Resources.Caption_Select_destination_folder;
            openModFolder.ShowNewFolderButton = true;
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                var parts = openModFolder.SelectedPath.Split('\\');
                CreateModPak(openModFolder.SelectedPath, parts[parts.Length - 1]);
            }
        }

        private void CreateModPak(string modPath, string modName)
        {
            var dataFolder = Path.Combine(modPath, DataFolder);
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);
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
                        if (addFileNode)
                        {
                            var key = Path.GetFileName(fileName).ToLower();
                            if (structureNode.Nodes.ContainsKey(key))
                            {
                                root = structureNode.Nodes[key];
                            }
                            else
                            {
                                root = structureNode.Nodes.Add(key, Path.GetFileName(fileName), 1, 1);
                                root.Tag = LocalizationLanguage.Supported.FirstOrDefault(l => string.Equals(key, l.FileName, StringComparison.OrdinalIgnoreCase));
                                //root.ContextMenuStrip = cmsLanguageFile;
                                if (checkConflicts)
                                    root.ForeColor = Color.Green;
                            }
                        }
                        ReadPackage(fileName, root, checkConflicts);
                    }
                }
            }
            catch
            {
                MessageBox.Show(Resources.Unable_to_read_mod_packages, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                modTree.EndUpdate();
            }
        }

        private void ReadPackage(string pakFileName, TreeNode rootNode, bool checkConflicts)
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
                                node.Tag = new List<string> { fileTag };
                                if (checkConflicts)
                                {
                                    _new++;
                                    node.ForeColor = Color.Green;
                                    ExpandFullNode(parent);
                                }
                            }
                            parent = node;
                        }
                        else
                        {
                            parent = parent.Nodes[key];
                            if (isFile)
                            {
                                var refs = (List<string>)parent.Tag;
                                refs.Add(fileTag);
                                if (refs.Count > 1)
                                {
                                    _conflicts++;
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
            _new = _conflicts = 0;
            _primaryModFolder = _secondaryModFolder = null;
            _localizationNode.Nodes.Clear();
            _dataNode.Nodes.Clear();
        }

        private void CmsLocalizationAddLanguage_Click(object sender, EventArgs e)
        {
            var languages = new List<LocalizationLanguage>();
            foreach (TreeNode node in _localizationNode.Nodes)
            {
                if(node.Tag is LocalizationLanguage language)
                    languages.Add(language);
            }

            using (var form = new SelectLanguageForm(languages))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.SelectedLanguage != null)
                    {
                        modTree.BeginUpdate();
                        var node = _localizationNode.Nodes.Add(form.SelectedLanguage.FileName, form.SelectedLanguage.FileName, 1, 1);
                        node.ForeColor = Color.Blue;
                        //node.ContextMenuStrip = cmsLanguageFile;
                        var sourceLanguage = languages.FirstOrDefault(l => l.Name == "English");
                        if (sourceLanguage == null && languages.Count > 0)
                            sourceLanguage = languages[0];

                        var sourceNode = FindLanguageNode(sourceLanguage);
                        if (sourceNode != null)
                            foreach (TreeNode treeNode in sourceNode.Nodes)
                            {
                                var fileNode = node.Nodes.Add(treeNode.Name, treeNode.Text, treeNode.ImageIndex, treeNode.SelectedImageIndex);
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
                    if(node.Tag is LocalizationLanguage language)
                        if (language.Name == findLanguage.Name)
                            return node;
                }
            return null;
        }
    }
}
