using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Application.Validation
{
    public class CompanhiaAereaDTOValidationDelete : AbstractValidator<CompanhiaAereaDTODelete>
    {
        public CompanhiaAereaDTOValidationDelete()
        {
            RuleFor(x => x.Id)
                .CompanhiaAereaValidateId();
        }
    }
}
