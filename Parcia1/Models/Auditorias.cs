using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcia1.Models
{
    public class Auditorias
    {
        public int Id { get; set; }

        [Required]
        public int RolId { get; set; }

        [Required]
        public int RolUsuarioId { get; set; }

        [ForeignKey("RolUsuarioId")]
        public RolUsuario RolUsuario { get; set; }

        [Required]
        public string Accion {  get; set; }

        [Required]
        public DateTime FechaAccion { get; set; } = DateTime.Now;

        [Required]
        public string Detalles { get; set; }
    }
}
