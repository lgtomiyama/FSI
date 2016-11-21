using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FSI.Exposition.Forms
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            tpExportacao.SetToolTip(btnPatrDirExp, "Utilizar o diretório padrão do barramento");
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtDirRef.Text = ConfigurationManager.AppSettings["diretorioReferencias"];
            txtDirExp.Text = ConfigurationManager.AppSettings["diretorioExportacao"];
            txtDefaultNameSpace.Text = ConfigurationManager.AppSettings["defaultNameSpace"];
            txtTemplWSDLSN.Text = ConfigurationManager.AppSettings["diretorioTemplateWSDL_SN"];
            txtTemplWSDLSE.Text = ConfigurationManager.AppSettings["diretorioTemplateWSDL_SE"];
            txtTemplXSDReq.Text = ConfigurationManager.AppSettings["diretorioTemplateRequest"];
            txtTemplXSDRes.Text = ConfigurationManager.AppSettings["diretorioTemplateResponse"];
            txtTemplXSDUni.Text = ConfigurationManager.AppSettings["diretorioTemplateRequestResponse"];
        }
        public static void UpdateAppSettings(string KeyName, string KeyValue)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[KeyName].Value = KeyValue;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void btnSearchDirRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txtDirRef.Text;

            DialogResult result = fbd.ShowDialog();

            txtDirRef.Text = fbd.SelectedPath;
        }

        private void btnSearchDirExp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txtDirExp.Text;

            DialogResult result = fbd.ShowDialog();

            txtDirExp.Text = fbd.SelectedPath;
        }

        private void btnSearchTemplWSDLSN_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "wsdl files (*.wsdl)|*.xml";
            string path = txtTemplWSDLSN.Text;

            op.InitialDirectory = path;

            if (op.ShowDialog() == DialogResult.OK)
                txtTemplWSDLSN.Text = op.FileName;

        }

        private void btnTemplWSDLSE_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "wsdl files (*.wsdl)|*.xml";
            string path = txtTemplWSDLSE.Text;

            op.InitialDirectory = path;

            if (op.ShowDialog() == DialogResult.OK)
                txtTemplWSDLSE.Text = op.FileName;
        }

        private void btnSearchTemplXSDReq_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xsd files (*.xsd)|*.xml";
            string path = txtTemplXSDReq.Text;

            op.InitialDirectory = path;

            if (op.ShowDialog() == DialogResult.OK)
                txtTemplXSDReq.Text = op.FileName;
        }

        private void btnSearchTemplXSDRes_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xsd files (*.xsd)|*.xml";
            string path = txtTemplXSDRes.Text;

            op.InitialDirectory = path;

            if (op.ShowDialog() == DialogResult.OK)
                txtTemplXSDRes.Text = op.FileName;
        }

        private void btnSearchTemplXSDUni_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xsd files (*.xsd)|*.xml";
            string path = txtTemplXSDUni.Text;

            op.InitialDirectory = path;

            if (op.ShowDialog() == DialogResult.OK)
                txtTemplXSDUni.Text = op.FileName;
        }

        private void btnSalvarDirRef_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioReferencias", txtDirRef.Text);
        }

        private void btnSalvarDirExp_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioExportacao", txtDirExp.Text);
        }

        private void btnSalvarDefaultNameSpace_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("defaultNameSpace", txtDefaultNameSpace.Text);
        }

        private void btnSalvarTemplWSDLSN_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioTemplateWSDL_SN", txtTemplWSDLSN.Text);
        }

        private void btnSalvarTemplWSDLSE_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioTemplateWSDL_SE", txtTemplWSDLSE.Text);
        }

        private void btnSalvarTemplXSDReq_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioTemplateRequest", txtTemplXSDReq.Text);
        }

        private void btnSalvarTemplXSDRes_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioTemplateResponse", txtTemplXSDRes.Text);
        }

        private void btnSalvarTemplXSDUni_Click(object sender, EventArgs e)
        {
            UpdateAppSettings("diretorioTemplateRequestResponse", txtTemplXSDUni.Text);
        }

        private void btnPatrDirExp_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["diretorioReferencias"];
            if (path[path.Length-1].Equals('\\'))
                path = path.Remove(path.Length-1);
            txtDirExp.Text = path + "\\contract\\servicebus";
        }
    }
}
