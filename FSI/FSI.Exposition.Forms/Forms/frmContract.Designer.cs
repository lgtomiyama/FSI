namespace FSI.Exposition.Forms
{
    partial class frmContract
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
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOperations = new System.Windows.Forms.ComboBox();
            this.txtXSDIn = new System.Windows.Forms.RichTextBox();
            this.txtXSDOut = new System.Windows.Forms.RichTextBox();
            this.txtWSDL = new System.Windows.Forms.RichTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckUnion = new System.Windows.Forms.CheckBox();
            this.checkSNSE = new System.Windows.Forms.CheckBox();
            this.btnDir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(12, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "&Abrir Planilha";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(93, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "WSDL:";
            // 
            // cmbOperations
            // 
            this.cmbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperations.FormattingEnabled = true;
            this.cmbOperations.Location = new System.Drawing.Point(174, 14);
            this.cmbOperations.Name = "cmbOperations";
            this.cmbOperations.Size = new System.Drawing.Size(288, 21);
            this.cmbOperations.TabIndex = 8;
            this.cmbOperations.SelectedIndexChanged += new System.EventHandler(this.cmbOperations_SelectedIndexChanged);
            // 
            // txtXSDIn
            // 
            this.txtXSDIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXSDIn.Location = new System.Drawing.Point(3, 16);
            this.txtXSDIn.Name = "txtXSDIn";
            this.txtXSDIn.Size = new System.Drawing.Size(423, 354);
            this.txtXSDIn.TabIndex = 9;
            this.txtXSDIn.Text = "";
            // 
            // txtXSDOut
            // 
            this.txtXSDOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXSDOut.Location = new System.Drawing.Point(3, 16);
            this.txtXSDOut.Name = "txtXSDOut";
            this.txtXSDOut.Size = new System.Drawing.Size(423, 354);
            this.txtXSDOut.TabIndex = 10;
            this.txtXSDOut.Text = "";
            // 
            // txtWSDL
            // 
            this.txtWSDL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWSDL.Location = new System.Drawing.Point(12, 57);
            this.txtWSDL.Name = "txtWSDL";
            this.txtWSDL.Size = new System.Drawing.Size(870, 111);
            this.txtWSDL.TabIndex = 11;
            this.txtWSDL.Text = "";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(770, 5);
            this.btnSalvar.MinimumSize = new System.Drawing.Size(73, 23);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(102, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 379F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(870, 379);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtXSDIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 373);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XSDIn:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtXSDOut);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(438, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 373);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XSDOut:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 379);
            this.panel1.TabIndex = 14;
            // 
            // CheckUnion
            // 
            this.CheckUnion.AutoSize = true;
            this.CheckUnion.Location = new System.Drawing.Point(468, 18);
            this.CheckUnion.Name = "CheckUnion";
            this.CheckUnion.Size = new System.Drawing.Size(75, 17);
            this.CheckUnion.TabIndex = 15;
            this.CheckUnion.Text = "&Unir XSDs";
            this.CheckUnion.UseVisualStyleBackColor = true;
            // 
            // checkSNSE
            // 
            this.checkSNSE.AutoSize = true;
            this.checkSNSE.Location = new System.Drawing.Point(549, 18);
            this.checkSNSE.Name = "checkSNSE";
            this.checkSNSE.Size = new System.Drawing.Size(75, 17);
            this.checkSNSE.TabIndex = 16;
            this.checkSNSE.Text = "&WSDL-SE";
            this.checkSNSE.UseVisualStyleBackColor = true;
            // 
            // btnDir
            // 
            this.btnDir.Enabled = false;
            this.btnDir.Location = new System.Drawing.Point(770, 31);
            this.btnDir.MinimumSize = new System.Drawing.Size(73, 23);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(102, 23);
            this.btnDir.TabIndex = 17;
            this.btnDir.Text = "Abrir Caminho";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // frmContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.checkSNSE);
            this.Controls.Add(this.CheckUnion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtWSDL);
            this.Controls.Add(this.cmbOperations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnAbrir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 596);
            this.Name = "frmContract";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contract Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOperations;
        private System.Windows.Forms.RichTextBox txtXSDIn;
        private System.Windows.Forms.RichTextBox txtXSDOut;
        private System.Windows.Forms.RichTextBox txtWSDL;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CheckUnion;
        private System.Windows.Forms.CheckBox checkSNSE;
        private System.Windows.Forms.Button btnDir;
    }
}

