namespace NSW.KCDLocalizer.Forms
{
    partial class LocalizationAddForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenPackage = new System.Windows.Forms.Button();
            this.tbNewPackage = new System.Windows.Forms.TextBox();
            this.cbExistingLanguages = new System.Windows.Forms.ComboBox();
            this.cbIncludeTranslation = new System.Windows.Forms.CheckBox();
            this.cbPakResources = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbFromExisting = new System.Windows.Forms.RadioButton();
            this.rbFromPackage = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose language";
            // 
            // cbLanguages
            // 
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Location = new System.Drawing.Point(16, 30);
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(322, 21);
            this.cbLanguages.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(186, 352);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFromPackage);
            this.groupBox1.Controls.Add(this.rbFromExisting);
            this.groupBox1.Controls.Add(this.cbPakResources);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnOpenPackage);
            this.groupBox1.Controls.Add(this.tbNewPackage);
            this.groupBox1.Controls.Add(this.cbExistingLanguages);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Select source";
            // 
            // btnOpenPackage
            // 
            this.btnOpenPackage.Location = new System.Drawing.Point(299, 92);
            this.btnOpenPackage.Name = "btnOpenPackage";
            this.btnOpenPackage.Size = new System.Drawing.Size(25, 20);
            this.btnOpenPackage.TabIndex = 5;
            this.btnOpenPackage.Text = "...";
            this.btnOpenPackage.UseVisualStyleBackColor = true;
            this.btnOpenPackage.Click += new System.EventHandler(this.BtnOpenPackage_Click);
            // 
            // tbNewPackage
            // 
            this.tbNewPackage.Location = new System.Drawing.Point(20, 92);
            this.tbNewPackage.Name = "tbNewPackage";
            this.tbNewPackage.ReadOnly = true;
            this.tbNewPackage.Size = new System.Drawing.Size(273, 20);
            this.tbNewPackage.TabIndex = 7;
            this.tbNewPackage.DoubleClick += new System.EventHandler(this.BtnOpenPackage_Click);
            // 
            // cbExistingLanguages
            // 
            this.cbExistingLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExistingLanguages.FormattingEnabled = true;
            this.cbExistingLanguages.Location = new System.Drawing.Point(20, 42);
            this.cbExistingLanguages.Name = "cbExistingLanguages";
            this.cbExistingLanguages.Size = new System.Drawing.Size(306, 21);
            this.cbExistingLanguages.TabIndex = 5;
            // 
            // cbIncludeTranslation
            // 
            this.cbIncludeTranslation.AutoSize = true;
            this.cbIncludeTranslation.Location = new System.Drawing.Point(16, 329);
            this.cbIncludeTranslation.Name = "cbIncludeTranslation";
            this.cbIncludeTranslation.Size = new System.Drawing.Size(112, 17);
            this.cbIncludeTranslation.TabIndex = 7;
            this.cbIncludeTranslation.Text = "Include translation";
            this.cbIncludeTranslation.UseVisualStyleBackColor = true;
            // 
            // cbPakResources
            // 
            this.cbPakResources.FormattingEnabled = true;
            this.cbPakResources.Location = new System.Drawing.Point(20, 131);
            this.cbPakResources.Name = "cbPakResources";
            this.cbPakResources.Size = new System.Drawing.Size(304, 124);
            this.cbPakResources.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select resources";
            // 
            // rbFromExisting
            // 
            this.rbFromExisting.AutoSize = true;
            this.rbFromExisting.Location = new System.Drawing.Point(4, 19);
            this.rbFromExisting.Name = "rbFromExisting";
            this.rbFromExisting.Size = new System.Drawing.Size(141, 17);
            this.rbFromExisting.TabIndex = 10;
            this.rbFromExisting.TabStop = true;
            this.rbFromExisting.Text = "From existing localization";
            this.rbFromExisting.UseVisualStyleBackColor = true;
            // 
            // rbFromPackage
            // 
            this.rbFromPackage.AutoSize = true;
            this.rbFromPackage.Location = new System.Drawing.Point(4, 69);
            this.rbFromPackage.Name = "rbFromPackage";
            this.rbFromPackage.Size = new System.Drawing.Size(136, 17);
            this.rbFromPackage.TabIndex = 11;
            this.rbFromPackage.TabStop = true;
            this.rbFromPackage.Text = "From other package file";
            this.rbFromPackage.UseVisualStyleBackColor = true;
            // 
            // LocalizationAddForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 380);
            this.Controls.Add(this.cbIncludeTranslation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocalizationAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new localization";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNewPackage;
        private System.Windows.Forms.ComboBox cbExistingLanguages;
        private System.Windows.Forms.Button btnOpenPackage;
        private System.Windows.Forms.CheckBox cbIncludeTranslation;
        private System.Windows.Forms.CheckedListBox cbPakResources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbFromPackage;
        private System.Windows.Forms.RadioButton rbFromExisting;
    }
}