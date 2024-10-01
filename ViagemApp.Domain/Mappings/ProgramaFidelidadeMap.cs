using AutoMapper;
using ViagemApp.Domain.DTO;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Mappings
{
    public class ProgramaFidelidadeMap : Profile
    {
        public ProgramaFidelidadeMap()
        {
            CreateMap<ProgramaFidelidadeDTOInsert, ProgramaFidelidade>()
                .AfterMap((dto, entity) => { entity.Id = Guid.NewGuid(); });

            CreateMap<ProgramaFidelidadeDTOUpdate,   ProgramaFidelidade>();
            CreateMap<ProgramaFidelidadeDTODelete,   ProgramaFidelidade>();
            CreateMap<ProgramaFidelidadeDTOResponse, ProgramaFidelidade>();
            CreateMap<ProgramaFidelidade, ProgramaFidelidadeDTOResponse>();

        }
    }
}
