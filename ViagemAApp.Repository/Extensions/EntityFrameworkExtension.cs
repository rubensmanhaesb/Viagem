using DomainSharedLib.Context;
using DomainSharedLib.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViagemAApp.Repository.Context;

namespace ViagemAApp.Repository.Extensions
{

    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration, AmbienteEnum ambienteEnum)
        {
            services.AddScoped<IDbContextFactoryProvider>(provider =>
            {
                return ambienteEnum switch
                {
                    AmbienteEnum.Testing => new TestingDbContextFactoryProvider(),
                    _ => new ProductionDbContextFactoryProvider(configuration)
                };
            });

            services.AddScoped<IDbContextFactory, DbContextFactory>(provider =>
            {
                var dbContextOptions = provider.GetRequiredService<IDbContextFactoryProvider>().CreateDbContextOptions();
                return new DbContextFactory(dbContextOptions);
            });

            services.AddDbContext<DbContext, DataContext>();
  
            return services;
        }
    }
}



