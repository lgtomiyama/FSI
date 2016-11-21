using FSI.Control.ServiceIntegration;
using FSI.Model.ServiceIntegration;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FSI.Exposition.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<IntegrationScope> IS;
        List<ContractServiceSctructure> contracts;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xlsx files (*.xlsx)|*.xlsx";


            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IntegrationControl IC = new IntegrationControl();
                    IS = IC.ReadIntegrationPlan(op.FileName);
                    MessageBox.Show("Serviço "+ IS.FirstOrDefault().Services.FirstOrDefault().Name +" carregado com sucesso!");
                    button2.Enabled = true;
                }
                catch (Exception ex)
                {
                    button2.Enabled = false;
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntegrationControl IC = new IntegrationControl();
            foreach (var iScope in IS)
            {
                foreach (var svc in iScope.Services)
                {
                    svc.Template = ConfigurationManager.AppSettings["diretorioTemplateWSDL"];
                    foreach (var operation in svc.Operations)
                    {
                        operation.RequestMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateRequest"];
                        operation.ResponseMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateResponse"];
                    }
                }
                contracts = IC.ContratIntegrationScope(iScope, false);
                cmbOperations.DisplayMember = "Name";
                cmbOperations.DataSource = contracts.FirstOrDefault().Operations;
                txtWSDL.Text = Beautify(contracts.FirstOrDefault().WSDL);
                txtXSDIn.Text = Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDIn);
                txtXSDOut.Text = Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDOut);
                btnSalvar.Enabled = true;
            }
        }
        private string Beautify(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

        private void cmbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtXSDIn.Text = Beautify(((ContractOperationSctructure)((ComboBox)sender).SelectedItem).XSDIn);
            txtXSDOut.Text = Beautify(((ContractOperationSctructure)((ComboBox)sender).SelectedItem).XSDOut);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            IntegrationControl IC = new IntegrationControl();
            IC.ContractPersist(contracts);
        }
    }
}
