using FSI.Model.ServiceIntegration;
using System.Xml;

namespace FSI.Transformation
{
    public interface IRequestData
    {
        XmlDocument GetRequest(Operation operation,  Service serviceMessage);
    }
}
