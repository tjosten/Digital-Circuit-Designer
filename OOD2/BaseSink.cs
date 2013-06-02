using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


namespace OOD2
{
    public partial class BaseSink : BaseControl
    {
        private Image image;
        private bool status = true;

        public BaseSink()
        {
            this.init(Properties.Resources.input_off);
            // allow drag & drop
            this.AllowDrop = true;
        }

        public void on()
        {
            this.status = true;
            this.Image = Properties.Resources.input_on;
        }

        public void off()
        {
            this.status = false;
            this.Image = Properties.Resources.input_off;
        }
    }
}