using FluentValidation;
using ViagemApp.Application.Validation;
using ViagemApp.Application.DTO;

namespace ViagemApp.Application.Validation
{
    public class ProgramaFidelidadeFactoryDTOValidation : IProgramaFidelidadeFactoryDTOValidation
    {
        private readonly Dictionary<Type, Func<IValidator>> _validators;

        public ProgramaFidelidadeFactoryDTOValidation()
        {
            _validators = new Dictionary<Type, Func<IValidator>>()
        {
            { typeof(ProgramaFidelidadeDTOInsert), () => new ProgramaFidelidadeDTOValidationInsert() },
            { typeof(ProgramaFidelidadeDTODelete), () => new ProgramaFidelidadeDTOValidationDelete() },
            { typeof(ProgramaFidelidadeDTOUpdate), () => new ProgramaFidelidadeDTOValidationUpdate() },
            { typeof(ProgramaFidelidadeDTOValidation), () => new ProgramaFidelidadeDTOValidation() }
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
