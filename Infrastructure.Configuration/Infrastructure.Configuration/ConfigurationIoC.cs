using Infrastructure.Configuration.Configurations;
using Infrastructure.Logging.LoggingIoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class ConfigurationIoC
    {
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MainConfiguration>(configuration.GetSection("MainConfiguration"));
            services.RegisterNLog();
        }
    }
}
