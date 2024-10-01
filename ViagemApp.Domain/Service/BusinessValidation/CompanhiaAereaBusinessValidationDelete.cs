using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class CompanhiaAereaBusinessValidationDelete : BaseBusinessRuleValidator<CompanhiaAerea>
    {
        public CompanhiaAereaBusinessValidationDelete(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public override async Task<bool> ValidateAsync(CompanhiaAerea entity)
        {
            var companhiaTask1 = CheckExistsAsync(
                x => x.Id == entity.Id,
                result => !result.Any(),
                e => $"Companhia aérea não encontrada!",
                null
            );

            var result = await Task.WhenAll(companhiaTask1).ConfigureAwait(false);

            return result.Any(r => r);
        }
    }
}
