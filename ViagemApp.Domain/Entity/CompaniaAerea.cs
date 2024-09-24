namespace ViagemApp.Domain.Entities
{
    public class CompaniaAerea
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        #region Relacionamentos
        public ICollection<ParceriaFidelidade>? ParceriaFidelidade { get; set; }
        #endregion
    }
}
