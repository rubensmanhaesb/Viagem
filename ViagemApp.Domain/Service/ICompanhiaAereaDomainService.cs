using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service
{
    public interface ICompanhiaAereaDomainService
    {
        Task<CompanhiaAerea> UpdateAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> DeleteAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> AddAsync(CompanhiaAerea entity);
        Task<IEnumerable<CompanhiaAerea?>> GetByConditionAsync(
            int pageSize = 10,
            int pageNumber = 1,
            Expression<Func<CompanhiaAerea, bool>> predicate = null,
            Expression<Func<CompanhiaAerea, object>>[] orderBy = null,
            bool isAscending = true,
            Expression<Func<CompanhiaAerea, object>>[] includes = null);
    }
}

