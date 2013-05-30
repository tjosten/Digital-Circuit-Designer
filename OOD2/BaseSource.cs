using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


namespace OOD2
{
    public partial class BaseSource : BaseControl
    {
        private Image image;
        public List<BaseControl> outputs = new List<BaseControl>();
        private bool status = true;

        public BaseSource()
        {
            this.init(Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\source-on.png"));
            // allow drag & drop
            this.AllowDrop = true;
        }

        public void toggle()
        {
            if (this.status)
            {
                this.status = false;
                this.Image = Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\source-off.png");
            }
            else
            {
                this.status = true;
                this.Image = Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\source-on.png");
            }
        }
    }
}