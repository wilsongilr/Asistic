using AsisTIC.Contexts;
using AsisTIC.Models;
using AsisTIC.Models.Dto;
using AsisTIC.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Net;

namespace AsisTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITHTicketTipoSolicitudController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //Reemplazamos el dbcontext para utilizar los repositorios
        //public readonly ApplicationDbContext _context;
        private readonly ITicketRepositorio _ticketRepositorio;
        private readonly ITicketTipoSolicitudRepositorio _ticketsolicitudrepositorio;    
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public ITHTicketTipoSolicitudController(ITicketRepositorio ticketRepositorio, ITicketTipoSolicitudRepositorio ticketTipoSolicitudRepositorio, IConfiguration configuration, IMapper mapper)
        {
            _ticketRepositorio = ticketRepositorio;
            _ticketsolicitudrepositorio = ticketTipoSolicitudRepositorio;
            _configuration = configuration;
            _mapper = mapper;
            _response = new();
        }


        //--Esta opcion es sin el mapper///
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<ITHTicketDto>>> GetTickets()
        //{
        //    return Ok(await _context.ITHticket.ToListAsync());
        //}


        //--Esta opcion es con el mapper mejor así///
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<ITHTicketDto>>> GetTickets()
        public async Task<ActionResult<ApiResponse>> GetTipoSolicitudes()
        {

            //Creamos una list
            //IEnumerable<ITHTicket> ticketList = await _context.ITHticket.ToListAsync(); Este se reemplaza para utilizar los repositorios

            try
            {
                IEnumerable<ITHTipoSolicitud> tiposolicitudList = await _ticketsolicitudrepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<ITHTipoSolicitudDto>>(tiposolicitudList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessage = new List<string>() { ex.Message.ToString() }; 
            }
           return _response;

        }


        //--Esta opcion es sin el mapper///
        //[HttpGet("id:int", Name ="GetTicket")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<ActionResult<ITHTicketDto>> GetTickets(int id)
        //{
        //    if(id==0)
        //    {
        //        return BadRequest();
        //    }
        //    var ticket = await _context.ITHticket.FirstOrDefaultAsync(t => t.IdTicket  == id); 

        //    if(ticket==null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(ticket);
        //}


        //--Esta opcion es con el mapper mejor así///
        [HttpGet("id:int", Name = "GetTiipoSolicitud")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiResponse>> GetTipoSolicitudes(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                //var ticket = await _context.ITHticket.FirstOrDefaultAsync(t => t.IdTicket == id); se reepmplaza por repositorio
                            var tiposolicitud = await _ticketsolicitudrepositorio.Obtener(t => t.idsolicitud == id);

                if (tiposolicitud == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }

                _response.Resultado = _mapper.Map<ITHTipoSolicitudDto>(tiposolicitud);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.ErrorMessage = new List<string>() { ex.Message.ToString() };
            }
            return _response;   
         
        }

        //--Esta opcion es sin el mapper///
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public async Task<ActionResult<ITHTicketDto>> CrearTicket([FromBody] ITHTickeCreatetDto ticketdto)
        //{
        //    if(!ModelState.IsValid) 
        //    {
        //        return BadRequest(ModelState);    
        //    }

        //    if(ticketdto == null)
        //    {
        //        return BadRequest(ticketdto);
        //    }

        //    ITHTicket modelo = new()
        //    {
        //    //    IdTicket = ticketdto.IdTicket,
        //        Solicitud = ticketdto.Solicitud,
        //        Descripcion = ticketdto.Descripcion,
        //        IdSolicitud = ticketdto.IdSolicitud,
        //        IdEstado = ticketdto.IdEstado,
        //        UsrSolicita = ticketdto.UsrSolicita,
        //        FechaSolicitud = DateTime.Now

        //    };

        //   await _context.ITHticket.AddAsync(modelo);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtRoute("GetTicket", new { id = modelo.IdTicket }, modelo);

        //}

        //--Esta opcion es con el mapper mejor así///
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ApiResponse>> CrearTipoSolicitud([FromBody] ITHTipoSolicitudCrearDto CrearsolicituDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (CrearsolicituDto == null)
                {
                    return BadRequest(CrearsolicituDto);
                }

                if(await _ticketsolicitudrepositorio.Obtener(s => s.solicitud == CrearsolicituDto.solicitud) != null )
                {
                    ModelState.AddModelError("SolicitudExiste", "El nombre de solicitud ya existe");
                    return BadRequest(ModelState);
                }

                ITHTipoSolicitud modelo = _mapper.Map<ITHTipoSolicitud>(CrearsolicituDto);
                //await _context.ITHticket.AddAsync(modelo);

                await _ticketsolicitudrepositorio.Crear(modelo);
                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.Created;

                //await _context.SaveChangesAsync();

                //await _ticketRepositorio.Grabar();

                return CreatedAtRoute("GetTiipoSolicitud", new { id = modelo.idsolicitud }, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessage = new List<string>() { ex.Message.ToString() };    
            }

            return _response;

        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateTipoSolicitud(int id, [FromBody] ITHTipoSolicitudUpdateDto updateDTO)
        {
            if(updateDTO == null || id != updateDTO.idsolicitud)
            {
                _response.IsExitoso = false;
                _response.StatusCode=HttpStatusCode.NoContent;
                return BadRequest(_response);
            }
            ITHTipoSolicitud modelo = _mapper.Map<ITHTipoSolicitud>(updateDTO);
            await _ticketsolicitudrepositorio.Actualizar(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }

    }
}
