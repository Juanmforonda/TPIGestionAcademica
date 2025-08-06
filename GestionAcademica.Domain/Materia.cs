using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica.Domain
{
    public class Materia
    {
        public int ID { get; private set; }
        public string Descripcion { get; private set; }
        public int HSSemanales { get; private set; }
        public int HSTotales { get; private set; }
        public int IDPlan { get; private set; }

        public Materia(int id, string descripcion, int hsSemanales, int hsTotales, int idPlan)
        {
            SetID(id);
            SetDescripcion(descripcion);
            SetHSSemanales(hsSemanales);
            SetHSTotales(hsTotales);
            SetIDPlan(idPlan);
        }

        public void SetID(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID debe ser mayor o igual a 0.", nameof(id));
            ID = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        public void SetHSSemanales(int hsSemanales)
        {
            if (hsSemanales < 0)
                throw new ArgumentException("Las horas semanales deben ser mayores o iguales a 0.", nameof(hsSemanales));
            HSSemanales = hsSemanales;
        }

        public void SetHSTotales(int hsTotales)
        {
            if (hsTotales < 0)
                throw new ArgumentException("Las horas totales deben ser mayores o iguales a 0.", nameof(hsTotales));
            HSTotales = hsTotales;
        }

        public void SetIDPlan(int idPlan)
        {
            if (idPlan < 0)
                throw new ArgumentException("El ID de plan debe ser mayor o igual a 0.", nameof(idPlan));
            IDPlan = idPlan;
        }
    }
}
