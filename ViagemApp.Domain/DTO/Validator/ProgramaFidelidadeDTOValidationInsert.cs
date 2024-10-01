using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;


namespace ViagemApp.Domain.DTO.Validator
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
