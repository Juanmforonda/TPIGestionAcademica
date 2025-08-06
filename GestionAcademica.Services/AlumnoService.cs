using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.Services
{
    public class AlumnoService
    {
        public void Add(Alumno alumno)
        {
            alumno.SetId(GetNextId());
            AlumnoInMemory.Alumnos.Add(alumno);
        }

        public bool Delete(int id)
        {
            Alumno? alumnoToDelete = AlumnoInMemory.Alumnos.Find(x => x.Id == id);

            if (alumnoToDelete != null)
            {
                AlumnoInMemory.Alumnos.Remove(alumnoToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Alumno? Get(int id)
        {
            // Debería devolver un objeto clonado
            return AlumnoInMemory.Alumnos.Find(x => x.Id == id);
        }

        public IEnumerable<Alumno> GetAll()
        {
            // Devuelvo una lista nueva cada vez que se llama a GetAll
            // pero idealmente debería implementar un Deep Clone
            return AlumnoInMemory.Alumnos.ToList();
        }

        public bool Update(Alumno alumno)
        {
            Alumno? alumnoToUpdate = AlumnoInMemory.Alumnos.Find(x => x.Id == alumno.Id);

            if (alumnoToUpdate != null)
            {
                alumnoToUpdate.SetNombre(alumno.Nombre);
                alumnoToUpdate.SetApellido(alumno.Apellido);
                alumnoToUpdate.SetLegajo(alumno.Legajo);
                alumnoToUpdate.SetEmail(alumno.Email);
                alumnoToUpdate.SetFechaNacimiento(alumno.FechaNacimiento);

                return true;
            }
            else
            {
                return false;
            }
        }

        // No es ThreadSafe pero sirve para el propósito del ejemplo        
        private static int GetNextId()
        {
            int nextId;

            if (AlumnoInMemory.Alumnos.Count > 0)
            {
                nextId = AlumnoInMemory.Alumnos.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}

