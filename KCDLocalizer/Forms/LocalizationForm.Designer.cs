namespace NSW.KCDLocalizer.Forms
{
    partial class LocalizationForm
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
            this.openXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenDestinationFile = new System.Windows.Forms.Button();
            this.tbDestinationFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransaltion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbHideTranslated = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbAutoTranslate = new System.Windows.Forms.CheckBox();
            this.cbAddMissedKeys = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // openXmlFile
            // 
            this.openXmlFile.Filter = "Package file|*.pak|XML file|*.xml";
            // 
            // btnOpenDestinationFile
            // 
            this.btnOpenDestinationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationFile.Location = new System.Drawing.Point(763, 6);
            this.btnOpenDestinationFile.Name = "btnOpenDestinationFile";
            this.btnOpenDestinationFile.Size = new System.Drawing.Size(25, 20);
            this.btnOpenDestinationFile.TabIndex = 1;
            this.btnOpenDestinationFile.Text = "...";
            this.btnOpenDestinationFile.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFile.Click += new System.EventHandler(this.BtnOpenDestinationFile_Click);
            // 
            // tbDestinationFile
            // 
            this.tbDestinationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationFile.Location = new System.Drawing.Point(120, 6);
            this.tbDestinationFile.Name = "tbDestinationFile";
            this.tbDestinationFile.ReadOnly = true;
            this.tbDestinationFile.Size = new System.Drawing.Size(637, 20);
            this.tbDestinationFile.TabIndex = 3;
            this.tbDestinationFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TbDestinationFile_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Get localization from";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.colEnglish,
            this.colTransaltion});
            this.gvMain.Location = new System.Drawing.Point(15, 57);
            this.gvMain.MultiSelect = false;
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.RowHeadersVisible = false;
            this.gvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMain.Size = new System.Drawing.Size(773, 350);
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
            // colEnglish
            // 
            this.colEnglish.DataPropertyName = "English";
            this.colEnglish.HeaderText = "English";
            this.colEnglish.Name = "colEnglish";
            this.colEnglish.ReadOnly = true;
            // 
            // colTransaltion
            // 
            this.colTransaltion.DataPropertyName = "Translation";
            this.colTransaltion.HeaderText = "Translation";
            this.colTransaltion.Name = "colTransaltion";
            this.colTransaltion.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(632, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cbHideTranslated
            // 
            this.cbHideTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbHideTranslated.AutoSize = true;
            this.cbHideTranslated.Location = new System.Drawing.Point(15, 417);
            this.cbHideTranslated.Name = "cbHideTranslated";
            this.cbHideTranslated.Size = new System.Drawing.Size(97, 17);
            this.cbHideTranslated.TabIndex = 11;
            this.cbHideTranslated.Text = "Hide translated";
            this.cbHideTranslated.UseVisualStyleBackColor = true;
            this.cbHideTranslated.CheckedChanged += new System.EventHandler(this.CbHideTranslated_CheckedChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(546, 413);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(80, 23);
            this.btnAddNew.TabIndex = 12;
            this.btnAddNew.Text = "Add New Key";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(713, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbAutoTranslate
            // 
            this.cbAutoTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoTranslate.AutoSize = true;
            this.cbAutoTranslate.Checked = true;
            this.cbAutoTranslate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoTranslate.Location = new System.Drawing.Point(15, 34);
            this.cbAutoTranslate.Name = "cbAutoTranslate";
            this.cbAutoTranslate.Size = new System.Drawing.Size(91, 17);
            this.cbAutoTranslate.TabIndex = 14;
            this.cbAutoTranslate.Text = "Auto-translate";
            this.cbAutoTranslate.UseVisualStyleBackColor = true;
            // 
            // cbAddMissedKeys
            // 
            this.cbAddMissedKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAddMissedKeys.AutoSize = true;
            this.cbAddMissedKeys.Checked = true;
            this.cbAddMissedKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddMissedKeys.Location = new System.Drawing.Point(112, 34);
            this.cbAddMissedKeys.Name = "cbAddMissedKeys";
            this.cbAddMissedKeys.Size = new System.Drawing.Size(105, 17);
            this.cbAddMissedKeys.TabIndex = 15;
            this.cbAddMissedKeys.Text = "Add missed keys";
            this.cbAddMissedKeys.UseVisualStyleBackColor = true;
            // 
            // LocalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.cbAddMissedKeys);
            this.Controls.Add(this.cbAutoTranslate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.cbHideTranslated);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDestinationFile);
            this.Controls.Add(this.btnOpenDestinationFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LocalizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LocalizationForm";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openXmlFile;
        private System.Windows.Forms.Button btnOpenDestinationFile;
        private System.Windows.Forms.TextBox tbDestinationFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbHideTranslated;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransaltion;
        private System.Windows.Forms.CheckBox cbAutoTranslate;
        private System.Windows.Forms.CheckBox cbAddMissedKeys;
    }
}