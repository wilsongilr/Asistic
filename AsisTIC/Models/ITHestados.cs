using System.ComponentModel.DataAnnotations;

namespace AsisTIC.Models
{
    public class ITHestados
    {
        [Key]
        public int Idestado { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
