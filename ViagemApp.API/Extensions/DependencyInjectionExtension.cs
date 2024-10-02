using DomainSharedLib.Context;
using ViagemAApp.Repository.Persistence;
using ViagemApp.Domain.Repository;
using System.Reflection;
using DomainSharedLib.Extensions;

namespace ViagemApp.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>(provider=>
            {
                var dbContextFactory = provider.GetRequiredService<IDbContextFactory>();
                var dbContext = dbContextFactory.CreateDbContext();  // Cria o DbContext usando a fábrica
                return new UnitOfWork(dbContext);
            });

            #region DomainService & BusinessValidator
            services.AddAllServices(Assembly.Load("ViagemApp.Domain"), ServiceLifetime.Transient);
            #endregion  DomainService & BusinessValidator


            #region Validator DTO
            services.AddDTOValidatorsFromAssembly(Assembly.Load("ViagemApp.Domain"), ServiceLifetime.Transient);
            #endregion Validator DTO

            return services;
        }
    }
}
