using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Extensions;
using FluentValidation;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class ProgramaFidelidadeBusinessValidationDelete : BaseBusinessRuleValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeBusinessValidationDelete(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {
            RuleFor(c => c.Id)
                .MustAsync(BeUniqueId)
                .WithMessage(c => $"Id {c.Id} não encontrado!");
        }

        private async Task<bool> BeUniqueId(Guid Id, CancellationToken cancellationToken)
        {
            var result = await GetByConditionAsync(predicate: x => x.Id == Id);
            return result.Any();
        }

    }
}
