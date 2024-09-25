using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Domain.DTO;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Mappings
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
