using DomainSharedLib.BusinesValidator;
using DomainSharedLib.Extensions;
using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;


namespace ViagemApp.Domain.Service.BusinessValidator
{
    public class CompaniaAereaBusinessValidatorInsert : BaseBusinessRuleValidator<CompaniaAerea>
    {

        public CompaniaAereaBusinessValidatorInsert(IBaseQueryRepository<CompaniaAerea> query) : base(query)
        {
        }

        public async override Task<bool> ValidateAsync(CompaniaAerea entity)
        {
            var companiaAereaTask = CheckExistsAsync(
                x => x.Nome.ToLower() == entity.Nome.ToLower(),
                result => result.Any(),
                e => $"Compania aérea {e.Nome.CapitalizeWords()} já cadastrada!",
                null
            );

            var result = await Task.WhenAll(companiaAereaTask).ConfigureAwait(false);
            
            return !companiaAereaTask.Result;

        }


    }
}
