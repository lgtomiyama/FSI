using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FSI.Model.ServiceIntegration
{
    public class ContractServiceSctructure
    {
        public ContractServiceSctructure()
        {
            Operations = new List<ContractOperationSctructure>();
        }
        public string name { get; set; }
        public string Path { get; set; }
        public string tamLevel { get; set; }
        public Enum.ServiceType ServiceType  { get; set; }
        public XmlDocument WSDL { get; set; }
        public List<ContractOperationSctructure> Operations { get; set; }
    }

}
