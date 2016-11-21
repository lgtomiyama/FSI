using FSI.Control.ServiceIntegration;
using FSI.Exposition.Forms.Common;
using FSI.Model.ServiceIntegration;
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
    public partial class frmContractTool : Form
    {
        public frmContractTool()
        {
            InitializeComponent();
        }

        List<IntegrationScope> IS;
        List<ContractServiceSctructure> contracts;
        #region eventos

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
                    prrencherTreeView(IS.FirstOrDefault().Services.FirstOrDefault());

                    limparTela();

                }
                catch (Exception ex)
                {
                    panelExport.Enabled = false;
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        }
        private void cmbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).DataSource != null)
            {
                foreach (var operation in contracts.FirstOrDefault().Operations)
                {
                    if (((Operation)((ComboBox)sender).SelectedItem).Name == operation.Name)
                    {
                        if (!CheckUnion.Checked)
                        {

                            txtXSDIn.Text = TextHelper.Beautify(operation.XSDIn);
                            txtXSDOut.Text = TextHelper.Beautify(operation.XSDOut);
                        }
                        else
                        {
                            txtXSDIn.Text = TextHelper.Beautify(operation.XSDInOut);
                        }
                    }
                }
                Operation selectedOperation = (Operation)((ComboBox)sender).SelectedItem;
                selecionarOperacaoTreeView(selectedOperation);

                TextHelper.HighlightRTF(txtXSDOut);
                TextHelper.HighlightRTF(txtXSDIn);
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportar();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            IntegrationControl IC = new IntegrationControl();
            IC.ContractPersist(contracts);
            panelSave.Enabled = true;
            MessageBox.Show("Contrato gerado em : \n " + contracts.FirstOrDefault().Path.Replace("/", "\\").Replace("\\\\", "\\"));
        }
        private void btnDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", contracts.FirstOrDefault().Path.Replace("/", "\\").Replace("\\\\", "\\"));
        }
        private void treeViewContract_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((MessageStructure)e.Node.Tag != null)
            {
                MessageStructure prop = ((MessageStructure)e.Node.Tag);
                groupProperty.Text = prop.PropName;
                if (prop.Reference != null)
                {
                    txtPropType.Text = prop.Reference.Type;
                    txtPropPath.Text = prop.Reference.Path != null ? ConfigurationManager.AppSettings["diretorioReferencias"] + prop.Reference.Path + ".xsd" : "";
                    txtPropNamespace.Text = prop.Reference.NameSpace != null ? prop.Reference.NameSpace : "";
                    groupProperty.Enabled = true;
                }
                else
                {
                    groupProperty.Enabled = false;
                }
                checkRequired.Checked = prop.Required;
            }
        }
        private void CheckUnion_CheckedChanged(object sender, EventArgs e)
        {
            exportar();
            LayoutXSDResponse(CheckUnion.Checked);
        }
        private void checkSNSE_CheckedChanged(object sender, EventArgs e)
        {
            exportar();
        }
        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            string path = txtPropPath.Text.Replace(groupProperty.Text + ".xsd", "");
            OpenFileDialog fileXSD = new OpenFileDialog();
            if (Directory.Exists(path))
            {
                fileXSD.InitialDirectory = path;
            }
            else
            {
                MessageBox.Show("Este caminho não existe");
            }


            if (fileXSD.ShowDialog() == DialogResult.OK)
            {
                txtPropPath.Text = fileXSD.FileName;
            }
        }
        private void checkRequired_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ((MessageStructure)treeViewContract.SelectedNode.Tag).Required = checkRequired.Checked;
            }
            catch { }
        }
        private void txtPropNamespace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((MessageStructure)treeViewContract.SelectedNode.Tag).Reference.NameSpace = txtPropNamespace.Text;
            }
            catch { }
        }
        private void txtPropPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((MessageStructure)treeViewContract.SelectedNode.Tag).Reference.Path = txtPropPath.Text.Replace(ConfigurationManager.AppSettings["diretorioReferencias"], "").Replace(".xsd", "");
            }
            catch { }

        }
        #endregion
        #region Layout
        private void LayoutXSDResponse(bool hideResponse)
        {
            if (hideResponse)
            {
                tableLayoutPanel3.ColumnStyles[3] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F);
                tableLayoutPanel3.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);
                txtXSDOut.Text = "XSD Out";
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[3] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                tableLayoutPanel3.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20);
            }
            btnExpandXSDIn.Visible = !hideResponse;
            btnExpandXSDOut.Visible = !hideResponse;
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            LayoutAuxPanel();
        }

        private void LayoutAuxPanel()
        {
            if (btnExpandWSDL.Text == "►")
            {
                tableLayoutPanel2.ColumnStyles[1] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                btnExpandWSDL.Text = "◄";
            }
            else
            {
                btnExpandWSDL.Text = "►";
                tableLayoutPanel2.ColumnStyles[1] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0);
            }
        }
        private void btnExpandXSDOut_Click(object sender, EventArgs e)
        {
            if (btnExpandXSDOut.Text == "◄")
            {
                tableLayoutPanel3.ColumnStyles[1] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F);
                tableLayoutPanel3.ColumnStyles[0] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);
                btnExpandXSDOut.Text = "►";
                //btnExpandXSDIn.Visible = false;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[1] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                tableLayoutPanel3.ColumnStyles[0] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20);
                btnExpandXSDOut.Text = "◄";
                //btnExpandXSDIn.Visible = true;
            }
        }
        private void btnExpandXSDIn_Click(object sender, EventArgs e)
        {
            if (btnExpandXSDIn.Text == "►")
            {
                tableLayoutPanel3.ColumnStyles[3] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F);
                tableLayoutPanel3.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);
                btnExpandXSDIn.Text = "◄";
                //btnExpandXSDOut.Visible = false;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[3] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
                tableLayoutPanel3.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20);
                btnExpandXSDIn.Text = "►";
                //btnExpandXSDOut.Visible = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "▲")
            {
                tableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                tableLayoutPanel1.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0);
                button3.Text = "▼";
            }
            else
            {
                tableLayoutPanel1.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F);
                tableLayoutPanel1.RowStyles[2] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25);
                button3.Text = "▲";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "▼")
            {
                tableLayoutPanel1.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                tableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0);
                button2.Text = "▲";
            }
            else
            {
                tableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F);
                tableLayoutPanel1.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25);
                button2.Text = "▼";
            }
        }
        #endregion
        #region Metodos
        private void exportar()
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
                cmbOperations.DataSource = IS.FirstOrDefault().Services.FirstOrDefault().Operations;
                txtWSDL.Text = TextHelper.Beautify(contracts.FirstOrDefault().WSDL);

                if (!CheckUnion.Checked)
                {
                    txtXSDOut.Text = TextHelper.Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDOut);
                    txtXSDIn.Text = TextHelper.Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDIn);
                }
                else
                {
                    txtXSDIn.Text = TextHelper.Beautify(contracts.FirstOrDefault().Operations.FirstOrDefault().XSDInOut);
                }
                panelSave.Enabled = true;
                groupProperty.Enabled = false;
            }
            TextHelper.HighlightRTF(txtXSDOut);
            TextHelper.HighlightRTF(txtXSDIn);
            TextHelper.HighlightRTF(txtWSDL);
        }
        private void prrencherTreeView(Service svc)
        {
            treeViewContract.Nodes.Clear();
            TreeNode masterNode = new TreeNode(svc.Name);
            foreach (var item in svc.Operations)
            {
                TreeNode operationNode = new TreeNode(item.Name);
                TreeNode operationNodeRequest = new TreeNode("Request");
                operationNode.Nodes.Add(operationNodeRequest);
                criarTreeView(item.RequestMessage.Structure, operationNodeRequest);

                TreeNode operationNodeResponse = new TreeNode("Response");
                operationNode.Nodes.Add(operationNodeResponse);
                criarTreeView(item.ResponseMessage.Structure, operationNodeResponse);
                masterNode.Nodes.Add(operationNode);
            }
            treeViewContract.Nodes.Add(masterNode);

        }
        private void selecionarOperacaoTreeView(Operation selectedOperation)
        {
            treeViewContract.CollapseAll();
            for (int i = 0; i < treeViewContract.Nodes[0].Nodes.Count; i++)
            {
                if (treeViewContract.Nodes[0].Nodes[i].Text == selectedOperation.Name)
                {
                    treeViewContract.Nodes[0].Expand();
                    treeViewContract.Nodes[0].Nodes[i].Expand();
                    treeViewContract.SelectedNode = treeViewContract.Nodes[0].Nodes[i];
                    treeViewContract.SelectedNode.EnsureVisible();
                    treeViewContract.Focus();
                }
            }
        }
        //private void preencherTreeView(Operation selectedOperation)
        //{
        //    treeViewContract.Nodes.Clear();
        //    TreeNode masterNode = new TreeNode(selectedOperation.Name);
        //    criarTreeView(selectedOperation.RequestMessage.Structure, masterNode);
        //    treeViewContract.Nodes.Add(masterNode);
        //}
        private void limparTela()
        {
            cmbOperations.DataSource = null;
            panelExport.Enabled = true;
            panelSave.Enabled = false;
            groupProperty.Enabled = false;
            txtPropNamespace.Text = "";
            txtPropPath.Text = "";
            txtPropType.Text = "";
            txtWSDL.Text = "WSDL";
            txtXSDIn.Text = "XSD In";
            txtXSDOut.Text = "XSD Out";
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


        #endregion



    }
}
