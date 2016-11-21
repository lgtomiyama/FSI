namespace FSI.Exposition.Forms
{
    partial class frmConfig
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
            this.components = new System.ComponentModel.Container();
            this.lblDirRef = new System.Windows.Forms.Label();
            this.txtDirRef = new System.Windows.Forms.TextBox();
            this.btnSearchDirRef = new System.Windows.Forms.Button();
            this.btnSalvarDirRef = new System.Windows.Forms.Button();
            this.btnSalvarDirExp = new System.Windows.Forms.Button();
            this.btnSearchDirExp = new System.Windows.Forms.Button();
            this.txtDirExp = new System.Windows.Forms.TextBox();
            this.lblDirExp = new System.Windows.Forms.Label();
            this.btnSalvarDefaultNameSpace = new System.Windows.Forms.Button();
            this.txtDefaultNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvarTemplWSDLSN = new System.Windows.Forms.Button();
            this.btnSearchTemplWSDLSN = new System.Windows.Forms.Button();
            this.txtTemplWSDLSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvarTemplWSDLSE = new System.Windows.Forms.Button();
            this.btnTemplWSDLSE = new System.Windows.Forms.Button();
            this.txtTemplWSDLSE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalvarTemplXSDReq = new System.Windows.Forms.Button();
            this.btnSearchTemplXSDReq = new System.Windows.Forms.Button();
            this.txtTemplXSDReq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvarTemplXSDRes = new System.Windows.Forms.Button();
            this.btnSearchTemplXSDRes = new System.Windows.Forms.Button();
            this.txtTemplXSDRes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvarTemplXSDUni = new System.Windows.Forms.Button();
            this.btnSearchTemplXSDUni = new System.Windows.Forms.Button();
            this.txtTemplXSDUni = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPatrDirExp = new System.Windows.Forms.Button();
            this.tpExportacao = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblDirRef
            // 
            this.lblDirRef.AutoSize = true;
            this.lblDirRef.Location = new System.Drawing.Point(12, 9);
            this.lblDirRef.Name = "lblDirRef";
            this.lblDirRef.Size = new System.Drawing.Size(112, 13);
            this.lblDirRef.TabIndex = 0;
            this.lblDirRef.Text = "Diretório Referências: ";
            // 
            // txtDirRef
            // 
            this.txtDirRef.Location = new System.Drawing.Point(15, 25);
            this.txtDirRef.Name = "txtDirRef";
            this.txtDirRef.Size = new System.Drawing.Size(416, 20);
            this.txtDirRef.TabIndex = 1;
            // 
            // btnSearchDirRef
            // 
            this.btnSearchDirRef.Location = new System.Drawing.Point(437, 25);
            this.btnSearchDirRef.Name = "btnSearchDirRef";
            this.btnSearchDirRef.Size = new System.Drawing.Size(24, 20);
            this.btnSearchDirRef.TabIndex = 2;
            this.btnSearchDirRef.Text = "...";
            this.btnSearchDirRef.UseVisualStyleBackColor = true;
            this.btnSearchDirRef.Click += new System.EventHandler(this.btnSearchDirRef_Click);
            // 
            // btnSalvarDirRef
            // 
            this.btnSalvarDirRef.Location = new System.Drawing.Point(467, 25);
            this.btnSalvarDirRef.Name = "btnSalvarDirRef";
            this.btnSalvarDirRef.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarDirRef.TabIndex = 3;
            this.btnSalvarDirRef.Text = "Salvar";
            this.btnSalvarDirRef.UseVisualStyleBackColor = true;
            this.btnSalvarDirRef.Click += new System.EventHandler(this.btnSalvarDirRef_Click);
            // 
            // btnSalvarDirExp
            // 
            this.btnSalvarDirExp.Location = new System.Drawing.Point(497, 64);
            this.btnSalvarDirExp.Name = "btnSalvarDirExp";
            this.btnSalvarDirExp.Size = new System.Drawing.Size(58, 20);
            this.btnSalvarDirExp.TabIndex = 7;
            this.btnSalvarDirExp.Text = "Salvar";
            this.btnSalvarDirExp.UseVisualStyleBackColor = true;
            this.btnSalvarDirExp.Click += new System.EventHandler(this.btnSalvarDirExp_Click);
            // 
            // btnSearchDirExp
            // 
            this.btnSearchDirExp.Location = new System.Drawing.Point(437, 64);
            this.btnSearchDirExp.Name = "btnSearchDirExp";
            this.btnSearchDirExp.Size = new System.Drawing.Size(24, 20);
            this.btnSearchDirExp.TabIndex = 6;
            this.btnSearchDirExp.Text = "...";
            this.btnSearchDirExp.UseVisualStyleBackColor = true;
            this.btnSearchDirExp.Click += new System.EventHandler(this.btnSearchDirExp_Click);
            // 
            // txtDirExp
            // 
            this.txtDirExp.Location = new System.Drawing.Point(15, 64);
            this.txtDirExp.Name = "txtDirExp";
            this.txtDirExp.Size = new System.Drawing.Size(416, 20);
            this.txtDirExp.TabIndex = 5;
            // 
            // lblDirExp
            // 
            this.lblDirExp.AutoSize = true;
            this.lblDirExp.Location = new System.Drawing.Point(12, 48);
            this.lblDirExp.Name = "lblDirExp";
            this.lblDirExp.Size = new System.Drawing.Size(103, 13);
            this.lblDirExp.TabIndex = 4;
            this.lblDirExp.Text = "Diretório Exportação";
            // 
            // btnSalvarDefaultNameSpace
            // 
            this.btnSalvarDefaultNameSpace.Location = new System.Drawing.Point(437, 103);
            this.btnSalvarDefaultNameSpace.Name = "btnSalvarDefaultNameSpace";
            this.btnSalvarDefaultNameSpace.Size = new System.Drawing.Size(118, 20);
            this.btnSalvarDefaultNameSpace.TabIndex = 11;
            this.btnSalvarDefaultNameSpace.Text = "Salvar";
            this.btnSalvarDefaultNameSpace.UseVisualStyleBackColor = true;
            this.btnSalvarDefaultNameSpace.Click += new System.EventHandler(this.btnSalvarDefaultNameSpace_Click);
            // 
            // txtDefaultNameSpace
            // 
            this.txtDefaultNameSpace.Location = new System.Drawing.Point(15, 103);
            this.txtDefaultNameSpace.Name = "txtDefaultNameSpace";
            this.txtDefaultNameSpace.Size = new System.Drawing.Size(416, 20);
            this.txtDefaultNameSpace.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Default NameSpace:";
            // 
            // btnSalvarTemplWSDLSN
            // 
            this.btnSalvarTemplWSDLSN.Location = new System.Drawing.Point(467, 142);
            this.btnSalvarTemplWSDLSN.Name = "btnSalvarTemplWSDLSN";
            this.btnSalvarTemplWSDLSN.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarTemplWSDLSN.TabIndex = 15;
            this.btnSalvarTemplWSDLSN.Text = "Salvar";
            this.btnSalvarTemplWSDLSN.UseVisualStyleBackColor = true;
            this.btnSalvarTemplWSDLSN.Click += new System.EventHandler(this.btnSalvarTemplWSDLSN_Click);
            // 
            // btnSearchTemplWSDLSN
            // 
            this.btnSearchTemplWSDLSN.Location = new System.Drawing.Point(437, 142);
            this.btnSearchTemplWSDLSN.Name = "btnSearchTemplWSDLSN";
            this.btnSearchTemplWSDLSN.Size = new System.Drawing.Size(24, 20);
            this.btnSearchTemplWSDLSN.TabIndex = 14;
            this.btnSearchTemplWSDLSN.Text = "...";
            this.btnSearchTemplWSDLSN.UseVisualStyleBackColor = true;
            this.btnSearchTemplWSDLSN.Click += new System.EventHandler(this.btnSearchTemplWSDLSN_Click);
            // 
            // txtTemplWSDLSN
            // 
            this.txtTemplWSDLSN.Location = new System.Drawing.Point(15, 142);
            this.txtTemplWSDLSN.Name = "txtTemplWSDLSN";
            this.txtTemplWSDLSN.Size = new System.Drawing.Size(416, 20);
            this.txtTemplWSDLSN.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Template WSDL SN: ";
            // 
            // btnSalvarTemplWSDLSE
            // 
            this.btnSalvarTemplWSDLSE.Location = new System.Drawing.Point(467, 181);
            this.btnSalvarTemplWSDLSE.Name = "btnSalvarTemplWSDLSE";
            this.btnSalvarTemplWSDLSE.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarTemplWSDLSE.TabIndex = 19;
            this.btnSalvarTemplWSDLSE.Text = "Salvar";
            this.btnSalvarTemplWSDLSE.UseVisualStyleBackColor = true;
            this.btnSalvarTemplWSDLSE.Click += new System.EventHandler(this.btnSalvarTemplWSDLSE_Click);
            // 
            // btnTemplWSDLSE
            // 
            this.btnTemplWSDLSE.Location = new System.Drawing.Point(437, 181);
            this.btnTemplWSDLSE.Name = "btnTemplWSDLSE";
            this.btnTemplWSDLSE.Size = new System.Drawing.Size(24, 20);
            this.btnTemplWSDLSE.TabIndex = 18;
            this.btnTemplWSDLSE.Text = "...";
            this.btnTemplWSDLSE.UseVisualStyleBackColor = true;
            this.btnTemplWSDLSE.Click += new System.EventHandler(this.btnTemplWSDLSE_Click);
            // 
            // txtTemplWSDLSE
            // 
            this.txtTemplWSDLSE.Location = new System.Drawing.Point(15, 181);
            this.txtTemplWSDLSE.Name = "txtTemplWSDLSE";
            this.txtTemplWSDLSE.Size = new System.Drawing.Size(416, 20);
            this.txtTemplWSDLSE.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Template WSDL SE:";
            // 
            // btnSalvarTemplXSDReq
            // 
            this.btnSalvarTemplXSDReq.Location = new System.Drawing.Point(467, 220);
            this.btnSalvarTemplXSDReq.Name = "btnSalvarTemplXSDReq";
            this.btnSalvarTemplXSDReq.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarTemplXSDReq.TabIndex = 23;
            this.btnSalvarTemplXSDReq.Text = "Salvar";
            this.btnSalvarTemplXSDReq.UseVisualStyleBackColor = true;
            this.btnSalvarTemplXSDReq.Click += new System.EventHandler(this.btnSalvarTemplXSDReq_Click);
            // 
            // btnSearchTemplXSDReq
            // 
            this.btnSearchTemplXSDReq.Location = new System.Drawing.Point(437, 220);
            this.btnSearchTemplXSDReq.Name = "btnSearchTemplXSDReq";
            this.btnSearchTemplXSDReq.Size = new System.Drawing.Size(24, 20);
            this.btnSearchTemplXSDReq.TabIndex = 22;
            this.btnSearchTemplXSDReq.Text = "...";
            this.btnSearchTemplXSDReq.UseVisualStyleBackColor = true;
            this.btnSearchTemplXSDReq.Click += new System.EventHandler(this.btnSearchTemplXSDReq_Click);
            // 
            // txtTemplXSDReq
            // 
            this.txtTemplXSDReq.Location = new System.Drawing.Point(15, 220);
            this.txtTemplXSDReq.Name = "txtTemplXSDReq";
            this.txtTemplXSDReq.Size = new System.Drawing.Size(416, 20);
            this.txtTemplXSDReq.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Template XSD Request:";
            // 
            // btnSalvarTemplXSDRes
            // 
            this.btnSalvarTemplXSDRes.Location = new System.Drawing.Point(467, 259);
            this.btnSalvarTemplXSDRes.Name = "btnSalvarTemplXSDRes";
            this.btnSalvarTemplXSDRes.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarTemplXSDRes.TabIndex = 27;
            this.btnSalvarTemplXSDRes.Text = "Salvar";
            this.btnSalvarTemplXSDRes.UseVisualStyleBackColor = true;
            this.btnSalvarTemplXSDRes.Click += new System.EventHandler(this.btnSalvarTemplXSDRes_Click);
            // 
            // btnSearchTemplXSDRes
            // 
            this.btnSearchTemplXSDRes.Location = new System.Drawing.Point(437, 259);
            this.btnSearchTemplXSDRes.Name = "btnSearchTemplXSDRes";
            this.btnSearchTemplXSDRes.Size = new System.Drawing.Size(24, 20);
            this.btnSearchTemplXSDRes.TabIndex = 26;
            this.btnSearchTemplXSDRes.Text = "...";
            this.btnSearchTemplXSDRes.UseVisualStyleBackColor = true;
            this.btnSearchTemplXSDRes.Click += new System.EventHandler(this.btnSearchTemplXSDRes_Click);
            // 
            // txtTemplXSDRes
            // 
            this.txtTemplXSDRes.Location = new System.Drawing.Point(15, 259);
            this.txtTemplXSDRes.Name = "txtTemplXSDRes";
            this.txtTemplXSDRes.Size = new System.Drawing.Size(416, 20);
            this.txtTemplXSDRes.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Template XSD Response:";
            // 
            // btnSalvarTemplXSDUni
            // 
            this.btnSalvarTemplXSDUni.Location = new System.Drawing.Point(467, 298);
            this.btnSalvarTemplXSDUni.Name = "btnSalvarTemplXSDUni";
            this.btnSalvarTemplXSDUni.Size = new System.Drawing.Size(88, 20);
            this.btnSalvarTemplXSDUni.TabIndex = 31;
            this.btnSalvarTemplXSDUni.Text = "Salvar";
            this.btnSalvarTemplXSDUni.UseVisualStyleBackColor = true;
            this.btnSalvarTemplXSDUni.Click += new System.EventHandler(this.btnSalvarTemplXSDUni_Click);
            // 
            // btnSearchTemplXSDUni
            // 
            this.btnSearchTemplXSDUni.Location = new System.Drawing.Point(437, 298);
            this.btnSearchTemplXSDUni.Name = "btnSearchTemplXSDUni";
            this.btnSearchTemplXSDUni.Size = new System.Drawing.Size(24, 20);
            this.btnSearchTemplXSDUni.TabIndex = 30;
            this.btnSearchTemplXSDUni.Text = "...";
            this.btnSearchTemplXSDUni.UseVisualStyleBackColor = true;
            this.btnSearchTemplXSDUni.Click += new System.EventHandler(this.btnSearchTemplXSDUni_Click);
            // 
            // txtTemplXSDUni
            // 
            this.txtTemplXSDUni.Location = new System.Drawing.Point(15, 298);
            this.txtTemplXSDUni.Name = "txtTemplXSDUni";
            this.txtTemplXSDUni.Size = new System.Drawing.Size(416, 20);
            this.txtTemplXSDUni.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Template XSD unificado:";
            // 
            // btnPatrDirExp
            // 
            this.btnPatrDirExp.Location = new System.Drawing.Point(467, 64);
            this.btnPatrDirExp.Name = "btnPatrDirExp";
            this.btnPatrDirExp.Size = new System.Drawing.Size(24, 20);
            this.btnPatrDirExp.TabIndex = 6;
            this.btnPatrDirExp.Text = "#";
            this.btnPatrDirExp.UseVisualStyleBackColor = true;
            this.btnPatrDirExp.Click += new System.EventHandler(this.btnPatrDirExp_Click);
            // 
            // tpExportacao
            // 
            this.tpExportacao.IsBalloon = true;
            this.tpExportacao.ShowAlways = true;
            this.tpExportacao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tpExportacao.ToolTipTitle = "Diretório padrão SVN";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 331);
            this.Controls.Add(this.btnPatrDirExp);
            this.Controls.Add(this.btnSalvarTemplXSDUni);
            this.Controls.Add(this.btnSearchTemplXSDUni);
            this.Controls.Add(this.txtTemplXSDUni);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSalvarTemplXSDRes);
            this.Controls.Add(this.btnSearchTemplXSDRes);
            this.Controls.Add(this.txtTemplXSDRes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalvarTemplXSDReq);
            this.Controls.Add(this.btnSearchTemplXSDReq);
            this.Controls.Add(this.txtTemplXSDReq);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalvarTemplWSDLSE);
            this.Controls.Add(this.btnTemplWSDLSE);
            this.Controls.Add(this.txtTemplWSDLSE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSalvarTemplWSDLSN);
            this.Controls.Add(this.btnSearchTemplWSDLSN);
            this.Controls.Add(this.txtTemplWSDLSN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalvarDefaultNameSpace);
            this.Controls.Add(this.txtDefaultNameSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvarDirExp);
            this.Controls.Add(this.btnSearchDirExp);
            this.Controls.Add(this.txtDirExp);
            this.Controls.Add(this.lblDirExp);
            this.Controls.Add(this.btnSalvarDirRef);
            this.Controls.Add(this.btnSearchDirRef);
            this.Controls.Add(this.txtDirRef);
            this.Controls.Add(this.lblDirRef);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirRef;
        private System.Windows.Forms.TextBox txtDirRef;
        private System.Windows.Forms.Button btnSearchDirRef;
        private System.Windows.Forms.Button btnSalvarDirRef;
        private System.Windows.Forms.Button btnSalvarDirExp;
        private System.Windows.Forms.Button btnSearchDirExp;
        private System.Windows.Forms.TextBox txtDirExp;
        private System.Windows.Forms.Label lblDirExp;
        private System.Windows.Forms.Button btnSalvarDefaultNameSpace;
        private System.Windows.Forms.TextBox txtDefaultNameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvarTemplWSDLSN;
        private System.Windows.Forms.Button btnSearchTemplWSDLSN;
        private System.Windows.Forms.TextBox txtTemplWSDLSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvarTemplWSDLSE;
        private System.Windows.Forms.Button btnTemplWSDLSE;
        private System.Windows.Forms.TextBox txtTemplWSDLSE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvarTemplXSDReq;
        private System.Windows.Forms.Button btnSearchTemplXSDReq;
        private System.Windows.Forms.TextBox txtTemplXSDReq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvarTemplXSDRes;
        private System.Windows.Forms.Button btnSearchTemplXSDRes;
        private System.Windows.Forms.TextBox txtTemplXSDRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvarTemplXSDUni;
        private System.Windows.Forms.Button btnSearchTemplXSDUni;
        private System.Windows.Forms.TextBox txtTemplXSDUni;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPatrDirExp;
        private System.Windows.Forms.ToolTip tpExportacao;
    }
}