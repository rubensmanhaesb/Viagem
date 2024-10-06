using FluentValidation;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Validation.Extensions;

namespace ViagemApp.Applicaion.Validation
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
