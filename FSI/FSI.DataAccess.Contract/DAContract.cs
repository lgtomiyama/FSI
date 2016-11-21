using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System.IO;
using FSI.Model.ServiceIntegration.Enum;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using System;

namespace FSI.DataAccess.Contract
{
    public class DAContract : IContract
    {
        public void WriteServiceDescription(List<ContractServiceSctructure> structureList)
        {
            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            foreach (ContractServiceSctructure contract in structureList)
            {

                string fullPath = contract.Path + "\\" + contract.tamLevel + "-" + contract.name + "-";
                fullPath += contract.ServiceType == ServiceType.SN ? "EXP//" : "INT//";
                System.IO.Directory.CreateDirectory(fullPath + @"//types");
                StreamWriter WSDL = new StreamWriter(fullPath + contract.name + "V1.wsdl", false, utf8WithoutBom);
                contract.WSDL.Save(WSDL);
                WSDL.Close();
                foreach (var operation in contract.Operations)
                {
                    if (operation.XSDInOut != null)
                    {
                        StreamWriter XSDInOut = new StreamWriter(fullPath + @"//types//" + FirstUpper(operation.Name) + "V1.xsd", false, utf8WithoutBom);
                        operation.XSDInOut.Save(XSDInOut);
                        XSDInOut.Close();
                    }
                    else
                    {
                        StreamWriter XSDIn = new StreamWriter(fullPath + @"//types//" + FirstUpper(operation.Name) + "_RequestV1.xsd", false, utf8WithoutBom);
                        operation.XSDIn.Save(XSDIn);
                        XSDIn.Close();
                        StreamWriter XSDOut = new StreamWriter(fullPath + @"//types//" + FirstUpper(operation.Name) + "_ResponseV1.xsd", false, utf8WithoutBom);
                        operation.XSDOut.Save(XSDOut);
                        XSDOut.Close();

                    }
                }
            }

        }

        public List<MessageStructure> GetTreeReferences()
        {
            List<MessageStructure> main = new List<MessageStructure>(); 
            MessageStructure nodeCanonical = new MessageStructure("Canonical");
            DirSearch(ConfigurationManager.AppSettings["diretorioReferencias"] + @"\canonical", nodeCanonical);
            MessageStructure nodeCommon = new MessageStructure("Common");
            DirSearch(ConfigurationManager.AppSettings["diretorioReferencias"] + @"\common", nodeCommon);
            main.Add(nodeCanonical);
            main.Add(nodeCommon);
            return main;
        }
       
        public void DirSearch(string sDir, MessageStructure nd)
        {
           
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    MessageStructure nodeFolder = new MessageStructure(d.Replace(sDir, "").Replace("\\", ""));
                    nodeFolder.Reference.Path= d;
                    foreach (string f in Directory.GetFiles(d))
                    {
                        if (f.EndsWith(".xsd"))
                        {
                            MessageStructure nodeFile = new MessageStructure(f.Replace(d, "").Replace("\\", ""));
                            nodeFile.Reference.Path =  f.Replace("\\\\", "\\");
                            //refs.Add(f);
                            nodeFolder.Children.Add(nodeFile);
                            GetElements(nodeFile.Reference.Path, nodeFile);
                        }
                    }
                    nd.Children.Add(nodeFolder);
                    DirSearch(d, nodeFolder);
                }

            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }


        private void GetElements(string f, MessageStructure nodeFile)
        {
            XDocument xDoc = XDocument.Load(f);
            nodeFile.Reference.xml = xDoc.ToString();
            var ns = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema");

            

            foreach (XElement item in xDoc.Descendants(ns + "element"))
            {
                ReferenceElements nodeProp = new ReferenceElements(item.Attribute("name").Value);
                nodeProp.Xml = item.ToString();
                //nodeProp.ToolTipText = f;
                //nodeProp.Name = nodeFile.Reference.Replace(".xsd", "") + "." + item.Attribute("name").Value;
                nodeFile.Reference.Elements.Add(nodeProp);
            }
        }

        private string FirstUpper(string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToString();
        }

        public List<string> GetSequence(string xsdPath, string operationName)
        {
            XDocument xDoc = XDocument.Load(xsdPath);
            var namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("empty", @"http://www.w3.org/2001/XMLSchema");
            XElement aa = xDoc.XPathSelectElement("/empty:schema/empty:complexType[@name='" + FirstUpper(operationName) + "RequestType']/empty:sequence", namespaceManager);
            List<string> sequenceList = new List<string>();
            foreach (XElement item in aa.Descendants())
            {
                sequenceList.Add(item.Attribute("name").Value);
            }

            return sequenceList;

        }
    }
}
