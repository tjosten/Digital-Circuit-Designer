using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Or : OOD2.Library.Interfaces.Gate
    {
        public Or()
        {
        }

        public new bool run(int a, int b)
        {
            if (a == 1 || b == 1)
                return true;
            return false;
        }
    }
}
