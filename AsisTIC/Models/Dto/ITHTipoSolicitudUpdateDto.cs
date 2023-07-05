using System.ComponentModel.DataAnnotations;

namespace AsisTIC.Models.Dto
{
    public class ITHTipoSolicitudUpdateDto
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
    }
}
