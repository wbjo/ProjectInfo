using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Veolia.Extranet.Api.Core.Database.Connection
{
    public interface IConnectionSession
    {
        IDbConnection Connection { get; }

        void Dispose();

        void SetCurrentTransaction(IDbTransaction databaseTransaction);

        IDbTransaction GetCurrentTransaction();
    }
}
