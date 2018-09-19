using System.Data;

namespace Veolia.Extranet.Api.Core.Database.Transaction
{
    public interface ITransactionSession
    {
        IDbTransaction Transaction { get; }
        IDbConnection Connection { get; }

        void Dispose();

        void Commit();

        void Rollback();
    }
}
