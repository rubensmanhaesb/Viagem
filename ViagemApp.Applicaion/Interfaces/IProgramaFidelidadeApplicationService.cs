using ViagemApp.Application.DTO;


namespace ViagemApp.Applicaion.Interfaces
{
    public interface IProgramaFidelidadeApplicationService : IDisposable
    {
        Task<ProgramaFidelidadeDTOResponse> UpdateAsync(ProgramaFidelidadeDTOUpdate entity);
        Task<ProgramaFidelidadeDTOResponse> DeleteAsync(ProgramaFidelidadeDTODelete entity);
        Task<ProgramaFidelidadeDTOResponse> AddAsync(ProgramaFidelidadeDTOInsert entity);
        Task<List<ProgramaFidelidadeDTOResponse>> Get();
    }
}
