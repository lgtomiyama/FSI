using FSI.Control.ServiceIntegration;
using FSI.Model.ServiceIntegration;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace FSI.Exposition.Forms
{
    public partial class frmContract : Form
    {
        public frmContract()
        {
            InitializeComponent();
        }
        List<IntegrationScope> IS;
        List<ContractServiceSctructure> contracts;
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xlsx files (*.xlsx)|*.xlsx";


            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IntegrationControl IC = new IntegrationControl();
                    IS = IC.ReadIntegrationPlan(op.FileName);
                    if (IS[0].errorQt <= 0)
                    {
                        MessageBox.Show("Serviço " + IS.FirstOrDefault().Services.FirstOrDefault().Name + " carregado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Serviço " + IS.FirstOrDefault().Services.FirstOrDefault().Name + " importado com erros! \n " + string.Join("", IS[0].propErrorList.ToArray()), "Alerta!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    btnExportar.Enabled = true;
                    btnDir.Enabled = false;
                }
                catch (Exception ex)
                {
                    btnExportar.Enabled = false;
                    btnDir.Enabled = false;
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            IntegrationControl IC = new IntegrationControl();
            foreach (var iScope in IS)
            {
                foreach (var svc in iScope.Services)
                {
                    if (!checkSNSE.Checked)
                        svc.Template = ConfigurationManager.AppSettings["diretorioTemplateWSDL_SN"];
                    else
                        svc.Template = ConfigurationManager.AppSettings["diretorioTemplateWSDL_SE"];

                    foreach (var operation in svc.Operations)
                    {
                        if (!CheckUnion.Checked)
                        {
                            operation.RequestMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateRequest"];
                            operation.ResponseMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateResponse"];
                        }
                        else
                        {
                            operation.RequestMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateRequestResponse"];
                            operation.ResponseMessage.Template = ConfigurationManager.AppSettings["diretorioTemplateRequestResponse"];
                        }

                    }
                }
                contracts = IC.ContractIntegrationScope(iScope, CheckUnion.Checked, checkSNSE.Checked);
                cmbOperations.DisplayMember = "Name";
                cmbOperations.DataSource = contracts.FirstOrDefault().Operations;
                txtWSDL.Text = Beautify(contracts.FirstOrDefault().WSDL);

                if (!CheckUnion.Checked)
                {
                    txtXSDOut.Text = Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDOut);
                    txtXSDIn.Text = Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDIn);
                }
                else
                {
                    txtXSDIn.Text = Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDInOut);
                }
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
            if (!CheckUnion.Checked)
            {
                txtXSDIn.Text = Beautify(((ContractOperationSctructure)((ComboBox)sender).SelectedItem).XSDIn);
                txtXSDOut.Text = Beautify(((ContractOperationSctructure)((ComboBox)sender).SelectedItem).XSDOut);
            }
            else
            {
                txtXSDIn.Text = Beautify(((ContractOperationSctructure)((ComboBox)sender).SelectedItem).XSDInOut);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            IntegrationControl IC = new IntegrationControl();
            IC.ContractPersist(contracts);
            btnDir.Enabled = true;
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", contracts.FirstOrDefault().Path.Replace("/", "\\").Replace("\\\\", "\\"));
        }

    }
}
