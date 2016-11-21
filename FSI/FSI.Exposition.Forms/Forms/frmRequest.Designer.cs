namespace FSI.Exposition.Forms
{
    partial class frmRequest
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
            this.txtRequest = new System.Windows.Forms.RichTextBox();
            this.cmbOperations = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.treeViewContract = new System.Windows.Forms.TreeView();
            this.groupProperty = new System.Windows.Forms.GroupBox();
            this.btnValidarSequence = new System.Windows.Forms.Button();
            this.btnGenerateLoad = new System.Windows.Forms.Button();
            this.checkRequired = new System.Windows.Forms.CheckBox();
            this.checkGerar = new System.Windows.Forms.CheckBox();
            this.txtPropType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPropValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbrir.Location = new System.Drawing.Point(3, 2);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnAbrir.MaximumSize = new System.Drawing.Size(0, 23);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(115, 23);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "&Abrir Planilha";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequest.Location = new System.Drawing.Point(3, 182);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(420, 255);
            this.txtRequest.TabIndex = 10;
            this.txtRequest.Text = "";
            // 
            // cmbOperations
            // 
            this.cmbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperations.FormattingEnabled = true;
            this.cmbOperations.Location = new System.Drawing.Point(124, 3);
            this.cmbOperations.Name = "cmbOperations";
            this.cmbOperations.Size = new System.Drawing.Size(293, 21);
            this.cmbOperations.TabIndex = 11;
            this.cmbOperations.SelectedIndexChanged += new System.EventHandler(this.cmbOperations_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtResponse, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRequest, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeViewContract, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupProperty, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 427);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(429, 182);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(420, 255);
            this.txtResponse.TabIndex = 17;
            this.txtResponse.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.84615F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.15385F));
            this.tableLayoutPanel2.Controls.Add(this.btnAbrir, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbOperations, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 34);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Response";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel3.Controls.Add(this.txtUrl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSubmit, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(429, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 34);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Enabled = false;
            this.txtUrl.Location = new System.Drawing.Point(3, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(314, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(323, 2);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnSubmit.MaximumSize = new System.Drawing.Size(0, 23);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // treeViewContract
            // 
            this.treeViewContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewContract.Location = new System.Drawing.Point(3, 43);
            this.treeViewContract.Name = "treeViewContract";
            this.treeViewContract.Size = new System.Drawing.Size(420, 118);
            this.treeViewContract.TabIndex = 18;
            this.treeViewContract.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContract_AfterSelect);
            // 
            // groupProperty
            // 
            this.groupProperty.Controls.Add(this.btnValidarSequence);
            this.groupProperty.Controls.Add(this.btnGenerateLoad);
            this.groupProperty.Controls.Add(this.checkRequired);
            this.groupProperty.Controls.Add(this.checkGerar);
            this.groupProperty.Controls.Add(this.txtPropType);
            this.groupProperty.Controls.Add(this.label4);
            this.groupProperty.Controls.Add(this.txtPropValue);
            this.groupProperty.Controls.Add(this.label3);
            this.groupProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupProperty.Location = new System.Drawing.Point(429, 43);
            this.groupProperty.Name = "groupProperty";
            this.groupProperty.Size = new System.Drawing.Size(420, 118);
            this.groupProperty.TabIndex = 19;
            this.groupProperty.TabStop = false;
            this.groupProperty.Text = "Propriedades";
            // 
            // btnValidarSequence
            // 
            this.btnValidarSequence.Enabled = false;
            this.btnValidarSequence.Location = new System.Drawing.Point(323, 19);
            this.btnValidarSequence.Name = "btnValidarSequence";
            this.btnValidarSequence.Size = new System.Drawing.Size(91, 93);
            this.btnValidarSequence.TabIndex = 7;
            this.btnValidarSequence.Text = "Validar &Sequence";
            this.btnValidarSequence.UseVisualStyleBackColor = true;
            this.btnValidarSequence.Click += new System.EventHandler(this.btnValidarSequence_Click);
            // 
            // btnGenerateLoad
            // 
            this.btnGenerateLoad.Enabled = false;
            this.btnGenerateLoad.Location = new System.Drawing.Point(7, 89);
            this.btnGenerateLoad.Name = "btnGenerateLoad";
            this.btnGenerateLoad.Size = new System.Drawing.Size(203, 23);
            this.btnGenerateLoad.TabIndex = 6;
            this.btnGenerateLoad.Text = "Gerar Novamente";
            this.btnGenerateLoad.UseVisualStyleBackColor = true;
            this.btnGenerateLoad.Click += new System.EventHandler(this.btnGenerateLoad_Click);
            // 
            // checkRequired
            // 
            this.checkRequired.AutoSize = true;
            this.checkRequired.Enabled = false;
            this.checkRequired.Location = new System.Drawing.Point(141, 19);
            this.checkRequired.Name = "checkRequired";
            this.checkRequired.Size = new System.Drawing.Size(69, 17);
            this.checkRequired.TabIndex = 5;
            this.checkRequired.Text = "Required";
            this.checkRequired.UseVisualStyleBackColor = true;
            // 
            // checkGerar
            // 
            this.checkGerar.AutoSize = true;
            this.checkGerar.Location = new System.Drawing.Point(9, 19);
            this.checkGerar.Name = "checkGerar";
            this.checkGerar.Size = new System.Drawing.Size(52, 17);
            this.checkGerar.TabIndex = 4;
            this.checkGerar.Text = "&Gerar";
            this.checkGerar.UseVisualStyleBackColor = true;
            this.checkGerar.CheckedChanged += new System.EventHandler(this.checkGerar_CheckedChanged);
            // 
            // txtPropType
            // 
            this.txtPropType.Location = new System.Drawing.Point(43, 66);
            this.txtPropType.Name = "txtPropType";
            this.txtPropType.Size = new System.Drawing.Size(167, 20);
            this.txtPropType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tipo";
            // 
            // txtPropValue
            // 
            this.txtPropValue.Location = new System.Drawing.Point(43, 40);
            this.txtPropValue.Name = "txtPropValue";
            this.txtPropValue.Size = new System.Drawing.Size(167, 20);
            this.txtPropValue.TabIndex = 1;
            this.txtPropValue.TextChanged += new System.EventHandler(this.txtPropValue_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valor";
            // 
            // frmRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 427);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRequest";
            this.Text = "Request Tool";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupProperty.ResumeLayout(false);
            this.groupProperty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.RichTextBox txtRequest;
        private System.Windows.Forms.ComboBox cmbOperations;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.TreeView treeViewContract;
        private System.Windows.Forms.GroupBox groupProperty;
        private System.Windows.Forms.TextBox txtPropType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPropValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkGerar;
        private System.Windows.Forms.CheckBox checkRequired;
        private System.Windows.Forms.Button btnGenerateLoad;
        private System.Windows.Forms.Button btnValidarSequence;
    }
}