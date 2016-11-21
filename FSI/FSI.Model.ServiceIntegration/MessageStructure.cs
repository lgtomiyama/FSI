using System.Collections.Generic;

namespace FSI.Model.ServiceIntegration
{
    public class MessageStructure
    {


        public List<MessageStructure> Children { get; set; }
        public MessageStructure Parent { get; set; }
        public Reference Reference { get; set; }
        public bool Required { get; set; }
        public bool GenerateOnLoad { get; set; }
        public string PropName { get; set; }
        public string DefaultValue { get; set; }
        public MessageStructure()
        {
            Children = new List<MessageStructure>();
            GenerateOnLoad = false;
        }

        public MessageStructure(string v)
        {
            Reference = new Reference(v);
            Children = new List<MessageStructure>();
            GenerateOnLoad = false;
        }
    }
}
