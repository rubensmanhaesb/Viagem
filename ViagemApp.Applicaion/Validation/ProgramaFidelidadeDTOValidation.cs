using FluentValidation;
using ViagemApp.Application.Validation.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Applicaion.Validation
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
