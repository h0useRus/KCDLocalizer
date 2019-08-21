namespace NSW.KCDLocalizer.Forms
{
    partial class LocalizationCreateForm
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
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbProcess
            // 
            this.pbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcess.Location = new System.Drawing.Point(12, 12);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(389, 23);
            this.pbProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProcess.TabIndex = 0;
            this.pbProcess.UseWaitCursor = true;
            // 
            // LocalizationCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 49);
            this.ControlBox = false;
            this.Controls.Add(this.pbProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocalizationCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new package";
            this.Shown += new System.EventHandler(this.LocalizationCreateForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProcess;
    }
}