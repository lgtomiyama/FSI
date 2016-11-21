using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FSI.Model.ServiceIntegration;
using System.IO;
using System.Configuration;
using FSI.Model.ServiceIntegration.Enum;

namespace FSI.Transformation.ContractModel
{
    public class ContractWSDL_Vivo1 : IContractData
    {
        IntegrationScope _IScope;
        List<ContractServiceSctructure> _CSList;
        bool _unionSchemaDefinitions;
        bool _uSE;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractWSDL_Vivo1"/> class.
        /// </summary>
        /// <param name="unionSchemaDefinitions">Defines if the xsds will be generated in the same document.</param>
        /// <param name="uSE">Defines if the wsdl will be generated in SE template.</param>
        public ContractWSDL_Vivo1(bool unionSchemaDefinitions, bool uSE)
        {
            _unionSchemaDefinitions = unionSchemaDefinitions;
            _uSE = uSE;
        }
        public List<ContractServiceSctructure> ToContracts(IntegrationScope IScope)
        {
            _IScope = IScope;
            _CSList = new List<ContractServiceSctructure>();

            foreach (var service in _IScope.Services)
            {
                ContractServiceSctructure cStructure = new ContractServiceSctructure();
                cStructure.WSDL = GenerateWSDL(service);
                cStructure.Path = ConfigurationManager.AppSettings["diretorioExportacao"] + "/" + string.Join("/", service.TAM) + "/";
                
                cStructure.name = service.Name;
                cStructure.tamLevel = service.TAMLevel;
                cStructure.ServiceType = _uSE ? ServiceType.SE : ServiceType.SN;
                foreach (var operation in service.Operations)
                {
                    cStructure.Operations.Add(GenerateDetachedXSD(operation, _unionSchemaDefinitions, service));
                }
                _CSList.Add(cStructure);
            }

            return _CSList;
        }

        private XmlDocument GenerateWSDL(Service service)
        {
            StringBuilder sbTemplate = CreateTemplate(service.Template);

            StringBuilder sbImports = new StringBuilder();
            StringBuilder sbMessages = new StringBuilder();
            StringBuilder sbOperations = new StringBuilder();
            StringBuilder sbBindingOperations = new StringBuilder();
            int tamSize = service.TAM.Length +  3;
            string referenc_NS = string.Concat(Enumerable.Repeat("../", tamSize));
            //Import das operações
            foreach (var operation in service.Operations)
            {
                if (_unionSchemaDefinitions)
                {
                    sbImports.AppendLine("		<xsd:import ");
                    sbImports.AppendLine("				namespace=\"" + _IScope.NormalPath + string.Join("/", service.TAM) + "/" + service.Name + "/v1/types\" ");
                    sbImports.AppendLine("				schemaLocation=\"types/" + FirstUpper(operation.Name) + ".xsd\"/>");
                }
                else
                {
                    sbImports.AppendLine("		<xsd:import ");
                    sbImports.AppendLine("				namespace=\"" + _IScope.NormalPath + string.Join("/", service.TAM) + "/" + service.Name + "/v1/types\" ");
                    sbImports.AppendLine("				schemaLocation=\"types/" + FirstUpper(operation.Name) + "_RequestV1.xsd\"/>");
                    sbImports.AppendLine("		");
                    sbImports.AppendLine("		<xsd:import ");
                    sbImports.AppendLine("				namespace=\"" + _IScope.NormalPath + string.Join("/", service.TAM) + "/" + service.Name + "/v1/types\" ");
                    sbImports.AppendLine("				schemaLocation=\"types/" + FirstUpper(operation.Name) + "_ResponseV1.xsd\"/>");
                    sbImports.AppendLine("		");
                }
                sbMessages.AppendLine("<wsdl:message name=\"" + FirstUpper(operation.Name) + "RequestMessage\">");
                sbMessages.AppendLine("	<wsdl:part element=\"types:" + FirstLower(operation.Name) + "Request\" name=\"body\"/>");
                //if(!_uSE)
                    sbMessages.AppendLine("	<wsdl:part element=\"tefh:tefHeader\" name=\"header\"/>");
                sbMessages.AppendLine("</wsdl:message>");
                sbMessages.AppendLine("");
                sbMessages.AppendLine("<wsdl:message name=\"" + FirstUpper(operation.Name) + "ResponseMessage\">");
                sbMessages.AppendLine("	<wsdl:part element=\"types:" + FirstLower(operation.Name) + "Response\" name=\"body\"/>");
                if (_uSE)
                    sbMessages.AppendLine("<wsdl:part element=\"tefh: tefHeader\" name=\"header\" />");
                sbMessages.AppendLine("</wsdl:message>");
                sbMessages.AppendLine("");

                sbOperations.AppendLine("		<wsdl:operation name=\"" + FirstLower(operation.Name) + "\">");
                sbOperations.AppendLine("			<wsdl:input message=\"tns:" + FirstUpper(operation.Name) + "RequestMessage\"/>");
                sbOperations.AppendLine("			<wsdl:output message=\"tns:" + FirstUpper(operation.Name) + "ResponseMessage\"/>");

                if (_uSE)
                {
                    sbOperations.AppendLine("<wsdl:fault name=\"customFault\" message=\"tns:CustomFaultMessage\" />");
                }
                else
                {
                    sbOperations.AppendLine("<wsdl:fault name=\"InputValidationFault\" message=\"tns:InputValidationFaultMessage\" />");
                    sbOperations.AppendLine("<wsdl:fault name=\"MandatoryParameterMissingFault\" message=\"tns:MandatoryParameterMissingFaultMessage\" />");
                    sbOperations.AppendLine("<wsdl:fault name=\"GeneralFault\" message=\"tns:GeneralFaultMessage\" />");
                }

                sbOperations.AppendLine("		</wsdl:operation>");

                sbBindingOperations.AppendLine("		<wsdl:operation name=\"" + FirstLower(operation.Name) + "\">");
                sbBindingOperations.AppendLine("			<soap11:operation soapAction=\"" + _IScope.NormalPath + string.Join("/", service.TAM) + "/" + service.Name + "/v1/" + FirstUpper(operation.Name) + "\"/>");
                sbBindingOperations.AppendLine("			");
                sbBindingOperations.AppendLine("			<wsdl:input>");
                //if (!_uSE)
                sbBindingOperations.AppendLine("				<soap11:header message=\"tns:" + FirstUpper(operation.Name) + "RequestMessage\" part=\"header\" use=\"literal\"/>");
                sbBindingOperations.AppendLine("				<soap11:body parts=\"body\" use=\"literal\"/>");
                sbBindingOperations.AppendLine("			</wsdl:input>");
                sbBindingOperations.AppendLine("			<wsdl:output>");
                if (!_uSE)
                {
                    sbBindingOperations.AppendLine("				<soap11:body use=\"literal\"/>");
                }
                else
                {
                    sbBindingOperations.AppendLine("				<soap11:header message=\"tns:" + FirstUpper(operation.Name) + "ResponseMessage\" part=\"header\" use=\"literal\"/>");
                    sbBindingOperations.AppendLine("				<soap11:body parts=\"body\" use=\"literal\"/>");
                }
                sbBindingOperations.AppendLine("			</wsdl:output>");

                if (_uSE)
                {
                    sbBindingOperations.AppendLine("			<wsdl:fault name=\"customFault\">");
                    sbBindingOperations.AppendLine("				<soap11:fault name=\"customFault\" use=\"literal\" />");
                    sbBindingOperations.AppendLine("			</wsdl:fault>");
                   
                }
                else
                {
                    sbBindingOperations.AppendLine("			<wsdl:fault name=\"InputValidationFault\">");
                    sbBindingOperations.AppendLine("				<soap11:fault name=\"InputValidationFault\" use=\"literal\" />");
                    sbBindingOperations.AppendLine("				</wsdl:fault>");
                    sbBindingOperations.AppendLine("				<wsdl:fault name=\"MandatoryParameterMissingFault\">");
                    sbBindingOperations.AppendLine("				<soap11:fault name=\"MandatoryParameterMissingFault\" use=\"literal\" />");
                    sbBindingOperations.AppendLine("				</wsdl:fault>");
                    sbBindingOperations.AppendLine("				<wsdl:fault name=\"GeneralFault\">");
                    sbBindingOperations.AppendLine("				<soap11:fault name=\"GeneralFault\" use=\"literal\" />");
                    sbBindingOperations.AppendLine("			</wsdl:fault>");
                }
                sbBindingOperations.AppendLine("		</wsdl:operation>");
            }
            //Messages
            sbTemplate.Replace("@@infoTAM@@", string.Join("/", service.TAM) + "/");
            sbTemplate.Replace("@@infoNome@@", service.Name);
            sbTemplate.Replace("@@Imports@@", sbImports.ToString());
            sbTemplate.Replace("@@Messages@@", sbMessages.ToString());
            sbTemplate.Replace("@@Operations@@", sbOperations.ToString());
            sbTemplate.Replace("@@BindingOperations@@", sbBindingOperations.ToString());
            sbTemplate.Replace("@@LevelFromRoot@@", referenc_NS);
            XmlDocument WSDL = new XmlDocument();
      
            WSDL.LoadXml(sbTemplate.ToString());

            return WSDL;
        }

        public IntegrationScope ToData(ContractServiceSctructure IScope)
        {
            throw new NotImplementedException();
        }

        public ContractServiceSctructure ToSingleContract(Service IScope)
        {
            throw new NotImplementedException();
        }
        private ContractOperationSctructure GenerateDetachedXSD(Operation operation, bool _unionSchemaDefinitions, Service service)
        {
            StringBuilder sbRequest = CreateTemplate(operation.RequestMessage.Template);
            StringBuilder sbResponse = CreateTemplate(operation.ResponseMessage.Template);

            StringBuilder sbNameSpaceRequest = new StringBuilder();
            StringBuilder sbNameSpaceResponse = new StringBuilder();

            StringBuilder sbImportsRequest = new StringBuilder();
            StringBuilder sbImportsResponse = new StringBuilder();

            StringBuilder sbPropertiesRequest = new StringBuilder();
            StringBuilder sbPropertiesResponse = new StringBuilder();

            StringBuilder sbListasRequest = new StringBuilder();
            StringBuilder sbListasResponse = new StringBuilder();

            List<StringBuilder> lSbComplexTypesRequest = new List<StringBuilder>();
            List<StringBuilder> lSbComplexTypesResponse = new List<StringBuilder>();
            StringBuilder sbComplexTypesRequest = new StringBuilder();
            StringBuilder sbComplexTypesResponse = new StringBuilder();
            #region PegarImports

            List<Reference> referenciasRequest = new List<Reference>();
            GetReferences(operation.RequestMessage.Structure, referenciasRequest);
            List<Reference> referenciasResponse = new List<Reference>();
            GetReferences(operation.ResponseMessage.Structure, referenciasResponse);

            List<MessageStructure> listaListasRequest = new List<MessageStructure>();
            GetLists(operation.RequestMessage.Structure, listaListasRequest);
            List<MessageStructure> listaListasResponse = new List<MessageStructure>();
            GetLists(operation.ResponseMessage.Structure, listaListasResponse);

            if (_unionSchemaDefinitions)
                referenciasRequest.AddRange(referenciasResponse);

            referenciasRequest = referenciasRequest.Where(x => (x.Path ?? string.Empty) != string.Empty).GroupBy(x => x.ObjName)
                                                             .Select(g => g.First())
                                                             .ToList();
            referenciasResponse = referenciasResponse.Where(x => (x.Path ?? string.Empty) != string.Empty).GroupBy(x => x.ObjName)
                                                             .Select(g => g.First())
                                                             .ToList();
            #endregion

            #region NameSpace     
            foreach (var reference in referenciasRequest)
            {
                sbNameSpaceRequest.AppendLine("		xmlns:" + reference.Initial + "=\"" + reference.NameSpace + "\"");
            }
            if (!_unionSchemaDefinitions)
            {
                foreach (var reference in referenciasResponse)
                {
                    sbNameSpaceResponse.AppendLine("		xmlns:" + reference.Initial + "=\"" + reference.NameSpace + "\"");
                }
            }
            #endregion

            #region Imports
           
            foreach (var reference in referenciasRequest)
            {
                string referencePath = reference.Path.Replace("\\", "/");
                referencePath = referencePath.FirstOrDefault().Equals("/")? referencePath.Substring(1, referencePath.Length - 1) : referencePath;
                string referenc_NS = string.Concat(Enumerable.Repeat("../", reference.LevelsFromRoot));
                sbImportsRequest.AppendLine("	<import");
                sbImportsRequest.AppendLine("		schemaLocation=\"" + (referenc_NS + referencePath).Replace("//", "/") + ".xsd\"");
                sbImportsRequest.AppendLine("		namespace=\"" + reference.NameSpace + "\"/>");
            }
            if (!_unionSchemaDefinitions)
            {
                foreach (var reference in referenciasResponse)
                {
                    string referencePath = reference.Path.Replace("\\", "/");
                    referencePath = referencePath.FirstOrDefault().Equals("/") ? referencePath.Substring(1, referencePath.Length - 1) : referencePath;
                    string referenc_NS = string.Concat(Enumerable.Repeat("../", reference.LevelsFromRoot));
                    sbImportsResponse.AppendLine("	<import");
                    sbImportsResponse.AppendLine("		schemaLocation=\"" + (referenc_NS + referencePath).Replace("//", "/") + ".xsd\"");
                    sbImportsResponse.AppendLine("		namespace=\"" + reference.NameSpace + "\"/>");
                }
            }
            #endregion

            #region propriedades
            GetProperties(sbPropertiesRequest, lSbComplexTypesRequest, operation.RequestMessage.Structure);
            GetProperties(sbPropertiesResponse, lSbComplexTypesResponse, operation.ResponseMessage.Structure);

            foreach (StringBuilder item in lSbComplexTypesRequest)
            {
                sbComplexTypesRequest.AppendLine(item.ToString());
            }

            foreach (StringBuilder item in lSbComplexTypesResponse)
            {
                sbComplexTypesResponse.AppendLine(item.ToString());
            }

            #endregion

            MontaListas(sbComplexTypesResponse, listaListasResponse);
            MontaListas(sbComplexTypesRequest, listaListasRequest);

            ContractOperationSctructure COS = new ContractOperationSctructure();
            COS.Name = operation.Name;
            if (_unionSchemaDefinitions)
            {
                sbNameSpaceRequest.AppendLine(sbNameSpaceResponse.ToString());
                sbImportsRequest.AppendLine(sbImportsResponse.ToString());
                //sbPropertiesRequest.AppendLine(sbPropertiesRequest.ToString());
                sbListasRequest.AppendLine(sbListasRequest.ToString());

                sbRequest.Replace("@@infoTAM@@", string.Join("/", service.TAM) + "/");
                sbRequest.Replace("@@infoNome@@", service.Name);
                sbRequest.Replace("@@MethodName@@", FirstUpper(operation.Name));
                sbRequest.Replace("@@MethodNameLower@@", FirstLower(operation.Name));
                sbRequest.Replace("@@NameSpaces@@", sbNameSpaceRequest.ToString());
                sbRequest.Replace("@@Imports@@", sbImportsRequest.ToString());
                sbRequest.Replace("@@MethodRequestProperties@@", sbPropertiesRequest.ToString());
                sbRequest.Replace("@@MethodResponseProperties@@", sbPropertiesRequest.ToString());
                sbRequest.Replace("@@Entities@@", sbListasRequest.ToString());
                sbRequest.Replace("@@ComplexTypes@@", sbComplexTypesRequest.ToString());
                XmlDocument inout = new XmlDocument();
                inout.LoadXml(sbRequest.ToString());
                COS.XSDInOut = inout;

            }
            else
            {
                sbRequest.Replace("@@infoTAM@@", string.Join("/", service.TAM) + "/");
                sbRequest.Replace("@@infoNome@@", service.Name);
                sbRequest.Replace("@@MethodName@@", FirstUpper(operation.Name));
                sbRequest.Replace("@@MethodNameLower@@", FirstLower(operation.Name));
                sbRequest.Replace("@@NameSpaces@@", sbNameSpaceRequest.ToString());
                sbRequest.Replace("@@Imports@@", sbImportsRequest.ToString());
                sbRequest.Replace("@@MethodProperties@@", sbPropertiesRequest.ToString());
                sbRequest.Replace("@@Entities@@", sbListasRequest.ToString());
                sbRequest.Replace("@@ComplexTypes@@", sbComplexTypesRequest.ToString());

                sbResponse.Replace("@@infoTAM@@", string.Join("/", service.TAM) + "/");
                sbResponse.Replace("@@infoNome@@", service.Name);
                sbResponse.Replace("@@MethodName@@", FirstUpper(operation.Name));
                sbResponse.Replace("@@MethodNameLower@@", FirstLower(operation.Name));
                sbResponse.Replace("@@NameSpaces@@", sbNameSpaceResponse.ToString());
                sbResponse.Replace("@@Imports@@", sbImportsResponse.ToString());
                sbResponse.Replace("@@MethodProperties@@", sbPropertiesResponse.ToString());
                sbResponse.Replace("@@Entities@@", sbListasResponse.ToString());
                sbResponse.Replace("@@ComplexTypes@@", sbComplexTypesResponse.ToString());

                XmlDocument xIn = new XmlDocument();
                
                xIn.LoadXml(sbRequest.ToString());
                COS.XSDIn = xIn;

                XmlDocument xOut = new XmlDocument();
                xOut.LoadXml(sbResponse.ToString());
                COS.XSDOut = xOut;
            }
            COS.Name = operation.Name;
            COS.Path = ConfigurationManager.AppSettings["diretorioExportacao"] + "/" + string.Join("/", service.TAM) + "/" + @"\\types\\";
            return COS;
        }

        private void GetProperties(StringBuilder sbProperties, List<StringBuilder> lSbComplexTypes, MessageStructure structure)
        {
            foreach (var child in structure.Children)
            {

                if (child.Required)
                {
                    sbProperties.AppendLine("		<element name=\"" + FirstLower(child.PropName) + "\" type=\"" + child.Reference.Initial + ":" + child.Reference.ObjName + "\" minOccurs=\"1\" maxOccurs=\"1\" />");
                }
                else
                {
                    sbProperties.AppendLine("		<element name=\"" + FirstLower(child.PropName) + "\" type=\"" + child.Reference.Initial + ":" + child.Reference.ObjName + "\" minOccurs=\"0\" maxOccurs=\"1\" />");
                }
                
                if (child.Children.Count > 0 && string.IsNullOrEmpty(child.Reference.Path))
                {
                    GetComplex(child, lSbComplexTypes);
                }
            }
        }

        private void GetComplex(MessageStructure child, List<StringBuilder> lSbComplexTypes)
        {
            StringBuilder sbComplexTypes = new StringBuilder();
            if (child.Children.FirstOrDefault().Reference != null && child.Children.FirstOrDefault().Reference.List)
                sbComplexTypes.AppendLine("	<complexType name=\"" + child.Children.FirstOrDefault().Reference.ObjName + "\">");
            else
                sbComplexTypes.AppendLine("	<complexType name=\"" + child.Reference.ObjName + "\">");
            sbComplexTypes.AppendLine("		<sequence>");
            StringBuilder sbPropChildComplex = new StringBuilder();
            GetProperties(sbPropChildComplex, lSbComplexTypes, child);
            sbComplexTypes.AppendLine(sbPropChildComplex.ToString());
            sbComplexTypes.AppendLine("		</sequence>");
            sbComplexTypes.AppendLine("	</complexType>	");

            if (!child.Children.FirstOrDefault().PropName.Contains("[?]"))
            {

                lSbComplexTypes.Add(sbComplexTypes);
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

        private StringBuilder CreateTemplate(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(path))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            return sb;
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
        private void GetLists(MessageStructure structure, List<MessageStructure> listaListasRequest)
        {

            if (structure.Children != null)
            {
                foreach (MessageStructure child in structure.Children)
                {
                    if (child.Reference.List)
                    {
                        listaListasRequest.Add(child);
                    }
                    GetLists(child, listaListasRequest);
                }
            }
        }
        private void MontaListas(StringBuilder ssb, List<MessageStructure> listaListas)
        {
            foreach (var Lista in listaListas)
            {

                ssb.AppendLine("	<complexType name=\"" + Lista.Parent.Reference.ObjName + "\">");
                ssb.AppendLine("		<sequence>");
                ssb.AppendLine("			<element name=\"" + Lista.PropName.Replace("[?]", "") + "\" type=\"" + Lista.Parent.Reference.Initial + ":" + Lista.Reference.ObjName.Replace("[?]", "") + "\" minOccurs=\"0\" maxOccurs=\"unbounded\"/>");
                ssb.AppendLine("		</sequence>");
                ssb.AppendLine("	</complexType>");
            }

        }

    }
}
