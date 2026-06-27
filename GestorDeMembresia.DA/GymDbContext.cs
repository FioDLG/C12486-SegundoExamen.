using Microsoft.EntityFrameworkCore;
using GestorDeMembresia.Model;

namespace GestorDeMembresia.DA
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        public DbSet<Membresia> Membresias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membresia>(entity =>
            {
                entity.ToTable("Membresias");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Identificacion).IsRequired();
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Apellidos).IsRequired();
                entity.Property(e => e.Telefono).IsRequired();
                entity.Property(e => e.PrecioBaseMensual).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TipoDePlan).IsRequired();
                entity.Property(e => e.FechaDeInicio).IsRequired();
                entity.Property(e => e.FechaDeVencimiento).IsRequired();
                entity.Property(e => e.MontoTotal).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Estado).IsRequired();
            });
        }
    }
}


