namespace NSW.KCDLocalizer.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenSourceFile = new System.Windows.Forms.Button();
            this.btnOpenDestinationFile = new System.Windows.Forms.Button();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.tbDestinationFile = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblSorceRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTranslated = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWariningRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErrorRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnglishSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransaltionDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.newXmlFile = new System.Windows.Forms.SaveFileDialog();
            this.cbHideGood = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // openXmlFile
            // 
            this.openXmlFile.Filter = "XML files|*.xml";
            // 
            // btnOpenSourceFile
            // 
            this.btnOpenSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSourceFile.Location = new System.Drawing.Point(763, 15);
            this.btnOpenSourceFile.Name = "btnOpenSourceFile";
            this.btnOpenSourceFile.Size = new System.Drawing.Size(25, 20);
            this.btnOpenSourceFile.TabIndex = 0;
            this.btnOpenSourceFile.Text = "...";
            this.btnOpenSourceFile.UseVisualStyleBackColor = true;
            this.btnOpenSourceFile.Click += new System.EventHandler(this.BtnOpenSourceFile_Click);
            // 
            // btnOpenDestinationFile
            // 
            this.btnOpenDestinationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFile.Location = new System.Drawing.Point(705, 44);
            this.btnOpenDestinationFile.Name = "btnOpenDestinationFile";
            this.btnOpenDestinationFile.Size = new System.Drawing.Size(25, 20);
            this.btnOpenDestinationFile.TabIndex = 1;
            this.btnOpenDestinationFile.Text = "...";
            this.btnOpenDestinationFile.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFile.Click += new System.EventHandler(this.BtnOpenDestinationFile_Click);
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourceFile.Location = new System.Drawing.Point(80, 15);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.ReadOnly = true;
            this.tbSourceFile.Size = new System.Drawing.Size(677, 20);
            this.tbSourceFile.TabIndex = 2;
            this.tbSourceFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TbSourceFile_MouseDoubleClick);
            // 
            // tbDestinationFile
            // 
            this.tbDestinationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationFile.Location = new System.Drawing.Point(80, 44);
            this.tbDestinationFile.Name = "tbDestinationFile";
            this.tbDestinationFile.ReadOnly = true;
            this.tbDestinationFile.Size = new System.Drawing.Size(619, 20);
            this.tbDestinationFile.TabIndex = 3;
            this.tbDestinationFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TbDestinationFile_MouseDoubleClick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSorceRows,
            this.lblTranslated,
            this.lblWariningRows,
            this.lblErrorRows,
            this.mainProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 426);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 24);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblSorceRows
            // 
            this.lblSorceRows.AutoSize = false;
            this.lblSorceRows.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblSorceRows.Name = "lblSorceRows";
            this.lblSorceRows.Size = new System.Drawing.Size(40, 19);
            // 
            // lblTranslated
            // 
            this.lblTranslated.AutoSize = false;
            this.lblTranslated.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTranslated.Name = "lblTranslated";
            this.lblTranslated.Size = new System.Drawing.Size(40, 19);
            // 
            // lblWariningRows
            // 
            this.lblWariningRows.AutoSize = false;
            this.lblWariningRows.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWariningRows.Name = "lblWariningRows";
            this.lblWariningRows.Size = new System.Drawing.Size(40, 19);
            // 
            // lblErrorRows
            // 
            this.lblErrorRows.AutoSize = false;
            this.lblErrorRows.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblErrorRows.Name = "lblErrorRows";
            this.lblErrorRows.Size = new System.Drawing.Size(40, 19);
            // 
            // mainProgress
            // 
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(100, 18);
            this.mainProgress.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Translation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.AllowUserToResizeColumns = false;
            this.gvMain.AllowUserToResizeRows = false;
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colEnglishSrc,
            this.colTransaltionDes});
            this.gvMain.Location = new System.Drawing.Point(15, 70);
            this.gvMain.MultiSelect = false;
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.RowHeadersVisible = false;
            this.gvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMain.Size = new System.Drawing.Size(773, 324);
            this.gvMain.TabIndex = 7;
            this.gvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvMain_CellDoubleClick);
            this.gvMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.GvMain_RowPrePaint);
            // 
            // colKey
            // 
            this.colKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colKey.DataPropertyName = "Key";
            this.colKey.HeaderText = "Key";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Width = 50;
            // 
            // colEnglishSrc
            // 
            this.colEnglishSrc.DataPropertyName = "OriginalEnglish";
            this.colEnglishSrc.HeaderText = "English";
            this.colEnglishSrc.Name = "colEnglishSrc";
            this.colEnglishSrc.ReadOnly = true;
            // 
            // colTransaltionDes
            // 
            this.colTransaltionDes.DataPropertyName = "DestinationTranslation";
            this.colTransaltionDes.HeaderText = "Translation";
            this.colTransaltionDes.Name = "colTransaltionDes";
            this.colTransaltionDes.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(713, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save All";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(736, 44);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(52, 20);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // newXmlFile
            // 
            this.newXmlFile.DefaultExt = "xml";
            // 
            // cbHideGood
            // 
            this.cbHideGood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbHideGood.AutoSize = true;
            this.cbHideGood.Location = new System.Drawing.Point(15, 404);
            this.cbHideGood.Name = "cbHideGood";
            this.cbHideGood.Size = new System.Drawing.Size(77, 17);
            this.cbHideGood.TabIndex = 11;
            this.cbHideGood.Text = "Hide Good";
            this.cbHideGood.UseVisualStyleBackColor = true;
            this.cbHideGood.CheckedChanged += new System.EventHandler(this.CbHideTranslated_CheckedChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(632, 400);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 12;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.cbHideGood);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tbDestinationFile);
            this.Controls.Add(this.tbSourceFile);
            this.Controls.Add(this.btnOpenDestinationFile);
            this.Controls.Add(this.btnOpenSourceFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openXmlFile;
        private System.Windows.Forms.Button btnOpenSourceFile;
        private System.Windows.Forms.Button btnOpenDestinationFile;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.TextBox tbDestinationFile;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnglishSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransaltionDes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripProgressBar mainProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblSorceRows;
        private System.Windows.Forms.ToolStripStatusLabel lblTranslated;
        private System.Windows.Forms.ToolStripStatusLabel lblWariningRows;
        private System.Windows.Forms.ToolStripStatusLabel lblErrorRows;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.SaveFileDialog newXmlFile;
        private System.Windows.Forms.CheckBox cbHideGood;
        private System.Windows.Forms.Button btnAddNew;
    }
}