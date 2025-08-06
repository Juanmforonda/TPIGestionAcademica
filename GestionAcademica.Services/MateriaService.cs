using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestionAcademica.Domain;
using GestionAcademica.DataAccess;

namespace GestionAcademica.Services
{
    public class MateriaService
    {
        public void Add(Materia materia)
        {
            materia.SetId(GetNextId());
            MateriaInMemory.Materias.Add(materia);
        }

        public bool Delete(int id)
        {
            Materia? materiaToDelete = MateriaInMemory.Materias.Find(x => x.Id == id);

            if (materiaToDelete != null)
            {
                MateriaInMemory.Materias.Remove(materiaToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Materia? Get(int id)
        {
            return MateriaInMemory.Materias.Find(x => x.Id == id);
        }

        public IEnumerable<Materia> GetAll()
        {
            return MateriaInMemory.Materias.ToList();
        }

        public bool Update(Materia materia)
        {
            Materia? materiaToUpdate = MateriaInMemory.Materias.Find(x => x.Id == materia.Id);

            if (materiaToUpdate != null)
            {
                materiaToUpdate.SetNombre(materia.Nombre);
                materiaToUpdate.SetCodigo(materia.Codigo);
                materiaToUpdate.SetCreditos(materia.Creditos);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static int GetNextId()
        {
            int nextId;

            if (MateriaInMemory.Materias.Count > 0)
            {
                nextId = MateriaInMemory.Materias.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}
