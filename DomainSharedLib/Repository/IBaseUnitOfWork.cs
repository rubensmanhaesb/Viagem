
namespace DomainSharedLib.Repository
{
    public interface IBaseUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
