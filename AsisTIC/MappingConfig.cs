using AsisTIC.Models;
using AsisTIC.Models.Dto;
using AutoMapper;
namespace AsisTIC
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            //Forma 1 de hacer el reverse
            CreateMap<ITHTicket, ITHTicketDto>();
            CreateMap<ITHTicketDto, ITHTicket>();

            //Forma 2 de hacer reverse, de las dos formas funciona 
            CreateMap<ITHTicket,ITHTickeCreatetDto>().ReverseMap();
            CreateMap<ITHTicket, ITHTicketUpdateDto>().ReverseMap();

            CreateMap<ITHTipoSolicitud, ITHTipoSolicitudDto>().ReverseMap();
            CreateMap<ITHTipoSolicitud, ITHTipoSolicitudCrearDto>().ReverseMap();
            CreateMap<ITHTipoSolicitud, ITHTipoSolicitudUpdateDto>().ReverseMap();

            

        }
    }
}
