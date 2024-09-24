
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
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region DomainService

            services.AddTransient<ICompaniaAereaDomainService, CompaniaAereaDomainService>();
            #endregion  DomainService

            #region Validator DTO
            
            services.AddTransient<AbstractValidator<CompaniaAereaDTODelete>, CompaniaAereaDTODeleteValidator>();
            services.AddTransient<AbstractValidator<CompaniaAereaDTOUpdate>, CompaniaAereaDTOUpdateValidator>();
            services.AddTransient<AbstractValidator<CompaniaAereaDTOInsert>, CompaniaAereaDTOInsertValidator>();

            #endregion Validator DTO



            return services;
        }
    }
}
