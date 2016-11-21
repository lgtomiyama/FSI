//using SharpSvn;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace FSI.Exposition.Forms
{
    [RunInstaller(true)]
    public partial class InstallerSetup : System.Configuration.Install.Installer
    {
        public InstallerSetup()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            try
            {
                AddConfigurationFileDetails();
                //GetSVN();
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao atualizar o arquivo de configuração da aplicação: " + e.Message);
                base.Rollback(savedState);
            }
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

        private void showParameters()
        {
            StringBuilder sb = new StringBuilder();
            StringDictionary myStringDictionary = this.Context.Parameters;
            if (this.Context.Parameters.Count > 0)
            {
                foreach (string myString in this.Context.Parameters.Keys)
                {
                    sb.AppendFormat("String={0} Value= {1}\n", myString,
                    this.Context.Parameters[myString]);
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void AddConfigurationFileDetails()
        {
            try
            {
                string defaultNameSpace = Context.Parameters["DEFAULTNAMESPACE"];
                string assemblypath = Context.Parameters["assemblypath"];
                string appConfigPath = assemblypath + ".config";
               // string diretorioExportacao = Context.Parameters["targetdir"] + "export";
                string diretorioExportacao = Context.Parameters["targetdir"] + "telefonica-sb\\contract\\servicebus";
                string diretorioReferencias = Context.Parameters["targetdir"] + "telefonica-sb";
                string templatesPath = Context.Parameters["targetdir"] + "Templates\\";
                templatesPath = templatesPath.Replace("\\\\", "\\");
                templatesPath = templatesPath.Replace("\\\\", "\\");
                diretorioExportacao = diretorioExportacao.Replace("\\\\", "\\");
                diretorioReferencias = diretorioReferencias.Replace("\\\\", "\\");
                // Write the path to the app.config file  
                XmlDocument doc = new XmlDocument();
                doc.Load(appConfigPath);

                XmlNode configuration = null;
                foreach (XmlNode node in doc.ChildNodes)
                    if (node.Name == "configuration")
                        configuration = node;

                if (configuration != null)
                {
                    //MessageBox.Show("configuration != null");  
                    // Get the ‘appSettings’ node  
                    XmlNode settingNode = null;
                    foreach (XmlNode node in configuration.ChildNodes)
                    {
                        if (node.Name == "appSettings")
                            settingNode = node;
                    }

                    if (settingNode != null)
                    {
                        //MessageBox.Show("settingNode != null");  
                        //Reassign values in the config file  
                        foreach (XmlNode node in settingNode.ChildNodes)
                        {
                            //MessageBox.Show("node.Value = " + node.Value);  
                            if (node.Attributes == null)
                                continue;
                            XmlAttribute attribute = node.Attributes["value"];
                            //MessageBox.Show("attribute != null ");  
                            //MessageBox.Show("node.Attributes['value'] = " + node.Attributes["value"].Value);  
                            if (node.Attributes["key"] != null)
                            {
                                //MessageBox.Show("node.Attributes['key'] != null ");  
                                //MessageBox.Show("node.Attributes['key'] = " + node.Attributes["key"].Value);  
                                switch (node.Attributes["key"].Value)
                                {
                                    case "diretorioReferencias":
                                        attribute.Value = diretorioReferencias;
                                        break;
                                    case "diretorioExportacao":
                                        attribute.Value = diretorioExportacao;
                                        break;
                                    case "defaultNameSpace":
                                        attribute.Value = defaultNameSpace;
                                        break;
                                        //-----
                                    case "diretorioTemplateWSDL_SN":
                                        attribute.Value = templatesPath + "TemplateWSDL_SN.wsdl";
                                        break;
                                    case "diretorioTemplateWSDL_SE":
                                        attribute.Value = templatesPath + "TemplateWSDL_SE.wsdl"; 
                                        break;
                                    case "diretorioTemplateRequest":
                                        attribute.Value = templatesPath + "TemplateRequest_SE.xsd"; 
                                        break;
                                    case "diretorioTemplateResponse":
                                        attribute.Value = templatesPath + "TemplateResponse_SE.xsd"; 
                                        break;
                                    case "diretorioTemplateRequestResponse":
                                        attribute.Value = templatesPath + "Template_SE.xsd"; 
                                        break;
                                }
                            }
                        }
                    }
                    doc.Save(appConfigPath);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

