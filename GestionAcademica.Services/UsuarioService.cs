using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.Services
{
    public class UsuarioService
    {

        public bool Save(Usuario usuario)
        {
            switch (usuario.State)
            {
                case States.New:
                    usuario.ID = GetNextId();
                    UsuarioInMemory.Usuarios.Add(usuario);
                    break;
                case States.Deleted:

                    if (usuario != null)
                    {
                        UsuarioInMemory.Usuarios.Remove(usuario);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case States.Modified:
                    Usuario? usuarioToUpdate = UsuarioInMemory.Usuarios.Find(x => x.ID == usuario.ID);

                    if (usuarioToUpdate != null)
                    {
                        usuarioToUpdate.SetClave(usuario.Clave);
                        usuarioToUpdate.SetEmail(usuario.Email);
                        usuarioToUpdate.SetNombre(usuario.Nombre);
                        usuarioToUpdate.SetApellido(usuario.Apellido);
                        usuarioToUpdate.SetNombreUsuario(usuario.NombreUsuario);
                        usuarioToUpdate.SetHabilitado(usuario.Habilitado);
                    }
                    else
                    {
                        return false;
                    }
                        break;

            }
            usuario.State = States.Unmodified;
            return true;
        }



        public Usuario? Get(int id)
        {
            return UsuarioInMemory.Usuarios.Find(x => x.ID == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioInMemory.Usuarios.ToList();
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
