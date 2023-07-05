using System.ComponentModel.DataAnnotations;

namespace AsisTICWeb.Models.Dto
{
    public class ITHTipoSolicitudCrearDto
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
