using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


namespace OOD2
{
    public partial class BaseControl : PictureBox
    {
        private Image image;
        public List<BaseControl> outputs = new List<BaseControl>();
        public List<BaseControl> inputs = new List<BaseControl>();

        public int currentState = -1;

        protected OOD2.Library.Interfaces.Gate gate;

        public BaseControl()
        {
            // allow drag & drop
            this.AllowDrop = true;
        }

        protected virtual void init(System.Drawing.Image image)
        {
            this.image = image;
            this.Image = image;
            this.Height = image.Height;
            this.Width = image.Width;
        }

        public void draw(Point point, PictureBox pictureBox)
        {
            this.Location = point;
            pictureBox.Controls.Add(this);
        }

        public Point tellPosition()
        {
            return this.Location;
        }
    }
}