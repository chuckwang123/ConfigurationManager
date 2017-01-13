using ConfigurationManager.Models;

namespace ConfigurationManager.Interfaces
{
    public interface ISqlConnectionValidator
    {
        void CheckConnection(ConnectionString connection);
    }
}
