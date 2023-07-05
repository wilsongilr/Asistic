using AsisTIC.Contexts;
using AsisTIC.Models;
using AsisTIC.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsisTIC.Repositorio
{
    public class TicketTipoSolicitudRepositorio : Repositorio<ITHTipoSolicitud>, ITicketTipoSolicitudRepositorio
    {


        private readonly ApplicationDbContext _context;
        
        public TicketTipoSolicitudRepositorio(ApplicationDbContext context) :base(context) 
        {
            _context = context; 
            
        }

        public async Task<ITHTipoSolicitud> Actualizar(ITHTipoSolicitud entidad)
        {


            entidad.Activo = true;
            _context.ITHtipoSolicitud.Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
