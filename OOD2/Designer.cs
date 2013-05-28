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
        List<Control> activeControls = new List<Control>();
        String dragSourceType;

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
            this.baseAndControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseAndControl_DoDragDrop);
            this.baseOrControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseOrControl_DoDragDrop);
            this.baseXorControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseXorControl_DoDragDrop);
            this.baseNotControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseNotControl_DoDragDrop);
        }

        private void baseAndControl_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseAndControl.DoDragDrop(this.baseAndControl, DragDropEffects.Copy);
        }

        private void baseOrControl_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseOrControl.DoDragDrop(this.baseOrControl, DragDropEffects.Copy);
        }

        private void baseXorControl_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseXorControl.DoDragDrop(this.baseXorControl, DragDropEffects.Copy);
        }

        private void baseNotControl_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseNotControl.DoDragDrop(this.baseNotControl, DragDropEffects.Copy);
        }
        
        private void Canvas_OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            
        }

        private void Canvas_OnDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
        }

        private void Canvas_OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragDrop");

            // determine drop position
            PictureBox canvas = (PictureBox)sender;

            int x = e.X;
            int y = e.Y;

            // update x, y so it aligns to the grid
            x = ((int)(x / 10)) * 10;
            y = ((int)(y / 10)) * 10;

            Point dropPoint = this.pictureBox1.PointToClient(new Point(x, y));

            System.Console.WriteLine("Drop Position: " + dropPoint.X + ":" + dropPoint.Y);

            System.Console.WriteLine("Drop type: " + this.dragSourceType);

            // add the thing to the canvas
            BaseControl control = new BaseControl();
            switch(this.dragSourceType)
            {
                case "OOD2.AndControl":
                    control = new AndControl();
                    break;
                case "OOD2.OrControl":
                    control = new OrControl();
                    break;
                case "OOD2.XorControl":
                    control = new XorControl();
                    break;
                case "OOD2.NotControl":
                    control = new NotControl();
                    break;
            }

            control.draw(dropPoint, this.pictureBox1);
            control.Click += new EventHandler(controlClickHandler);

            // add the control to the list
            this.controls.Add(control);
        }

        private void Canvas_OnDragLeave(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragLeave");
        }

        // click handler for controls
        public void controlClickHandler(object sender, EventArgs e)
        {
            BaseControl control = (BaseControl)sender;

            // check if this control is already acitve; if so - unactivate it
            if (this.activeControls.Contains(control))
            {
                this.activeControls.Remove(control);

                if (this.activeControls.Count == 0) 
                {
                    btnDelete.Enabled = false;
                }

                this.pictureBox1.Invalidate();

                return;
            }

            // set the sending control to active control
            this.activeControls.Add(control);

            // enable the control edit buttons
            btnDelete.Enabled = true;

            // redraw canvas
            this.pictureBox1.Invalidate();
        }

        // paint everything on the canvas
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            PictureBox pb = (PictureBox)sender;
            Graphics gr = e.Graphics;

            // get width and height of picturebox
            int pbWidth = pb.Width;
            int pbHeight = pb.Height;

            // create some pens and stuff
            Pen penGray = new Pen(Color.LightGray);

            // draw grid
            for (int i = 0; i < pbHeight; i+=10) 
            {
                gr.DrawLine(penGray, new Point(i, 0), new Point(i, pbHeight));
                gr.DrawLine(penGray, new Point(0, i), new Point(pbWidth, i));
            }

            // draw all controls
            foreach(BaseControl control in this.controls)
            {
                control.draw(control.tellPosition(), pb);
                // remove the event and add it again - prevents system from adding it twice
                control.Click -= new EventHandler(controlClickHandler);
                control.Click += new EventHandler(controlClickHandler);
            }

            // draw rectangles for active controls
            foreach(BaseControl control in this.activeControls)
            {
                // mark it as active by drawing a border around it
                Rectangle rect = new Rectangle(control.Location.X, control.Location.Y, control.ClientSize.Width, control.ClientSize.Height);
                rect.Inflate(1, 1);
                ControlPaint.DrawBorder(gr, rect, Color.Red, ButtonBorderStyle.Dashed);
            }
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete the active control
            if (this.activeControls.Count != 0)
            {
                foreach(BaseControl control in this.activeControls)
                {
                    this.controls.Remove(control);
                    this.pictureBox1.Controls.Remove(control);
                }
                this.activeControls.Clear();
                this.btnDelete.Enabled = false;
                this.pictureBox1.Invalidate();
            }
        }

        private void baseAndControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragSourceType = sender.GetType().ToString();
        }

        private void baseOrControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragSourceType = sender.GetType().ToString();
        }

        private void baseXorControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragSourceType = sender.GetType().ToString();
        }

        private void baseNotControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragSourceType = sender.GetType().ToString();
        }
    }
}