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
            System.Drawing.Image image = System.Drawing.Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\and.png");
            base.init(image);
            this.AllowDrop = true;
        }
    }
}
