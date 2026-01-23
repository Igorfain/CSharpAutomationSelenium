using Dapper;
using Npgsql;
using System.Data;

namespace Infra.Database.Helpers;

public class DbHelper : IDisposable
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public DbHelper(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public void BeginTransaction()
    {
        _transaction = _connection.BeginTransaction();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction = null;
    }

    public T QuerySingle<T>(string sql, object? parameters = null)
    {
        return _connection.QueryFirstOrDefault<T>(sql, parameters, _transaction);
    }

    public int Execute(string sql, object? parameters = null)
    {
        return _connection.Execute(sql, parameters, _transaction);
    }

    public IEnumerable<T> Query<T>(string sql, object? parameters = null)
    {
        return _connection.Query<T>(sql, parameters, _transaction);
    }


    public void Dispose()
    {
        _transaction?.Dispose();
        _connection.Dispose();
    }
}
