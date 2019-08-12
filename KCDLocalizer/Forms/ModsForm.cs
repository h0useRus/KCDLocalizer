using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class ModsForm : Form
    {
        private const string DataFolder = "Data";
        private const string LocalizationFolder = "Localization";

        private readonly string _title;
        private readonly TreeNode _dataNode = new TreeNode(DataFolder, 0, 0);
        private readonly TreeNode _localizationNode = new TreeNode(LocalizationFolder, 1 , 1);

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
        }

        private void UpdateControls()
        {
            Text = _title + (!string.IsNullOrWhiteSpace(_primaryModFolder) ? $"| {_primaryModFolder}" : string.Empty);
            modTree.Enabled = !string.IsNullOrWhiteSpace(_primaryModFolder);
            menuSaveMerge.Enabled = !string.IsNullOrWhiteSpace(_secondaryModFolder) && _conflicts == 0;
        }

        private void MenuOpenMod_Click(object sender, EventArgs e)
        {
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                _primaryModFolder = openModFolder.SelectedPath;
                _dataNode.Nodes.Clear();
                LoadModStructure(_primaryModFolder, _dataNode, false);
                _localizationNode.Nodes.Clear();
                LoadModStructure(_primaryModFolder, _localizationNode, true);
                menuOpenModMerge.Enabled = true;
                UpdateControls();
            }
        }

        private void MenuOpenModMerge_Click(object sender, EventArgs e)
        {
            if (openModFolder.ShowDialog() == DialogResult.OK)
            {
                _secondaryModFolder = openModFolder.SelectedPath;
                LoadModStructure(_secondaryModFolder, _dataNode, false, true);
                LoadModStructure(_secondaryModFolder, _localizationNode, true, true);
                menuOpenModMerge.Enabled = false;
                UpdateControls();
            }
        }

        private int GetNodeImageIndex(string name, out bool isFile)
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
                case ".xml" : return 3;
                case ".lua": return 6;
                case ".jpg":
                case ".png":
                case ".dds": return 5;
                default: return 4;
            }
        }

        private void LoadModStructure(string rootPath, TreeNode structureNode, bool addFileNode, bool checkConflicts = false)
        {
            var dataFolder = Path.Combine(rootPath, structureNode.Text);
            if (Directory.Exists(dataFolder))
            {
                var files = Directory.GetFiles(dataFolder, "*.pak");
                foreach (var fileName in files)
                {
                    var root = structureNode;
                    if (addFileNode)
                    {
                        var key = Path.GetFileName(fileName).ToLower();
                        if (!structureNode.Nodes.ContainsKey(key))
                        {
                            root = structureNode.Nodes.Add(key, Path.GetFileName(fileName));
                            root.Tag = new List<string> { fileName };
                        }
                        else
                        {
                            root = structureNode.Nodes[key];
                            ((List<string>)root.Tag).Add(fileName);
                        }
                    }

                    using (var pakFile = ZipFile.OpenRead(fileName))
                    {
                        foreach (var entry in pakFile.Entries)
                        {
                            var parent = root;
                            if(!Path.HasExtension(entry.FullName))
                                continue;
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
                                        node.Tag= new List<string> {string.Join(":", Path.GetFileNameWithoutExtension(fileName), entry.FullName)};
                                        if (checkConflicts)
                                        {
                                            _new++;
                                            modTree.BeginUpdate();
                                            node.ForeColor = Color.Green;
                                            modTree.EndUpdate();
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
                                        var refs = (List<string>) parent.Tag;
                                        refs.Add(string.Join(":", Path.GetFileNameWithoutExtension(fileName), entry.FullName));
                                        parent.ToolTipText = string.Join(Environment.NewLine,refs);
                                        if (refs.Count > 1)
                                        {
                                            _conflicts++;
                                            modTree.BeginUpdate();
                                            parent.NodeFont = new Font(modTree.Font, FontStyle.Bold);
                                            parent.ForeColor = Color.Red;
                                            modTree.EndUpdate();
                                            ExpandFullNode(parent);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ExpandFullNode(TreeNode treeNode)
        {
            var node = treeNode;
            while (node != null)
            {
                node.Expand();
                node = node.Parent;
            }
        }
    }
}
