using Infrastructure.Repository.Provider.Strategies;
using static Infrastructure.Repository.Enumerators;

namespace Infrastructure.Repository.Provider
{
    public static class ConnectionProvider
    {
        public static ISqlConnectionProvider GetSqlConnectionProvider(SqlProviderEnum providerEnum)
        {
            return providerEnum switch
            {
                SqlProviderEnum.SqlServer => new SqlServerConnectionProvider(),
                SqlProviderEnum.MySql => new MySqlConnectionProvider(),
                SqlProviderEnum.Oracle => new OracleConnectionProvider(),
                _ => null,
            };
        }
    }
}
