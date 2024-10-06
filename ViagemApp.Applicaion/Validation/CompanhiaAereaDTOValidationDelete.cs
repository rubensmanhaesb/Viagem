using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Applicaion.Validation
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
