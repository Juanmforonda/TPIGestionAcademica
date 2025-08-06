using GestionAcademica.Domain;

namespace GestionAcademica.DataAccess
{
    public class UsuarioInMemory
    {
        public static List<Usuario> Usuarios;

        static UsuarioInMemory()
        {
            Usuarios = new List<Usuario>
            {
                new Usuario(1, "clave123", "juan@email.com", "Juan", "Pérez", "juanp", true),
                new Usuario(2, "clave456", "ana@email.com", "Ana", "García", "anag", false)
            };
        }
    }
}
