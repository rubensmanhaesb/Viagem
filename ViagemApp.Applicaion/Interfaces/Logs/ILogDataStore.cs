using ViagemApp.Application.Models;

namespace ViagemApp.Application.Interfaces.Logs
{
    public interface ILogDataStore
    {
        Task AddAsync(LogModel model);

        Task<List<LogModel>> GetAsync(Guid Id, int pageNumber, int pageSize);

        Task<int> GetTotalCountAsync(Guid Id);
    }
}
