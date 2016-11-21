namespace FSI.Exposition.Forms.Forms
{
    partial class frmManualBuild
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
            this.treeContract = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeContract
            // 
            this.treeContract.Location = new System.Drawing.Point(367, 37);
            this.treeContract.Name = "treeContract";
            this.treeContract.Size = new System.Drawing.Size(238, 314);
            this.treeContract.TabIndex = 0;
            // 
            // frmManualBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 363);
            this.Controls.Add(this.treeContract);
            this.Name = "frmManualBuild";
            this.Text = "frmManualBuild";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeContract;
    }
}