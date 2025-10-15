namespace PracticaAPI.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }                       // INT (AI)
        public string Nombre { get; set; } = string.Empty; // VARCHAR(100)
        public string Email { get; set; } = string.Empty;  // VARCHAR(150)
        public string PasswordHash { get; set; } = string.Empty; // VARCHAR(255)

        // FK correcta (coincide con la columna de la tabla usuarios)
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
    }
}