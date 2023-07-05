using System.ComponentModel.DataAnnotations;

namespace AsisTICWeb.Models.Dto
{
    public class ITHestadosDto
    {
        [Key]
        public int Idestado { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
