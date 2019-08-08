namespace NSW.KCDLocalizer.Forms
{
    partial class EditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbOriginalEnglish = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOriginalTranslation = new System.Windows.Forms.TextBox();
            this.tbDestinationEnglish = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDestinationTranslation = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(469, 20);
            this.tbKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Original English";
            // 
            // tbOriginalEnglish
            // 
            this.tbOriginalEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOriginalEnglish.Location = new System.Drawing.Point(12, 69);
            this.tbOriginalEnglish.Multiline = true;
            this.tbOriginalEnglish.Name = "tbOriginalEnglish";
            this.tbOriginalEnglish.Size = new System.Drawing.Size(776, 60);
            this.tbOriginalEnglish.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Original Translation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Destination English";
            // 
            // tbOriginalTranslation
            // 
            this.tbOriginalTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOriginalTranslation.Location = new System.Drawing.Point(12, 148);
            this.tbOriginalTranslation.Multiline = true;
            this.tbOriginalTranslation.Name = "tbOriginalTranslation";
            this.tbOriginalTranslation.Size = new System.Drawing.Size(776, 60);
            this.tbOriginalTranslation.TabIndex = 6;
            // 
            // tbDestinationEnglish
            // 
            this.tbDestinationEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationEnglish.Location = new System.Drawing.Point(12, 227);
            this.tbDestinationEnglish.Multiline = true;
            this.tbDestinationEnglish.Name = "tbDestinationEnglish";
            this.tbDestinationEnglish.Size = new System.Drawing.Size(776, 60);
            this.tbDestinationEnglish.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Destination Translation";
            // 
            // tbDestinationTranslation
            // 
            this.tbDestinationTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationTranslation.Location = new System.Drawing.Point(12, 306);
            this.tbDestinationTranslation.Multiline = true;
            this.tbDestinationTranslation.Name = "tbDestinationTranslation";
            this.tbDestinationTranslation.Size = new System.Drawing.Size(776, 60);
            this.tbDestinationTranslation.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(713, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(632, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbDestinationTranslation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDestinationEnglish);
            this.Controls.Add(this.tbOriginalTranslation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOriginalEnglish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditForm";
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOriginalEnglish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOriginalTranslation;
        private System.Windows.Forms.TextBox tbDestinationEnglish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDestinationTranslation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}