﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace DomainSharedLib.Repository { 

    public interface IBaseRepository<T> : IBaseQueryRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
