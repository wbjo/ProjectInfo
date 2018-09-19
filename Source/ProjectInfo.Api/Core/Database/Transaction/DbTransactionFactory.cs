using System;
using System.Data;
using Spinit.Data;

namespace Veolia.Extranet.Api.Core.Database.Transaction
{
    public class DbTransactionFactory : IDbTransactionFactory
    {
        private readonly IIsolationLevelResolver _isolationLevelResolver;

        public DbTransactionFactory(IIsolationLevelResolver isolationLevelResolver)
        {
            _isolationLevelResolver = isolationLevelResolver;
        }

        public IDbTransaction OpenTransaction(IDbConnection connection)
        {
            connection.Open();
            return connection.BeginTransaction(_isolationLevelResolver.GetIsolationLevel());
        }
    }
}
