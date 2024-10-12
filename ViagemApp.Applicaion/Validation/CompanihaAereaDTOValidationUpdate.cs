using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Application.Validation
{
    public class CompanihaAereaDTOValidationUpdate : AbstractValidator<CompanhiaAereaDTOUpdate>
    {
        public CompanihaAereaDTOValidationUpdate()
        {
            RuleFor(x => x.Nome)
                .CompanhiaAereaValidateNome();

            RuleFor(cliente => cliente.Id)
                .CompanhiaAereaValidateId();
        }
    }
}
