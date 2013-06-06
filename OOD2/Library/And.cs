using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class And : OOD2.Library.Interfaces.Gate
    {
        public And()
        {
        }

        public new bool run(int a, int b)
        {
            if (a == 1 && b == 1)
                return true;
            return false;
        }
    }
}
