using AsisTIC.Models;

namespace AsisTIC.Repositorio.IRepositorio
{
    public interface ITicketRepositorio :IRepositorio<ITHTicket>
    {
        Task<ITHTicket> Actualizar(ITHTicket entidad);
    }
}
