using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcia1.Models
{
    public class Envios
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]

        public Usuario Usuario { get; set; }

        [Required]
        public int DestinatariosId { get; set; }

        [ForeignKey("DestinatariosId")]

        public Destinatarios Destinatarios { get; set; }

        [Required]
        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public EstadosEnvio EstadosEnvio { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaEntrega { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }

        [Required]
        public int RolUsuarioId { get; set; }
        
        [ForeignKey("RolUsuarioId")]
        public RolUsuario RolUsuario { get; set; }


    }
}
