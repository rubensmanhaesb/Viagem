using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;


namespace ViagemApp.Domain.DTO.Validator
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
