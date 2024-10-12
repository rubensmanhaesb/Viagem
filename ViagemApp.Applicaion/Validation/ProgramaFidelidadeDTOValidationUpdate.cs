using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Application.Validation
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
