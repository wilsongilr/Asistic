using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsisTICWeb.Models.Dto
{
    public class ITHTickeCreatetDto
    {
       
        [Required(ErrorMessage ="Tipo Solicitud Es Requerido")]
        public int IdSolicitud { get; set; }
        [Required(ErrorMessage ="Solicitud es requerido")]
        public string Solicitud { get; set; }
        [Required(ErrorMessage ="Descripción es requerido")]
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string UsrSolicita { get; set; } 
    //    public DateTime FechaSolicitud { get; set;}
      
    }


  
}
