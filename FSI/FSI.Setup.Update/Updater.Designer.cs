namespace FSI.Setup.Update
{
    partial class Updater
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
            this.btnAtualizarAplicacao = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnCanonico = new System.Windows.Forms.Button();
            this.btnAtualizarTemplates = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualizarAplicacao
            // 
            this.btnAtualizarAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAtualizarAplicacao.Location = new System.Drawing.Point(3, 3);
            this.btnAtualizarAplicacao.Name = "btnAtualizarAplicacao";
            this.btnAtualizarAplicacao.Size = new System.Drawing.Size(328, 29);
            this.btnAtualizarAplicacao.TabIndex = 0;
            this.btnAtualizarAplicacao.Text = "Atualizar &Aplicação";
            this.btnAtualizarAplicacao.UseVisualStyleBackColor = true;
            this.btnAtualizarAplicacao.Click += new System.EventHandler(this.btnAtualizarAplicacao_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(328, 29);
            this.progressBar1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAtualizarAplicacao, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCanonico, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAtualizarTemplates, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 199);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(3, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(328, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "F&echar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(3, 105);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 13);
            this.lblFile.TabIndex = 3;
            // 
            // btnCanonico
            // 
            this.btnCanonico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanonico.Location = new System.Drawing.Point(3, 73);
            this.btnCanonico.Name = "btnCanonico";
            this.btnCanonico.Size = new System.Drawing.Size(328, 29);
            this.btnCanonico.TabIndex = 4;
            this.btnCanonico.Text = "Atualizar &Canônico";
            this.btnCanonico.UseVisualStyleBackColor = true;
            this.btnCanonico.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAtualizarTemplates
            // 
            this.btnAtualizarTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAtualizarTemplates.Location = new System.Drawing.Point(3, 38);
            this.btnAtualizarTemplates.Name = "btnAtualizarTemplates";
            this.btnAtualizarTemplates.Size = new System.Drawing.Size(328, 29);
            this.btnAtualizarTemplates.TabIndex = 5;
            this.btnAtualizarTemplates.Text = "Atualizar &Templates";
            this.btnAtualizarTemplates.UseVisualStyleBackColor = true;
            this.btnAtualizarTemplates.Click += new System.EventHandler(this.btnAtualizarTemplates_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 199);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "Atualizador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Updater_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtualizarAplicacao;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnCanonico;
        private System.Windows.Forms.Button btnAtualizarTemplates;
    }
}

