using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    public partial class NotControl : BaseControl
    {
        public NotControl()
        {
            System.Drawing.Image image = Properties.Resources.not;
            base.init(image);
            this.AllowDrop = true;

            // assign gate to control
            this.gate = new Library.Not();
        }

        public bool checkStatus()
        {
            Library.Not not = (Library.Not)this.gate;

            if (this.inputs.Count == 2)
                return not.run(this.inputs[0].currentState, this.inputs[1].currentState);
            else
                return not.run(this.getSingleInput().currentState, -1);
        }

        public BaseControl getSingleInput()
        {
            if (this.inputs.Count == 1)
            {
                try
                {
                    return this.inputs[0];
                }
                catch (Exception)
                {
                    return this.inputs[1];
                }

            } else
                return null;
        }
    }
}
