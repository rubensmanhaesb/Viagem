using FluentValidation;

namespace ViagemApp.Domain.DTO.Validator
{
    public class ProgramaFidelidadeDTOValidatorDelete : AbstractValidator<ProgramaFidelidadeDTODelete>
    {
        public ProgramaFidelidadeDTOValidatorDelete()
        {
            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para exclusão.");
        }
    }
}
