using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace OOD2
{
    public partial class BaseControl : PictureBox
    {
        private Image image;

        public BaseControl()
        {
            //this.init();
            // allow drag & drop
            this.AllowDrop = true;
        }

        protected void init(System.Drawing.Image image)
        {
            //image = Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\and.jpg");
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