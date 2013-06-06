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
    }
}
