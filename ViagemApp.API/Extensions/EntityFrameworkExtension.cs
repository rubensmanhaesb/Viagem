using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;

namespace ViagemApp.API.Extensions
{

    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ViagemApp");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));


            return services;
        }
    }
}



