using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidation
{
    public class ProgramaFidelidadeValidationFactory : IValidatorFactory<ProgramaFidelidade>
    {
        private readonly IDbContextFactory _dbContextFactory;

        public ProgramaFidelidadeValidationFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public BaseBusinessRuleValidator<ProgramaFidelidade> CreateValidator(OperationType operationType)
        {
            var validators = new Dictionary<OperationType, Func<IDbContextFactory, BaseBusinessRuleValidator<ProgramaFidelidade>>>
                {
                    { OperationType.Create, dbContextFactory => new ProgramaFidelidadeBusinessValidationInsert(dbContextFactory)},
                    { OperationType.Update, dbContextFactory => new ProgramaFidelidadeBusinessValidationUpdate(dbContextFactory)},
                    { OperationType.Delete, dbContextFactory => new ProgramaFidelidadeBusinessValidationDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
