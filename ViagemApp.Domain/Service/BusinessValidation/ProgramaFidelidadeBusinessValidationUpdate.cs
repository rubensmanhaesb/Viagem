using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Extensions;
using ViagemApp.Domain.Entities;
using DomainSharedLib.Context;
using FluentValidation;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class ProgramaFidelidadeBusinessValidationUpdate : BaseBusinessRuleValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeBusinessValidationUpdate(IDbContextFactory dbContextFactory ) : base(dbContextFactory)
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {

            RuleFor(c => c.Id)
                .MustAsync(BeUniqueId)
                .WithMessage(c => $"Programa de fidelidade não cadastrada para o id {c.Id}!");


            RuleFor(c => c.Nome)
                .MustAsync(BeUniqueName)
                .WithMessage(c => $"Programa de fidelidade {c.Nome.CapitalizeWords()} já cadastrado!");

        }

        private async Task<bool> BeUniqueId(Guid Id, CancellationToken cancellationToken)
        {
            var result = await GetByConditionAsync(predicate: x => x.Id == Id, cancellationToken: cancellationToken);
            return result.Any();
        }

        private async Task<bool> BeUniqueName(ProgramaFidelidade entity, string nome, CancellationToken cancellationToken)
        {

            var result = await GetByConditionAsync(
                predicate: x => x.Nome.ToLower() == nome.ToLower() && x.Id != entity.Id, cancellationToken: cancellationToken);

            return !result.Any();  // Retorna true se o nome for único
        }

    }
}
