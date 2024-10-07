using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Extensions;
using FluentValidation;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class CompanhiaAereaBusinessValidationInsert : BaseBusinessRuleValidator<CompanhiaAerea>
    {

        public CompanhiaAereaBusinessValidationInsert(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
            ConfigureRules();
        }
     
        private void ConfigureRules()
        {

            RuleFor(c => c.Id)
                .MustAsync(BeUniqueId)
                .WithMessage(c => $"Id {c.Id} já cadastrada para a companhia aérea {c.Nome}!");


            RuleFor(c => c.Nome)
                .MustAsync(BeUniqueName)
                .WithMessage(c => $"Companhia aérea {c.Nome.CapitalizeWords()} já cadastrada!");

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
