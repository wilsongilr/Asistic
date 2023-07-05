using AsisTIC_Utilidad;
using AsisTICWeb.Models;
using AsisTICWeb.Models.Dto;
using AsisTICWeb.Services.IServices;

namespace AsisTICWeb.Services
{
    public class TicketService : BaseService, ITicketService
    {

        public readonly IHttpClientFactory _httpClient;
        private string _ticketUrl;





        public TicketService(IHttpClientFactory httpClient, IConfiguration configuration) :base(httpClient)
        {
            _httpClient = httpClient;

            _ticketUrl = configuration.GetValue<string>("ServiceUrls:API_URL");

        }

        public Task<T> Actualizar<T>(ITHTicketUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _ticketUrl + "/api/ITHTicket/"+dto.IdTicket
            });
        }

        public Task<T> Crear<T>(ITHTickeCreatetDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.POST,
                Datos = dto,
                Url = _ticketUrl + "/api/ITHTicket"
            });
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _ticketUrl + "/api/ITHTicket/" + id
            });
        }

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _ticketUrl + "/api/ITHTicket/"
            });
        }
    }
}
