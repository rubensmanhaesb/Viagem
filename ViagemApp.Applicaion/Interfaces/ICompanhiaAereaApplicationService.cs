using ViagemApp.Application.DTO;


namespace ViagemApp.Applicaion.Interfaces
{

    public interface ICompanhiaAereaApplicationService : IDisposable
    {
        Task<CompanhiaAereaDTOResponse> UpdateAsync(CompanhiaAereaDTOUpdate dto);
        Task<CompanhiaAereaDTOResponse> DeleteAsync(CompanhiaAereaDTODelete dto);
        Task<CompanhiaAereaDTOResponse> AddAsync(CompanhiaAereaDTOInsert dto);
        Task<List<CompanhiaAereaDTOResponse>> Get();
    }

}
