using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class ProgramaFidelidadeBusinessValidationInsert : BaseBusinessRuleValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeBusinessValidationInsert(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async override Task<bool> ValidateAsync(ProgramaFidelidade entity)
        {
            var companiaAereaTask = CheckExistsAsync(
                x => x.Nome.ToLower() == entity.Nome.ToLower(),
                result => result.Any(),
                e => $"Programa de fidelidade {e.Nome.CapitalizeWords()} já cadastrado!",
                null
            );

            var result = await Task.WhenAll(companiaAereaTask).ConfigureAwait(false);

            return result.Any(r => r);

        }


    }
}
