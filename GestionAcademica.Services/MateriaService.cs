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

        public bool Save(Materia materia)
        {
            switch (materia.State)
            {
                case States.New:
                    materia.ID = GetNextId();
                    MateriaInMemory.Materias.Add(materia);
                    break;
                case States.Deleted:

                    if (materia != null)
                    {
                        MateriaInMemory.Materias.Remove(materia);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case States.Modified:
                    Materia? materiaToUpdate = MateriaInMemory.Materias.Find(x => x.ID == materia.ID);

                    if (materiaToUpdate != null)
                    {
                        materiaToUpdate.SetDescripcion(materia.Descripcion);
                        materiaToUpdate.SetHSSemanales(materia.HSSemanales);
                        materiaToUpdate.SetHSTotales(materia.HSTotales);
                        materiaToUpdate.SetIDPlan(materia.IDPlan);

                    }
                    else
                    {
                        return false;
                    }
                    break;

            }
            materia.State = States.Unmodified;
            return true;
        
        }



        public Materia? Get(int id)
        {
            return MateriaInMemory.Materias.Find(x => x.ID == id);
        }

        public IEnumerable<Materia> GetAll()
        {
            return MateriaInMemory.Materias.ToList();
        }



        private static int GetNextId()
        {
            int nextId;

            if (MateriaInMemory.Materias.Count > 0)
            {
                nextId = MateriaInMemory.Materias.Max(x => x.ID) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}

