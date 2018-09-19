using System.Data;
using Veolia.Extranet.Api.Core.Database.Connection;

namespace Veolia.Extranet.Api.Core.Database.Transaction
{
    public class TransactionSession : ITransactionSession
    {
        private readonly IDbTransactionFactory _databaseTransactionFactory;

        private readonly IConnectionSession _connectionSession;

        private IDbTransaction _databaseTransaction;

        public TransactionSession(IDbTransactionFactory databaseTransactionFactory, IConnectionSession connectionSession)
        {
            _databaseTransactionFactory = databaseTransactionFactory;
            _connectionSession = connectionSession;
        }

        public IDbConnection Connection => _connectionSession.Connection;

        public IDbTransaction Transaction
        {
            get
            {
                if (_databaseTransaction == null)
                {
                    _databaseTransaction = _databaseTransactionFactory.OpenTransaction(Connection);
                    _connectionSession.SetCurrentTransaction(_databaseTransaction);
                }

                return _databaseTransaction;
            }
        }

        public bool HasTransaction()
        {
            return _databaseTransaction != null;
        }

        public void Dispose()
        {
            _databaseTransaction?.Dispose();
            _connectionSession?.Dispose();
        }

        public void Commit()
        {
            _databaseTransaction?.Commit();
            _connectionSession.SetCurrentTransaction(null);
        }

        public void Rollback()
        {
            _databaseTransaction?.Rollback();
        }
    }
}
