using AsisTICWeb.Models.Dto;
using AutoMapper;

namespace AsisTICWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ITHTicketDto, ITHTickeCreatetDto>().ReverseMap();
            CreateMap<ITHTicketDto, ITHTicketUpdateDto>().ReverseMap();
            CreateMap<ITHTipoSolicitudDto, ITHTipoSolicitudCrearDto>().ReverseMap();
            CreateMap<ITHTipoSolicitudDto, ITHTipoSolicitudUpdateDto>().ReverseMap();
        }
    }
}
