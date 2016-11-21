namespace GERDOR_WSDL.Forms
{
    partial class CarregarPlanilhas
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDiretorio = new System.Windows.Forms.Button();
            this.gbPlanilha = new System.Windows.Forms.GroupBox();
            this.gbServico = new System.Windows.Forms.GroupBox();
            this.lstArquivos = new System.Windows.Forms.ListBox();
            this.txtBuscaArquivos = new GERADOR_WSDL.Utilitarios.txtBusca();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressProcessamentoArquivos = new System.Windows.Forms.ProgressBar();
            this.gdvPlanilhasAdicionadas = new System.Windows.Forms.DataGridView();
            this.txtBuscaPlanilhaAdicionadas = new GERADOR_WSDL.Utilitarios.txtBusca();
            this.btnGerarDocumento = new System.Windows.Forms.Button();
            this.btnAreaTransferencia = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbPlanilha.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPlanilhasAdicionadas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGerarDocumento, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAreaTransferencia, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 639);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAdicionar);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gbPlanilha);
            this.panel3.Controls.Add(this.lstArquivos);
            this.panel3.Controls.Add(this.txtBuscaArquivos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 597);
            this.panel3.TabIndex = 1;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Location = new System.Drawing.Point(359, 35);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 95);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "&Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnDiretorio);
            this.panel4.Location = new System.Drawing.Point(359, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(75, 31);
            this.panel4.TabIndex = 8;
            // 
            // btnDiretorio
            // 
            this.btnDiretorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiretorio.Location = new System.Drawing.Point(0, 4);
            this.btnDiretorio.Name = "btnDiretorio";
            this.btnDiretorio.Size = new System.Drawing.Size(75, 23);
            this.btnDiretorio.TabIndex = 2;
            this.btnDiretorio.Text = "&Diretório";
            this.btnDiretorio.UseVisualStyleBackColor = true;
            this.btnDiretorio.Click += new System.EventHandler(this.btnDiretorio_Click);
            // 
            // gbPlanilha
            // 
            this.gbPlanilha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPlanilha.Controls.Add(this.gbServico);
            this.gbPlanilha.Location = new System.Drawing.Point(4, 136);
            this.gbPlanilha.Name = "gbPlanilha";
            this.gbPlanilha.Size = new System.Drawing.Size(436, 458);
            this.gbPlanilha.TabIndex = 7;
            this.gbPlanilha.TabStop = false;
            this.gbPlanilha.Text = "Planilha";
            // 
            // gbServico
            // 
            this.gbServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServico.Location = new System.Drawing.Point(6, 207);
            this.gbServico.Name = "gbServico";
            this.gbServico.Size = new System.Drawing.Size(424, 245);
            this.gbServico.TabIndex = 16;
            this.gbServico.TabStop = false;
            this.gbServico.Text = "Serviço";
            // 
            // lstArquivos
            // 
            this.lstArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstArquivos.FormattingEnabled = true;
            this.lstArquivos.Location = new System.Drawing.Point(4, 35);
            this.lstArquivos.Name = "lstArquivos";
            this.lstArquivos.Size = new System.Drawing.Size(349, 95);
            this.lstArquivos.TabIndex = 0;
            // 
            // txtBuscaArquivos
            // 
            this.txtBuscaArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaArquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaArquivos.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaArquivos.Location = new System.Drawing.Point(4, 9);
            this.txtBuscaArquivos.Name = "txtBuscaArquivos";
            this.txtBuscaArquivos.Size = new System.Drawing.Size(349, 20);
            this.txtBuscaArquivos.TabIndex = 1;
            this.txtBuscaArquivos.Text = "Busca";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressProcessamentoArquivos);
            this.panel2.Controls.Add(this.gdvPlanilhasAdicionadas);
            this.panel2.Controls.Add(this.txtBuscaPlanilhaAdicionadas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(449, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 597);
            this.panel2.TabIndex = 0;
            // 
            // progressProcessamentoArquivos
            // 
            this.progressProcessamentoArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressProcessamentoArquivos.Location = new System.Drawing.Point(4, 565);
            this.progressProcessamentoArquivos.Name = "progressProcessamentoArquivos";
            this.progressProcessamentoArquivos.Size = new System.Drawing.Size(654, 23);
            this.progressProcessamentoArquivos.TabIndex = 9;
            // 
            // gdvPlanilhasAdicionadas
            // 
            this.gdvPlanilhasAdicionadas.AllowUserToAddRows = false;
            this.gdvPlanilhasAdicionadas.AllowUserToDeleteRows = false;
            this.gdvPlanilhasAdicionadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvPlanilhasAdicionadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvPlanilhasAdicionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvPlanilhasAdicionadas.Location = new System.Drawing.Point(3, 35);
            this.gdvPlanilhasAdicionadas.Name = "gdvPlanilhasAdicionadas";
            this.gdvPlanilhasAdicionadas.RowHeadersVisible = false;
            this.gdvPlanilhasAdicionadas.Size = new System.Drawing.Size(655, 475);
            this.gdvPlanilhasAdicionadas.TabIndex = 3;
            // 
            // txtBuscaPlanilhaAdicionadas
            // 
            this.txtBuscaPlanilhaAdicionadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaPlanilhaAdicionadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaPlanilhaAdicionadas.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscaPlanilhaAdicionadas.Location = new System.Drawing.Point(3, 9);
            this.txtBuscaPlanilhaAdicionadas.Name = "txtBuscaPlanilhaAdicionadas";
            this.txtBuscaPlanilhaAdicionadas.Size = new System.Drawing.Size(652, 20);
            this.txtBuscaPlanilhaAdicionadas.TabIndex = 4;
            this.txtBuscaPlanilhaAdicionadas.Text = "Busca";
            // 
            // btnGerarDocumento
            // 
            this.btnGerarDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGerarDocumento.Location = new System.Drawing.Point(3, 613);
            this.btnGerarDocumento.Name = "btnGerarDocumento";
            this.btnGerarDocumento.Size = new System.Drawing.Size(75, 23);
            this.btnGerarDocumento.TabIndex = 6;
            this.btnGerarDocumento.Text = "&Exportar";
            this.btnGerarDocumento.UseVisualStyleBackColor = true;
            this.btnGerarDocumento.Click += new System.EventHandler(this.btnGerarDocumento_Click);
            // 
            // btnAreaTransferencia
            // 
            this.btnAreaTransferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaTransferencia.Location = new System.Drawing.Point(1038, 613);
            this.btnAreaTransferencia.Name = "btnAreaTransferencia";
            this.btnAreaTransferencia.Size = new System.Drawing.Size(75, 23);
            this.btnAreaTransferencia.TabIndex = 5;
            this.btnAreaTransferencia.Text = "&Copiar";
            this.btnAreaTransferencia.UseVisualStyleBackColor = true;
            // 
            // CarregarPlanilhas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 639);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CarregarPlanilhas";
            this.Text = "CarregarPlanilhas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.gbPlanilha.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPlanilhasAdicionadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDiretorio;
        private System.Windows.Forms.GroupBox gbPlanilha;
        private System.Windows.Forms.GroupBox gbServico;
        private System.Windows.Forms.ListBox lstArquivos;
        private GERADOR_WSDL.Utilitarios.txtBusca txtBuscaArquivos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gdvPlanilhasAdicionadas;
        private GERADOR_WSDL.Utilitarios.txtBusca txtBuscaPlanilhaAdicionadas;
        private System.Windows.Forms.Button btnGerarDocumento;
        private System.Windows.Forms.Button btnAreaTransferencia;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ProgressBar progressProcessamentoArquivos;
    }
}