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
                new Especialidad(2, "Ingeniería Electrónica"),
                new Especialidad(3, "Ingeniería Industrial"),
                new Especialidad(4, "Ingeniería Química"),
                new Especialidad(5, "Ingeniería Civil"),
                new Especialidad(6, "Ingeniería Mecánica"),
                new Especialidad(8, "Ingeniería Biomédica"),
                new Especialidad(9, "Ingeniería Ambiental"),
                new Especialidad(10, "Ingeniería en Alimentos")
            };
        }
    }
}

