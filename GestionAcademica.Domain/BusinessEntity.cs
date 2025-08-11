using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica.Domain
{
    public abstract class BusinessEntity
    {
        public int ID { get; set; }
        public States State { get; set; } = States.Unmodified;
    }

    public enum States
    {
        New,
        Modified,
        Deleted,
        Unmodified
    }
}

