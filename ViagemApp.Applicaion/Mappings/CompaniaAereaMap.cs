using AutoMapper;
using ViagemApp.Application.DTO;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Application.Mappings
{
    public class CompaniaAereaMap : Profile
    {
        public CompaniaAereaMap()
        {
            CreateMap<CompanhiaAereaDTOInsert, CompanhiaAerea>()
                .AfterMap((dto, entity) => { entity.Id = Guid.NewGuid(); });

            CreateMap<CompanhiaAereaDTOUpdate, CompanhiaAerea>();
            CreateMap<CompanhiaAereaDTODelete, CompanhiaAerea>();
            CreateMap<CompanhiaAereaDTOResponse, CompanhiaAerea>();
            CreateMap<CompanhiaAerea, CompanhiaAereaDTOResponse>();

        }
    }
}
