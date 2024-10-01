using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidator
{
    public class ProgramaFidelidadeBusinessValidatorDelete : BaseBusinessRuleValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeBusinessValidatorDelete(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public override async Task<bool> ValidateAsync(ProgramaFidelidade entity)
        {
            var companhiaTask1 = CheckExistsAsync(
                x => x.Id == entity.Id,
                result => !result.Any(),
                e => $"Programa de fidelidade não encontrado!",
                null
            );

            var result = await Task.WhenAll(companhiaTask1).ConfigureAwait(false);

            return result.Any(r => r);
        }
    }
}
