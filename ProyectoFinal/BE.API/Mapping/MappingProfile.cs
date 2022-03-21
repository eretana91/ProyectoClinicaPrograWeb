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
            CreateMap<data.Citas, DataModels.Citas>().ReverseMap();
            CreateMap<data.CitasProgramadas, DataModels.CitasProgramadas>().ReverseMap();
            CreateMap<data.Direccion, DataModels.Direccion>().ReverseMap();
            CreateMap<data.Doctor, DataModels.Doctor>().ReverseMap();
            CreateMap<data.Expediente, DataModels.Expediente>().ReverseMap();
            CreateMap<data.Paciente, DataModels.Paciente>().ReverseMap();
            CreateMap<data.Persona, DataModels.Persona>().ReverseMap();
            CreateMap<data.ReporteCitas, DataModels.ReporteCitas>().ReverseMap();
            CreateMap<data.TipoUsuario, DataModels.TipoUsuario>().ReverseMap();
            CreateMap<data.Usuarios, DataModels.Usuarios>().ReverseMap();
        }
    }
}
