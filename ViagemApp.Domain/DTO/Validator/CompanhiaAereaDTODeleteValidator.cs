using FluentValidation;

namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTODeleteValidator : AbstractValidator<CompanhiaAereaDTODelete>
    {
        public CompanhiaAereaDTODeleteValidator()
        {
            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para exclusão.");
        }
    }
}
