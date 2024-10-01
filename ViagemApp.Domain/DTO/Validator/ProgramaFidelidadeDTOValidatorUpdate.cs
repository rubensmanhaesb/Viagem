using FluentValidation;


namespace ViagemApp.Domain.DTO.Validator
{
    public class ProgramaFidelidadeDTOValidatorUpdate : AbstractValidator<ProgramaFidelidadeDTOUpdate>
    {
        public ProgramaFidelidadeDTOValidatorUpdate()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do programa de fidelidade é obrigatório.")
                .Must(nome => nome.Length > 2).WithMessage("O nome do programa de fidelidade deve ter mais de 2 caracteres.")
                .MaximumLength(100).WithMessage("O nome do programa de fidelidade não pode ter mais de 100 caracteres.");

            RuleFor(cliente => cliente.Id).NotEmpty().WithMessage("O ID é obrigatório para atualização.");
        }
    }
}
