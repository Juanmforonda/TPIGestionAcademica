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
                new Especialidad(1, "Ingenier�a en Sistemas"),
                new Especialidad(2, "Ingenier�a Electr�nica"),
                new Especialidad(3, "Ingenier�a Industrial"),
                new Especialidad(4, "Ingenier�a Qu�mica"),
                new Especialidad(5, "Ingenier�a Civil"),
                new Especialidad(6, "Ingenier�a Mec�nica"),
                new Especialidad(8, "Ingenier�a Biom�dica"),
                new Especialidad(9, "Ingenier�a Ambiental"),
                new Especialidad(10, "Ingenier�a en Alimentos")
            };
        }
    }
}

