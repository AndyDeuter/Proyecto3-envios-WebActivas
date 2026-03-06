using System.ComponentModel.DataAnnotations;

namespace Parcia1.Models
{
    public class Destinatarios
    {
        [Key]
        public int DestinatariosId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Pais { get; set; }

        public ICollection<Envios> Envio { get; set; }
    }
}
