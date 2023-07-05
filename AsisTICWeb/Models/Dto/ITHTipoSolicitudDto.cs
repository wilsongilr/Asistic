using System.ComponentModel.DataAnnotations;

namespace AsisTICWeb.Models.Dto
{
    public class ITHTipoSolicitudDto
    {
        [Key]
        public int IdSolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
