using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;


namespace ViagemApp.Domain.DTO.Validator
{
    public class ProgramaFidelidadeDTOValidationUpdate : AbstractValidator<ProgramaFidelidadeDTOUpdate>
    {
        public ProgramaFidelidadeDTOValidationUpdate()
        {
            RuleFor(x => x.Nome)
                .ProgramaFidelidadeValidateNome();

            RuleFor(cliente => cliente.Id)
                .ProgramaFidelidadeValidateId();
        }
    }
}
