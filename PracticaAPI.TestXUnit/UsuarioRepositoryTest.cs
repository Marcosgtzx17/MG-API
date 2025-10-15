using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticaAPI.Entidades;
using PracticaAPI.Repositorios;

namespace PracticaAPI.TestXUnit
{
    public class UsuarioRepositorytest
    {

        private appDBContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<appDBContext>()
                .UseInMemoryDatabase(databaseName: $"TestDB_{System.Guid.NewGuid()}").Options;

            var context = new appDBContext(options);

            context.Roles.Add(
                new Rol { Id = 1, Nombre = "Admin" }
            );
            context.Usuarios.Add(
                new Usuario
                {
                    Id = 2,
                    Nombre = "Marcos",
                    Email = "marcos@test.com",
                    PasswordHash = "12345",
                    RolId = 1
                }
            );

            context.SaveChanges();
            return context;
        }


        [Fact]
        public async Task GetByEmailAsync_RetonarUsuarioexistente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);
            // Act
            var usuario = await repo.GetByEmailAsync("marcos@test.com");

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("Marcos", usuario.Nombre);
            Assert.Equal("Admin", usuario.Rol.Nombre);  
        }

        [Fact]
        public  async Task AddAsync_AgregarUsuario()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            var nuevoUsuario =new Usuario()
            {
                Nombre = "Halland",
                Email = "halland@test.com",
                PasswordHash = "12345",
                RolId = 1

            };

            //Act
            await repo.AddAsync(nuevoUsuario);

            //Assert
            var usuarioGuardado = await context.Usuarios.FirstOrDefaultAsync( u => u.Email == "halland@test.com");
            Assert.NotNull(usuarioGuardado);
            Assert.Equal("Halland", usuarioGuardado.Nombre);
            }


        [Fact]
        public async Task GetAllUsuariosAsync_RetornarListadoUsuarios()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);
            //Act
            var lista = await repo.GetAllUsuariosAsync();
            //Assert
            Assert.NotEmpty(lista);
            Assert.Contains(lista, u => u.Email == "marcos@test.com");
        }


    }
}