using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.Services
{
    public class EspecialidadService
    {
        public bool Save(Especialidad especialidad)
        {
            switch (especialidad.State)
            {
                case States.New:
                    especialidad.ID = GetNextId();
                    EspecialidadInMemory.Especialidades.Add(especialidad);
                    break;
                case States.Deleted:

                    if (especialidad != null)
                    {
                        EspecialidadInMemory.Especialidades.Remove(especialidad);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case States.Modified:
                    Especialidad? especialidadToUpdate = EspecialidadInMemory.Especialidades.Find(x => x.ID == especialidad.ID);

                    if (especialidadToUpdate != null)
                    {
                        especialidadToUpdate.SetDescripcion(especialidad.Descripcion);
                    }
                    else
                    {
                        return false;
                    }
                    break;

            }
            especialidad.State = States.Unmodified;
            return true;
        }

        public Especialidad? Get(int id)
        {
            return EspecialidadInMemory.Especialidades.Find(x => x.ID == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return EspecialidadInMemory.Especialidades.ToList();
        }

        private static int GetNextId()
        {
            int nextId;

            if (EspecialidadInMemory.Especialidades.Count > 0)
            {
                nextId = EspecialidadInMemory.Especialidades.Max(x => x.ID) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}

