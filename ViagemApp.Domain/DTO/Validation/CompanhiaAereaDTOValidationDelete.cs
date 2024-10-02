using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;

namespace ViagemApp.Domain.DTO.Validation
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
