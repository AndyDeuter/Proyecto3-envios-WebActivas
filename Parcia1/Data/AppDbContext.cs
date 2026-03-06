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

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Paquetes> Paquetes { get; set; }

        public DbSet<EstadosEnvio> EstadosEnvio { get; set; }

        public DbSet<RolUsuario> RolUsuario { get; set; }

        public DbSet<Auditorias> Auditorias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Envios>()
                .HasOne(e => e.RolUsuario)
                .WithMany()
                .HasForeignKey(e => e.RolUsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Envios>()
                .HasOne(e => e.Destinatarios)
                .WithMany(d => d.Envio)
                .HasForeignKey(e => e.DestinatariosId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Envios>()
                .Property(p => p.Costo)
                .HasColumnType("decimal(10,2)");
        }


    }
}
