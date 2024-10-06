using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Service
{
    public interface IProgramaFidelidadeDomainService : IBaseQueryRepository<ProgramaFidelidade>, IDisposable
    {
        Task<ProgramaFidelidade> UpdateAsync(ProgramaFidelidade entity);
        Task<ProgramaFidelidade> DeleteAsync(ProgramaFidelidade entity);
        Task<ProgramaFidelidade> AddAsync(ProgramaFidelidade entity);
    }
}
