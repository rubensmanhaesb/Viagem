using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Extensions;
using FluentValidation;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class ProgramaFidelidadeBusinessValidationInsert : BaseBusinessRuleValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeBusinessValidationInsert(IDbContextFactory dbContextFactory ) : base(dbContextFactory)
        {
            ConfigureRules();
        }


        private void ConfigureRules()
        {

            RuleFor(c => c.Id)
                .MustAsync(BeUniqueId)
                .WithMessage(c => $"Id {c.Id} já cadastrada para a Programa de fidelidade {c.Nome}!");


            RuleFor(c => c.Nome)
                .MustAsync(BeUniqueName)
                .WithMessage(c => $"Programa de fidelidade {c.Nome.CapitalizeWords()} já cadastrado!");

        }

        private async Task<bool> BeUniqueId(Guid Id, CancellationToken cancellationToken)
        {
            var result = await GetByConditionAsync(predicate: x => x.Id == Id, cancellationToken: cancellationToken);
            return !result.Any();
        }

        private async Task<bool> BeUniqueName(string nome, CancellationToken cancellationToken)
        {
            var result = await GetByConditionAsync(
                predicate: x => x.Nome.ToLower() == nome.ToLower(), cancellationToken: cancellationToken);

            return !result.Any();
        }
    }
}
