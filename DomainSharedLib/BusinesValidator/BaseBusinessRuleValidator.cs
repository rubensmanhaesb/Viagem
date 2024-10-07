using DomainSharedLib.Context;
using DomainSharedLib.Repository;
using FluentValidation;
using System.Linq.Expressions;



namespace DomainSharedLib.BusinesValidator
{
    public abstract class BaseBusinessRuleValidator<T> : AbstractValidator<T>, IBaseQueryRepository<T>  where T : class
    {
        private readonly IDbContextFactory _dbContextFactory;

        protected BaseBusinessRuleValidator(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<T?>> GetByConditionAsync(int? pageSize = null, int? pageNumber = null, Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] orderBy = null, bool isAscending = true, Expression<Func<T, object>>[] includes = null)
        {
            using (var query = new BaseQueryRepository<T>(_dbContextFactory.CreateDbContext()))
            {
                var result = await query.GetByConditionAsync(pageSize, pageNumber, predicate, orderBy, isAscending, includes).ConfigureAwait(false);

                return result;
            }

        }
    }

}
