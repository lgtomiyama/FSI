using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using FSI.Model.ServiceIntegration;
namespace FSI.Transformation
{
    public class RequestSOAP : IRequestData
    {
        public XmlDocument GetRequest(Operation operation, Service serviceMessage)
        {
            XmlDocument requestXML = new XmlDocument();

            StringBuilder sbRequestMessage = new StringBuilder();
            StringBuilder sbReferences = new StringBuilder();
            StringBuilder sbProperties = new StringBuilder();

            List<Reference> referenciasRequest = new List<Reference>();
            GetReferences(operation.RequestMessage.Structure, referenciasRequest);

            referenciasRequest = referenciasRequest.Where(x => (x.Path ?? string.Empty) != string.Empty).GroupBy(x => x.ObjName)
                                                 .Select(g => g.First())
                                                 .ToList();

            sbRequestMessage.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"");
            sbRequestMessage.AppendLine("xmlns:v1=\""+ ConfigurationManager.AppSettings["defaultNameSpace"]  +"Common/TEFHeader/v1\"");

            sbRequestMessage.AppendLine("		xmlns:Vop=\""+ ConfigurationManager.AppSettings["defaultNameSpace"] + "" + string.Join("/", serviceMessage.TAM) +"/"+ serviceMessage.Name +  "/v1\"");

            #region NameSpace     
            foreach (var reference in referenciasRequest)
            {
                sbRequestMessage.AppendLine("		xmlns:" + reference.Initial + "=\"" + reference.NameSpace + "\"");
            }
            sbRequestMessage.AppendLine(">");
            #endregion
            //Todo: Header

            sbRequestMessage.AppendLine("<Vop:" + operation.Name + "Request" + ">");

            WriteProperties(operation.RequestMessage.Structure, sbRequestMessage);

            sbRequestMessage.AppendLine("</Vop:" + operation.Name + "Request" + ">");

            sbRequestMessage.AppendLine("</soapenv:Envelope>");

            requestXML.LoadXml(sbRequestMessage.ToString());

            return requestXML;
        }

        public void OrganizeSequenceRequest(Operation operation, List<string> requestsList)
        {
            List<MessageStructure> Children = new List<MessageStructure>();
            foreach (string nameSequence in requestsList)
            {
                foreach (MessageStructure child in operation.RequestMessage.Structure.Children)
                {
                    if (child.PropName.ToUpper() == nameSequence.ToUpper())
                        Children.Add(child);
                }
            }
            operation.RequestMessage.Structure.Children = Children;
        }

        private void WriteProperties(MessageStructure structure, StringBuilder sbRequestMessage)
        {
            foreach (var child in structure.Children)
            {
                if (child.GenerateOnLoad)
                {
                    if (child.Children.Count > 0)
                    {
                        if (string.IsNullOrEmpty(child.Reference.Path))
                        {
                            sbRequestMessage.AppendLine("<Vop:" + FirstLower(child.PropName.Replace("[?]", "")) + ">");
                            WriteProperties(child, sbRequestMessage);
                            sbRequestMessage.AppendLine("</Vop:" + FirstLower(child.PropName.Replace("[?]", "")) + ">");
                        }
                        else
                        {
                            sbRequestMessage.AppendLine("<Vop:" + FirstLower( child.PropName.Replace("[?]", "")) + ">");
                            WriteProperties(child, sbRequestMessage);
                            sbRequestMessage.AppendLine("</Vop:" + FirstLower(child.PropName.Replace("[?]", "")) + ">");
                        }
                    }
                    else
                    {
                        sbRequestMessage.Append("<" + child.Parent.Reference.Initial + ":" + FirstLower(child.PropName.Replace("[?]", "")) + ">");
                        sbRequestMessage.Append(child.DefaultValue);
                        sbRequestMessage.Append("</" + child.Parent.Reference.Initial + ":" + FirstLower(child.PropName.Replace("[?]", "")) + ">");
                    }
                }
            }
        }


        private string FirstLower(string str)
        {
            return str[0].ToString().ToLower() + str.Substring(1).ToString();
        }
        private string FirstUpper(string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToString();
        }


        private void GetReferences(MessageStructure structure, List<Reference> references)
        {
            if (structure.Children != null)
            {
                foreach (MessageStructure child in structure.Children)
                {
                    references.Add(child.Reference);
                    GetReferences(child, references);
                }
            }
        }
    }
}
