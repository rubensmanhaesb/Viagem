using DomainSharedLib.Repositories;
using DomainSharedLib.Repository;
using System.Linq.Expressions;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service
{
    public interface ICompanhiaAereaDomainService : IBaseQueryRepository<CompanhiaAerea>
    {
        Task<CompanhiaAerea> UpdateAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> DeleteAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> AddAsync(CompanhiaAerea entity);
    }
}

