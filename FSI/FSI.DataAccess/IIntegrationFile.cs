using System.Data;

namespace FSI.DataAccess
{
    public interface IIntegrationFile
    {
        DataSet ReadIntegrationFile(string path);
    }
}
