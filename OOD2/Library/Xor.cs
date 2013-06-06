using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Xor : OOD2.Library.Interfaces.Gate
    {
        public Xor()
        {
        }

        public new bool run(int a, int b)
        {
            bool a2, b2;

            if (a == 1)
                a2 = true;
            else
                a2 = false;

            if (b == 1)
                b2 = true;
            else
                b2 = false;
            
            return a2 ^ b2;
        }
    }
}