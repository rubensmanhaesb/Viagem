using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidator
{
    public class CompanhiaAereaValidatorFactory : IValidatorFactory<CompanhiaAerea>
    {
        private readonly IBaseQueryRepository<CompanhiaAerea> _baseQueryRepository;
        private readonly IDbContextFactory _dbContextFactory;

        public CompanhiaAereaValidatorFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            //_baseQueryRepository = baseQueryRepository;
        }

        public BaseBusinessRuleValidator<CompanhiaAerea> CreateValidator(OperationType operationType)
        {
            var validators = new Dictionary<OperationType, Func<IDbContextFactory, BaseBusinessRuleValidator<CompanhiaAerea>>>
                {
                    { OperationType.Create, dbContextFactory => new CompanhiaAereaBusinessValidatorInsert(dbContextFactory)},
                    { OperationType.Update, dbContextFactory => new CompanhiaAereaBusinessValidatorUpdate(dbContextFactory)},
                    { OperationType.Delete, dbContextFactory => new CompanhiaAereaBusinessValidatorDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
