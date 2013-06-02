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
        }
    }
}
