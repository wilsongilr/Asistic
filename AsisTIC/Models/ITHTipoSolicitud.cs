using System.ComponentModel.DataAnnotations;

namespace AsisTIC.Models
{
    public class ITHTipoSolicitud
    {
        [Key]
        public int idsolicitud { get; set; }
        [Required]
        public string solicitud { get; set; }
        public bool Activo { get; set; }    


    }
}
