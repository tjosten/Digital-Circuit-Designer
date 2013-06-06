using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Not : OOD2.Library.Interfaces.Gate
    {
        public Not()
        {
        }

        public new bool run(int a, int b)
        {
            if ((a == 0 && b == 0) || (a == 0 && b == -1) || (a == -1 && b == 0))
                return true;
            return false;
        }
    }
}
