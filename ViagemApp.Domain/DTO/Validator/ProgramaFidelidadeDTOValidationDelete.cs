using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;

namespace ViagemApp.Domain.DTO.Validator
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
