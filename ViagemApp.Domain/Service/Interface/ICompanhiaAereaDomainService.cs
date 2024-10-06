using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service
{
    public interface ICompanhiaAereaDomainService : IBaseQueryRepository<CompanhiaAerea>, IDisposable
    {
        Task<CompanhiaAerea> UpdateAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> DeleteAsync(CompanhiaAerea entity);
        Task<CompanhiaAerea> AddAsync(CompanhiaAerea entity);
    }
}

