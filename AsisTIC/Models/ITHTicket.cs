﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsisTIC.Models
{
    public class ITHTicket
    {
        [Key]
        public int IdTicket { get; set; }
        [Required]
        [ForeignKey("IdSolicitud")]
        public int IdSolicitud { get; set; }
        [Required]
        public string Solicitud { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [ForeignKey(nameof(IdEstado))]
        public int IdEstado { get; set; }
        public string UsrSolicita { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public bool Adjunto { get; set; }
        

    }
}
