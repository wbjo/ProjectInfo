using System;
using Spinit.Data;
using Veolia.Extranet.Api.Core.Database.Connection;

namespace Veolia.Extranet.Api.Core.Database.Transaction
{
    public class TransactionUnitOfWork : ITransactionUnitOfWork
    {
        private readonly IDbTransactionFactory _transactionFactory;

        private readonly IUnitOfWork<IConnectionSession> _connectionUnitOfWork;

        private ITransactionSession _session;

        public TransactionUnitOfWork(IDbTransactionFactory transactionFactory, IUnitOfWork<IConnectionSession> connectionUnitOfWork)
        {
            _transactionFactory = transactionFactory;
            _connectionUnitOfWork = connectionUnitOfWork;
        }

        public bool IsDisposed { get; private set; }

        public ITransactionSession Session => _session ?? (_session = new TransactionSession(_transactionFactory, _connectionUnitOfWork.Session));
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            if (HasSession())
            {
                _session.Dispose();
                _session = null;
            }

            _connectionUnitOfWork?.Dispose();
            IsDisposed = true;
        }

        public void Commit()
        {
            VerifyNotDisposed();

            if (HasSession())
            {
                _session.Commit();
            }

            Dispose();
        }

        public void Rollback()
        {
            VerifyNotDisposed();

            if (HasSession())
            {
                _session.Rollback();
            }

            Dispose();
        }

        private void VerifyNotDisposed()
        {
            if (IsDisposed)
            {
                throw new InvalidOperationException("The Unit of Work has been disposed and can no longer be used");
            }
        }

        private bool HasSession()
        {
            return _session != null;
        }
    }
}
