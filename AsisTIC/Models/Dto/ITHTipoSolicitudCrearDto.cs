using System.ComponentModel.DataAnnotations;

namespace AsisTIC.Models.Dto
{
    public class ITHTipoSolicitudCrearDto
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
