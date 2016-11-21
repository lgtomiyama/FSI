using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FSI.Model.ServiceIntegration
{
    public class ContractOperationSctructure
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public XmlDocument XSDIn { get; set; }
        public XmlDocument XSDOut { get; set; }
        public XmlDocument XSDInOut { get; set; }
    }
}
