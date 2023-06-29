using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsisTIC.Models.Dto
{
    public class ITHTickeCreatetDto
    {
       
        [Required]
        public int IdSolicitud { get; set; }
        [Required]
        public string Solicitud { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string UsrSolicita { get; set; } 
      
       
    }
}
