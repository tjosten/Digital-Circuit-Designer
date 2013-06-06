using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Xor : OOD2.Library.Interfaces.Gate
    {

        private List<OOD2.Library.Input> inputs;

        public Xor()
        {
            // the and-switch has a maximum of 2 inputs
            this.inputs = new List<OOD2.Library.Input>(2);
        }

        public bool run()
        {
            // we assume the outcome is true, until proven otherwise
            //TODO: to be done

            return true;
        }
    }
}
