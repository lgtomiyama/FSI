using System;
using System.Collections.Generic;
using System.Xml;
using FSI.Model.ServiceIntegration;

namespace FSI.Transformation.ContractModel
{
    public class ContractToModel
    {
        public List<ContractServiceSctructure> ToContract(IntegrationScope IScope, bool _unionSchemaDefinitions, bool _use)
        {
            return GetDocumentType(_unionSchemaDefinitions, _use).ToContracts(IScope);
        }

        public IntegrationScope ToData(ContractServiceSctructure IScope)
        {
            throw new NotImplementedException();
        }
        private IContractData GetDocumentType(bool _unionSchemaDefinitions, bool _use)
        {
            //TODO:Introduzir arquivo de configurção e reflection
            //para selecionar o objeto correto a ser consumido.
            return new ContractWSDL_Vivo1(_unionSchemaDefinitions, _use);
        }
    }
}
