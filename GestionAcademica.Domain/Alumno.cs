using System.Text.RegularExpressions;

namespace GestionAcademica.Domain
{
    public class Alumno
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Legajo { get; private set; }

        public string Email { get; private set; }
        public DateTime FechaNacimiento { get; private set; }

        public Alumno(int id, string nombre, string apellido, string legajo, string email, DateTime fechaNacimiento)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetLegajo(legajo);
            SetEmail(email);
            SetFechaNacimiento(fechaNacimiento);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
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

        public void SetLegajo(string legajo)
        {
            if (string.IsNullOrWhiteSpace(legajo))
                throw new ArgumentException("El legajo no puede ser nulo o vacío.", nameof(legajo));
            Legajo = legajo;
        }
        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            if (fechaNacimiento == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaNacimiento));
            FechaNacimiento = fechaNacimiento;
        }
    }
}
