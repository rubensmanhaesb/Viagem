
namespace ViagemApp.Application.DTO
{
    public record ParceriaFidelidadeDTODelete
    {
        public Guid IdCompaniaAerea { get; set; }

        public Guid IdProgramaFidelidade{ get; set; }
    }
}
