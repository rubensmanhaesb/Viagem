using FluentValidation;


namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTOInsertValidator : AbstractValidator<CompanhiaAereaDTOInsert>
    {
        public CompanhiaAereaDTOInsertValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome da companhia aérea é obrigatório.")
                .Must(nome => nome.Length > 2).WithMessage("O nome da companhia aérea deve ter mais de 2 caracteres.")
                .MaximumLength(150).WithMessage("O nome da companhia aérea não pode ter mais de 150 caracteres.");

        }
    }
}
