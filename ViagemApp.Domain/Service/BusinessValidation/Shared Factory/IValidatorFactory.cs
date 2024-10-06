using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Shared;


namespace ViagemApp.Domain.Service.BusinessValidation
{
    public interface IValidatorFactory<T> where T : class
    {
        BaseBusinessRuleValidator<T> CreateValidator(CrudOperation operationType);
    }
}
