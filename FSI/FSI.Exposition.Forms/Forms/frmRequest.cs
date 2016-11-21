using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FSI.Control.ServiceIntegration;
using FSI.Model.ServiceIntegration;
using System.Xml;
using System.Net;
using System.IO;
using FSI.Exposition.Forms.Common;

namespace FSI.Exposition.Forms
{
    public partial class frmRequest : Form
    {
        public frmRequest()
        {
            InitializeComponent();
        }
        List<IntegrationScope> IS;
        IntegrationControl IC = new IntegrationControl();
        //List<ContractServiceSctructure> contracts;
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    IS = IC.ReadIntegrationPlan(op.FileName);
                    

                    cmbOperations.DisplayMember = "Name";
                    cmbOperations.DataSource = IS.FirstOrDefault().Services.FirstOrDefault().Operations;
                    txtUrl.Text = "http://10.129.224.26/" + string.Join("/", IS.FirstOrDefault().Services.FirstOrDefault().TAM) + "/"  + cmbOperations.Text + "/v1/" + cmbOperations.Text;
                    txtUrl.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnValidarSequence.Enabled = true;
                    btnGenerateLoad.Enabled = true;
                    if (IS[0].errorQt <= 0)
                    {
                        MessageBox.Show("Serviço " + IS.FirstOrDefault().Services.FirstOrDefault().Name + " carregado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Serviço " + IS.FirstOrDefault().Services.FirstOrDefault().Name + " importado com erros! \n" + string.Join("", IS[0].propErrorList.ToArray()), "Alerta!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                catch (Exception ex)
                {
                    txtUrl.Enabled = false;
                    btnSubmit.Enabled = false;
                    btnValidarSequence.Enabled = false;
                    btnGenerateLoad.Enabled = false;
                    MessageBox.Show("Erro: " + ex.Message);

                }
            }
        }

        private TreeNode criarTreeView(MessageStructure messageSctructtureNode, TreeNode parent)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = messageSctructtureNode.PropName;
            newNode.Tag = messageSctructtureNode;
            newNode.Text = messageSctructtureNode.PropName;
            parent.Nodes.Add(newNode);
            foreach (var item in messageSctructtureNode.Children)
            {
                criarTreeView(item, newNode);
            }
            return parent;
        }

   
        private void cmbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operation selectedOperation = (Operation)((ComboBox)sender).SelectedItem;
            treeViewContract.Nodes.Clear();
            TreeNode masterNode = new TreeNode(selectedOperation.Name);
            criarTreeView(selectedOperation.RequestMessage.Structure, masterNode);
            
            treeViewContract.Nodes.Add(masterNode);
            txtRequest.Text = TextHelper.Beautify(IC.GetRequest(selectedOperation, IS.FirstOrDefault().Services.FirstOrDefault()));
            TextHelper.HighlightRTF(txtRequest);
        }

        private void btnValidarSequence_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xsd files (*.xsd)|*.xsd";
            if (op.ShowDialog() == DialogResult.OK)
            {
                IC.OrganizarSequenceRequest((Operation)cmbOperations.SelectedItem, op.FileName);
                txtRequest.Text = TextHelper.Beautify(IC.GetRequest((Operation)((ComboBox)cmbOperations).SelectedItem, IS.FirstOrDefault().Services.FirstOrDefault()));
                TextHelper.HighlightRTF(txtRequest);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var _url = txtUrl.Text;
                var _action = txtUrl.Text;

                XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
                HttpWebRequest webRequest = CreateWebRequest(_url, _action);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
                WebResponse asyncResult = webRequest.GetResponse();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(txtRequest.Text);
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private void treeViewContract_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            if ((MessageStructure)e.Node.Tag != null)
            {
                MessageStructure prop = ((MessageStructure)e.Node.Tag);
                groupProperty.Text = prop.PropName;
                txtPropType.Text = prop.Reference != null ? prop.Reference.Type : "";
                txtPropValue.Text = prop.DefaultValue;
                checkRequired.Checked = prop.Required;
                checkGerar.Checked = prop.GenerateOnLoad;
            }
        }

        private void checkGerar_CheckedChanged(object sender, EventArgs e)
        {
            ((MessageStructure)treeViewContract.SelectedNode.Tag).GenerateOnLoad = checkGerar.Checked;
        }

        private void txtPropValue_TextChanged(object sender, EventArgs e)
        {
            ((MessageStructure)treeViewContract.SelectedNode.Tag).DefaultValue = ((TextBox)sender).Text;
        }

        private void btnGenerateLoad_Click(object sender, EventArgs e)
        {
            txtRequest.Text = TextHelper.Beautify(IC.GetRequest((Operation)((ComboBox)cmbOperations).SelectedItem, IS.FirstOrDefault().Services.FirstOrDefault()));
            TextHelper.HighlightRTF(txtRequest);
        }

    }
}
