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
                new Materia(1, "Matemática Discreta", "MAT101", 6),
                new Materia(2, ".NET", "NET301", 8)
            };
        }
    }
}
