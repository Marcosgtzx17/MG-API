namespace PracticaAPI.Entidades
{
    public class Rol
    {
        public int Id { get; set; }                       // INT (AI)
        public string Nombre { get; set; } = string.Empty; // VARCHAR(100)

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}