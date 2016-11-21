namespace GERDOR_WSDL
{
    partial class GeradorContratos
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
            this.wsdlButton = new System.Windows.Forms.Button();
            this.xsdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wsdlButton
            // 
            this.wsdlButton.Location = new System.Drawing.Point(12, 12);
            this.wsdlButton.Name = "wsdlButton";
            this.wsdlButton.Size = new System.Drawing.Size(260, 23);
            this.wsdlButton.TabIndex = 0;
            this.wsdlButton.Text = "Gerar WSDL";
            this.wsdlButton.UseVisualStyleBackColor = true;
            this.wsdlButton.Click += new System.EventHandler(this.wsdlButton_Click);
            // 
            // xsdButton
            // 
            this.xsdButton.Location = new System.Drawing.Point(12, 41);
            this.xsdButton.Name = "xsdButton";
            this.xsdButton.Size = new System.Drawing.Size(260, 23);
            this.xsdButton.TabIndex = 1;
            this.xsdButton.Text = "Gerar XSD";
            this.xsdButton.UseVisualStyleBackColor = true;
            this.xsdButton.Click += new System.EventHandler(this.xsdButton_Click);
            // 
            // GeradorContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 76);
            this.Controls.Add(this.xsdButton);
            this.Controls.Add(this.wsdlButton);
            this.Name = "GeradorContratos";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button wsdlButton;
        private System.Windows.Forms.Button xsdButton;
    }
}

