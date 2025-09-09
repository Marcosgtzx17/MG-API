namespace PracticaAPI.DTOs.UsuarioDTOs
{
    public class UsuarioListadoDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}
