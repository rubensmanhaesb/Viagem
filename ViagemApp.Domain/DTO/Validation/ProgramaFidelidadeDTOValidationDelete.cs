using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;

namespace ViagemApp.Domain.DTO.Validation
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
