using System.ComponentModel.DataAnnotations;

namespace Parcia1.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public string Direccion {  get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Envios> Envio { get; set; }
    }
}
