using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System.Xml;

namespace FSI.DataAccess
{
    public interface IContract
    {
        void WriteServiceDescription(List<ContractServiceSctructure> structureList);
    }
}
