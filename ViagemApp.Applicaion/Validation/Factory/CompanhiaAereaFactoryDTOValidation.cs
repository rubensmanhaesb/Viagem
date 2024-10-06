using FluentValidation;
using ViagemApp.Applicaion.Validation;
using ViagemApp.Application.DTO;

namespace ViagemApp.Application.Validation
{
    public class CompanhiaAereaFactoryDTOValidation : ICompanhiaAereaFactoryDTOValidation
    {
        private readonly Dictionary<Type, Func<IValidator>> _validators;

        public CompanhiaAereaFactoryDTOValidation()
        {
            _validators = new Dictionary<Type, Func<IValidator>>()
        {
            { typeof(CompanhiaAereaDTOInsert), () => new CompanhiaAereaDTOValidationInsert() },
            { typeof(CompanhiaAereaDTODelete), () => new CompanhiaAereaDTOValidationDelete() },
            { typeof(CompanhiaAereaDTOUpdate), () => new CompanihaAereaDTOValidationUpdate() },
            { typeof(CompanhiaAereaDTOValidation), () => new CompanhiaAereaDTOValidation() }
        };
        }

        public IValidator<T> GetValidator<T>()
        {
            var key = typeof(T);

            if (_validators.TryGetValue(key, out var validatorFactory))
            {
                return (IValidator<T>)validatorFactory();
            }

            throw new InvalidOperationException("Validador não encontrado para o tipo fornecido.");
        }

    }
}

