using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;


namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTOValidationInsert : AbstractValidator<CompanhiaAereaDTOInsert>
    {
        public CompanhiaAereaDTOValidationInsert()
        {
            RuleFor(x => x.Nome)
                .CompanhiaAereaValidateNome();

        }
    }
}
