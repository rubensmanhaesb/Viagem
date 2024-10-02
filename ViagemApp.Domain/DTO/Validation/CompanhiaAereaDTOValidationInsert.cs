using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;


namespace ViagemApp.Domain.DTO.Validation
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
