using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library.Interfaces
{
    public abstract class Gate
    {
        // run method;
        // this is where the magic depending on the gate typs happens
        // returns either true (if the operation is a success) or false
        public virtual bool run(int a, int b)  {
            return false;
        }
    }
}
