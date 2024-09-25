
namespace ViagemApp.Domain.Entities
{
    public class ParceriaFidelidade
    {
        public Guid IdCompanhiaAeria { get; set; }
        public Guid IdProgramaFidelidade { get; set; }
        public int? QtdLimiteCpf { get; set; }

        #region Relacionamentos
        public CompanhiaAerea? CompanhiaAeria { get; set; }
        public ProgramaFidelidade? ProgramaFidelidade { get; set; }
        #endregion
    }
}
