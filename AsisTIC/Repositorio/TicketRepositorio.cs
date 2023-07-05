using AsisTIC.Contexts;
using AsisTIC.Models;
using AsisTIC.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsisTIC.Repositorio
{
    public class TicketRepositorio : Repositorio<ITHTicket>, ITicketRepositorio
    {


        private readonly ApplicationDbContext _context;
        
        public TicketRepositorio(ApplicationDbContext context) :base(context) 
        {
            _context = context; 
            
        }

        public async Task<ITHTicket> Actualizar(ITHTicket entidad)
        {
            entidad.FechaSolicitud = DateTime.Now;
            _context.ITHticket.Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
