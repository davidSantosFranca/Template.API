using System.Collections.Generic;

namespace Infrastructure.Repository.Provider
{
    public interface ISqlConnectionProvider
    {
        public bool Open();
        public bool Close();
        public List<dynamic> Query(string strQuery, object parameters);
        public List<dynamic> Query(string strQuery);
        public List<T> Query<T>(string strQuery, object parameters);
        public List<T> Query<T>(string strQuery);
        public int Execute(string sql, object parameters);
        public int Execute(string sql);
        public void SetConnectionString(string connStr);
    }
}
