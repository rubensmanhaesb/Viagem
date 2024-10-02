using FluentValidation;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.DTO.Validation.Extensions;

namespace ViagemApp.Domain.DTO.Validation
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
