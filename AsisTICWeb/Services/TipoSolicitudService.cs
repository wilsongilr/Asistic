using AsisTIC_Utilidad;
using AsisTICWeb.Models;
using AsisTICWeb.Models.Dto;
using AsisTICWeb.Services.IServices;

namespace AsisTICWeb.Services
{
    public class TipoSolicitudService : BaseService, ITipolicitudService
    {

        public readonly IHttpClientFactory httpClientFactory;
        private string _ticketTipoSolicitudUrl;
        public TipoSolicitudService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            httpClientFactory = httpClient;

            _ticketTipoSolicitudUrl = configuration.GetValue<string>("ServiceUrls:API_URL");
        }

        public Task<T> Actualizar<T>(ITHTipoSolicitudUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _ticketTipoSolicitudUrl + "/api/ITHTicket/" + dto.idsolicitud
            });
        }

        public Task<T> Crear<T>(ITHTipoSolicitudCrearDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.POST,
                Datos = dto,
                Url = _ticketTipoSolicitudUrl + "/api/ITHTicketTipoSolicitud"
            });
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _ticketTipoSolicitudUrl + "/api/ITHTicketTipoSolicitud/" + id
            });
        }

       

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _ticketTipoSolicitudUrl + "/api/ITHTicketTipoSolicitud/"
            });
        }
    }
}
