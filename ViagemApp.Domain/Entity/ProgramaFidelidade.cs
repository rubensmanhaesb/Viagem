using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemApp.Domain.Entities
{
    public class ProgramaFidelidade
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        #region Relacionamentos
        public ICollection<ParceriaFidelidade>? ParceriaFidelidade { get; set; }
        #endregion
    }
}
