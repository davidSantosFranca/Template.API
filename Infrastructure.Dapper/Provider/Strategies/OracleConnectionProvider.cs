using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Repository.Provider.Strategies
{
    internal class OracleConnectionProvider : ISqlConnectionProvider
    {
        private readonly OracleConnection conn;
        public OracleConnectionProvider()
        {
            conn = new();
        }
        public int Execute(string sql)
        {
            return Execute(sql, null);
        }
        public int Execute(string sql, object parameters)
        {
            return conn.Execute(GetTreatedSqlString(sql), commandType: CommandType.Text);
        }
        public List<dynamic> Query(string strQuery, object parameters)
        {
            return conn.Query<dynamic>(GetTreatedSqlString(strQuery), param: parameters, buffered: true).ToList();
        }

        public List<dynamic> Query(string strQuery)
        {
            return conn.Query<dynamic>(GetTreatedSqlString(strQuery), buffered: true).ToList();
        }

        public List<T> Query<T>(string strQuery, object parameters)
        {

            return conn.Query<T>(GetTreatedSqlString(strQuery), param: parameters, buffered: true).ToList();
        }

        private string GetTreatedSqlString(string strQuery)
        {
            return strQuery.Replace("@", ":");
        }

        public List<T> Query<T>(string strQuery)
        {
            return conn.Query<T>(GetTreatedSqlString(strQuery), buffered: true, commandType: CommandType.Text).ToList();
        }

        public void SetConnectionString(string connStr)
        {
            conn.ConnectionString = connStr;
        }

        public bool Open()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch
            {
                throw;
            }
        }

        public bool Close()
        {
            try
            {
                conn.Close();
                return conn.State == ConnectionState.Closed;
            }
            catch
            {

                throw;
            }
        }
    }
}
