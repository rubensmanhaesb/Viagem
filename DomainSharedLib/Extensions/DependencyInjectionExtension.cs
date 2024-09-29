using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DomainSharedLib.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime)
        {
            // Filtra todas as classes do assembly que implementam uma interface
            var typesWithInterfaces = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any()) // Apenas classes que implementam interfaces
                .ToList();

            foreach (var implementationType in typesWithInterfaces)
            {
                // Pega todas as interfaces implementadas pela classe
                var interfaces = implementationType.GetInterfaces()
                    .Where(i => i.IsPublic); // Garante que a interface é pública

                foreach (var interfaceType in interfaces)
                {
                    // Apenas registre a implementação se a interface for genérica ou não estiver registrada ainda
                    if (!services.Any(s => s.ServiceType == interfaceType))
                    {
                        services.Add(new ServiceDescriptor(interfaceType, implementationType, lifetime));
                    }
                }
            }

            return services;
        }
        public static void AddDTOValidatorsFromAssembly(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime)
        {
            // Encontra todos os tipos no assembly que herdam de AbstractValidator<T>
            var validators = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition) // Filtra classes concretas
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

            // Registrar cada validador encontrado na injeção de dependência
            foreach (var validator in validators)
            {
                // Obter o tipo da entidade validada (por exemplo, AbstractValidator<MyEntity>)
                var entityType = validator.BaseType.GetGenericArguments().First();

                // Registrar como AbstractValidator<T> e IValidator<T>
                var abstractValidatorInterface = typeof(AbstractValidator<>).MakeGenericType(entityType);
                var iValidatorInterface = typeof(IValidator<>).MakeGenericType(entityType);

                // Usar TryAdd para evitar duplicação
                services.TryAdd(new ServiceDescriptor(abstractValidatorInterface, validator, lifetime));
                services.TryAdd(new ServiceDescriptor(iValidatorInterface, validator, lifetime));
            }
        }

    }
}
