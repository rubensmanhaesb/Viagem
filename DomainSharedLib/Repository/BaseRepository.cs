﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DomainSharedLib.Repository
{
    public class BaseRepository<T>
        : IBaseRepository<T>, IDisposable
        where T : class
    {
        private readonly DbSet<T> _dbSet;
        private DbContext _dbContext;

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
            Expression<Func<T, object>>[] includes = null,
            CancellationToken cancellationToken = default)
        {
            using (var query = new BaseQueryRepository<T>(_dbContext)) 
            { 
                return await query.GetByConditionAsync(pageSize: pageSize, pageNumber: pageNumber,
                    predicate: predicate, orderBy: orderBy, isAscending: isAscending, includes: includes, cancellationToken ).ConfigureAwait(false);
            }
        }

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual void Update(T entity) => _dbSet.Update(entity);

        public virtual void Delete(T entity) => _dbSet.Remove(entity);

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
