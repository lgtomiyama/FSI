using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Runtime.InteropServices;

namespace GERDOR_WSDL
{
    //Criardor: Lucas Garcia Tomiyama
    public class ContractGenerator
    {
        private int colunaPropertyInput = 1;
        private int colunaTypeInput = 3;
        private int colunaTypeOutput = 9;
        private int colunaRequiredInput = 2;
        private int colunaRequiredOutPut = 8;
        private int colunaPropertyOutput = 7;
        private int linhaPropertyInput = 3;
        private int linhaPropertyOutput = 3;
        private int colunaAlternativeNameInput = 5;
        private int colunaAlternativeNameOutPut = 11;

        List<EstruturaReferencia> listaListasRequest;
        List<EstruturaReferencia> listaListasResponse;
        List<EstruturaReferencia> referenciasRequest;
        List<EstruturaReferencia> referenciasResponse;
        private string diretorioReferencias;
        private string diretorioExportacao;
        private string diretorioTemplateWSDL;
        private string diretorioTemplateRequest;
        private string diretorioTemplateResponse;
        int nsCounter = 0;
        public ContractGenerator()
        {
            nsCounter = 0;
            diretorioReferencias = ConfigurationManager.AppSettings["diretorioReferencias"];
            diretorioTemplateWSDL = ConfigurationManager.AppSettings["diretorioTemplateWSDL"];
            diretorioTemplateRequest = ConfigurationManager.AppSettings["diretorioTemplateRequest"];
            diretorioTemplateResponse = ConfigurationManager.AppSettings["diretorioTemplateResponse"];
            diretorioExportacao = ConfigurationManager.AppSettings["diretorioExportacao"];
        }
        #region WSDL
        public void GerarWSDL(string path)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            try
            {

                Worksheet wsWSDL = wb.Sheets[1];
                String infoTAM = wsWSDL.Cells[1, 2].Value;
                string infoNome = wsWSDL.Cells[2, 2].Value;

                StringBuilder sbTemplate = CreateTemplate(diretorioTemplateWSDL);

                StringBuilder sbImports = new StringBuilder();
                StringBuilder sbMessages = new StringBuilder();
                StringBuilder sbOperations = new StringBuilder();
                StringBuilder sbBindingOperations = new StringBuilder();

                #region ImportsOperações
                bool hasOperation = true;
                int countOperation = 0;     
                while (hasOperation)
                {
                    string infoOperation = wsWSDL.Cells[3 + countOperation, 2].Value;
                    if (!string.IsNullOrEmpty(infoOperation))
                    {
                        sbImports.AppendLine("		<xsd:import ");
                        sbImports.AppendLine("				namespace=\"http://telefonica.br/" + infoTAM + infoNome + "/v1\" ");
                        sbImports.AppendLine("				schemaLocation=\"types/" + infoOperation + "_RequestV1.xsd\"/>");
                        sbImports.AppendLine("		");
                        sbImports.AppendLine("		<xsd:import ");
                        sbImports.AppendLine("				namespace=\"http://telefonica.br/" + infoTAM + infoNome + "/v1\" ");
                        sbImports.AppendLine("				schemaLocation=\"types/" + infoOperation + "_ResponseV1.xsd\"/>");
                        sbImports.AppendLine("		");
                    }
                    else
                        hasOperation = false;
                    countOperation++;
                }

                #endregion
                #region Messages


                hasOperation = true;
                countOperation = 0;
                while (hasOperation)
                {
                    string infoOperation = wsWSDL.Cells[3 + countOperation, 2].Value;
                    if (!string.IsNullOrEmpty(infoOperation))
                    {
                        sbMessages.AppendLine("<wsdl:message name=\"" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "RequestMessage\">");
                        sbMessages.AppendLine("	<wsdl:part element=\"types:" + infoOperation + "Request\" name=\"body\"/>");
                        sbMessages.AppendLine("	<wsdl:part element=\"tefh:tefHeader\" name=\"header\"/>");
                        sbMessages.AppendLine("</wsdl:message>");
                        sbMessages.AppendLine("");
                        sbMessages.AppendLine("<wsdl:message name=\"" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "ResponseMessage\">");
                        sbMessages.AppendLine("	<wsdl:part element=\"types:" + infoOperation + "Response\" name=\"body\"/>");
                        sbMessages.AppendLine("</wsdl:message>");
                        sbMessages.AppendLine("");
                    }
                    else
                        hasOperation = false;
                    countOperation++;
                }
                #endregion
                #region Operations
                hasOperation = true;
                countOperation = 0;
                
                
                while (hasOperation)
                {
                    string infoOperation = wsWSDL.Cells[3 + countOperation, 2].Value;
                    if (!string.IsNullOrEmpty(infoOperation))
                    {
                        sbOperations.AppendLine("		<wsdl:operation name=\"" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "\">");
                        sbOperations.AppendLine("			<wsdl:input message=\"tns:" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "RequestMessage\"/>");
                        sbOperations.AppendLine("			<wsdl:output message=\"tns:" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "ResponseMessage\"/>");
                      



                        sbOperations.AppendLine("<wsdl:fault name=\"InputValidationFault\" message=\"tns:InputValidationFaultMessage\" />");
                        sbOperations.AppendLine("<wsdl:fault name=\"MandatoryParameterMissingFault\" message=\"tns:MandatoryParameterMissingFaultMessage\" />");
                        sbOperations.AppendLine("<wsdl:fault name=\"GeneralFault\" message=\"tns:GeneralFaultMessage\" />");




                        sbOperations.AppendLine("		</wsdl:operation>");
                    }
                    else
                        hasOperation = false;
                    countOperation++;
                }

                #endregion
                #region Binding
                hasOperation = true;
                countOperation = 0;
                while (hasOperation)
                {
                    string infoOperation = wsWSDL.Cells[3 + countOperation, 2].Value;
                    if (!string.IsNullOrEmpty(infoOperation))
                    {
                        sbBindingOperations.AppendLine("		<wsdl:operation name=\"" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "\">");
                        sbBindingOperations.AppendLine("			<soap11:operation soapAction=\"http://telefonica.br/" + infoTAM + infoNome + "/v1/" + infoOperation[0].ToString().ToUpper() + infoOperation.Substring(1).ToString() + "\"/>");
                        sbBindingOperations.AppendLine("			");
                        sbBindingOperations.AppendLine("			<wsdl:input>");
                        sbBindingOperations.AppendLine("				<soap11:header message=\"tns:" + infoOperation[0].ToString().ToLower() + infoOperation.Substring(1).ToString() + "RequestMessage\" part=\"header\" use=\"literal\"/>");
                        sbBindingOperations.AppendLine("				<soap11:body parts=\"body\" use=\"literal\"/>");
                        sbBindingOperations.AppendLine("			</wsdl:input>");
                        sbBindingOperations.AppendLine("			<wsdl:output>");
                        sbBindingOperations.AppendLine("				<soap11:body use=\"literal\"/>");
                        sbBindingOperations.AppendLine("			</wsdl:output>");
                        sbBindingOperations.AppendLine("			<wsdl:fault name=\"InputValidationFault\">");
                        sbBindingOperations.AppendLine("				<soap11:fault name=\"InputValidationFault\" use=\"literal\" />");
                        sbBindingOperations.AppendLine("				</wsdl:fault>");
                        sbBindingOperations.AppendLine("				<wsdl:fault name=\"MandatoryParameterMissingFault\">");
                        sbBindingOperations.AppendLine("				<soap11:fault name=\"MandatoryParameterMissingFault\" use=\"literal\" />");
                        sbBindingOperations.AppendLine("				</wsdl:fault>");
                        sbBindingOperations.AppendLine("				<wsdl:fault name=\"GeneralFault\">");
                        sbBindingOperations.AppendLine("				<soap11:fault name=\"GeneralFault\" use=\"literal\" />");
                        sbBindingOperations.AppendLine("				</wsdl:fault>");
                        //sbBindingOperations.AppendLine("			<wsdl:fault name=\"customFault\">");
                        //sbBindingOperations.AppendLine("				<soap11:fault name=\"customFault\" use=\"literal\"/>");
                        //sbBindingOperations.AppendLine("			</wsdl:fault>");
                        sbBindingOperations.AppendLine("		</wsdl:operation>");
                    }
                    else
                        hasOperation = false;
                    countOperation++;
                }

                #endregion

                sbTemplate.Replace("@@infoTAM@@", infoTAM);
                sbTemplate.Replace("@@infoNome@@", infoNome);
                sbTemplate.Replace("@@Imports@@", sbImports.ToString());
                sbTemplate.Replace("@@Messages@@", sbMessages.ToString());
                sbTemplate.Replace("@@Operations@@", sbOperations.ToString());
                sbTemplate.Replace("@@BindingOperations@@", sbBindingOperations.ToString());

                Directory.CreateDirectory(diretorioExportacao + "/" + infoTAM + infoNome);
                StreamWriter file = new System.IO.StreamWriter(diretorioExportacao + "/" + infoTAM + infoNome + "/" + infoNome + "V1.wsdl");
                file.WriteLine(sbTemplate.ToString());
                file.Close();
            }
            //catch (Exception a)
            //{
            //
            //    throw a;
            //}
            finally
            {
                // Marshal.ReleaseComObject(excel);
                excel.Workbooks.Close();
            }

        }
        #endregion
        public void GerarXsd(string path)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            try
            {
                Worksheet wsWSDL = wb.Sheets[1];
                string infoTAM = wsWSDL.Cells[1, 2].Value;
                string infoNome = wsWSDL.Cells[2, 2].Value;
                //bool fimAbas = false;
                int abaInicio = 2;
                for (int i = abaInicio; i <= wb.Sheets.Count; i++)
                {
                    Worksheet aba = wb.Sheets[i];
                    ContractGenerator CG = new ContractGenerator();
                    CG.MontaXSD_request(aba, infoTAM, infoNome);
                }
            }
            //catch (Exception a)
            //{
            //
            //    throw a;
            //}
            finally
            {
                excel.Workbooks.Close();
            }

        }
        private void MontaXSD_request(Worksheet aba, string infoTAM, string infoNome)
        {

            listaListasRequest = new List<EstruturaReferencia>();
            listaListasResponse = new List<EstruturaReferencia>();
            referenciasRequest = new List<EstruturaReferencia>();
            referenciasResponse = new List<EstruturaReferencia>();

            EstruturaReferencia estruturaRequest = MontaArvoreOBJ(aba, Sentido.Request);
            EstruturaReferencia estruturaResponse = MontaArvoreOBJ(aba, Sentido.Response);
            string operacao = aba.Name;

            StringBuilder sbRequest = CreateTemplate(diretorioTemplateRequest);
            StringBuilder sbResponse = CreateTemplate(diretorioTemplateResponse);

            StringBuilder sbNameSpaceRequest = new StringBuilder();
            StringBuilder sbNameSpaceResponse = new StringBuilder();

            StringBuilder sbImportsRequest = new StringBuilder();
            StringBuilder sbImportsResponse = new StringBuilder();

            StringBuilder sbPropertiesRequest = new StringBuilder();
            StringBuilder sbPropertiesResponse = new StringBuilder();

            StringBuilder sbListasRequest = new StringBuilder();
            StringBuilder sbListasResponse = new StringBuilder();
            #region PegarImports

            referenciasRequest = referenciasRequest.ToList().GroupBy(x => x.NomeObj + x.NomeProp).Select(y => y.First()).ToList();
            referenciasResponse = referenciasResponse.ToList().GroupBy(x => x.NomeObj + x.NomeProp).Select(y => y.First()).ToList();
            #endregion

            #region NameSpace           

            foreach (var item in referenciasRequest)
            {
                sbNameSpaceRequest.AppendLine("		xmlns:" + item.Sigla + "=\"http://telefonica.br" + item.Diretorio.Replace("\\", "/").Replace("canonical/", "") + "/v1\"");
            }
            foreach (var item in referenciasResponse)
            {
                sbNameSpaceResponse.AppendLine("		xmlns:" + item.Sigla + "=\"http://telefonica.br" + item.Diretorio.Replace("\\", "/").Replace("canonical/", "") + "/v1\"");
            }
            #endregion

            #region Imports
            foreach (var item in referenciasRequest)
            {
                sbImportsRequest.AppendLine("	<import");
                sbImportsRequest.AppendLine("		schemaLocation=\"../../../../../.." + item.Diretorio.Replace("\\", "/") + ".xsd\"");
                sbImportsRequest.AppendLine("		namespace=\"http://telefonica.br" + item.Diretorio.Replace("\\", "/").Replace("canonical/", "") + "/v1\"/>");
            }
            foreach (var item in referenciasResponse)
            {
                sbImportsResponse.AppendLine("	<import");
                sbImportsResponse.AppendLine("		schemaLocation=\"../../../../../.." + item.Diretorio.Replace("\\", "/") + ".xsd\"");
                sbImportsResponse.AppendLine("		namespace=\"http://telefonica.br" + item.Diretorio.Replace("\\", "/").Replace("canonical/", "") + "/v1\"/>");
            }
            #endregion

            MontaPropriedades(estruturaRequest, sbPropertiesRequest);
            MontaPropriedades(estruturaResponse, sbPropertiesResponse);

            MontaListas(listaListasRequest, sbListasRequest);
            MontaListas(listaListasResponse, sbListasResponse);

            sbRequest.Replace("@@infoTAM@@", infoTAM);
            sbRequest.Replace("@@infoNome@@", infoNome);
            sbRequest.Replace("@@MethodName@@", operacao[0].ToString().ToLower() + operacao.Substring(1).ToString() );
            sbRequest.Replace("@@NameSpaces@@", sbNameSpaceRequest.ToString());
            sbRequest.Replace("@@Imports@@", sbImportsRequest.ToString());
            sbRequest.Replace("@@MethodProperties@@", sbPropertiesRequest.ToString());
            sbRequest.Replace("@@Entities@@", sbListasRequest.ToString());

            sbResponse.Replace("@@infoTAM@@", infoTAM);
            sbResponse.Replace("@@infoNome@@", infoNome);
            sbResponse.Replace("@@MethodName@@", operacao[0].ToString().ToLower() + operacao.Substring(1).ToString());
            sbResponse.Replace("@@NameSpaces@@", sbNameSpaceResponse.ToString());
            sbResponse.Replace("@@Imports@@", sbImportsResponse.ToString());
            sbResponse.Replace("@@MethodProperties@@", sbPropertiesResponse.ToString());
            sbResponse.Replace("@@Entities@@", sbListasResponse.ToString());
            Directory.CreateDirectory(diretorioExportacao + "/" + infoTAM + infoNome + "/types");
            System.IO.StreamWriter fileRequest = new System.IO.StreamWriter(diretorioExportacao + "/" + infoTAM + infoNome +"/types/" + operacao[0].ToString().ToUpper() + operacao.Substring(1).ToString() + "_RequestV1.xsd");
            fileRequest.WriteLine(sbRequest.ToString());
            fileRequest.Close();

            System.IO.StreamWriter fileResponse = new System.IO.StreamWriter(diretorioExportacao + "/" + infoTAM + infoNome + "/types/" + operacao[0].ToString().ToUpper() + operacao.Substring(1).ToString() + "_ResponseV1.xsd");
            fileResponse.WriteLine(sbResponse.ToString());
            fileResponse.Close();
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
        #region XML 
        private void MontaPropriedades(EstruturaReferencia estruturaRequest, StringBuilder ssb)
        {
            foreach (var filhos in estruturaRequest.Filhos)
            {
                ssb.AppendLine("		<element name=\"" + filhos.NomeProp[0].ToString().ToLower() + filhos.NomeProp.Substring(1).ToString() + "\" type=\"" + filhos.Sigla + ":" + filhos.NomeObj + "\" />");
            }
        }
        private void MontaListas(List<EstruturaReferencia> listaListas, StringBuilder ssb)
        {
            foreach (var Lista in listaListas)
            {
                ssb.AppendLine("	<complexType name=\"" + Lista.NomeObj.Replace("[?]", "") + "\">");
                ssb.AppendLine("		<sequence>");
                foreach (var propLista in Lista.Filhos)
                {
                    if (propLista.NomeProp.Contains("[?]"))
                    {
                        ssb.AppendLine("			<element name=\"" +propLista.NomeProp[0].ToString().ToLower() + propLista.NomeProp.Substring(1).ToString() + "\" type=\"" + propLista.Sigla + ":" + Lista.NomeObj + "\" minOccurs=\"0\" maxOccurs=\"unbounded\"/>");
                    }
                    else
                    {
                        ssb.AppendLine("			<element name=\"" + propLista.NomeProp[0].ToString().ToLower() + propLista.NomeProp.Substring(1).ToString()  + "\" type=\"" + propLista.Sigla + ":" + propLista.NomeObj + "\"/>");
                    }

                }

                ssb.AppendLine("		</sequence>");
                ssb.AppendLine("	</complexType>	");

                ssb.AppendLine("	<complexType name=\"" + Lista.Pai.NomeObj + "\">");
                ssb.AppendLine("		<sequence>");
                ssb.AppendLine("			<element name=\"" + Lista.Pai.NomeProp + "\" type=\"" + Lista.Pai.Sigla + ":" + Lista.NomeObj.Replace("[?]","")+ "\" minOccurs=\"0\" maxOccurs=\"unbounded\"/>");
                ssb.AppendLine("		</sequence>");
                ssb.AppendLine("	</complexType>");
            }

        }
        #endregion
        #region Estrutura       
        private EstruturaReferencia MontaArvoreOBJ(Worksheet aba, Sentido sentido)
        {

            EstruturaReferencia estrutura = new EstruturaReferencia()
            {
                Diretorio = "",
                NomeProp = "Contrato",
                Tipo = "Contrato"
            };
            bool hasObject = true;
            int countObject = 0;
            while (hasObject)
            {
                string infoProperty = aba.Cells[(sentido == Sentido.Request ? linhaPropertyInput : linhaPropertyOutput) + countObject, sentido == Sentido.Request ? colunaPropertyInput : colunaPropertyOutput].Value;
                string infoType = aba.Cells[(sentido == Sentido.Request ? linhaPropertyInput : linhaPropertyOutput) + countObject, sentido == Sentido.Request ? colunaTypeInput : colunaTypeOutput].Value;
                string requiredType = aba.Cells[(sentido == Sentido.Request ? linhaPropertyInput : linhaPropertyOutput) + countObject, sentido == Sentido.Request ? colunaRequiredInput : colunaRequiredOutPut].Value;
                string alternativeName = aba.Cells[(sentido == Sentido.Request ? linhaPropertyInput : linhaPropertyOutput) + countObject, sentido == Sentido.Request ? colunaAlternativeNameInput : colunaAlternativeNameOutPut].Value;

                if (!string.IsNullOrEmpty(infoProperty))
                {
                    AdicionaNaArvore(estrutura, infoProperty, infoType, requiredType, sentido, alternativeName);
                }
                else
                    hasObject = false;
                countObject++;
            }
            return estrutura;
        }
        private void AdicionaNaArvore(EstruturaReferencia RefA, string item, string type, string required, Sentido sentido, string alternativeName)
        {
            var arraySplit = item.Split('.');
            for (int i = 0; i < arraySplit.Count(); i++)
            {

                EstruturaReferencia no = ProcuraNo(RefA, arraySplit[i]);

                if (no != null && string.IsNullOrEmpty(alternativeName))
                {
                    RefA = no;
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
                        tipo = type;
                    }
                    else
                    {
                        tipo = "Complex";
                    }
                    EstruturaReferencia novo = (new EstruturaReferencia()
                    {
                        NomeProp = string.IsNullOrEmpty(alternativeName)? arraySplit[i].Trim(): alternativeName,
                        NomeObj = arraySplit[i][0].ToString().ToUpper().Trim() + arraySplit[i].Substring(1).ToString().Trim(),
                        Tipo = tipo,
                        requerido = required == "R" ? true : false,
                        Pai = RefA,
                        Sigla = "tns"

                    });
                    if (i == arraySplit.Length - 2)
                    {
                        if(!arraySplit[i].Contains("[?]"))
                            SearchFile(arraySplit[i], novo, sentido);
                    }
                    RefA.Filhos.Add(novo);
                    if (novo.Tipo == "Lista")
                    {
                        if (sentido == Sentido.Request)
                        {
                            listaListasRequest.Add(novo);
                        }
                        else
                        {
                            listaListasResponse.Add(novo);
                        }

                    }
                    RefA = novo;
                }

            }

        }
        private EstruturaReferencia ProcuraNo(EstruturaReferencia estrutura, string noBusca)
        {
            EstruturaReferencia ss = estrutura;

            ss = (from fi in estrutura.Filhos where fi.NomeProp == noBusca select fi).FirstOrDefault();
            if (ss == null)
            {
                return ss;
            }
            else if (ss.Filhos.Count() > 0 && ss.NomeProp != noBusca)
            {
                return ProcuraNo(ss, noBusca);
            }

            return ss;
        }
        
        private void SearchFile(string fileSearch, EstruturaReferencia estruturaRequest, Sentido sentido)
        {

            var fileList = new DirectoryInfo(diretorioReferencias).GetFiles(fileSearch.Trim().Replace("[?]","") + ".xsd", SearchOption.AllDirectories);

            var finalString = fileList[0].FullName.Replace(diretorioReferencias, "").Split('\\');

            estruturaRequest.Diretorio = fileList[0].FullName.Replace(diretorioReferencias, "").Replace(".xsd", "");

            estruturaRequest.Sigla = "ns" + nsCounter++;//(fileList[0].Name[0].ToString().ToLower() + fileList[0].Name.Substring(1).ToString()).Replace(".xsd", "");

            if (sentido.Equals(Sentido.Request))
            {
                referenciasRequest.Add(estruturaRequest);
            }
            else
            {
                referenciasResponse.Add(estruturaRequest);
            }
        }
        #endregion


    }
}
