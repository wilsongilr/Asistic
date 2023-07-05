using System.ComponentModel.DataAnnotations;

namespace AsisTICWeb.Models.Dto
{
    public class ITHTipoSolicitudUpdateDto
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
