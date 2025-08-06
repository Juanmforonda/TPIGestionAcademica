using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica.Domain
{
    public class Materia
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Codigo { get; private set; }
        public int Creditos { get; private set; }

        public Materia(int id, string nombre, string codigo, int creditos)
        {
            SetId(id);
            SetNombre(nombre);
            SetCodigo(codigo);
            SetCreditos(creditos);
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

        public void SetCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código no puede ser nulo o vacío.", nameof(codigo));
            Codigo = codigo;
        }

        public void SetCreditos(int creditos)
        {
            if (creditos < 0)
                throw new ArgumentException("Los créditos deben ser mayores o iguales a 0.", nameof(creditos));
            Creditos = creditos;
        }
    }
}
