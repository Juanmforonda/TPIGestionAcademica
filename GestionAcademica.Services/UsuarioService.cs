using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.Services
{
    public class UsuarioService
    {
        public void Add(Usuario usuario)
        {
            usuario.SetID(GetNextId());
            UsuarioInMemory.Usuarios.Add(usuario);
        }

        public bool Delete(int id)
        {
            Usuario? usuarioToDelete = UsuarioInMemory.Usuarios.Find(x => x.ID == id);

            if (usuarioToDelete != null)
            {
                UsuarioInMemory.Usuarios.Remove(usuarioToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario? Get(int id)
        {
            return UsuarioInMemory.Usuarios.Find(x => x.ID == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioInMemory.Usuarios.ToList();
        }

        public bool Update(Usuario usuario)
        {
            Usuario? usuarioToUpdate = UsuarioInMemory.Usuarios.Find(x => x.ID == usuario.ID);

            if (usuarioToUpdate != null)
            {
                usuarioToUpdate.SetClave(usuario.Clave);
                usuarioToUpdate.SetEmail(usuario.Email);
                usuarioToUpdate.SetNombre(usuario.Nombre);
                usuarioToUpdate.SetApellido(usuario.Apellido);
                usuarioToUpdate.SetNombreUsuario(usuario.NombreUsuario);
                usuarioToUpdate.SetHabilitado(usuario.Habilitado);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetNextId()
        {
            int nextId;

            if (UsuarioInMemory.Usuarios.Count > 0)
            {
                nextId = UsuarioInMemory.Usuarios.Max(x => x.ID) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}
