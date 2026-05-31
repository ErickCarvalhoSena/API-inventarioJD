

using Microsoft.EntityFrameworkCore;
using OficinaJD.API.Models;

namespace OficinaJD.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<PecaModelo> PecaModelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PecaModelo>().HasKey(pm => new { pm.PecaId, pm.ModeloId});

            modelBuilder.Entity<Peca>().ToTable("pecas");
            modelBuilder.Entity<Modelo>().ToTable("modelos");
            modelBuilder.Entity<PecaModelo>().ToTable("pecas_modelos");
            
        }
    }
}