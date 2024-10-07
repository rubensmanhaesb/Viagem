using System.Linq.Expressions;

namespace DomainSharedLib.Repository
{
    public interface IBaseQueryRepository<T> where T : class
    {

        Task<IEnumerable<T?>> GetByConditionAsync(
            int? pageSize = null,
            int? pageNumber = null,
            Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, object>>[] orderBy = null,
            bool isAscending = true,
            Expression<Func<T, object>>[] includes = null,
            CancellationToken cancellationToken = default);
    }
}
