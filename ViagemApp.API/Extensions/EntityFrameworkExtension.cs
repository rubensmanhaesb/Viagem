using DomainSharedLib.Context;
using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;


namespace ViagemApp.API.Extensions
{

    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsEnvironment("Testing"))
            {
                services.AddScoped<IDbContextFactory, DbContextFactory>(provider =>
                {
                    var options = new DbContextOptionsBuilder<DataContext>()
                        .UseInMemoryDatabase("TestDatabase")
                        .Options;

                    return new DbContextFactory(options);
                });
            }
            else
            {
                var connectionString = configuration.GetConnectionString("ViagemApp");

                services.AddScoped<IDbContextFactory, DbContextFactory>(provider =>
                {
                    var options = new DbContextOptionsBuilder<DataContext>()
                        .UseSqlServer(connectionString)
                        .Options;

                    return new DbContextFactory(options);
                });

            }
            services.AddDbContext<DbContext, DataContext>();
  
            return services;
        }
    }
}



