using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using System;
using System.IO;

namespace Infrastructure.Logging.LoggingIoC
{
    public static class NLogIoC
    {
        public static void RegisterNLog(this IServiceCollection services)
        {
            var cfgNlog = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                .AddJsonFile("NLogConfig.json")
                                .Build();
            var optNLog = new NLogProviderOptions()
            {
                ShutdownOnDispose = true,
                CaptureMessageProperties = true,
                CaptureMessageTemplates = true,
                LoggingConfigurationSectionName = "NLog",
                ParseMessageTemplates = true,
                IncludeScopes = true,
                RemoveLoggerFactoryFilter = true,
                ReplaceLoggerFactory = true
            };

            services.AddLogging(logging =>
            {
                logging.AddNLog(configuration: cfgNlog, options: optNLog);
            });
        }
    }
}
