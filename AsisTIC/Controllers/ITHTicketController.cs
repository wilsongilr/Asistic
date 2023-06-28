using AsisTIC.Contexts;
using AsisTIC.Models;
using AsisTIC.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<ITHTicketDto>> GetTickets()
        {
            return Ok(_context.ITHticket.ToList());
        }

        [HttpGet("id:int", Name ="GetTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ITHTicketDto> GetTickets(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var ticket = _context.ITHticket.FirstOrDefault(t => t.IdTicket  == id); 

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

        public ActionResult<ITHTicketDto> CrearTicket([FromBody] ITHTicketDto ticketdto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();    
            }
            if(ticketdto.IdTicket>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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

            _context.ITHticket.Add(modelo);
            _context.SaveChanges();

            return CreatedAtRoute("GetTicket", new { id = ticketdto.IdTicket }, ticketdto);

        }

    }
}
