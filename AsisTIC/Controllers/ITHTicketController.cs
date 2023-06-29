using AsisTIC.Contexts;
using AsisTIC.Models;
using AsisTIC.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsisTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITHTicketController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly ApplicationDbContext _context;

        public ITHTicketController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ITHTicketDto>>> GetTickets()
        {
            return Ok(await _context.ITHticket.ToListAsync());
        }

        [HttpGet("id:int", Name ="GetTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ITHTicketDto>> GetTickets(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var ticket = await _context.ITHticket.FirstOrDefaultAsync(t => t.IdTicket  == id); 

            if(ticket==null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ITHTicketDto>> CrearTicket([FromBody] ITHTickeCreatetDto ticketdto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);    
            }

            if(ticketdto == null)
            {
                return BadRequest(ticketdto);
            }

            ITHTicket modelo = new()
            {
            //    IdTicket = ticketdto.IdTicket,
                Solicitud = ticketdto.Solicitud,
                Descripcion = ticketdto.Descripcion,
                IdSolicitud = ticketdto.IdSolicitud,
                IdEstado = ticketdto.IdEstado,
                UsrSolicita = ticketdto.UsrSolicita,
                FechaSolicitud = DateTime.Now

            };

           await _context.ITHticket.AddAsync(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetTicket", new { id = modelo.IdTicket }, modelo);

        }

    }
}
