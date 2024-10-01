using DomainSharedLib.BusinesValidator;


namespace ViagemApp.Domain.Service.BusinessValidation
{
    public interface IValidatorFactory<T> where T : class
    {
        BaseBusinessRuleValidator<T> CreateValidator(OperationType operationType);
    }
}
