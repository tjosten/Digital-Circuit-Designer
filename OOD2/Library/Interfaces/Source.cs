using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2.Library.Interfaces
{
    public abstract class Source
    {
        // describes the current state of this source;
        // can be either true or false
        bool currentState
        {
            get;
            set;
        }

        // click handler for the source;
        // when clicked, the current state changes
        public virtual void clickHandler()
        {
        }
    }
}
