using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    public partial class OrControl : BaseControl
    {
        public OrControl()
        {
            System.Drawing.Image image = Properties.Resources.or;
            base.init(image);
            this.AllowDrop = true;

            // assign gate to control
            this.gate = new Library.Or();
        }

        public bool checkStatus()
        {
            Library.Or or = (Library.Or)this.gate;
            return or.run(this.inputs[0].currentState, this.inputs[1].currentState);
        }
    }
}
