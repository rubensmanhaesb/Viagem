using FluentValidation;


namespace ViagemApp.Domain.DTO.Validator
{
    public class CompaniaAereaDTOUpdateValidator : AbstractValidator<CompaniaAereaDTOUpdate>
    {
        public CompaniaAereaDTOUpdateValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da compania aérea é obrigatório.")
                .Must(nome => nome.Length > 2).WithMessage("O nome da compania aérea deve ter mais de 2 caracteres.")
                .MaximumLength(150).WithMessage("O nome da compania aérea não pode ter mais de 150 caracteres.");

            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para atualização.");
        }
    }
}
