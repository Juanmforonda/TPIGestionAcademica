namespace GestionAcademica.DTOs
{
    public class UsuarioDto
    {
        public int ID { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public bool Habilitado { get; set; }
    }
}
