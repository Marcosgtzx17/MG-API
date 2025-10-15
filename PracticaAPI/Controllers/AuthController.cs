using PracticaAPI.DTOs.UsuarioDTOs;
using PracticaAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PracticaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Esto genera /api/auth
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDTO dto)
        {
            var result = await _authService.RegistrarAsync(dto);
            return Ok(result); //  Devuelve DTO de respuesta
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null) return Unauthorized("Credenciales inválidas");
            return Ok(result);
        }
    }
}
