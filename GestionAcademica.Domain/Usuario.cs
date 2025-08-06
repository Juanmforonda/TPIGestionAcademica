namespace GestionAcademica.Domain
{
    public class Usuario
    {
        public int ID { get; private set; }
        public string Clave { get; private set; }
        public string Email { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string NombreUsuario { get; private set; }
        public bool Habilitado { get; private set; }

        public Usuario(int id, string clave, string email, string nombre, string apellido, string nombreUsuario, bool habilitado)
        {
            SetID(id);
            SetClave(clave);
            SetEmail(email);
            SetNombre(nombre);
            SetApellido(apellido);
            SetNombreUsuario(nombreUsuario);
            SetHabilitado(habilitado);
        }

        public void SetID(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID debe ser mayor o igual a 0.", nameof(id));
            ID = id;
        }

        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(clave));
            Clave = clave;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede ser nulo o vacío.", nameof(email));
            Email = email;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }

        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }
    }
}
