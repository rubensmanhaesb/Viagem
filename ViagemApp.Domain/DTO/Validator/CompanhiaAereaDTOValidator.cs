using FluentValidation;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTOValidator :  AbstractValidator<CompanhiaAerea>
    {
        public CompanhiaAereaDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Obrigatório informar o nomeda companhia aérea.")
                .MaximumLength(150).WithMessage("O nome não pode ter mais de 150 caracteres.") ;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Obrigatório informar o nomeda companhia aérea.");

        }
    }
}
