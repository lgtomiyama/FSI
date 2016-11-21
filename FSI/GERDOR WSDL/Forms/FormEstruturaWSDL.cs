using Common;
using GERADOR_WSDL.Utilitarios;
using System;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Xml;

namespace GERDOR_WSDL.Forms
{
    public class FormEstruturaWSDL : Form
    {
        #region Attributes
        private Button button1;
        private Label label1;
        private TreeView tvwService;
        private TextBox txtMessage;
        private Label label2;
        private Label label3;
        private RichText myText = new RichText();
        private ComboBox cboURL;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        #endregion
        #region Constructors
        public FormEstruturaWSDL()
        {
            InitializeComponent();
            MyInit();
        }
        #endregion
        #region Private Methods
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstruturaWSDL));
            this.tvwService = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboURL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tvwService
            // 
            this.tvwService.ImageIndex = 0;
            this.tvwService.ImageList = this.imageList1;
            this.tvwService.Location = new System.Drawing.Point(12, 121);
            this.tvwService.Name = "tvwService";
            this.tvwService.SelectedImageIndex = 0;
            this.tvwService.Size = new System.Drawing.Size(660, 214);
            this.tvwService.TabIndex = 0;
            this.tvwService.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwService_AfterSelect);
            this.tvwService.Click += new System.EventHandler(this.tvwService_Click);
            this.tvwService.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwService_MouseDown);
            this.tvwService.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwService_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(570, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Parse";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 357);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(660, 176);
            this.txtMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Service Description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // cboURL
            // 
            this.cboURL.Location = new System.Drawing.Point(12, 69);
            this.cboURL.Name = "cboURL";
            this.cboURL.Size = new System.Drawing.Size(552, 21);
            this.cboURL.TabIndex = 7;
            this.cboURL.Text = "http://www.webservicex.com/globalweather.asmx?WSDL";
            // 
            // FormEstruturaWSDL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(683, 545);
            this.Controls.Add(this.cboURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvwService);
            this.Name = "FormEstruturaWSDL";
            this.Text = "WSDL and Schema Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void MyInit()
        {
            myText.Size = txtMessage.Size;
            myText.Top = txtMessage.Top;
            myText.Left = txtMessage.Left;
            myText.Visible = true;
            txtMessage.Visible = false;
            this.Controls.Add(myText);
        }
        private void ReadServiceDescription()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                XmlTextReader reader = new XmlTextReader(cboURL.Text);
                ServiceDescription service =
                    ServiceDescription.Read(reader);
                WSDLParser parser = new WSDLParser(service);

                this.tvwService.Nodes.Add(parser.ServiceNode);
                this.cboURL.Items.Add(cboURL.Text);
                //http://soap.amazon.com/schemas2/AmazonWebServices.wsdl 
                //http://glkev.webs.innerhost.com/glkev_ws/weatherfetcher.asmx?wsdl
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadServiceDescription();
        }
        private void tvwService_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvwService.SelectedNode;
            this.myText.Text = "";
            if (tn != null)
            {
                if (tn.Tag is string)
                {
                    string message = (string)tn.Tag;
                    this.myText.Text = message;
                }
                else
                    if (tn.Tag is XSDParser.NodeData)
                {
                    XSDParser.NodeData data = tn.Tag as XSDParser.NodeData;
                    string message = data.baseObj.ToString() + "\n";
                    message += data.Namespace + "\n";
                    message += data.Type + "\n";
                    string xml = XMLGenerator.GetXmlSample(tn);

                    message += xml;

                    this.myText.Text = message;
                }
            }
        }
        private void tvwService_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void tvwService_MouseUp(object sender, MouseEventArgs e)
        {
            this.tvwService.SelectedNode = this.tvwService.GetNodeAt(e.X, e.Y);
        }
        private void tvwService_MouseDown(object sender, MouseEventArgs e)
        {
            this.tvwService.SelectedNode = this.tvwService.GetNodeAt(e.X, e.Y);
        }
        #endregion
        #region Protected Methods
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion
    }   
}
