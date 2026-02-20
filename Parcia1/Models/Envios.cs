using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcia1.Models
{
    public class Envios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]

        public Clientes Clientes { get; set; }

        [Required]
        public int DestinatarioId { get; set; }

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

    }
}
