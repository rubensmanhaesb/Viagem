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
            CreateMap<CompaniaAereaDTOInsert, CompaniaAerea>()
                .AfterMap((dto, entity) => { entity.Id = Guid.NewGuid(); });

            CreateMap<CompaniaAereaDTOUpdate, CompaniaAerea>();
            CreateMap<CompaniaAereaDTODelete, CompaniaAerea>();
            CreateMap<CompaniaAereaDTOResponse, CompaniaAerea>();
            CreateMap<CompaniaAerea, CompaniaAereaDTOResponse>();

        }
    }
}
