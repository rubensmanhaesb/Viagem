using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;


namespace ViagemApp.Domain.DTO.Validation
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
