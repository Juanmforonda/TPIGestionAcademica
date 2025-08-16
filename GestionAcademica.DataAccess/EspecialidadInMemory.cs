using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAcademica.Domain;

namespace GestionAcademica.DataAccess
{
    public class EspecialidadInMemory
    {
        public static List<Especialidad> Especialidades;

        static EspecialidadInMemory()
        {
            Especialidades = new List<Especialidad>
            {
                new Especialidad(1, "Ingeniería en Sistemas"),
                new Especialidad(2, "Ingeniería Electrónica")
            };
        }
    }
}

