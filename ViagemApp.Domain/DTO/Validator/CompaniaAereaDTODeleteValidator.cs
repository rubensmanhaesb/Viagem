using FluentValidation;

namespace ViagemApp.Domain.DTO.Validator
{
    public class CompaniaAereaDTODeleteValidator : AbstractValidator<CompaniaAereaDTODelete>
    {
        public CompaniaAereaDTODeleteValidator()
        {
            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para exclusão.");
        }
    }
}
