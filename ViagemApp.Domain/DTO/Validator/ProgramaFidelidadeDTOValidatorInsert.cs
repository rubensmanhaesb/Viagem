using FluentValidation;


namespace ViagemApp.Domain.DTO.Validator
{
    public class ProgramaFidelidadeDTOValidatorInsert : AbstractValidator<ProgramaFidelidadeDTOInsert>
    {
        public ProgramaFidelidadeDTOValidatorInsert()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do programa de fidelidade é obrigatório.")
                .Must(nome => nome.Length > 2).WithMessage("O nome do programa de fidelidade deve ter mais de 2 caracteres.")
                .MaximumLength(100).WithMessage("O nome da companhia aérea não pode ter mais de 100 caracteres.");

        }
    }
}
