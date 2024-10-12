using FluentValidation;
using ViagemApp.Application.Validation.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Application.Validation
{
    public class CompanhiaAereaDTOValidation : AbstractValidator<CompanhiaAerea>
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
