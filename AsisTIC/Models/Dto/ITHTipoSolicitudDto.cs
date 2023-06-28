using System.ComponentModel.DataAnnotations;

namespace AsisTIC.Models.Dto
{
    public class ITHTipoSolicitudDto
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
