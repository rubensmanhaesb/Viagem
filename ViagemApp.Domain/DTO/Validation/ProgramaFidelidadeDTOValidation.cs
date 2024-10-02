using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.DTO.Validation
{
    public class ProgramaFidelidadeDTOValidation : AbstractValidator<ProgramaFidelidade>
    {
        public ProgramaFidelidadeDTOValidation()
        {
            RuleFor(x => x.Nome)
                .ProgramaFidelidadeValidateNome();

            RuleFor(x => x.Id)
                .ProgramaFidelidadeValidateId();

        }
    }
}
