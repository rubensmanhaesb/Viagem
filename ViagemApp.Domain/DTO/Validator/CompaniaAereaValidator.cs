using FluentValidation;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.DTO.Validator
{
    public class CompaniaAereaValidator :  AbstractValidator<CompaniaAerea>
    {
        public CompaniaAereaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(150).WithMessage("O nome não pode ter mais de 100 caracteres.") ;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Nome é obrigatório");

        }
    }
}
