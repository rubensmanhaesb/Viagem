﻿using FluentValidation;


namespace ViagemApp.Application.Validation.Extensions
{
    public static class CompanhiaAereaValidationRulesExtension
    {
        public static IRuleBuilderOptions<T, string> CompanhiaAereaValidateNome<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Obrigatório informar o nome da companhia aérea.")
                .Must(nome => nome.Length > 2).WithMessage("O nome da companhia aérea deve ter mais de 2 caracteres.")
                .MaximumLength(150).WithMessage("O nome da companhia aérea não pode ter mais de 150 caracteres.");
        }

        public static IRuleBuilderOptions<T, Guid> CompanhiaAereaValidateId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("Obrigatório informar o Id da companhia aérea.");
        }
    }
}
