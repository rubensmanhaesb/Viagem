using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class CompanhiaAereaValidationFactory : IValidatorFactory<CompanhiaAerea>
    {
        private readonly IDbContextFactory _dbContextFactory;

        public CompanhiaAereaValidationFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public BaseBusinessRuleValidator<CompanhiaAerea> CreateValidator(OperationType operationType)
        {
            var validators = new Dictionary<OperationType, Func<IDbContextFactory, BaseBusinessRuleValidator<CompanhiaAerea>>>
                {
                    { OperationType.Create, dbContextFactory => new CompanhiaAereaBusinessValidationInsert(dbContextFactory)},
                    { OperationType.Update, dbContextFactory => new CompanhiaAereaBusinessValidationUpdate(dbContextFactory)},
                    { OperationType.Delete, dbContextFactory => new CompanhiaAereaBusinessValidationDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
