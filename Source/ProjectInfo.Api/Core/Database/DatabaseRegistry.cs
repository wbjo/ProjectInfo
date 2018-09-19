using Spinit.Data;
using StructureMap;
using Veolia.Extranet.Api.Core.Database.Connection;
using Veolia.Extranet.Api.Core.Database.Transaction;

namespace Veolia.Extranet.Api.Core.Database
{
    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            For<IConnectionStringResolver>().Use<ConnectionStringResolver>();
            For<IDbConnectionFactory>().Use<DbConnectionFactory>();
            For<IIsolationLevelResolver>().Use<IsolationLevelResolver>();
            Forward<ITransactionUnitOfWork, IUnitOfWork<ITransactionSession>>();
            Forward<IConnectionUnitOfWork, IUnitOfWork<IConnectionSession>>();
            For<IConnectionUnitOfWork>().Use<ConnectionUnitOfWork>();
            For<ITransactionUnitOfWork>().Use<TransactionUnitOfWork>();

            For<IConnectionSession>().Use(x => x.GetInstance<IUnitOfWork<IConnectionSession>>().Session);
            //// Request this if you want to make sure a transaction is not opened until you yourself call .Transaction
            For<ITransactionSession>().Use(x => x.GetInstance<IUnitOfWork<ITransactionSession>>().Session);
        }
    }
}
