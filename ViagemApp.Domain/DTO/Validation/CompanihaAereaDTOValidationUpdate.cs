using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;


namespace ViagemApp.Domain.DTO.Validation
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
