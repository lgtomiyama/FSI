using System.Linq;
using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System;
using FSI.Model.ServiceIntegration.Enum;
using System.IO;
using System.Data;
using System.Configuration;
using System.Xml.Linq;
using System.Xml;

namespace FSI.Transformation.ExcelModel
{

    public class ExcelSampleInfo_v0 : IIntegrationData
    {
        private int colunaPropertyInput = 0;
        private int colunaTypeInput = 2;
        private int colunaTypeOutput = 8;
        private int colunaRequiredInput = 1;
        private int colunaRequiredOutPut = 7;
        private int colunaPropertyOutput = 6;
        private int linhaProperty = 2;
        private int colunaAlternativeNameInput = 4;
        private int colunaAlternativeNameOutPut = 10;

        private string diretorioReferencias;
        int nsCounter = 0;

        List<Reference> referenceList = new List<Reference>();
        int errorImport = 0;
        List<string> errorReference = new List<string>();
        public ExcelSampleInfo_v0()
        {
            nsCounter = 0;
            diretorioReferencias = ConfigurationManager.AppSettings["diretorioReferencias"];
        }
        public List<IntegrationScope> ToModel(DataSet wb)
        {
            List<IntegrationScope> LiScope = new List<IntegrationScope>();
            IntegrationScope iScope = new IntegrationScope();
             
            GetIntegrationScopeInfo(iScope, wb);
            iScope.Services.Add(GetService(wb));
            iScope.errorQt = errorImport;
            iScope.propErrorList = errorReference;
            LiScope.Add(iScope);
            return LiScope;
        }
        private Service GetService(DataSet ds)
        {
            try
            {
                Service svc = new Service()
                {
                    Name = ds.Tables["WSDL$"].Rows[1].ItemArray[1].ToString(),
                    TAM = ds.Tables["WSDL$"].Rows[0].ItemArray[1].ToString().Split('/'),
                    TAMLevel = ds.Tables["WSDL$"].Rows[0].ItemArray[2].ToString()
                };

                if (string.IsNullOrEmpty(svc.TAM[svc.TAM.Length -1]))
                    svc.TAM = svc.TAM.Take(svc.TAM.Length - 1).ToArray();

                svc.Operations = GetOperations(ds, svc.TAM);
                return svc;
            }
            catch
            {
                throw new Exception("Erro ao ler o serviço da planilha, o arquivo pode estar fora dos padrões de layout, corrompido ou incompleto. \n \nFSI.Transformation.ExcelModel.ExcelSampleInfo_v0.GetService");
            }
        }
        private List<Operation> GetOperations(DataSet ds, string[] tam)
        {
            try
            {
                List<Operation> Operations = new List<Operation>();
                int opCount = 2;
                foreach (DataTable dt in ds.Tables)
                {
                    if (!dt.TableName.Contains("WSDL$") && !dt.TableName.Contains("'"))
                    {
                        Operation op = new Operation();
                        string opName = string.Empty;
                        //op.Name = ds.Tables["WSDL$"].Rows[opCount].ItemArray[1].ToString();
                        foreach (DataRow item in ds.Tables["WSDL$"].Rows)
                        {
                            if (item.ItemArray[0].ToString() != "TAM" &&
                                item.ItemArray[0].ToString() != "Nome" &&
                                item.ItemArray[1].ToString().ToUpper().StartsWith(dt.TableName.Replace("$", "").ToUpper()))
                            {
                                op.Name = item.ItemArray[1].ToString();
                            }
                        }

                        op.RequestMessage = GetOperation(dt, MessageDirection.Request, tam);
                        op.RequestMessage.References = referenceList;
                        op.ResponseMessage = GetOperation(dt, MessageDirection.Response, tam);
                        op.ResponseMessage.References = referenceList;
                        Operations.Add(op);
                        opCount++;
                    }

                }
                return Operations;
            }
            catch
            {
                throw new Exception("Erro ao ler as operações da planilha, o arquivo pode estar fora dos padrões de layout, corrompido ou incompleto. \n \nFSI.Transformation.ExcelModel.ExcelSampleInfo_v0.GetOperations");
            }
        }
        private void GetIntegrationScopeInfo(IntegrationScope iScope, DataSet ds)
        {
            iScope.Name = "SE";
            iScope.NormalPath = ConfigurationManager.AppSettings["defaultNameSpace"];
        }
        private Message GetOperation(DataTable dt, MessageDirection direction, string[] tam)
        {
            Message operationMessage = new Message();
            operationMessage.Direction = direction;
            operationMessage.Structure = new MessageStructure()
            {
                PropName = "Contrato"
            };
            int countObject = 0;
            //nsCounter = 0;
            referenceList = new List<Reference>();
            foreach (DataRow row in dt.Rows)
            {

                if (linhaProperty <= countObject)
                {
                    string infoProperty = row[direction == MessageDirection.Request ? colunaPropertyInput : colunaPropertyOutput].ToString();
                    string infoType = row[direction == MessageDirection.Request ? colunaTypeInput : colunaTypeOutput].ToString();
                    string requiredType = row[direction == MessageDirection.Request ? colunaRequiredInput : colunaRequiredOutPut].ToString();
                    string alternativeName = row[direction == MessageDirection.Request ? colunaAlternativeNameInput : colunaAlternativeNameOutPut].ToString();
                    if (!string.IsNullOrEmpty(infoProperty))
                    {
                        try
                        {

                            AddOnStructureTree(operationMessage.Structure, infoProperty, infoType, requiredType, direction, alternativeName, tam);
                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Erro na tentativa do import de: " + infoProperty + "\n" + ex.Message);

                        }
                    }
                }
                countObject++;
            }
            return operationMessage;
        }

        private void AddOnStructureTree(MessageStructure structure, string infoProperty, string infoType, string requiredType, MessageDirection direction, string alternativeName, string[] tam)
        {

            var arraySplit = infoProperty.Split('.');
            for (int i = 0; i < arraySplit.Count(); i++)
            {
                //Modificado para solucionar problemas relacionados aos "alias" dados a propriedades recorrentes
                //MessageStructure no = SearchNode(structure, arraySplit[i]);
                MessageStructure no = SearchNode(structure, arraySplit[i], !string.IsNullOrEmpty(alternativeName) && i + 2 == arraySplit.Count()? alternativeName : "");

                if (no != null)
                {
                    if (!string.IsNullOrEmpty(alternativeName) && i+2 == arraySplit.Count())
                        no.PropName = alternativeName;
                    structure = no;
                }
                else
                {
                    string tipo = "";
                    if (arraySplit[i].Contains("[?]"))
                    {
                        tipo = "Lista";
                    }
                    else if (i == arraySplit.Count() - 1)
                    {
                        tipo = infoType;
                    }
                    else
                    {
                        tipo = "Complex";
                    }
                    MessageStructure novo = new MessageStructure()
                    {
                        //PropName = !string.IsNullOrEmpty(alternativeName) && arraySplit.Count() != i-1 ? alternativeName : arraySplit[i].Trim(),
                        PropName = string.IsNullOrEmpty(alternativeName) ? arraySplit[i].Trim() : alternativeName,
                        Required = requiredType == "R" ? true : false,
                        Parent = structure,
                        Reference = new Reference(arraySplit[i][0].ToString().ToUpper().Trim() + arraySplit[i].Substring(1).ToString().Trim().Replace("[?]", ""))
                        {
                            Initial = "tns",

                            LevelsFromRoot = 0
                    
                        }

                    };
                    if (novo.Required)
                    {
                        novo.Parent.Required = true;
                    }
                    if (i == arraySplit.Length - 2)
                    {
                        var fileList = new DirectoryInfo(diretorioReferencias + @"\\canonical").GetFiles(arraySplit[i].Trim() + ".xsd", SearchOption.AllDirectories).ToList();
                        fileList.AddRange(new DirectoryInfo(diretorioReferencias + @"\\common").GetFiles(arraySplit[i].Trim() + ".xsd", SearchOption.AllDirectories).ToList());
                        if (fileList.Count() > 0)
                        {
                            var finalString = fileList[0].FullName.Replace(diretorioReferencias, "").Split('\\');
                            novo.Reference.Path = fileList[0].FullName.Replace(diretorioReferencias, "").Replace(".xsd", "");

                            XElement elemet = XElement.Load(fileList[0].FullName);
                            elemet.DescendantNodes().Where(x => x.NodeType == XmlNodeType.Comment).Remove();
                            string elementNamespace = elemet.Attribute("targetNamespace").Value;
                            novo.Reference.NameSpace = elementNamespace;
                            foreach (var item in elemet.Nodes())
                            {

                                if (((XElement)item).Name.ToString().Contains("complexType"))
                                {
                                    novo.Reference.ObjName = ((XElement)item).Attribute("name").Value;
                                }


                            }

                            novo.Reference.LevelsFromRoot = 4 + tam.Length;

                            novo.Reference.Initial = "ns" + nsCounter++;
                        }
                        else
                        {
                            novo.Reference.Path = "_erro" + errorImport++;
                            novo.Reference.NameSpace = "_erro" + errorImport++;
                            novo.Reference.LevelsFromRoot = 1;
                            novo.Reference.Initial = "_erro" + errorImport++;
                            errorReference.Add("Erro de importação em: " + arraySplit[i] + "\n");
                        }
                        Reference chkRef = ChecReferences(novo.Reference);
                        if (chkRef != null)
                        {
                            novo.Reference = chkRef;
                        }
                        else
                        {
                            referenceList.Add(novo.Reference);
                        }
                    }
                    structure.Children.Add(novo);
                    if (tipo == "Lista")
                    {
                        novo.Reference.List = true;
                    }

                    novo.Reference.Type = tipo;
                    novo.DefaultValue = GetTypeDefaultValue(tipo);
                    novo.GenerateOnLoad = true;
                    structure = novo;
                }
            }
        }
        private string GetTypeDefaultValue(string type)
        {
            switch (type)
            {
                case "String":
                    return "lero lero";
                case "Int":
                    return "123";
                case "Integer":
                    return "123";
                case "Double":  
                    return "123.6";

                default:
                    return "";
            }
        }
        private Reference ChecReferences(Reference reference)
        {
            foreach (var refers in referenceList)
            {
                if (refers.ObjName == reference.ObjName)
                    return refers;
            }
            return null;
        }

        private MessageStructure SearchNode(MessageStructure structure, string node, string alternativeName)
        {
            MessageStructure ss = structure;
            //Modificado para solucionar problemas relacionados aos "alias" dados a propriedades recorrentes
            if (alternativeName != "")
            {
                node = alternativeName;
            }
                ss = (from fi in structure.Children where fi.PropName == node select fi).FirstOrDefault();
                if (ss != null && structure.Children.Count() > 0 && ss.PropName != node)
                {
                    return SearchNode(ss, node, alternativeName);
                }
                else if (ss == null)
                {
                        return ss;
                }
            
            return ss;
        }
        public DataSet ToData(List<IntegrationScope> integrationScope)
        {
            throw new NotImplementedException();
        }
    }
}
