using DomainSharedLib.Context;
using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;


namespace ViagemApp.API.Extensions
{

    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ViagemApp");
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<DbContext, DataContext>();

            services.AddScoped<IDbContextFactory, DbContextFactory>(provider =>
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                return new DbContextFactory(options);
            });




            return services;
        }
    }
}



