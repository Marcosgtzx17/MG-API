using Microsoft.EntityFrameworkCore;
using PracticaAPI.Entidades;

namespace PracticaAPI.Repositorios
{
    public class appDBContext : DbContext
    {
        public appDBContext(DbContextOptions<appDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<CategoriaMG> CategoriasMG { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------- usuarios --------
            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("usuarios");           // nombre real en MySQL
                e.HasKey(x => x.Id);

                e.Property(x => x.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(x => x.Email)
                    .HasMaxLength(150)
                    .IsRequired();

                e.Property(x => x.PasswordHash)
                    .HasMaxLength(255)
                    .IsRequired();

                e.HasIndex(x => x.Email).IsUnique(); // email único

                e.HasOne(x => x.Rol)
                 .WithMany(r => r.Usuarios)
                 .HasForeignKey(x => x.RolId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // -------- rol --------
            modelBuilder.Entity<Rol>(e =>
            {
                e.ToTable("rol");                 // nombre real en MySQL
                e.HasKey(x => x.Id);

                e.Property(x => x.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // -------- CategoriaMG --------
            modelBuilder.Entity<CategoriaMG>(e =>
            {
                e.ToTable("CategoriaMG");        // EXACTO como en tu CREATE TABLE
                e.HasKey(x => x.Id);

                e.Property(x => x.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(x => x.Descripcion)
                    .HasMaxLength(255);
            });
        }
    }
}