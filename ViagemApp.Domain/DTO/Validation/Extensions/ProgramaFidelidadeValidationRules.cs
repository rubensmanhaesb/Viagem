using FluentValidation;


namespace ViagemApp.Domain.DTO.Validation.Extensions
{
    public static class ProgramaFidelidadeValidationRules
    {
        public static IRuleBuilderOptions<T, string> ProgramaFidelidadeValidateNome<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Obrigatório informar o nome do programa de fidelidade.")
                .Must(nome => nome.Length > 2).WithMessage("O nome do programa de fidelidade deve ter mais de 2 caracteres.")
                .MaximumLength(100).WithMessage("O nome do programa de fidelidade não pode ter mais de 100 caracteres.");
        }

        public static IRuleBuilderOptions<T, Guid> ProgramaFidelidadeValidateId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("Obrigatório informar o Id do programa de fidelidade.");
        }

    }
}
