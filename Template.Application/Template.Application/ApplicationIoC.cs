using Microsoft.Extensions.DependencyInjection;
using Template.Application.Services;

namespace Template.Application
{
    public static class ApplicationIoC
    {
        public static void ApplicationStartup(this IServiceCollection services)
        {
            services.AddScoped<WeatherForecastService>();
            //todo - Add services reg
        }
    }
}
