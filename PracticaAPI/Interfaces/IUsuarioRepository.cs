using PracticaAPI.Entidades;
using PracticaAPI.DTOs.UsuarioDTOs;

namespace PracticaAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> AddAsync(Usuario usuario);

        Task<List<UsuarioListadoDTO>> GetAllUsuariosAsync();

    }
}
