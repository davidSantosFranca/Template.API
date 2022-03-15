using Microsoft.Extensions.Logging;
using System;

namespace Template.Application.Services.Base
{
    public class ServiceBase<T> : IDisposable
    {
        private bool disposedValue;
        protected ILoggerFactory _loggerFactory;
        protected ILogger<T> _logger;
        private readonly IServiceProvider _serviceProvider;

        protected ILogger Logger => _logger;
        protected IServiceProvider ServiceProvider => _serviceProvider;

        public ServiceBase(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger<T>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                _logger = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
