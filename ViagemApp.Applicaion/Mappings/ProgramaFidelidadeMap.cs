using AutoMapper;
using ViagemApp.Application.DTO;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Application.Mappings
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
