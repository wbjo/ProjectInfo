using System.Data;

namespace Veolia.Extranet.Api.Core.Database.Transaction
{
    public interface IDbTransactionFactory
    {
        IDbTransaction OpenTransaction(IDbConnection connection);
    }
}
