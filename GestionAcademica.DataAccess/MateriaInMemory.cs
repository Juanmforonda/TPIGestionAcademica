using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAcademica.Domain;


namespace GestionAcademica.DataAccess
{
    public class MateriaInMemory
    {
        public static List<Materia> Materias;

        static MateriaInMemory()
        {
            Materias = new List<Materia>
            {
                new Materia(1, "Matemática Discreta", 4, 64, 1),
                new Materia(2, "Programación I", 6, 96, 1)
            };
        }
    }
}
