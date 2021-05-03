using AutoMapper;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ArticulosStock, ArticulosStockDTO>()
                .ForMember(a => a.vehiculoMarcaDescripcion, x => x.MapFrom(b => b.Vehiculo.Marca.Descripcion))
                .ForMember(a => a.vehiculoModeloDescripcion, x => x.MapFrom(b => b.Vehiculo.Modelo.Descripcion));
        }
    }
}
