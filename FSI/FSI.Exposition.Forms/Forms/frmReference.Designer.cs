namespace FSI.Exposition.Forms
{
    partial class frmReference
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gdvStructurePreview = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.cmbOperations = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeReferences = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdComeca = new System.Windows.Forms.RadioButton();
            this.rdTermina = new System.Windows.Forms.RadioButton();
            this.rdContem = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rtxPreview = new System.Windows.Forms.RichTextBox();
            this.grouopRef = new System.Windows.Forms.GroupBox();
            this.txtDetailsRef = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.groupAuxMess = new System.Windows.Forms.GroupBox();
            this.txtAlternative = new System.Windows.Forms.TextBox();
            this.lblAlternativeTitle = new System.Windows.Forms.Label();
            this.checkRequired = new System.Windows.Forms.CheckBox();
            this.lblProp = new System.Windows.Forms.Label();
            this.lblPropTitle = new System.Windows.Forms.Label();
            this.lblCanonico = new System.Windows.Forms.Label();
            this.lblCanonicoTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddProp = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnAddComplex = new System.Windows.Forms.Button();
            this.txtMessageStructure = new System.Windows.Forms.TextBox();
            this.textTreeViewSearch1 = new FSI.Exposition.Forms.TextTreeViewSearch();
            ((System.ComponentModel.ISupportInitialize)(this.gdvStructurePreview)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grouopRef.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupAuxMess.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdvStructurePreview
            // 
            this.gdvStructurePreview.AllowUserToAddRows = false;
            this.gdvStructurePreview.AllowUserToOrderColumns = true;
            this.gdvStructurePreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvStructurePreview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdvStructurePreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gdvStructurePreview.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gdvStructurePreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvStructurePreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvStructurePreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvStructurePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvStructurePreview.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdvStructurePreview.Location = new System.Drawing.Point(3, 81);
            this.gdvStructurePreview.Name = "gdvStructurePreview";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvStructurePreview.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdvStructurePreview.RowHeadersVisible = false;
            this.gdvStructurePreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvStructurePreview.ShowCellErrors = false;
            this.gdvStructurePreview.ShowCellToolTips = false;
            this.gdvStructurePreview.ShowEditingIcon = false;
            this.gdvStructurePreview.Size = new System.Drawing.Size(734, 115);
            this.gdvStructurePreview.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(746, 615);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddOperation, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbOperations, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(740, 404);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOperation.Location = new System.Drawing.Point(373, 379);
            this.btnAddOperation.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(367, 23);
            this.btnAddOperation.TabIndex = 19;
            this.btnAddOperation.Text = "Adicionar Operação";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // cmbOperations
            // 
            this.cmbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperations.FormattingEnabled = true;
            this.cmbOperations.Location = new System.Drawing.Point(0, 380);
            this.cmbOperations.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cmbOperations.Name = "cmbOperations";
            this.cmbOperations.Size = new System.Drawing.Size(370, 21);
            this.cmbOperations.TabIndex = 18;
            this.cmbOperations.SelectedIndexChanged += new System.EventHandler(this.cmbOperations_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treeReferences, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 359);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // treeReferences
            // 
            this.treeReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeReferences.Location = new System.Drawing.Point(0, 26);
            this.treeReferences.Margin = new System.Windows.Forms.Padding(0);
            this.treeReferences.Name = "treeReferences";
            this.treeReferences.Size = new System.Drawing.Size(370, 333);
            this.treeReferences.TabIndex = 0;
            this.treeReferences.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReferences_AfterSelect);
            this.treeReferences.DoubleClick += new System.EventHandler(this.treeReferences_DoubleClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.Controls.Add(this.textTreeViewSearch1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 26);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdComeca);
            this.panel1.Controls.Add(this.rdTermina);
            this.panel1.Controls.Add(this.rdContem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(170, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 26);
            this.panel1.TabIndex = 3;
            // 
            // rdComeca
            // 
            this.rdComeca.AutoSize = true;
            this.rdComeca.Location = new System.Drawing.Point(140, 4);
            this.rdComeca.Name = "rdComeca";
            this.rdComeca.Size = new System.Drawing.Size(64, 17);
            this.rdComeca.TabIndex = 2;
            this.rdComeca.Text = "Começa";
            this.rdComeca.UseVisualStyleBackColor = true;
            this.rdComeca.CheckedChanged += new System.EventHandler(this.rdComeca_CheckedChanged);
            // 
            // rdTermina
            // 
            this.rdTermina.AutoSize = true;
            this.rdTermina.Location = new System.Drawing.Point(71, 4);
            this.rdTermina.Name = "rdTermina";
            this.rdTermina.Size = new System.Drawing.Size(63, 17);
            this.rdTermina.TabIndex = 1;
            this.rdTermina.Text = "Termina";
            this.rdTermina.UseVisualStyleBackColor = true;
            this.rdTermina.CheckedChanged += new System.EventHandler(this.rdTermina_CheckedChanged);
            // 
            // rdContem
            // 
            this.rdContem.AutoSize = true;
            this.rdContem.Checked = true;
            this.rdContem.Location = new System.Drawing.Point(4, 4);
            this.rdContem.Name = "rdContem";
            this.rdContem.Size = new System.Drawing.Size(61, 17);
            this.rdContem.TabIndex = 0;
            this.rdContem.TabStop = true;
            this.rdContem.Text = "Contém";
            this.rdContem.UseVisualStyleBackColor = true;
            this.rdContem.CheckedChanged += new System.EventHandler(this.rdContem_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.rtxPreview, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.grouopRef, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(373, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(367, 359);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // rtxPreview
            // 
            this.rtxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxPreview.Location = new System.Drawing.Point(0, 100);
            this.rtxPreview.Margin = new System.Windows.Forms.Padding(0);
            this.rtxPreview.Name = "rtxPreview";
            this.rtxPreview.Size = new System.Drawing.Size(367, 259);
            this.rtxPreview.TabIndex = 3;
            this.rtxPreview.Text = "";
            // 
            // grouopRef
            // 
            this.grouopRef.Controls.Add(this.txtDetailsRef);
            this.grouopRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouopRef.Location = new System.Drawing.Point(3, 3);
            this.grouopRef.Name = "grouopRef";
            this.grouopRef.Size = new System.Drawing.Size(361, 94);
            this.grouopRef.TabIndex = 1;
            this.grouopRef.TabStop = false;
            this.grouopRef.Text = "Detalhes Referência";
            // 
            // txtDetailsRef
            // 
            this.txtDetailsRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtDetailsRef.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetailsRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailsRef.Location = new System.Drawing.Point(3, 16);
            this.txtDetailsRef.Name = "txtDetailsRef";
            this.txtDetailsRef.Size = new System.Drawing.Size(355, 75);
            this.txtDetailsRef.TabIndex = 0;
            this.txtDetailsRef.Text = "";
            this.txtDetailsRef.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtDetailsRef_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 364);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Construção de Operações:";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.gdvStructurePreview, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 413);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(740, 199);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.groupAuxMess, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(740, 78);
            this.tableLayoutPanel9.TabIndex = 7;
            // 
            // groupAuxMess
            // 
            this.groupAuxMess.Controls.Add(this.txtAlternative);
            this.groupAuxMess.Controls.Add(this.lblAlternativeTitle);
            this.groupAuxMess.Controls.Add(this.checkRequired);
            this.groupAuxMess.Controls.Add(this.lblProp);
            this.groupAuxMess.Controls.Add(this.lblPropTitle);
            this.groupAuxMess.Controls.Add(this.lblCanonico);
            this.groupAuxMess.Controls.Add(this.lblCanonicoTitle);
            this.groupAuxMess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAuxMess.Location = new System.Drawing.Point(373, 3);
            this.groupAuxMess.Name = "groupAuxMess";
            this.groupAuxMess.Size = new System.Drawing.Size(364, 72);
            this.groupAuxMess.TabIndex = 8;
            this.groupAuxMess.TabStop = false;
            this.groupAuxMess.Text = "Auxiliador Mensagens";
            // 
            // txtAlternative
            // 
            this.txtAlternative.Location = new System.Drawing.Point(73, 49);
            this.txtAlternative.Name = "txtAlternative";
            this.txtAlternative.Size = new System.Drawing.Size(226, 20);
            this.txtAlternative.TabIndex = 8;
            // 
            // lblAlternativeTitle
            // 
            this.lblAlternativeTitle.AutoSize = true;
            this.lblAlternativeTitle.Location = new System.Drawing.Point(7, 52);
            this.lblAlternativeTitle.Name = "lblAlternativeTitle";
            this.lblAlternativeTitle.Size = new System.Drawing.Size(60, 13);
            this.lblAlternativeTitle.TabIndex = 7;
            this.lblAlternativeTitle.Text = "Alternativo:";
            // 
            // checkRequired
            // 
            this.checkRequired.AutoSize = true;
            this.checkRequired.Location = new System.Drawing.Point(273, 16);
            this.checkRequired.Name = "checkRequired";
            this.checkRequired.Size = new System.Drawing.Size(75, 17);
            this.checkRequired.TabIndex = 6;
            this.checkRequired.Text = "Requerido";
            this.checkRequired.UseVisualStyleBackColor = true;
            // 
            // lblProp
            // 
            this.lblProp.AutoSize = true;
            this.lblProp.Location = new System.Drawing.Point(79, 33);
            this.lblProp.Name = "lblProp";
            this.lblProp.Size = new System.Drawing.Size(0, 13);
            this.lblProp.TabIndex = 5;
            // 
            // lblPropTitle
            // 
            this.lblPropTitle.AutoSize = true;
            this.lblPropTitle.Location = new System.Drawing.Point(6, 32);
            this.lblPropTitle.Name = "lblPropTitle";
            this.lblPropTitle.Size = new System.Drawing.Size(67, 13);
            this.lblPropTitle.TabIndex = 4;
            this.lblPropTitle.Text = "Propriedade:";
            // 
            // lblCanonico
            // 
            this.lblCanonico.AutoSize = true;
            this.lblCanonico.Location = new System.Drawing.Point(79, 20);
            this.lblCanonico.Name = "lblCanonico";
            this.lblCanonico.Size = new System.Drawing.Size(0, 13);
            this.lblCanonico.TabIndex = 3;
            // 
            // lblCanonicoTitle
            // 
            this.lblCanonicoTitle.AutoSize = true;
            this.lblCanonicoTitle.Location = new System.Drawing.Point(7, 20);
            this.lblCanonicoTitle.Name = "lblCanonicoTitle";
            this.lblCanonicoTitle.Size = new System.Drawing.Size(55, 13);
            this.lblCanonicoTitle.TabIndex = 0;
            this.lblCanonicoTitle.Text = "Canônico:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnAddProp, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtMessageStructure, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Enabled = false;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(370, 78);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // btnAddProp
            // 
            this.btnAddProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProp.Location = new System.Drawing.Point(0, 52);
            this.btnAddProp.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddProp.Name = "btnAddProp";
            this.btnAddProp.Size = new System.Drawing.Size(370, 26);
            this.btnAddProp.TabIndex = 2;
            this.btnAddProp.Text = "Adicionar ";
            this.btnAddProp.UseVisualStyleBackColor = true;
            this.btnAddProp.Click += new System.EventHandler(this.btnAddProp_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnAddList, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAddComplex, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(370, 26);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // btnAddList
            // 
            this.btnAddList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddList.Location = new System.Drawing.Point(185, 0);
            this.btnAddList.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(185, 26);
            this.btnAddList.TabIndex = 10;
            this.btnAddList.Text = "Inserir em Lista";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnAddComplex
            // 
            this.btnAddComplex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddComplex.Location = new System.Drawing.Point(0, 0);
            this.btnAddComplex.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddComplex.Name = "btnAddComplex";
            this.btnAddComplex.Size = new System.Drawing.Size(185, 26);
            this.btnAddComplex.TabIndex = 9;
            this.btnAddComplex.Text = "Inserir em Complexo";
            this.btnAddComplex.UseVisualStyleBackColor = true;
            this.btnAddComplex.Click += new System.EventHandler(this.btnAddComplex_Click);
            // 
            // txtMessageStructure
            // 
            this.txtMessageStructure.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageStructure.Location = new System.Drawing.Point(0, 26);
            this.txtMessageStructure.Margin = new System.Windows.Forms.Padding(0);
            this.txtMessageStructure.Name = "txtMessageStructure";
            this.txtMessageStructure.Size = new System.Drawing.Size(370, 20);
            this.txtMessageStructure.TabIndex = 1;
            // 
            // textTreeViewSearch1
            // 
            this.textTreeViewSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTreeViewSearch1.fieldsTreeCache = null;
            this.textTreeViewSearch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTreeViewSearch1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textTreeViewSearch1.Location = new System.Drawing.Point(3, 3);
            this.textTreeViewSearch1.Name = "textTreeViewSearch1";
            this.textTreeViewSearch1.searchType = FSI.Exposition.Forms.SearchType.Contains;
            this.textTreeViewSearch1.Size = new System.Drawing.Size(164, 20);
            this.textTreeViewSearch1.TabIndex = 2;
            this.textTreeViewSearch1.Text = "Busca";
            this.textTreeViewSearch1.treeReferences = null;
            // 
            // frmReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 615);
            this.Controls.Add(this.tableLayoutPanel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReference";
            this.Text = "Reference Tool";
            ((System.ComponentModel.ISupportInitialize)(this.gdvStructurePreview)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.grouopRef.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.groupAuxMess.ResumeLayout(false);
            this.groupAuxMess.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gdvStructurePreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ComboBox cmbOperations;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeReferences;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private TextTreeViewSearch textTreeViewSearch1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdComeca;
        private System.Windows.Forms.RadioButton rdTermina;
        private System.Windows.Forms.RadioButton rdContem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RichTextBox rtxPreview;
        private System.Windows.Forms.GroupBox grouopRef;
        private System.Windows.Forms.RichTextBox txtDetailsRef;
        private System.Windows.Forms.GroupBox groupAuxMess;
        private System.Windows.Forms.TextBox txtAlternative;
        private System.Windows.Forms.Label lblAlternativeTitle;
        private System.Windows.Forms.CheckBox checkRequired;
        private System.Windows.Forms.Label lblProp;
        private System.Windows.Forms.Label lblPropTitle;
        private System.Windows.Forms.Label lblCanonico;
        private System.Windows.Forms.Label lblCanonicoTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnAddProp;
        private System.Windows.Forms.TextBox txtMessageStructure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnAddComplex;
        private System.Windows.Forms.Label label1;
    }
}