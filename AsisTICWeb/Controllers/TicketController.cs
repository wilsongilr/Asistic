using AsisTICWeb.Models;
using AsisTICWeb.Models.Dto;
using AsisTICWeb.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AsisTICWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITipolicitudService _tipolicitudService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService,ITipolicitudService tipolicitudService, IMapper mapper)
        {
            _ticketService = ticketService;
            _tipolicitudService = tipolicitudService;
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
            List<ITHTipoSolicitudDto> tipoSolicitudList = new();

            var lista = await _tipolicitudService.ObtenerTodos<ApiResponse>();
            if (lista != null && lista.IsExitoso)
            {
                tipoSolicitudList = JsonConvert.DeserializeObject<List<ITHTipoSolicitudDto>>(Convert.ToString(lista.Resultado));
            }

            List<SelectListItem> items = tipoSolicitudList.ToList().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.solicitud.ToString().ToUpper(),
                    Value = d.IdSolicitud.ToString(),
                    Selected = false
                };
            });


         //   var FromTipoSolicitud = new SelectList(tipoSolicitudList.ToList(), "IdSolicitud", "Solicitud");
            ViewBag.items = items;
            //ViewBag.Lista = FromTipoSolicitud;
            return View();
        
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTicket(ITHTickeCreatetDto modelo, ITHTipoSolicitudDto modelotipo)
        {
           
            //ViewBag["DBTipoSolicitud"] = FromTipoSolicitud;
            //ViewData["DBTipoSolicitud"] = FromTipoSolicitud;


            //using (  cshparpEntity = new CSharpCornerEntities())
            //{
            //    var fromDatabaseEF = new SelectList(cshparpEntity.MySkills.ToList(), "ID", "Name");
            //    ViewData["DBMySkills"] = fromDatabaseEF;
            //}
            if (!ModelState.IsValid)
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
