using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcia1.Models
{
    public class Paquetes
    {
        [Key]
        public int PaquetesId { get; set; }

        public int EnvioId { get; set; }

        [ForeignKey("EnvioId")]
        public Envios Envios { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal peso { get; set; }

        public ICollection<Envios> Envio { get; set; }
    }
}
