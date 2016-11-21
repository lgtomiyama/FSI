using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.Model.ServiceIntegration
{
    public class ReferenceElements
    {

        public ReferenceElements(string value)
        {
            Name = value;
        }
        public string Name { get; set; }
        public string Xml { get; set; }
    }
}
