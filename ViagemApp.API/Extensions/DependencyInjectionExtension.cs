using DomainSharedLib.Context;
using DomainSharedLib.Repositories;
using DomainSharedLib.Repository;
using FluentValidation;
using ViagemAApp.Repository.Persistence;
using ViagemApp.Domain.DTO;
using ViagemApp.Domain.DTO.Validator;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;
using ViagemApp.Domain.Service;
using ViagemApp.Domain.Service.BusinessValidator;

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
            services.AddTransient<IBaseQueryRepository<CompanhiaAerea>, BaseRepository<CompanhiaAerea>>();


            #region DomainService
            services.AddTransient<ICompanhiaAereaDomainService, CompanhiaAereaDomainService>();
            #endregion  DomainService

            #region BusinessValidator
            services.AddTransient<IValidatorFactory<CompanhiaAerea>, CompanhiaAereaValidatorFactory>();
            #endregion BusinessValidator

            #region Validator DTO

            services.AddTransient<AbstractValidator<CompanhiaAereaDTODelete>, CompanhiaAereaDTODeleteValidator>();
            services.AddTransient<AbstractValidator<CompanhiaAereaDTOUpdate>, CompanihaAereaDTOUpdateValidator>();
            services.AddTransient<AbstractValidator<CompanhiaAereaDTOInsert>, CompanhiaAereaDTOInsertValidator>();

            #endregion Validator DTO

            return services;
        }
    }
}
