using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica.Domain
{
    public class Especialidad : BusinessEntity
    {
        public string Descripcion { get; private set; }

        public Especialidad(int id, string descripcion)
        {
            ID = id;
            SetDescripcion(descripcion);
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripci�n no puede ser nula o vac�a.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}

