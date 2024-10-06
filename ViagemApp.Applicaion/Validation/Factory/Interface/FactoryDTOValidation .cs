using FluentValidation;


namespace ViagemApp.Application.Validation
{
    public interface IFactoryDTOValidation
    {
        IValidator<T> GetValidator<T>();
    }
}
