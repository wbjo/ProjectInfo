using System.Data;
using System.Data.SqlClient;
using Spinit.Data;

namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringResolver _connectionStringResolver;

        public DbConnectionFactory(IConnectionStringResolver connectionStringResolver)
        {
            _connectionStringResolver = connectionStringResolver;
        }

        public IDbConnection BuildNew()
        {
            var connectionString = _connectionStringResolver.GetConnectionString();
            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
