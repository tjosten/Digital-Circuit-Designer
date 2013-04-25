using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Input
    {
        // current state of that input
        public bool currentState;

        // Gate to which this input is associated
        public OOD2.Library.Interfaces.Gate gate;

        // constructor with initial state argument
        public Input(bool state)
        {
            this.currentState = state;
        }
    }
}
