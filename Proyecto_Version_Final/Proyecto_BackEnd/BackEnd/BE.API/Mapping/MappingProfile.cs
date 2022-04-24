using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = BE.DAL.DO.Objects;

namespace BE.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Enfermedades, DataModels.Enfermedades>().ReverseMap();
            CreateMap<data.Biblioteca, DataModels.Biblioteca>().ReverseMap();
            CreateMap<data.Events, DataModels.Events>().ReverseMap();
            CreateMap<data.Expedientes, DataModels.Expedientes>().ReverseMap();
            CreateMap<data.Inventarios, DataModels.Inventarios>().ReverseMap();
            CreateMap<data.Pagos, DataModels.Pagos>().ReverseMap();
            CreateMap<data.SchedulerRecurringEvent, DataModels.SchedulerRecurringEvent>().ReverseMap();
            CreateMap<data.TipoPago, DataModels.TipoPago>().ReverseMap();
            CreateMap<data.TipoProducto, DataModels.TipoProducto>().ReverseMap();
            CreateMap<data.TipoUsuario, DataModels.TipoUsuario>().ReverseMap();
            CreateMap<data.Usuario, DataModels.Usuario>().ReverseMap();
        }
    }
}
