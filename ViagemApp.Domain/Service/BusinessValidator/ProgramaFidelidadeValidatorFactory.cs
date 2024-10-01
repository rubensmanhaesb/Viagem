using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service.BusinessValidator
{
    public class ProgramaFidelidadeValidatorFactory : IValidatorFactory<ProgramaFidelidade>
    {
        private readonly IDbContextFactory _dbContextFactory;

        public ProgramaFidelidadeValidatorFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public BaseBusinessRuleValidator<ProgramaFidelidade> CreateValidator(OperationType operationType)
        {
            var validators = new Dictionary<OperationType, Func<IDbContextFactory, BaseBusinessRuleValidator<ProgramaFidelidade>>>
                {
                    { OperationType.Create, dbContextFactory => new ProgramaFidelidadeBusinessValidatorInsert(dbContextFactory)},
                    { OperationType.Update, dbContextFactory => new ProgramaFidelidadeBusinessValidatorUpdate(dbContextFactory)},
                    { OperationType.Delete, dbContextFactory => new ProgramaFidelidadeBusinessValidatorDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
