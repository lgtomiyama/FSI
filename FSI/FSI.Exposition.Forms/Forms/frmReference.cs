using FSI.Exposition.Forms.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;
using FSI.Control.ServiceIntegration;
using FSI.Model.ServiceIntegration;

namespace FSI.Exposition.Forms
{

    public partial class frmReference : Form
    {

        public frmReference()
        {
            InitializeComponent();
            fillTreeView();
        }
        #region Variaves
        List<string> refs = new List<string>();
        TreeNode _fieldsTreeCache = new TreeNode();
        BindingSource bsStructurePreview = new BindingSource();
        //List<ServiceMessage> listaMessage = new List<ServiceMessage>();
        string selectPropType = string.Empty;

        #endregion

        #region Metodos     
        private void fillTreeView()
        {
            IntegrationControl IC = new IntegrationControl();
            List<MessageStructure> aa = IC.GetTreeReferences();
            foreach (MessageStructure item in aa)
            {
                _fieldsTreeCache.Nodes.Add(MessageStructureTreeToNodes(item));
            }
            textTreeViewSearch1.treeReferences = treeReferences;
            textTreeViewSearch1.fieldsTreeCache = _fieldsTreeCache;
        }
        private TreeNode MessageStructureTreeToNodes(MessageStructure references)
        {
            TreeNode rootNode = new TreeNode(references.Reference.ObjName);
            rootNode.Tag = references.Reference.xml;
            rootNode.ToolTipText = references.Reference.Path;
            foreach (ReferenceElements element in references.Reference.Elements)
            {
                TreeNode elementNode = new TreeNode(element.Name);
                elementNode.Tag = element.Xml;
                elementNode.ToolTipText = references.Reference.Path;
                elementNode.Name = references.Reference.ObjName.Replace(".xsd", "") + "." + element.Name;
                rootNode.Nodes.Add(elementNode);
            }

            foreach (MessageStructure child in references.Children)
            {
                rootNode.Nodes.Add(MessageStructureTreeToNodes(child));
            }
            return rootNode;
        }
        private void PreencherDetalhesREF(XElement xNodeElement, TreeNode node)
        {
            string details = "";
            foreach (XAttribute item in xNodeElement.Attributes())
            {

                switch (item.Name.LocalName)
                {
                    case "type":
                        details += "Tipo: " + item.Value + "\n";
                        selectPropType = item.Value;
                        break;
                    case "minOccurs":
                        details += "Minimo: " + item.Value + "\n";
                        break;
                    case "maxOccurs":
                        details += "Máximo: " + item.Value + "\n";
                        break;
                    default:
                        break;
                }
            }
            details += ("file:// " + node.ToolTipText.Replace("\\\\", "\\")).Replace(' ', (char)160);
            txtDetailsRef.Text = details;
        }
        private static DialogResult ShowInputDialog(string dialogName, ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = dialogName;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
        #endregion

        #region Eventos

        private void rdContem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdContem.Checked)
                textTreeViewSearch1.searchType = SearchType.Contains;
        }
        private void rdTermina_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTermina.Checked)
                textTreeViewSearch1.searchType = SearchType.EndsWith;
        }
        private void rdComeca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdComeca.Checked)
                textTreeViewSearch1.searchType = SearchType.StartsWith;
        }
        #region Botoes
        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            string nomeOperacao = "";
            if (ShowInputDialog("Nome da Operação", ref nomeOperacao) == DialogResult.OK)
            {
                ListViewItem op = new ListViewItem();
                op.Text = nomeOperacao;
                op.Tag = new List<ServiceMessage>();
                cmbOperations.DisplayMember = "Text";
                cmbOperations.Items.Add(op);
                cmbOperations.SelectedItem = op;
                tableLayoutPanel5.Enabled = true;

            }
        }
        private void btnAddProp_Click(object sender, EventArgs e)
        {

            ServiceMessage newMessage = new ServiceMessage()
            {
                Propriedade = txtMessageStructure.Text,
                Alternativo = txtAlternative.Text,
                RO = checkRequired.Checked ? "R" : "O",
                Tipo = selectPropType
            };
            List<ServiceMessage> listaMessage = (List<ServiceMessage>)((ListViewItem)cmbOperations.SelectedItem).Tag;
            listaMessage.Add(newMessage);
            bsStructurePreview.DataSource = DBNull.Value;
            bsStructurePreview.DataSource = listaMessage;
            gdvStructurePreview.DataSource = bsStructurePreview;

        }
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            string input = "";
            if (DialogResult.OK == ShowInputDialog("Nome do complexo: ", ref input))
                txtMessageStructure.Text = input + "." + txtMessageStructure.Text;
        }
        private void btnAddList_Click(object sender, EventArgs e)
        {
            string complex = lblCanonico.Text + "s";
            string complexList = lblCanonico.Text;
            if (DialogResult.OK == ShowInputDialog("Nome do complexo: ", ref complex))
            {
                if (DialogResult.OK == ShowInputDialog("Nome da lista: ", ref complexList))
                {
                    txtMessageStructure.Text = complex + "." + complexList + "[?]." + txtMessageStructure.Text;
                }
            }
        }
        #endregion
        private void treeReferences_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeReferences.SelectedNode.Tag != null)
            {
                string previewText = (string)treeReferences.SelectedNode.Tag;
                rtxPreview.Text = previewText;
                XElement xNodeElement = XElement.Parse(previewText);
                PreencherDetalhesREF(xNodeElement, treeReferences.SelectedNode);
                //lblTamanhoTitle.Text = xNodeElement.Attribute("type").Value;
                TextHelper.HighlightRTF(rtxPreview);
                if (treeReferences.SelectedNode.Name != "")
                {

                    lblCanonico.Text = treeReferences.SelectedNode.Name.Split('.')[0];
                    lblProp.Text = treeReferences.SelectedNode.Name.Split('.')[1];
                    txtMessageStructure.Text = treeReferences.SelectedNode.Name;
                    tableLayoutPanel5.Enabled = true;
                    groupAuxMess.Enabled = true;
                }
                else
                {
                    lblCanonico.Text = "";
                    lblProp.Text = "";
                    txtAlternative.Text = "";
                    tableLayoutPanel5.Enabled = false;
                    txtMessageStructure.Text = "";
                    groupAuxMess.Enabled = false;
                }
            }
        }
        private void gdvStructurePreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow item in gdvStructurePreview.SelectedRows)
                {
                    gdvStructurePreview.Rows.RemoveAt(item.Index);
                }
            }
        }
        private void treeReferences_DoubleClick(object sender, EventArgs e)
        {
            string path = treeReferences.SelectedNode.ToolTipText.Replace("\\\\", "\\");
            if (path != "")
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", path));
        }
        private void txtDetailsRef_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                string path = string.Format("/select,\"{0}\"", e.LinkText.Replace((char)160, ' ')).Replace("file:// ", "");
                Process.Start("explorer.exe", path);
            }
            catch (Exception)
            {
            }
        }
        private void cmbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ServiceMessage> listaMessage = (List<ServiceMessage>)((ListViewItem)cmbOperations.SelectedItem).Tag;
            bsStructurePreview.DataSource = DBNull.Value;
            bsStructurePreview.DataSource = listaMessage;
            gdvStructurePreview.DataSource = bsStructurePreview;
        }
        #endregion


    }
    public class ServiceMessage
    {
        public string Propriedade { get; set; }
        public string RO { get; set; }
        public string Tipo { get; set; }
        public string Lista { get; set; }
        public string Alternativo { get; set; }
    }
}