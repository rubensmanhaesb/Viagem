using FluentValidation;
using ViagemApp.Application.Validation.Extensions;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Applicaion.Validation
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
