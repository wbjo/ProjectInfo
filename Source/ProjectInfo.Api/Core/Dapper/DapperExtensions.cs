using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Veolia.Extranet.Api.Core.Database.Connection;
using Veolia.Extranet.Api.Core.Database.Transaction;

namespace Veolia.Extranet.Api.Core.Dapper
{
    public static class DapperExtensions
    {
        public static async Task<int> ExecuteAsync(this ITransactionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Transaction.Connection.ExecuteAsync(sql, param, @this.Transaction, commandTimeout, commandType);

        public static async Task<IEnumerable<T>> QueryAsync<T>(this ITransactionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Transaction.Connection.QueryAsync<T>(sql, param, @this.Transaction, commandTimeout, commandType);

        public static async Task<T> QueryFirstAsync<T>(this ITransactionSession @this, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Transaction.Connection.QueryFirstAsync<T>(sql, param, @this.Transaction, commandTimeout, commandType);

        public static async Task<SqlMapper.GridReader> QueryMultipleAsync(this ITransactionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Transaction.Connection.QueryMultipleAsync(sql, param, @this.Transaction, commandTimeout, commandType);

        public static async Task<T> ExecuteScalarAsync<T>(this ITransactionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.ExecuteScalarAsync<T>(sql, param, @this.Transaction, commandTimeout, commandType);

        public static async Task<int> ExecuteAsync(this IDbTransaction @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.ExecuteAsync(sql, param, @this, commandTimeout, commandType);

        public static async Task<T> ExecuteScalarAsync<T>(this IDbTransaction @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.ExecuteScalarAsync<T>(sql, param, @this, commandTimeout, commandType);

        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbTransaction @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.QueryAsync<T>(sql, param, @this, commandTimeout, commandType);

        public static async Task<T> QueryFirstAsync<T>(this IDbTransaction @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.QueryFirstAsync<T>(sql, param, @this, commandTimeout, commandType);

        public static async Task<int> ExecuteAsync(this IConnectionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.ExecuteAsync(sql, param, @this.GetCurrentTransaction(), commandTimeout, commandType);

        public static async Task<SqlMapper.GridReader> QueryMultipleAsync(this IConnectionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.QueryMultipleAsync(sql, param, @this.GetCurrentTransaction(), commandTimeout, commandType);

        public static async Task<IEnumerable<T>> QueryAsync<T>(this IConnectionSession @this, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.QueryAsync<T>(sql, param, @this.GetCurrentTransaction(), commandTimeout, commandType);

        public static async Task<T> QueryFirstAsync<T>(this IConnectionSession @this, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) =>
            await @this.Connection.QueryFirstAsync<T>(sql, param, @this.GetCurrentTransaction(), commandTimeout, commandType);
    }
}
