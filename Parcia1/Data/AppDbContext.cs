using Microsoft.EntityFrameworkCore;
using Parcia1.Models;

namespace Parcia1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Envios> Envio { get; set; }

        public DbSet<Destinatarios> Destinatarios { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Paquetes> Paquetes { get; set; }

        public DbSet<EstadosEnvio> EstadosEnvio { get; set; }



    }
}
