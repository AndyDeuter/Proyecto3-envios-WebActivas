using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcia1.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public int RolUsuarioId { get; set; }

        [ForeignKey("RolUsuarioId")]
        public RolUsuario RolUsuario { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Envios> Envio { get; set; }
    }
}

