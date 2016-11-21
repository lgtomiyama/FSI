using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GERDOR_WSDL.forms
{
    //Criardor: Lucas Garcia Tomiyama
    public partial class frmMain : Form
    {
        public frmMain()
        {
            //FormularioDeConexao();

            InitializeComponent();
            InciaMenu();
            Global.idioma = Global.Idioma.ENG;
        }

        private void InciaMenu()
        {

            ToolStripMenuItem menuInicio = new ToolStripMenuItem("&Inicio");
            //Tabelas
            ToolStripMenuItem menuInfoEstruturaServicos = new ToolStripMenuItem("Estrutura S&erviços");
            menuInfoEstruturaServicos.Click += new EventHandler(MenuInicial_InfoEstruturaServico);
            menuInicio.DropDownItems.Add(menuInfoEstruturaServicos);
            //Procedures
            ToolStripMenuItem menuInfoSE = new ToolStripMenuItem("S&E");
            menuInfoSE.Click += new EventHandler(MenuInicial_InfoSE);
            menuInicio.DropDownItems.Add(menuInfoSE);

            //Sair
            ToolStripSeparator ArquivoSairSeparator = new ToolStripSeparator();
            menuInicio.DropDownItems.Add(ArquivoSairSeparator);
            ToolStripMenuItem Arquivo_Sair = new ToolStripMenuItem("&Sair");
            Arquivo_Sair.Click += new EventHandler(Sair);
            menuInicio.DropDownItems.Add(Arquivo_Sair);

            //Adiciona a barra
            MenuSup.Items.Add(menuInicio);
            MenuSup.Items.Add(new ToolStripSeparator());
        }


        public void TrocaJanela(Form janela)
        {
            bool existe = false;
            foreach (Form i in this.MdiChildren)
            {
                if (i.ToString().Equals(janela.ToString()))
                {
                    i.Dispose();
                    existe = true;
                }

            }
            if (!existe)
            {
                ToolStripButton Tab = new ToolStripButton();
                Tab.Text = janela.Text;
                Tab.Click += new EventHandler(Tab_Click);
                MenuSup.Items.Add(Tab);
            }
            janela.MdiParent = this;
            janela.FormClosed += new FormClosedEventHandler(janela_FormClosed);
            janela.Show();

        }
        ToolStripItem btnRemover;
        public void FechaForm(Form form)
        {
            foreach (ToolStripItem btn in MenuSup.Items)
            {
                if (form.Text == btn.ToString())
                {
                    btnRemover = btn;
                }
            }
            MenuSup.Items.Remove(btnRemover);
        }


        void Tab_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                ToolStripButton btnTab = ((ToolStripButton)sender);

                if (btnTab.Text == frm.Text)
                {
                    frm.Focus();
                    frm.WindowState = FormWindowState.Maximized;
                }
            }
        }
        public void Sair(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja realmente sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                this.Dispose();
        }

        #region Eventos mdiChilds

        public void MenuInicial_InfoEstruturaServico(object sender, EventArgs e)
        {
            this.TrocaJanela(new Forms.FormEstruturaWSDL());
        }
        public void MenuInicial_InfoSE(object sender, EventArgs e)
        {
            this.TrocaJanela(new Forms.CarregarPlanilhas());
        }
        void janela_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FechaForm((Form)sender);
        }
        #endregion



    }
}
