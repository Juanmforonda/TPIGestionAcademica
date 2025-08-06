using GestionAcademica.Domain;

namespace GestionAcademica.DataAccess
{
    public class AlumnoInMemory
    {
        public static List<Alumno> Alumnos;

        static AlumnoInMemory()
        {
            Alumnos = new List<Alumno>
            {
                new Alumno(1, "Juan Manuel", "Foronda", "53120", "juanmforonda@gmail.com", new DateTime(1990, 5, 15)),
                new Alumno(2, "Augusto Manuel", "Londa", "12120", "augustolonda@gmail.com", new DateTime(2004, 12, 20)),

            };
        } 

        
    }
}
