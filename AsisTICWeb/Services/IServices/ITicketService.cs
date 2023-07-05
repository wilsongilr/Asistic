using AsisTICWeb.Models.Dto;

namespace AsisTICWeb.Services.IServices
{
    public interface ITicketService
    {
        Task<T> ObtenerTodos<T>();
        Task<T> Obtener<T>(int id);
        Task<T> Crear<T>(ITHTickeCreatetDto dto);
        Task<T> Actualizar<T>(ITHTicketUpdateDto dto);
    }
}
