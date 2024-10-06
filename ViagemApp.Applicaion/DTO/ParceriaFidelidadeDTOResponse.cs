
namespace ViagemApp.Application.DTO
{
    public record ParceriaFidelidadeDTOResponse
    {
        public Guid IdCompaniaAerea { get; set; }
        public Guid IdProgramaFidelidade { get; set; }
        public int? QtdLimiteCpf { get; set; }
    }
}
