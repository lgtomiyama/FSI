using System.Collections.Generic;

namespace FSI.Model.ServiceIntegration
{
    public class IntegrationScope
    {
        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// A value Name is used to describe the name of integration scope.
        /// Ex: SE, SN etc</value>
        public string Name { get; set; }
        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// A value Description is used to describe the integration scopoe function.
        /// Ex: Business Services, Enablement Services, Financial Services etc</value>
        public string Description { get; set; }
        /// <summary>
        /// Normal URL Path property. </summary>
        /// <value>
        /// A value NormalPath is used to describe the default URL where happens.
        /// Ex: http://telefonica.br/ </value>
        public string NormalPath { get; set; }

        /// <summary>
        /// Services property. </summary>
        /// <value>
        /// A value Services is used to collect services from the Integration Scope.</value>
        public List<Service> Services { get; set; }
        /// <summary>
        /// References property. </summary>
        /// <value>
        /// A value References is used to collect default references from the Integration Scope.</value>
        public List<Reference> References { get; set; }

        public IntegrationScope()
        {
            References = new List<Reference>();
            Services = new List<Service>();
        }

        public int errorQt { get; set; }
        public List<string> propErrorList { get; set; }
    }
}
    