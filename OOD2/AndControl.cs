using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    public partial class AndControl : BaseControl
    {
        public AndControl()
        {
            System.Drawing.Image image = Properties.Resources.and;
            base.init(image);
            this.AllowDrop = true;

            // assign gate to control
            this.gate = new Library.And();
        }

        public bool checkStatus()
        {
            Library.And and = (Library.And)this.gate;
            return and.run(this.inputs[0].currentState, this.inputs[1].currentState);
        }
    }
}
