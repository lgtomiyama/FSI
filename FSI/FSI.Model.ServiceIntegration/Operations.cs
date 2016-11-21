
namespace FSI.Model.ServiceIntegration
{
    public class Operation
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Message RequestMessage { get; set; }
        public Message ResponseMessage { get; set; }
    }
}
