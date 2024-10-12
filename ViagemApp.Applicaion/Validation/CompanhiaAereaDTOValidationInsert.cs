using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Application.Validation
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
