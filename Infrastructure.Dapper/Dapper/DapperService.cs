using Infrastructure.Repository.Options;
using Infrastructure.Repository.Provider;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repository.Dapper
{
    public class DapperService : IDisposable
    {
        private ILogger<DapperService> Logger { get; set; }

        public string ConnectionString { get; private set; }

        public DapperOptions DapperOptions;

        private ISqlConnectionProvider conn;
        private bool disposedValue;

        public DapperService(ILogger<DapperService> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void ConfigureConnection(DapperOptions dapperOptions)
        {
            DapperOptions = dapperOptions;
            conn = ConnectionProvider.GetSqlConnectionProvider(dapperOptions.Provider);
            conn.SetConnectionString(dapperOptions.ConnectionString);
        }
        public int Execute(string sql, object parameters)
        {
            try
            {
                conn.Open();
                return conn.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public int Execute(string sql)
        {
            try
            {
                conn.Open();
                return conn.Execute(sql);
            }
            catch (Exception ex)
            {

                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public List<dynamic> Query(string sql)
        {
            try
            {
                conn.Open();
                var resp = conn.Query(sql);
                conn.Close();
                return resp;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public List<dynamic> Query(string sql, object parameters)
        {
            try
            {
                conn.Open();
                var resp = conn.Query(sql, parameters);
                conn.Close();
                return resp;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public List<T> Query<T>(string sql)
        {
            try
            {
                conn.Open();
                var resp = conn.Query<T>(sql);
                conn.Close();
                return resp;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public List<T> Query<T>(string sql, object parameters)
        {
            try
            {
                conn.Open();
                var resp = conn.Query<T>(sql, parameters);
                conn.Close();
                return resp;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                Logger = null;
                DapperOptions = null;

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public object Query<T>(object queryValPossCarWithVal, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
