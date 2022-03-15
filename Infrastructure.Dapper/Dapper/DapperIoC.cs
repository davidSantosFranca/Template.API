using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository.Dapper
{
    public static class DapperIoC
    {
        public static void DapperStartup(this IServiceCollection services)
        {
            services.AddScoped<DapperService>();
        }

    }
}
