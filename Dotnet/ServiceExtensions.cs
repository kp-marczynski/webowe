using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<ShopDbContext>(o => o.UseMySQL(connectionString));
            services.AddTransient<ShopDbContext>();
        }
    }
}