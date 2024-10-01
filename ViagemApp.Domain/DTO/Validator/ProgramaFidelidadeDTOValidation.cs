using FluentValidation;
using ViagemApp.Domain.DTO.Validator.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.DTO.Validator
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
