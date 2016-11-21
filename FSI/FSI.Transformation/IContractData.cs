using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System.Xml;

namespace FSI.Transformation
{
    public interface IContractData
    {
        List<ContractServiceSctructure> ToContracts(IntegrationScope IScope);
        ContractServiceSctructure ToSingleContract(Service IScope);
        IntegrationScope ToData(ContractServiceSctructure IScope);
        
        

    }
}
