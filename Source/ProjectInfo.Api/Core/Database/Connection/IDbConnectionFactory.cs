using System.Data;

namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public interface IDbConnectionFactory
    {
        IDbConnection BuildNew();
    }
}
