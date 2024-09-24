using DomainSharedLib.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrasctructure.Repositories
{
    public class BaseRepository<T>
        : IBaseRepository<T>, IDisposable
        where T : class
    {
        private readonly DbSet<T> _dbSet;
        private DbContext _dbContext;
        private T _entity;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T?>> GetByConditionAsync(
            int? pageSize = null,
            int? pageNumber = null,
            Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, object>>[] orderBy = null,
            bool isAscending = true,
            Expression<Func<T, object>>[] includes = null)
        {
            var query = new BaseQueryRepository<T>(_dbContext);
            return await query.GetByConditionAsync(pageSize: pageSize, pageNumber: pageNumber, 
                predicate: predicate, orderBy: orderBy, isAscending: isAscending, includes: includes).ConfigureAwait(false);
        }

        public virtual async Task AddAsync(T entity) => _dbSet.Add(entity);

        public virtual async Task UpdateAsync(T entity) => _dbSet.Update(entity);

        public virtual async Task DeleteAsync(T entity) => _dbSet.Remove(entity);

        #region Dispose

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

 
        #endregion

    }
}
