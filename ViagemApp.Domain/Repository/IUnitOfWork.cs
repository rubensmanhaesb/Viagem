using DomainSharedLib.Repository;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Repository
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        public IBaseRepository<CompanhiaAerea> CompaniaAereaRepository { get; }
        public IBaseRepository<ProgramaFidelidade> ProgramaFidelidadeRepository { get; }
    }
}