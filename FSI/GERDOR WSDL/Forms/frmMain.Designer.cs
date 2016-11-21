namespace GERDOR_WSDL.forms
{
    partial class frmMain
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
            this.MenuSup = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // DBDetail
            // 
            this.MenuSup.Location = new System.Drawing.Point(0, 0);
            this.MenuSup.Name = "DBDetail";
            this.MenuSup.Size = new System.Drawing.Size(989, 24);
            this.MenuSup.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 803);
            this.Controls.Add(this.MenuSup);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuSup;
            this.Name = "frmMain";
            this.Text = "DBDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuSup;
    }
}

