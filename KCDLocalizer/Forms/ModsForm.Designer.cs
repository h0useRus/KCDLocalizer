using NSW.KCDLocalizer.Properties;

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
            this.openModFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.modTree = new System.Windows.Forms.TreeView();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.gpModInfo = new System.Windows.Forms.GroupBox();
            this.lbModInfoGameVersions = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbModInfoDependencies = new System.Windows.Forms.ListBox();
            this.tbModInfoCreated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbModInfoVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbModInfoAuthor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbModInfoDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbModInfoName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenMod = new System.Windows.Forms.Button();
            this.tbModFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsLocalization = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLocalizationAddLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLanguageFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLanguageFileAddFile = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpModInfo.SuspendLayout();
            this.cmsLocalization.SuspendLayout();
            this.cmsLanguageFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 450);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.modTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpModInfo);
            this.splitContainer1.Panel2.Controls.Add(this.btnOpenMod);
            this.splitContainer1.Panel2.Controls.Add(this.tbModFolder);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
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
            this.modTree.Size = new System.Drawing.Size(266, 450);
            this.modTree.TabIndex = 0;
            this.modTree.DoubleClick += new System.EventHandler(this.ModTree_DoubleClick);
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
            // gpModInfo
            // 
            this.gpModInfo.Controls.Add(this.lbModInfoGameVersions);
            this.gpModInfo.Controls.Add(this.label8);
            this.gpModInfo.Controls.Add(this.label7);
            this.gpModInfo.Controls.Add(this.lbModInfoDependencies);
            this.gpModInfo.Controls.Add(this.tbModInfoCreated);
            this.gpModInfo.Controls.Add(this.label6);
            this.gpModInfo.Controls.Add(this.tbModInfoVersion);
            this.gpModInfo.Controls.Add(this.label5);
            this.gpModInfo.Controls.Add(this.tbModInfoAuthor);
            this.gpModInfo.Controls.Add(this.label4);
            this.gpModInfo.Controls.Add(this.tbModInfoDesc);
            this.gpModInfo.Controls.Add(this.label3);
            this.gpModInfo.Controls.Add(this.tbModInfoName);
            this.gpModInfo.Controls.Add(this.label2);
            this.gpModInfo.Location = new System.Drawing.Point(6, 53);
            this.gpModInfo.Name = "gpModInfo";
            this.gpModInfo.Size = new System.Drawing.Size(512, 260);
            this.gpModInfo.TabIndex = 3;
            this.gpModInfo.TabStop = false;
            this.gpModInfo.Text = " Info ";
            this.gpModInfo.Resize += new System.EventHandler(this.GpModInfo_Resize);
            // 
            // lbModInfoGameVersions
            // 
            this.lbModInfoGameVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModInfoGameVersions.FormattingEnabled = true;
            this.lbModInfoGameVersions.Location = new System.Drawing.Point(260, 190);
            this.lbModInfoGameVersions.Name = "lbModInfoGameVersions";
            this.lbModInfoGameVersions.Size = new System.Drawing.Size(246, 56);
            this.lbModInfoGameVersions.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Supported game versions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mod dependencies";
            // 
            // lbModInfoDependencies
            // 
            this.lbModInfoDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModInfoDependencies.FormattingEnabled = true;
            this.lbModInfoDependencies.Location = new System.Drawing.Point(7, 190);
            this.lbModInfoDependencies.Name = "lbModInfoDependencies";
            this.lbModInfoDependencies.Size = new System.Drawing.Size(246, 56);
            this.lbModInfoDependencies.TabIndex = 10;
            // 
            // tbModInfoCreated
            // 
            this.tbModInfoCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModInfoCreated.Location = new System.Drawing.Point(363, 151);
            this.tbModInfoCreated.Name = "tbModInfoCreated";
            this.tbModInfoCreated.Size = new System.Drawing.Size(143, 20);
            this.tbModInfoCreated.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Created date";
            // 
            // tbModInfoVersion
            // 
            this.tbModInfoVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModInfoVersion.Location = new System.Drawing.Point(214, 151);
            this.tbModInfoVersion.Name = "tbModInfoVersion";
            this.tbModInfoVersion.Size = new System.Drawing.Size(143, 20);
            this.tbModInfoVersion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Version";
            // 
            // tbModInfoAuthor
            // 
            this.tbModInfoAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModInfoAuthor.Location = new System.Drawing.Point(7, 151);
            this.tbModInfoAuthor.Name = "tbModInfoAuthor";
            this.tbModInfoAuthor.Size = new System.Drawing.Size(201, 20);
            this.tbModInfoAuthor.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Author";
            // 
            // tbModInfoDesc
            // 
            this.tbModInfoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModInfoDesc.Location = new System.Drawing.Point(7, 72);
            this.tbModInfoDesc.Multiline = true;
            this.tbModInfoDesc.Name = "tbModInfoDesc";
            this.tbModInfoDesc.Size = new System.Drawing.Size(499, 60);
            this.tbModInfoDesc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // tbModInfoName
            // 
            this.tbModInfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModInfoName.Location = new System.Drawing.Point(7, 33);
            this.tbModInfoName.Name = "tbModInfoName";
            this.tbModInfoName.Size = new System.Drawing.Size(499, 20);
            this.tbModInfoName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // btnOpenMod
            // 
            this.btnOpenMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMod.Image = global::NSW.KCDLocalizer.Properties.Resources.open_box;
            this.btnOpenMod.Location = new System.Drawing.Point(498, 25);
            this.btnOpenMod.Name = "btnOpenMod";
            this.btnOpenMod.Size = new System.Drawing.Size(22, 22);
            this.btnOpenMod.TabIndex = 2;
            this.btnOpenMod.Text = "...";
            this.btnOpenMod.UseVisualStyleBackColor = true;
            this.btnOpenMod.Click += new System.EventHandler(this.BtnOpenMod_Click);
            // 
            // tbModFolder
            // 
            this.tbModFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbModFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbModFolder.Location = new System.Drawing.Point(6, 25);
            this.tbModFolder.Name = "tbModFolder";
            this.tbModFolder.ReadOnly = true;
            this.tbModFolder.Size = new System.Drawing.Size(486, 22);
            this.tbModFolder.TabIndex = 1;
            this.tbModFolder.Click += new System.EventHandler(this.BtnOpenMod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mod folder";
            // 
            // cmsLocalization
            // 
            this.cmsLocalization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLocalizationAddLanguage});
            this.cmsLocalization.Name = "cmsLocalization";
            this.cmsLocalization.ShowImageMargin = false;
            this.cmsLocalization.ShowItemToolTips = false;
            this.cmsLocalization.Size = new System.Drawing.Size(138, 26);
            // 
            // cmsLocalizationAddLanguage
            // 
            this.cmsLocalizationAddLanguage.Name = "cmsLocalizationAddLanguage";
            this.cmsLocalizationAddLanguage.Size = new System.Drawing.Size(137, 22);
            this.cmsLocalizationAddLanguage.Text = global::NSW.KCDLocalizer.Properties.Resources.Caption_Add_Localization;
            this.cmsLocalizationAddLanguage.Click += new System.EventHandler(this.CmsLocalizationAddLanguage_Click);
            // 
            // cmsLanguageFile
            // 
            this.cmsLanguageFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLanguageFileAddFile});
            this.cmsLanguageFile.Name = "cmsLanguageFile";
            this.cmsLanguageFile.ShowImageMargin = false;
            this.cmsLanguageFile.Size = new System.Drawing.Size(93, 26);
            // 
            // cmsLanguageFileAddFile
            // 
            this.cmsLanguageFileAddFile.Name = "cmsLanguageFileAddFile";
            this.cmsLanguageFileAddFile.Size = new System.Drawing.Size(92, 22);
            this.cmsLanguageFileAddFile.Text = "Add File";
            // 
            // ModsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModsForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpModInfo.ResumeLayout(false);
            this.gpModInfo.PerformLayout();
            this.cmsLocalization.ResumeLayout(false);
            this.cmsLanguageFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog openModFolder;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView modTree;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.ContextMenuStrip cmsLocalization;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalizationAddLanguage;
        private System.Windows.Forms.ContextMenuStrip cmsLanguageFile;
        private System.Windows.Forms.ToolStripMenuItem cmsLanguageFileAddFile;
        private System.Windows.Forms.Button btnOpenMod;
        private System.Windows.Forms.TextBox tbModFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpModInfo;
        private System.Windows.Forms.TextBox tbModInfoCreated;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbModInfoVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbModInfoAuthor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbModInfoDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbModInfoName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbModInfoGameVersions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbModInfoDependencies;
    }
}