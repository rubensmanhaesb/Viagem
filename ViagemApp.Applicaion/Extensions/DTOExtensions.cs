using DomainSharedLib.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ViagemApp.Application.Validation;


namespace ViagemApp.Application.Extensions
{
    public static class DTOExtensions
    {
        public static IServiceCollection DTOAddDependecyInjection(this IServiceCollection services)
        {
            #region Validator DTO
            services.AddSingleton<ICompanhiaAereaFactoryDTOValidation, CompanhiaAereaFactoryDTOValidation>();
            services.AddSingleton<IProgramaFidelidadeFactoryDTOValidation, ProgramaFidelidadeFactoryDTOValidation>();
            services.AddDTOValidatorsFromAssembly(Assembly.Load("ViagemApp.Application"), ServiceLifetime.Transient);
            #endregion Validator DTO

            #region Mediator 
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.Load("ViagemApp.Application")));
            #endregion Mediator


            return services;
        }
    }

}
