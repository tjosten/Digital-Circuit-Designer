using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOD2
{
    public partial class Designer : Form
    {

        List<Control> controls = new List<Control>();

        public Designer()
        {
            InitializeComponent();

            // set AllowDrop to the canvas picture box
            this.pictureBox1.AllowDrop = true;
            // bind the events to the canvas picture box
            this.pictureBox1.DragEnter += new DragEventHandler(this.Canvas_OnDragEnter);
            this.pictureBox1.DragOver += new DragEventHandler(this.Canvas_OnDragOver);
            this.pictureBox1.DragDrop += new DragEventHandler(this.Canvas_OnDragDrop);
            //this.pictureBox1.DragLeave += new DragEventHandler(this.Canvas_OnDragLeave);

            // allow the controls to be dragged
            this.testControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.testControl1_DoDragDrop);
        }

        private void testControl1_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.testControl1.DoDragDrop(this.testControl1, DragDropEffects.Copy);
        }
        
        private void Canvas_OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //not so much spam..
            //System.Console.WriteLine("Canvas_OnDragEnter");
        }

        private void Canvas_OnDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //not so much spam..
            //System.Console.WriteLine("Canvas_OnDragOver");
        }

        private void Canvas_OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragDrop");

            // determine drop position
            PictureBox canvas = (PictureBox)sender;
            Point dropPoint = this.pictureBox1.PointToClient(new Point(e.X, e.Y));

            System.Console.WriteLine("Drop Position: " + dropPoint.X + ":" + dropPoint.Y);

            // add the thing to the canvas
            TestControl control = new TestControl();
            control.draw(dropPoint, this.pictureBox1);

            // add the control to the list
            this.controls.Add(control);
        }

        private void Canvas_OnDragLeave(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragLeave");
        }
    }
}