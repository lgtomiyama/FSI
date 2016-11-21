using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System.Data;

namespace FSI.Transformation
{
    public interface IContract
    {
        List<IntegrationScope> ToModel(DataSet ds);
        DataSet ToData(List<IntegrationScope> integrationScope);
    } 
}
