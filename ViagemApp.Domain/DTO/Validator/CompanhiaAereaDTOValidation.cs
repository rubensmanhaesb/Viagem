using FluentValidation;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.DTO.Validator.Extensions;

namespace ViagemApp.Domain.DTO.Validator
{
    public class CompanhiaAereaDTOValidation :  AbstractValidator<CompanhiaAerea>
    {
        public CompanhiaAereaDTOValidation()
        {
            RuleFor(x => x.Nome)
                .CompanhiaAereaValidateNome();

            RuleFor(x => x.Id)
                .CompanhiaAereaValidateId();

        }
    }
}
