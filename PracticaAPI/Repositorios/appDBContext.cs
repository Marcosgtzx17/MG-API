using Microsoft.EntityFrameworkCore;
using PracticaAPI.Entidades;
using System.Collections.Generic;


using System.Reflection.Emit;


namespace PracticaAPI.Repositorios
{
    
        public class appDBContext : DbContext

        {

            public appDBContext(DbContextOptions<appDBContext> options)

                : base(options)

            {
            }

            public DbSet<Usuario> Usuarios { get; set; }

            public DbSet<Rol> Roles { get; set; }
           public DbSet<CategoriaMG> CategoriasMG { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

            {

                base.OnModelCreating(modelBuilder);



                // Email unico

                modelBuilder.Entity<Usuario>()

                    .HasIndex(u => u.Email)

                    .IsUnique();



                // Relacion 1 Rol -> N Usuarios

                modelBuilder.Entity<Usuario>()

                    .HasOne(u => u.Rol)

                    .WithMany(r => r.Usuarios)

                    .HasForeignKey(u => u.RolId);

            }
        }
    
}

