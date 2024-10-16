﻿using DomainSharedLib.Context;
using ViagemApp.Infra.Data.SqlServer.Persistence;
using ViagemApp.Domain.Repository;
using System.Reflection;
using DomainSharedLib.Extensions;
using FluentValidation;
using ViagemApp.Domain.Entities;
using DomainSharedLib.BusinesValidator;
using ViagemApp.Domain.Service.BusinessValidation;

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


            #region DomainService, BusinessValidator
            services.AddAllServices(Assembly.Load("ViagemApp.Domain"), ServiceLifetime.Transient);
            services.AddAllServices(Assembly.Load("ViagemApp.Application"), ServiceLifetime.Transient);
            #endregion  DomainService & BusinessValidator

            return services;
        }
    }
}
