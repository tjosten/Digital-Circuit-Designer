using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Not : OOD2.Library.Interfaces.Gate
    {

        private List<OOD2.Library.Input> inputs;

        public Not()
        {
            // the and-switch has a maximum of 2 inputs
            this.inputs = new List<OOD2.Library.Input>(2);
        }

        public bool run()
        {
            // we assume the outcome is true, until proven otherwise

            // check if we have any input connected
            if (this.inputs.Count == 0)
            {
                throw new Exception("The NOT-Gate needs to have at least 1 input connected in order to work!");
            }

            // iterate the inputs
            foreach (OOD2.Library.Input input in this.inputs)
            {
                if (input.currentState == true)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
