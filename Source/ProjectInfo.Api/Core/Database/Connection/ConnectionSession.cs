using System;
using System.Data;
using Veolia.Extranet.Api.Core.Database.Transaction;

namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public class ConnectionSession : IConnectionSession
    {
        private readonly IDbConnectionFactory _connectionFactory;

        private readonly IDbTransactionFactory _transactionFactory;

        private IDbConnection _connection;

        private IDbTransaction _currentTransaction;

        public ConnectionSession(IDbConnectionFactory connectionFactory, IDbTransactionFactory transactionFactory)
        {
            _connectionFactory = connectionFactory;
            _transactionFactory = transactionFactory;
        }

        public IDbConnection Connection => _connection ??
            (_connection = _connectionFactory.BuildNew());

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        public IDbTransaction GetCurrentTransaction()
        {
            return _currentTransaction;
        }

        public void SetCurrentTransaction(IDbTransaction databaseTransaction)
        {
            _currentTransaction = databaseTransaction;
        }

        public void RunInTransaction(Action<IDbTransaction> action)
        {
            using (var transaction = _transactionFactory.OpenTransaction(Connection))
            {
                action(transaction);
                transaction.Commit();
            }
        }

        public T RunInTransaction<T>(Func<IDbTransaction, T> action)
        {
            using (var transaction = _transactionFactory.OpenTransaction(Connection))
            {
                var result = action(transaction);
                transaction.Commit();
                return result;
            }
        }
    }
}
