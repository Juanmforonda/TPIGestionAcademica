using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica.DTOs
{
    public class MateriaDto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int HSSemanales { get; set; }
        public int HSTotales { get; set; }
        public int IDPlan { get; set; }
    }
}
