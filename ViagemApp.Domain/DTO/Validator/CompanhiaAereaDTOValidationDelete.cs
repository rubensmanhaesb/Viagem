using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;

namespace ViagemApp.Domain.DTO.Validator
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
