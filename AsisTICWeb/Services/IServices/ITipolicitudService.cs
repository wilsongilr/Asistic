using AsisTICWeb.Models.Dto;

namespace AsisTICWeb.Services.IServices
{
    public interface ITipolicitudService
    {
        Task<T>ObtenerTodos<T>();
        Task<T>Obtener<T>(int id);
        Task<T> Crear<T>(ITHTipoSolicitudCrearDto dto);
        Task<T> Actualizar<T>(ITHTipoSolicitudUpdateDto dto);
    }
}
