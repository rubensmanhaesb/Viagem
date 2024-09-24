using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service
{
    public interface ICompaniaAereaDomainService
    {
        Task<CompaniaAerea> UpdateAsync(CompaniaAerea entity);
        Task<CompaniaAerea> DeleteAsync(CompaniaAerea entity);
        Task<CompaniaAerea> AddAsync(CompaniaAerea entity);
        Task<IEnumerable<CompaniaAerea?>> GetByConditionAsync(
            int pageSize = 10,
            int pageNumber = 1,
            Expression<Func<CompaniaAerea, bool>> predicate = null,
            Expression<Func<CompaniaAerea, object>>[] orderBy = null,
            bool isAscending = true,
            Expression<Func<CompaniaAerea, object>>[] includes = null);
    }
}

