
namespace ViagemApp.Domain.DTO
{
    public class ParceriaFidelidadeDTOInsert
    {
        public Guid IdCompaniaAerea { get; set; }
        public Guid IdProgramaFidelidade { get; set; }
        public int? QtdLimiteCpf { get; set; }
    }
}
