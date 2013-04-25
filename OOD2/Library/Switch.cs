using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library
{
    class Switch : OOD2.Library.Interfaces.Source
    {
        // the raw state; this must never be accessed directly
        private bool rawState = false;

        // implementation of currentState as defined in interface
        public bool currentState
        {
            get
            {
                return this.rawState;
            }
            set
            {
                if ((bool)value == true)
                    this.rawState = true;
                else
                    this.rawState = false;
            }
        }

        public void clickHandler()
        {
            if (this.currentState == true)
                this.currentState = false;
            else
                this.currentState = true;
        }
    }
}
