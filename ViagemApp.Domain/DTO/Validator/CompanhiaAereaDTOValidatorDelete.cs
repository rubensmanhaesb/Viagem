using FluentValidation;

namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTOValidatorDelete : AbstractValidator<CompanhiaAereaDTODelete>
    {
        public CompanhiaAereaDTOValidatorDelete()
        {
            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para exclusão.");
        }
    }
}
