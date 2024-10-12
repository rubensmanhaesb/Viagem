using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Application.Validation
{
    public class ProgramaFidelidadeDTOValidationDelete : AbstractValidator<ProgramaFidelidadeDTODelete>
    {
        public ProgramaFidelidadeDTOValidationDelete()
        {
            RuleFor(cliente => cliente.Id)
                .ProgramaFidelidadeValidateId();
        }
    }
}
