using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.Service.BusinessValidator
{
    public class CompanhiaAereaBusinessValidatorInsert : BaseBusinessRuleValidator<CompanhiaAerea>
    {
        public CompanhiaAereaBusinessValidatorInsert(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async override Task<bool> ValidateAsync(CompanhiaAerea entity)
        {
            var companiaAereaTask = CheckExistsAsync(
                x => x.Nome.ToLower() == entity.Nome.ToLower(),
                result => result.Any(),
                e => $"Companhia aérea {e.Nome.CapitalizeWords()} já cadastrada!",
                null
            );

            var result = await Task.WhenAll(companiaAereaTask).ConfigureAwait(false);

            return result.Any(r => r);

        }


    }
}
