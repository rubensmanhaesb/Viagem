using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Shared;
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

        public BaseBusinessRuleValidator<CompanhiaAerea> CreateValidator(CrudOperation operationType)
        {
            var validators = new Dictionary<CrudOperation, Func<IDbContextFactory, BaseBusinessRuleValidator<CompanhiaAerea>>>
                {
                    { CrudOperation.Create, dbContextFactory => new CompanhiaAereaBusinessValidationInsert(dbContextFactory)},
                    { CrudOperation.Update, dbContextFactory => new CompanhiaAereaBusinessValidationUpdate(dbContextFactory)},
                    { CrudOperation.Delete, dbContextFactory => new CompanhiaAereaBusinessValidationDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
