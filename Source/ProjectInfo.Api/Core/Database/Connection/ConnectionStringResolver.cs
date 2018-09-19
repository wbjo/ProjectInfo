using System;
using Microsoft.Extensions.Configuration;
using Spinit.Data;

namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public class ConnectionStringResolver : IConnectionStringResolver
    {
        private readonly IConfiguration _configuration;
        public ConnectionStringResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionStrings = _configuration.GetSection("ConnectionStrings");
            if (connectionStrings != null)
            {
                if (!String.IsNullOrEmpty(connectionStrings.Value))
                    return connectionStrings.Value;
            }

            return connectionStrings[Environment.MachineName];
        }
        
        public void SetupDefaultConnection()
        {
            var defaultConnection = _configuration.GetSection("ConnectionStrings");
            defaultConnection["DefaultConnection"] = defaultConnection[Environment.MachineName];
        }
    }
}
