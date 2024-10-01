using FluentValidation;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.DTO.Validator
{
    public class ProgramaFidelidadeDTOValidator : AbstractValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Obrigatório informar o nome do programa de fidelidade.")
                .MaximumLength(100).WithMessage("O programade fidelidade não pode ter mais de 100 caracteres.");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Obrigatório informar o Id.");

        }
    }
}
