﻿using System;
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
            System.Drawing.Image image = System.Drawing.Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\or.png");
            base.init(image);
            this.AllowDrop = true;
        }
    }
}
