using AsisTICWeb.Models;
using AsisTICWeb.Models.Dto;
using AsisTICWeb.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsisTICWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexTickets()
        {
            List<ITHTicketDto> ticketList = new();

            var response = await _ticketService.ObtenerTodos<ApiResponse>();

            if(response != null && response.IsExitoso) 
            {
                ticketList = JsonConvert.DeserializeObject<List<ITHTicketDto>>(Convert.ToString(response.Resultado));
            }
            return View(ticketList);
        }

        //Get - completario al post
        public async Task<IActionResult> CrearTicket()
        { 
            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTicket(ITHTickeCreatetDto modelo)
        {
            if(!ModelState.IsValid)
            {
                var response = await _ticketService.Crear<ApiResponse>(modelo);

                if(response != null && response.IsExitoso) {
                    return RedirectToAction(nameof(IndexTickets));
                }
            }
            return View(modelo);
        }
    }
}
