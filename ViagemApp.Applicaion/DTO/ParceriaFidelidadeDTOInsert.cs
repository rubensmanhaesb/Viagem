
namespace ViagemApp.Application.DTO
{
    public record ParceriaFidelidadeDTOInsert
    {
        public Guid IdCompaniaAerea { get; set; }
        public Guid IdProgramaFidelidade { get; set; }
        public int? QtdLimiteCpf { get; set; }
    }
}
