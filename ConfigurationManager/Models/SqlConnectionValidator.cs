using System.Data.SqlClient;
using ConfigurationManager.Interfaces;

namespace ConfigurationManager.Models
{
    public class SqlConnectionValidator : ISqlConnectionValidator
    {
        public void CheckConnection(ConnectionString connection)
        {
            var connectionString =
                $"Data Source={connection.DataSource}; Initial Catalog={connection.InitialCatalog}; User ID={connection.UserId}; Password={connection.Password}; Connection Timeout=5;";

            using (var mDbConnection = new SqlConnection(connectionString))
            {
                mDbConnection.Open();
                mDbConnection.Close();
            }
        }
    }
}
