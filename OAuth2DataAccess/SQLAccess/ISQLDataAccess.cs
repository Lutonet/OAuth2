namespace OAuth2DataAccess.SQLAccess
{
    public interface ISQLDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "SQLServer");

        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "SQLServer");
    }
}