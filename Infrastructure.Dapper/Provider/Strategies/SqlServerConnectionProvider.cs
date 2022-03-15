using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Repository.Provider
{
    public class SqlServerConnectionProvider : ISqlConnectionProvider
    {
        private SqlConnection conn;
        public SqlServerConnectionProvider()
        {
            conn = new SqlConnection();

        }

        public List<dynamic> Query(string strQuery, object parameters)
        {
            return conn.Query(strQuery, parameters, buffered: false).ToList();
        }

        public List<dynamic> Query(string strQuery)
        {
            return conn.Query(strQuery, buffered: false).ToList();
        }

        public List<T> Query<T>(string strQuery, object parameters)
        {
            return conn.Query<T>(strQuery, param: parameters, buffered: false).ToList();
        }

        public List<T> Query<T>(string strQuery)
        {
            return conn.Query<T>(strQuery, buffered: false).ToList();
        }

        public void SetConnectionString(string connStr)
        {
            conn.ConnectionString = connStr;
        }

        public bool Open()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                return conn.State == System.Data.ConnectionState.Open;
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
                return conn.State == System.Data.ConnectionState.Closed;
            }
            catch
            {

                throw;
            }
        }

        public void Execute(string sql, object parameters)
        {
            throw new System.NotImplementedException();
        }

        int ISqlConnectionProvider.Execute(string sql, object parameters)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(string sql, object parameters)
        {
            throw new System.NotImplementedException();
        }

        public int InsertMany(string sql, object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public int Execute(string sql)
        {
            throw new System.NotImplementedException();
        }
    }
}
