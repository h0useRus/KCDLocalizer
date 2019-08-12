namespace NSW.KCDLocalizer.Forms
{
    partial class ModsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModsForm));
            this.mainMenu = new System.Windows.Forms.ToolStrip();
            this.openModFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.modTree = new System.Windows.Forms.TreeView();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.menuOpenMod = new System.Windows.Forms.ToolStripButton();
            this.menuOpenModMerge = new System.Windows.Forms.ToolStripButton();
            this.menuSaveMerge = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenMod,
            this.menuOpenModMerge,
            this.menuSaveMerge});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 39);
            this.mainMenu.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Location = new System.Drawing.Point(0, 39);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 411);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.modTree);
            this.splitContainer1.Size = new System.Drawing.Size(800, 411);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 3;
            // 
            // modTree
            // 
            this.modTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modTree.ImageIndex = 0;
            this.modTree.ImageList = this.iconsList;
            this.modTree.Location = new System.Drawing.Point(0, 0);
            this.modTree.Name = "modTree";
            this.modTree.SelectedImageIndex = 0;
            this.modTree.ShowNodeToolTips = true;
            this.modTree.Size = new System.Drawing.Size(266, 411);
            this.modTree.TabIndex = 0;
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "data_icon.png");
            this.iconsList.Images.SetKeyName(1, "localization_icon.png");
            this.iconsList.Images.SetKeyName(2, "folder.png");
            this.iconsList.Images.SetKeyName(3, "icons8-xml-32.png");
            this.iconsList.Images.SetKeyName(4, "icons8-term-32.png");
            this.iconsList.Images.SetKeyName(5, "icons8-image-file-32.png");
            this.iconsList.Images.SetKeyName(6, "icons8-code-file-32.png");
            // 
            // menuOpenMod
            // 
            this.menuOpenMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOpenMod.Image = global::NSW.KCDLocalizer.Properties.Resources.icons8_open_box_48;
            this.menuOpenMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpenMod.Name = "menuOpenMod";
            this.menuOpenMod.Size = new System.Drawing.Size(36, 36);
            this.menuOpenMod.Text = "Open mod";
            this.menuOpenMod.ToolTipText = "Open mod";
            this.menuOpenMod.Click += new System.EventHandler(this.MenuOpenMod_Click);
            // 
            // menuOpenModMerge
            // 
            this.menuOpenModMerge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOpenModMerge.Enabled = false;
            this.menuOpenModMerge.Image = global::NSW.KCDLocalizer.Properties.Resources.icons8_merge_files_48;
            this.menuOpenModMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpenModMerge.Name = "menuOpenModMerge";
            this.menuOpenModMerge.Size = new System.Drawing.Size(36, 36);
            this.menuOpenModMerge.Text = "Open Merge";
            this.menuOpenModMerge.ToolTipText = "Open mod for merge";
            this.menuOpenModMerge.Click += new System.EventHandler(this.MenuOpenModMerge_Click);
            // 
            // menuSaveMerge
            // 
            this.menuSaveMerge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuSaveMerge.Enabled = false;
            this.menuSaveMerge.Image = global::NSW.KCDLocalizer.Properties.Resources.icons8_merge_48;
            this.menuSaveMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSaveMerge.Name = "menuSaveMerge";
            this.menuSaveMerge.Size = new System.Drawing.Size(36, 36);
            this.menuSaveMerge.Text = "Save merge";
            this.menuSaveMerge.ToolTipText = "Save merge results";
            // 
            // ModsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModsForm";
            this.Text = "ModsForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainMenu;
        private System.Windows.Forms.ToolStripButton menuOpenMod;
        private System.Windows.Forms.ToolStripButton menuOpenModMerge;
        private System.Windows.Forms.FolderBrowserDialog openModFolder;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView modTree;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.ToolStripButton menuSaveMerge;
    }
}