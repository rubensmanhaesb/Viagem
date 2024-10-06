﻿using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Extensions;
using ViagemApp.Domain.Entities;
using DomainSharedLib.Context;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class CompanhiaAereaBusinessValidationUpdate : BaseBusinessRuleValidator<CompanhiaAerea>
    {
        public CompanhiaAereaBusinessValidationUpdate(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async override Task<bool> ValidateAsync(CompanhiaAerea entity)
        {
            var companhiaTask1 = CheckExistsAsync(
                x => x.Id == entity.Id,
                result => !result.Any(),
                e => $"Companhia aérea não cadastrada!",
                null
            );

            var companhiaTask2 = CheckExistsAsync(
                x => x.Nome.ToLower() == entity.Nome.ToLower() &&
                    x.Id != entity.Id,
                    result => result.Any(),
                e => $"Companhia aérea {e.Nome.CapitalizeWords()}  já cadastrado para o Guid {e.Id}!",
                null
            );

            var result = await Task.WhenAll(companhiaTask1, companhiaTask2).ConfigureAwait(false);


            return result.Any(r => r);
        }


    }
}
