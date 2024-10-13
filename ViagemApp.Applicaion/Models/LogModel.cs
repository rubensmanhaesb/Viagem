using DomainSharedLib.Shared;


namespace ViagemApp.Application.Models
{

    public class LogModel
    {
        public Guid? Id { get; set; }
        public CrudOperation TipoOperacao { get; set; }
        public DateTime? DataOperacao { get; set; }
        public List<Guid?> ObjectIds { get; set; }
        public string? Dados { get; set; }
    }


}



