using AsisTIC.Models;

namespace AsisTIC.Repositorio.IRepositorio
{
    public interface ITicketTipoSolicitudRepositorio : IRepositorio<ITHTipoSolicitud>
    {
        Task<ITHTipoSolicitud> Actualizar(ITHTipoSolicitud entidad);
    }
}
