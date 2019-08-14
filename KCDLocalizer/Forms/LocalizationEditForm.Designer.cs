namespace NSW.KCDLocalizer.Forms
{
    partial class LocalizationEditForm
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
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSampleTranslation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTranslation = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTranslationCopy = new System.Windows.Forms.Button();
            this.gbEnglish = new System.Windows.Forms.GroupBox();
            this.btnEnglishCopy = new System.Windows.Forms.Button();
            this.tbEnglish = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSampleEnglish = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTranslation = new System.Windows.Forms.GroupBox();
            this.btnFromEnglishToTranslation = new System.Windows.Forms.Button();
            this.gbEnglish.SuspendLayout();
            this.gbTranslation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(12, 29);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(469, 20);
            this.tbKey.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sample";
            // 
            // tbSampleTranslation
            // 
            this.tbSampleTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSampleTranslation.Location = new System.Drawing.Point(6, 32);
            this.tbSampleTranslation.Multiline = true;
            this.tbSampleTranslation.Name = "tbSampleTranslation";
            this.tbSampleTranslation.Size = new System.Drawing.Size(895, 60);
            this.tbSampleTranslation.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Destination";
            // 
            // tbTranslation
            // 
            this.tbTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTranslation.Location = new System.Drawing.Point(6, 126);
            this.tbTranslation.Multiline = true;
            this.tbTranslation.Name = "tbTranslation";
            this.tbTranslation.Size = new System.Drawing.Size(895, 60);
            this.tbTranslation.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(844, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(763, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnTranslationCopy
            // 
            this.btnTranslationCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslationCopy.Image = global::NSW.KCDLocalizer.Properties.Resources.arrow_down;
            this.btnTranslationCopy.Location = new System.Drawing.Point(879, 98);
            this.btnTranslationCopy.Name = "btnTranslationCopy";
            this.btnTranslationCopy.Size = new System.Drawing.Size(22, 22);
            this.btnTranslationCopy.TabIndex = 13;
            this.btnTranslationCopy.UseVisualStyleBackColor = true;
            this.btnTranslationCopy.Click += new System.EventHandler(this.BtnTranslationCopy_Click);
            // 
            // gbEnglish
            // 
            this.gbEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEnglish.Controls.Add(this.btnEnglishCopy);
            this.gbEnglish.Controls.Add(this.tbEnglish);
            this.gbEnglish.Controls.Add(this.label4);
            this.gbEnglish.Controls.Add(this.tbSampleEnglish);
            this.gbEnglish.Controls.Add(this.label2);
            this.gbEnglish.Location = new System.Drawing.Point(12, 55);
            this.gbEnglish.Name = "gbEnglish";
            this.gbEnglish.Size = new System.Drawing.Size(907, 196);
            this.gbEnglish.TabIndex = 14;
            this.gbEnglish.TabStop = false;
            this.gbEnglish.Text = " English Text ";
            // 
            // btnEnglishCopy
            // 
            this.btnEnglishCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnglishCopy.Image = global::NSW.KCDLocalizer.Properties.Resources.arrow_down;
            this.btnEnglishCopy.Location = new System.Drawing.Point(879, 98);
            this.btnEnglishCopy.Name = "btnEnglishCopy";
            this.btnEnglishCopy.Size = new System.Drawing.Size(22, 22);
            this.btnEnglishCopy.TabIndex = 17;
            this.btnEnglishCopy.UseVisualStyleBackColor = true;
            this.btnEnglishCopy.Click += new System.EventHandler(this.BtnEnglishCopy_Click);
            // 
            // tbEnglish
            // 
            this.tbEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEnglish.Location = new System.Drawing.Point(6, 126);
            this.tbEnglish.Multiline = true;
            this.tbEnglish.Name = "tbEnglish";
            this.tbEnglish.Size = new System.Drawing.Size(895, 60);
            this.tbEnglish.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Destination";
            // 
            // tbSampleEnglish
            // 
            this.tbSampleEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSampleEnglish.Location = new System.Drawing.Point(6, 32);
            this.tbSampleEnglish.Multiline = true;
            this.tbSampleEnglish.Name = "tbSampleEnglish";
            this.tbSampleEnglish.Size = new System.Drawing.Size(895, 60);
            this.tbSampleEnglish.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sample";
            // 
            // gbTranslation
            // 
            this.gbTranslation.Controls.Add(this.label3);
            this.gbTranslation.Controls.Add(this.tbSampleTranslation);
            this.gbTranslation.Controls.Add(this.btnTranslationCopy);
            this.gbTranslation.Controls.Add(this.label5);
            this.gbTranslation.Controls.Add(this.tbTranslation);
            this.gbTranslation.Location = new System.Drawing.Point(12, 285);
            this.gbTranslation.Name = "gbTranslation";
            this.gbTranslation.Size = new System.Drawing.Size(907, 197);
            this.gbTranslation.TabIndex = 15;
            this.gbTranslation.TabStop = false;
            this.gbTranslation.Text = " Translation text ";
            // 
            // btnFromEnglishToTranslation
            // 
            this.btnFromEnglishToTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromEnglishToTranslation.Image = global::NSW.KCDLocalizer.Properties.Resources.arrow_down;
            this.btnFromEnglishToTranslation.Location = new System.Drawing.Point(891, 257);
            this.btnFromEnglishToTranslation.Name = "btnFromEnglishToTranslation";
            this.btnFromEnglishToTranslation.Size = new System.Drawing.Size(22, 22);
            this.btnFromEnglishToTranslation.TabIndex = 18;
            this.btnFromEnglishToTranslation.UseVisualStyleBackColor = true;
            this.btnFromEnglishToTranslation.Click += new System.EventHandler(this.BtnFromEnglishToTranslation_Click);
            // 
            // LocalizationEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(931, 519);
            this.Controls.Add(this.btnFromEnglishToTranslation);
            this.Controls.Add(this.gbTranslation);
            this.Controls.Add(this.gbEnglish);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LocalizationEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.gbEnglish.ResumeLayout(false);
            this.gbEnglish.PerformLayout();
            this.gbTranslation.ResumeLayout(false);
            this.gbTranslation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSampleTranslation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTranslation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTranslationCopy;
        private System.Windows.Forms.GroupBox gbEnglish;
        private System.Windows.Forms.Button btnEnglishCopy;
        private System.Windows.Forms.TextBox tbEnglish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSampleEnglish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbTranslation;
        private System.Windows.Forms.Button btnFromEnglishToTranslation;
    }
}