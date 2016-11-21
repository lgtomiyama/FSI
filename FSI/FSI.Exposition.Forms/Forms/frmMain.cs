using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSI.Exposition.Forms
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
            ToolStripMenuItem menuTools = new ToolStripMenuItem("&Ferramentas");
            #region Ferramentas
            //Contratos
            //ToolStripMenuItem menuInfoEstruturaServicos = new ToolStripMenuItem("&Contract Tool");
            //menuInfoEstruturaServicos.Click += new EventHandler(MenuInicial_ContractTool);
            //menuTools.DropDownItems.Add(menuInfoEstruturaServicos);
            //Referencias
            ToolStripMenuItem menuContract = new ToolStripMenuItem("&Contract Tool");
            menuContract.Click += new EventHandler(MenuInicial_ContractTool);
            menuTools.DropDownItems.Add(menuContract);
            //Request
            ToolStripMenuItem menuRequests = new ToolStripMenuItem("Re&quest Tool");
            menuRequests.Click += new EventHandler(MenuInicial_ResquestTool);
            menuTools.DropDownItems.Add(menuRequests);
            //Referencias
            ToolStripMenuItem menuReference = new ToolStripMenuItem("&Reference Tool (Beta)");
            menuReference.Click += new EventHandler(MenuInicial_ReferenceTool);
            menuTools.DropDownItems.Add(menuReference);

            #endregion

            #region Inicio
            //Configurações
            ToolStripMenuItem menuConfiguration = new ToolStripMenuItem("&Configurações");
            menuConfiguration.Click += new EventHandler(MenuInicial_menuConfiguration);
            menuInicio.DropDownItems.Add(menuConfiguration);
            //Atualizar
            ToolStripMenuItem menuAtualizacao = new ToolStripMenuItem("Atuali&zar Aplicação");
            menuAtualizacao.Click += new EventHandler(MenuInicial_menuAtualizacao);
            menuInicio.DropDownItems.Add(menuAtualizacao);
            //Atualizar updates
            ToolStripMenuItem menuAtualizacaoAtualizador = new ToolStripMenuItem("Atualizar At&ualizador");
            menuAtualizacaoAtualizador.Click += new EventHandler(MenuInicial_menAtualizacaoAtualizador);
            menuInicio.DropDownItems.Add(menuAtualizacaoAtualizador);
            //Sair
            ToolStripSeparator ArquivoSairSeparator = new ToolStripSeparator();
            menuInicio.DropDownItems.Add(ArquivoSairSeparator);
            ToolStripMenuItem Arquivo_Sair = new ToolStripMenuItem("&Sair");
            Arquivo_Sair.Click += new EventHandler(Sair);
            menuInicio.DropDownItems.Add(Arquivo_Sair);
            #endregion


            //Adiciona a barra
            MenuSup.Items.Add(menuInicio);
            MenuSup.Items.Add(menuTools);
            MenuSup.Items.Add(new ToolStripSeparator());
        }

        private void MenuInicial_ReferenceTool(object sender, EventArgs e)
        {
            this.TrocaJanela(new frmReference());
        }

        private void MenuInicial_menAtualizacaoAtualizador(object sender, EventArgs e)
        {
            this.TrocaJanela(new frmUpdateUpdater());
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
            janela.WindowState = FormWindowState.Maximized;
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


        public void MenuInicial_ContractTool(object sender, EventArgs e)
        {
            this.TrocaJanela(new frmContractTool());

        }
        private void MenuInicial_ResquestTool(object sender, EventArgs e)
        {
            this.TrocaJanela(new frmRequest());
        }
        void janela_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FechaForm((Form)sender);
        }
        private void MenuInicial_menuConfiguration(object sender, EventArgs e)
        {
            this.TrocaJanela(new frmConfig());
        }
        private void MenuInicial_menuAtualizacao(object sender, EventArgs e)
        {
            Process app = new Process();
            app.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "FSI.Setup.Update.exe";
            app.StartInfo.Arguments = "\"https://quark.everis.com/svn/BEATRIX/trunk/tools/1. contract generator/FSI.Exposition.Forms/bin/Release/\" \"https://quark.everis.com/svn/BEATRIX/trunk/src/telefonica-sb\" \"https://quark.everis.com/svn/BEATRIX/trunk/tools/1. contract generator/Templates/\" "; // if you need some
            app.Start();
            this.Dispose();
        }
        #endregion



    }
}
