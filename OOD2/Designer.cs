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

        // list of all controls on the canvas
        List<Control> controls = new List<Control>();

        // list of all controls selected (by left-clicking)
        List<Control> activeControls = new List<Control>();

        // type of base source dragged right now
        String dragSourceType;

        // control where current connection-line begins
        BaseControl controlStart;

        // control where current connection-line ends
        BaseControl controlEnd;

        public Designer()
        {
            InitializeComponent();

            // set AllowDrop to the canvas picture box
            this.canvas.AllowDrop = true;
            // bind the events to the canvas picture box
            this.canvas.DragEnter += new DragEventHandler(this.Canvas_OnDragEnter);
            this.canvas.DragDrop += new DragEventHandler(this.Canvas_OnDragDrop);

            // allow the controls to be dragged
            this.baseAndControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseAndControl_DoDragDrop);
            this.baseOrControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseOrControl_DoDragDrop);
            this.baseXorControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseXorControl_DoDragDrop);
            this.baseNotControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseNotControl_DoDragDrop);
            this.baseSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseSource_DoDragDrop);
            this.baseSink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseSink_DoDragDrop);
        }

        // drag/drop events for all the base controls
        private void baseSink_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseSink.DoDragDrop(this.baseSink, DragDropEffects.Copy);
        }

        private void baseSource_DoDragDrop(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.baseSource.DoDragDrop(this.baseSource, DragDropEffects.Copy);
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

        private void Canvas_OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // determine drop position
            PictureBox canvas = (PictureBox)sender;

            int x = e.X;
            int y = e.Y;

            // update x, y so it aligns to the grid
            x = ((int)(x / 10)) * 10;
            y = ((int)(y / 10)) * 10;

            Point dropPoint = this.canvas.PointToClient(new Point(x, y));

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
                case "OOD2.BaseSource":
                    control = new BaseSource();
                    break;
                case "OOD2.BaseSink":
                    control = new BaseSink();
                    break;
            }
            // draw it on the canvas
            control.draw(dropPoint, this.canvas);
            control.MouseClick += new MouseEventHandler(controlClickHandler);
            control.MouseDown += new MouseEventHandler(connectControlsStart);
            control.MouseUp += new MouseEventHandler(connectControlsEnd);

            // add the control to the list
            this.controls.Add(control);

            // redraw the canvas
            this.canvas.Invalidate();
        }

        private void Canvas_OnDragLeave(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragLeave");
        }

        // click handler for controls
        public void controlClickHandler(object sender, MouseEventArgs e)
        {
            BaseControl control = (BaseControl)sender;

            // check if we want to toggle something
            if (e.Button == MouseButtons.Right)
            {
                if (control.GetType().ToString() == "OOD2.BaseSource")
                {
                    // toggle here
                    BaseSource sourceControl = (BaseSource)sender;
                    sourceControl.toggle();
                    this.canvas.Invalidate();
                }
                return;
            }

            // check if this control is already acitve; if so - unactivate it
            if (this.activeControls.Contains(control))
            {
                this.activeControls.Remove(control);

                if (this.activeControls.Count == 0) 
                {
                    btnDelete.Enabled = false;
                }

                this.canvas.Invalidate();
                return;
            }

            // set the sending control to active control
            this.activeControls.Add(control);

            // enable the control edit buttons
            btnDelete.Enabled = true;

            // redraw canvas
            this.canvas.Invalidate();
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
                control.MouseClick -= new MouseEventHandler(controlClickHandler);
                control.MouseClick += new MouseEventHandler(controlClickHandler);

                // remove the event and add it again - prevents system from adding it twice
                control.MouseDown -= new MouseEventHandler(connectControlsStart);
                control.MouseDown += new MouseEventHandler(connectControlsStart);

                // remove the event and add it again - prevents system from adding it twice
                control.MouseUp -= new MouseEventHandler(connectControlsEnd);
                control.MouseUp += new MouseEventHandler(connectControlsEnd);
            }

            // draw all connections
            foreach (BaseControl control in this.controls)
            {
                // draw connections if existing
                if (control.outputs.Count > 0)
                {
                    foreach (BaseControl outputControl in control.outputs)
                    {
                        this.drawConnectControls(control, outputControl, gr);
                    }
                }
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
            this.canvas.Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete the active control
            if (this.activeControls.Count != 0)
            {
                foreach(BaseControl control in this.activeControls)
                {
                    this.removeControl(control);
                }
                this.activeControls.Clear();
                this.btnDelete.Enabled = false;
                this.canvas.Invalidate();
            }
        }

        private void removeControl(BaseControl control)
        {
            this.controls.Remove(control);
            this.canvas.Controls.Remove(control);

            // remove connections where this control is defined as an output for others
            foreach (BaseControl c in this.controls) {
                if (c.outputs.Contains(control))
                {
                    c.outputs.Remove(control);
                }
            }
        }

        // set the type of base control which is dragged right now
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragSourceType = sender.GetType().ToString();
        }

        // set the start control during the connection-line process
        private void connectControlsStart(object sender, MouseEventArgs e)
        {
            this.controlStart = (BaseControl)sender;
        }

        // connect two controls with each other
        private void drawConnectControls(BaseControl controlStart, BaseControl controlEnd, Graphics gr)
        {
            if (controlStart == controlEnd)
            {
                Console.WriteLine("Cannot connect the same gates with each other, aborting.");
                return;
            }

            Console.WriteLine(controlStart.ToString() + ":" + controlEnd.ToString());

            // let's connect these..
            Pen penBlack = new Pen(Color.Black, 3);
            Point start = controlStart.tellPosition();
            Point end = controlEnd.tellPosition();

            // add the half-width and half-height of the controls from the points
            start.X += controlStart.Width / 2;
            start.Y += controlStart.Height / 2;
            end.X += controlEnd.Width / 2;
            end.Y += controlEnd.Height / 2;

            // draw the line!
            gr.DrawLine(penBlack, start, end);
        }

        // end event of connection-line process
        private void connectControlsEnd(object sender, EventArgs e)
        {
            if (this.controlStart == null)
                return;

            // get the controlEnd controll by the mouse position
            Point mousePosition = this.canvas.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Console.WriteLine("Mouse position: " + mousePosition.X + ":" + mousePosition.Y);

            // determine controlEnd
            foreach (BaseControl control in this.controls)
            {
                Point controlPosition = control.tellPosition();

                if (mousePosition.X >= controlPosition.X && mousePosition.X <= controlPosition.X + control.Width)
                {
                    if (mousePosition.Y >= controlPosition.Y && mousePosition.Y <= controlPosition.Y + control.Height)
                    {
                        this.controlEnd = control;
                        break;
                    }
                }
            }

            // whoops, where somewhere on the canvas where no control is at all.
            if (this.controlEnd == null)
            {
                return;
            }

            // check if the end is a source, if so: abort
            if (this.controlEnd.GetType().ToString() == "OOD2.BaseSource")
            {
                Console.WriteLine("The source is a source! That's an error in the matrix.");
                return;
            }

            // check if i am already an output of controlEnd
            if (this.controlEnd.outputs.Contains(this.controlStart))
            {
                Console.WriteLine("I'm already an output, aborting!");
                return;
            }

            // check if i am already an output of controlStart
            if (this.controlStart.outputs.Contains(this.controlEnd))
            {
                Console.WriteLine("I'm already an output, aborting!");
                return;
            }

            drawConnectControls(this.controlStart, this.controlEnd, this.canvas.CreateGraphics());
            this.controlStart.outputs.Add(this.controlEnd);

            this.controlStart = null;
            this.controlEnd = null;
        }
    }
}