using PracticaAPI.DTOs.UsuarioDTOs;

namespace PracticaAPI.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioRespuestaDTO> RegistrarAsync(UsuarioRegistroDTO DTO);
        Task<UsuarioRespuestaDTO> LoginAsync(UsuarioLoginDTO DTO);

    }
}
