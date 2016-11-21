using FSI.DataAccess.Excel;
using FSI.DataAccess.Contract;
using FSI.Model.ServiceIntegration;
using FSI.Transformation.ContractModel;
using FSI.Transformation.ExcelModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using FSI.Transformation;

namespace FSI.Control.ServiceIntegration
{
    public class IntegrationControl
    {
        public List<IntegrationScope> ReadIntegrationPlan(string path)
        {
            try
            {
                DataSet ds = new DAExcel().ReadIntegrationFile(path);
                List<IntegrationScope> iScope = new ExcelTransformationExtension().ToModel(ds);
                return iScope;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContractServiceSctructure> ContractIntegrationScope(IntegrationScope iScope, bool _unionSchemaDefinitions, bool _use)
        {
            try
            {
                List<ContractServiceSctructure> structureList = new ContractToModel().ToContract(iScope, _unionSchemaDefinitions, _use);
                return structureList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ContractPersist(List<ContractServiceSctructure> structureList)
        {
            try
            {
                new DAContract().WriteServiceDescription(structureList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MessageStructure> GetTreeReferences()
        {
            try
            {
                return new DAContract().GetTreeReferences();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public XmlDocument GetRequest(Operation operation, Service serviceMessage)
        {
            try
            {
                return new RequestSOAP().GetRequest(operation, serviceMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OrganizarSequenceRequest(Operation operation, string xsdPath)
        {
            try
            {
                DAContract contractAccess = new DAContract();
                List<string> requestsList = contractAccess.GetSequence(xsdPath, operation.Name);
                
                new RequestSOAP().OrganizeSequenceRequest(operation, requestsList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
