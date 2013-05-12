using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace OOD2
{
    public partial class TestControl : PictureBox
    {
        private Image image;

        public TestControl()
        {
            this.init();
            // allow drag & drop
            this.AllowDrop = true;
        }

        void init()
        {
            image = Image.FromFile("C:\\Users\\Timo Josten\\Documents\\GitHub\\OOD2-Assignment\\OOD2\\img\\and.jpg");
            this.Image = image;
            this.Height = image.Height;
            this.Width = image.Width;
        }
    }
}