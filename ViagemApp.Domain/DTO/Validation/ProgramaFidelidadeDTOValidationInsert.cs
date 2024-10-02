using FluentValidation;
using ViagemApp.Domain.DTO.Validation.Extensions;


namespace ViagemApp.Domain.DTO.Validation
{
    public class ProgramaFidelidadeDTOValidationInsert : AbstractValidator<ProgramaFidelidadeDTOInsert>
    {
        public ProgramaFidelidadeDTOValidationInsert()
        {
            RuleFor(x => x.Nome)
                .ProgramaFidelidadeValidateNome();
        }
    }
}
