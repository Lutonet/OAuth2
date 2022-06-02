using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OAuth2DataAccess.SQLAccess;

public class SQLDataAccess : ISQLDataAccess
{
    private readonly IConfiguration _config;

    public SQLDataAccess(IConfiguration config)
    {
        _config=config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
                                                     U parameters,
                                                     string connectionId = "SQLServer")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> LoadSingleRecord<T, U>(string storedProcedure,
                                                U parameters,
                                                string connectionId = "SQLServer")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return (await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure));
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "SQLServer"
        )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}