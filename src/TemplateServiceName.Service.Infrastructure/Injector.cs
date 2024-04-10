using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TemplateServiceName.Service.Infrastructure
{
    public static class Injector
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            //services.AddDbContext<Context>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
        }
    }
}
