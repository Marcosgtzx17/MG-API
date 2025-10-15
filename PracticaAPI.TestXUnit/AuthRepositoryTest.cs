using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using PracticaAPI.DTOs.UsuarioDTOs;
using PracticaAPI.Entidades;
using PracticaAPI.Interfaces;
using PracticaAPI.Repositorios;

namespace PracticaAPI.TestXUnit
{
    public class AuthRepositoryTest
    {
        private IConfiguration GetTestConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {

                {"Jwt:Key", "ClaveSuperSecretaMuyLargatest1234567890!" },
                {"Jwt:Issuer", "AuthServiceTest"},
                {"Jwt:Audience", "AuthServiceUsers"},



            };
            return new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        }

        [Fact]
        public async Task RegistrarAsync_RetorneUsuarioConToken()
        {
            //Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            var config = GetTestConfiguration();
            var usuario = new Usuario
            {
                Id = 1,
                Nombre = "Marcos",
                Email = "marcos@test.com",
                PasswordHash = "hash",
                Rol = new Rol { Id = 2, Nombre = "Usuario" }
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Usuario>())).ReturnsAsync(usuario);

            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(usuario);

            var service = new AuthRepository(mockRepo.Object, config);

            var registroDTO = new UsuarioRegistroDTO
            {
                Nombre = "Marcos",
                Email = "marcos@test.com",
                Password = "12345"
            };

            //Act
            var result = await service.RegistrarAsync(registroDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Marcos", result.Nombre);
            Assert.Equal("marcos@test.com", result.Email);
            Assert.False(string.IsNullOrEmpty(result.Token));

        }


        [Fact]

        public async Task LoginAsync_RetornaNullSiUsuarioNoExiste()
        {
            //Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            var config = GetTestConfiguration();

            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((Usuario)null);

            var service = new AuthRepository(mockRepo.Object, config);

            var loginDTO = new UsuarioLoginDTO
            {
            Email = "marcosNoexiste@test.com",
            Password = "12345"
            };

            //Act
            var result =  service.LoginAsync(loginDTO);
            
            //Assert
            Assert.NotNull(result);


        }

    }
}
