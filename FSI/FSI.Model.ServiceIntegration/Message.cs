using FSI.Model.ServiceIntegration.Enum;
using System.Collections.Generic;

namespace FSI.Model.ServiceIntegration
{
    public class Message
    {
        public MessageDirection Direction { get; set; }
        public List<Reference> References { get; set; }
        public MessageStructure Structure { get; set; }
        public string Template { get; set; }
    }
}
