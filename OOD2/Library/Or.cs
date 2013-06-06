using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Or : OOD2.Library.Interfaces.Gate
    {

        private List<OOD2.Library.Input> inputs;

        public Or()
        {
            // the and-switch has a maximum of 2 inputs
            this.inputs = new List<OOD2.Library.Input>(2);
        }

        public bool run()
        {
            // we assume the outcome is true, until proven otherwise

            // check if we have at least inputs connected
            if (this.inputs.Count < 2)
            {
                throw new Exception("The OR-Gate needs to have at least 2 inputs connected in order to work!");
            }

            // iterate the inputs
            foreach(OOD2.Library.Input input in this.inputs)
            {
                if (input.currentState == true)
                {
                    return true;
                }
            }

            return true;
        }
    }
}
