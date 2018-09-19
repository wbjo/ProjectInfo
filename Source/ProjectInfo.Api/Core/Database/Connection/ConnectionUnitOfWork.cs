using Veolia.Extranet.Api.Core.Database.Transaction;

namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public class ConnectionUnitOfWork : IConnectionUnitOfWork
    {
        private readonly IDbConnectionFactory _connectionFactory;

        private readonly IDbTransactionFactory _transactionFactory;

        private IConnectionSession _connectionSession;

        public ConnectionUnitOfWork(IDbConnectionFactory connectionFactory, IDbTransactionFactory transactionFactory)
        {
            _connectionFactory = connectionFactory;
            _transactionFactory = transactionFactory;
        }

        public IConnectionSession Session => _connectionSession ?? (_connectionSession = new ConnectionSession(_connectionFactory, _transactionFactory));

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            if (HasSession())
            {
                _connectionSession.Dispose();
                _connectionSession = null;
            }

            IsDisposed = true;
        }

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        private bool HasSession()
        {
            return _connectionSession != null;
        }
    }
}
