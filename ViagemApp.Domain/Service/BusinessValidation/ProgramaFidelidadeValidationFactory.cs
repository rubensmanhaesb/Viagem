using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using DomainSharedLib.Shared;
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

        public BaseBusinessRuleValidator<ProgramaFidelidade> CreateValidator(CrudOperation operationType)
        {
            var validators = new Dictionary<CrudOperation, Func<IDbContextFactory, BaseBusinessRuleValidator<ProgramaFidelidade>>>
                {
                    { CrudOperation.Create, dbContextFactory => new ProgramaFidelidadeBusinessValidationInsert(dbContextFactory)},
                    { CrudOperation.Update, dbContextFactory => new ProgramaFidelidadeBusinessValidationUpdate(dbContextFactory)},
                    { CrudOperation.Delete, dbContextFactory => new ProgramaFidelidadeBusinessValidationDelete(dbContextFactory)}
                };

            if (validators.TryGetValue(operationType, out var validatorFactory))
                return validatorFactory(_dbContextFactory);
            else
                throw new ArgumentException("Operação não suportada.");
        }
    }
}
