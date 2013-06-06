using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2
{
    public partial class XorControl : BaseControl
    {
        public XorControl()
        {
            System.Drawing.Image image = Properties.Resources.xor;
            base.init(image);
            this.AllowDrop = true;

            // assign gate to control
            this.gate = new Library.Xor();
        }
    }
}
