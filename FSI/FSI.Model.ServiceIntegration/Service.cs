using System.Collections.Generic;

namespace FSI.Model.ServiceIntegration
{
    public class Service
    {
        /// <summary>
        /// Name property. 
        /// A value tag is used to describe the Service Name.</summary>
        public string Name { get; set; }
        /// <summary>
        /// Description property.
        /// A value tag is used to describe the Service.</summary>
        public string Description { get; set; }
        /// <summary>
        /// TAM property. 
        /// A value TAM is used to describes TAM which define the schema Ex: CustomerManagement/CustomerOrderEstablishment/CustomerAndProductDataCollection/
        /// </summary>]
        public string[] TAM { get; set; }
        /// <summary>
        /// TAM property. 
        /// A value TAM is used to describes TAM Level
        /// Ex: 03.05.12
        /// </summary>
        public string TAMLevel { get; set; }
        /// <summary>
        /// Address property. 
        /// A value Address is used to describes URL
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// References List. 
        /// A list of refernces used to compose the Service
        /// </summary>
        public List<Reference> References { get; set; }
        /// <summary>
        /// Operations List. 
        /// A list of operations used to compose the Service
        /// </summary>
        public List<Operation> Operations { get; set; }
        public Service()
        {
            References = new List<Reference>();
            Operations = new List<Operation>();
        }
        /// <summary>
        /// Template property. </summary>
        /// <value>
        /// A value Template is used to set the template of Contract
        /// Ex: WSDL template</value>
        public string Template { get; set; }

    }
}
