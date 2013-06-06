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
        public new List<BaseControl> outputs = new List<BaseControl>();
        private bool status = true;

        public BaseSource()
        {
            this.init(Properties.Resources.source_on);
            // allow drag & drop
            this.AllowDrop = true;
        }

        public bool getStatus()
        {
            return this.status;
        }

        public void toggle()
        {
            if (this.status)
            {
                this.status = false;
                this.Image = Properties.Resources.source_off;
            }
            else
            {
                this.status = true;
                this.Image = Properties.Resources.source_on; ;
            }
        }
    }
}