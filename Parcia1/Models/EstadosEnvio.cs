using System.ComponentModel.DataAnnotations;

namespace Parcia1.Models
{
    public class EstadosEnvio
    {
        [Key]
        public int EstadoId { get; set; }

        [Required]
        public string NombreEstado { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public ICollection<Envios> Envio { get; set; }
    }
}
