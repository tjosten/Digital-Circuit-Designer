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

        // hätte man auch schöner benennen können #FIXME #YOLO
        bool isIterating = false;
        bool foundUnknown = false;

        // splash screen
        Splash splash;

        public Designer()
        {
            InitializeComponent();

            this.splash = new Splash();
            splash.Show();

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
            if (this.isIterating)
                return;

            // determine drop position
            PictureBox canvas = (PictureBox)sender;

            int x = e.X;
            int y = e.Y;

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

            // update x, y so we have the center of our control where the mouse is
            x -= control.Width / 2;
            y -= control.Height / 2;

            Point dropPoint = this.canvas.PointToClient(new Point(x, y));

            System.Console.WriteLine("Drop Position: " + dropPoint.X + ":" + dropPoint.Y);

            // draw it on the canvas
            control.draw(dropPoint, this.canvas);
            control.MouseClick += new MouseEventHandler(controlClickHandler);
            control.MouseDown += new MouseEventHandler(connectControlsStart);
            control.MouseUp += new MouseEventHandler(connectControlsEnd);

            // add the control to the list
            this.controls.Add(control);

            // redraw the canvas
            this.canvas.Invalidate();

            // trigger run
            this.run();
        }

        private void Canvas_OnDragLeave(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Console.WriteLine("Canvas_OnDragLeave");
        }

        // click handler for controls
        public void controlClickHandler(object sender, MouseEventArgs e)
        {

            if (this.isIterating)
                return;

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
                // trigger run
                this.run();
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
        private void Canvas_Paint(object sender, PaintEventArgs e)
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

            // trigger run
            this.run();
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

            // trigger run
            this.run();
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

            // remove connections where this control is defined as an input for others
            foreach (BaseControl c in this.controls)
            {
                if (c.inputs.Contains(control))
                {
                    c.inputs.Remove(control);
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

            Color color;

            if (controlStart.currentState == 1)
            {
                color = Color.Green;
            }
            else if (controlStart.currentState == 0)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.Gray;
            }

            Pen penBlack = new Pen(color, 2);
            Point start = controlStart.tellPosition();
            Point end = controlEnd.tellPosition();

            System.Drawing.Drawing2D.AdjustableArrowCap bigArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(7, 7);
            penBlack.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            penBlack.CustomEndCap = bigArrow;

            // add the half-width and half-height of the controls from the points
            start.X += controlStart.Width / 2;
            start.Y += controlStart.Height / 2;
            end.X += controlEnd.Width / 2;
            end.Y += controlEnd.Height / 2;

            // determine where to exactly put the arrow..

            /*if (controlStart.tellPosition().X > controlEnd.tellPosition().X)
            {
                // we want to have the right side
                //end.X += controlEnd.Width / 2;
            }
            else if (controlStart.tellPosition().X < controlEnd.tellPosition().X)
            {
                // we want to have the left side
                //end.X -= controlEnd.Width / 2;  
            }*/

            if (controlStart.tellPosition().Y > controlEnd.tellPosition().Y)
            {
                // we want to have the upper side
                end.Y += controlEnd.Height / 2;
            }
            else if (controlStart.tellPosition().Y < controlEnd.tellPosition().Y)
            {
                // we want to have the lower side
                end.Y -= controlEnd.Height / 2;
            }

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

            // check if controlEnd has already 2 inputs
            if (this.controlEnd.inputs.Count == 2)
            {
                Console.WriteLine("The end already has 2 inputs!");
                return;
            }

            // check if the end is a source, if so: abort
            if (this.controlEnd.GetType().ToString() == "OOD2.BaseSource")
            {
                Console.WriteLine("The source is a source! That's an error in the matrix.");
                return;
            }

            // check if i am already an input of controlEnd
            if (this.controlEnd.inputs.Contains(this.controlStart))
            {
                Console.WriteLine("I'm already an input, aborting!");
                return;
            }

            // check if i am already an input of controlStart
            if (this.controlStart.inputs.Contains(this.controlEnd))
            {
                Console.WriteLine("I'm already an input, aborting!");
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
            this.controlEnd.inputs.Add(this.controlStart);

            this.controlStart = null;
            this.controlEnd = null;

            // trigger run
            this.run();
        }

        private void run()
        {
            if (this.isIterating)
            {
                return;
            }
            this.isIterating = true;
            this.foundUnknown = true;
            cutPower();

            // disable some buttons
            btnRedraw.Enabled = false;
            
            // unselect all controls
            this.activeControls.Clear();
            this.canvas.Invalidate();

            while (this.foundUnknown)
            {
                this.foundUnknown = false;
                foreach (BaseControl control in this.controls)
                {
                    if (control.GetType().ToString() == "OOD2.BaseSource")
                    {
                        BaseSource quelle = (BaseSource)control;
                        if (/*quelle.getStatus()*/true) // we always have to do that, because of the NotControl!
                        {
                            recursiveIterator(control, null);
                        }

                    }
                }
            }

            btnRedraw.Enabled = true;

            this.isIterating = false;
        }

        private void cutPower()
        {
            foreach (BaseControl control in this.controls)
            {
                if (control.GetType().ToString() == "OOD2.BaseSink")
                {
                    BaseSink senke = (BaseSink)control;
                    senke.off();
                }
                else if (control.GetType().ToString() != "OOD2.BaseSource")
                {
                    control.currentState = -1;
                }
            }
        }

        private void recursiveIterator(BaseControl control, BaseControl lastControl = null)
        {
            foreach (BaseControl subcontrol in control.outputs)
            {
                if (subcontrol.GetType().ToString() == "OOD2.BaseSink") {
                    // HEUREKA
                    BaseSink senke = (BaseSink)subcontrol;

                    // invalidate canvas
                    canvas.Invalidate();

                    foreach (BaseControl input in senke.inputs)
                    {
                        if (input.currentState == -1)
                            this.foundUnknown = true;
                        else if (input.currentState == 0)
                            senke.off();
                        else if (input.currentState == 1)
                        {
                            senke.on();
                            break;
                        }
                    }
                } else {

                    if (subcontrol.inputs.Count != 2)
                        if (subcontrol.GetType().ToString() != "OOD2.NotControl")
                            continue;
                        else {
                            // special exception for NotControl as it can has only 1 input
                            NotControl not = (NotControl)subcontrol;
                            
                            if (not.getSingleInput() == null)
                                continue;

                            if (not.getSingleInput().currentState > -1)
                            {
                                if (not.checkStatus())
                                    not.currentState = 1;
                                else
                                    not.currentState = 0;
                            }
                            else
                            {
                                this.foundUnknown = true;
                            }
                            recursiveIterator(subcontrol, control);
                            continue;
                        }

                    if (subcontrol.inputs[0].currentState > -1 &&
                        subcontrol.inputs[1].currentState > -1)
                    {
                        switch (subcontrol.GetType().ToString())
                        {
                            case "OOD2.AndControl":
                                AndControl and = (AndControl)subcontrol;
                                if (and.checkStatus())
                                    and.currentState = 1;
                                else
                                    and.currentState = 0;
                                break;
                            case "OOD2.OrControl":
                                OrControl or = (OrControl)subcontrol;
                                if (or.checkStatus())
                                    or.currentState = 1;
                                else
                                    or.currentState = 0;
                                break;
                            case "OOD2.XorControl":
                                XorControl xor = (XorControl)subcontrol;
                                if (xor.checkStatus())
                                    xor.currentState = 1;
                                else
                                    xor.currentState = 0;
                                break;
                            case "OOD2.NotControl":
                                NotControl not = (NotControl)subcontrol;
                                if (not.checkStatus())
                                    not.currentState = 1;
                                else
                                    not.currentState = 0;
                                break;
                        }
                    }
                    else
                    {
                        this.foundUnknown = true;
                    }

                    recursiveIterator(subcontrol, control);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // we're gonna saving the current state here, yo
            if (this.controls.Count == 0)
            {
                MessageBox.Show("You might want to create a design first.");
                return;
            }


            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {

                Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>(this.controls.Count);

                foreach (BaseControl control in this.controls)
                {
                    Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
                    List<string> typeList = new List<string>(1);
                    typeList.Add(control.GetType().ToString());
                    data.Add("type", typeList);

                    List<string> stateList = new List<string>(1);
                    stateList.Add(control.currentState.ToString());
                    data.Add("currentState", stateList);

                    List<string> xList = new List<string>(1);
                    xList.Add(control.tellPosition().X.ToString());
                    data.Add("x", xList);

                    List<string> yList = new List<string>(1);
                    yList.Add(control.tellPosition().Y.ToString());
                    data.Add("y", yList);

                    List<string> inputs = new List<string>(control.inputs.Count);
                    foreach (BaseControl input in control.inputs)
                    {
                        inputs.Add(input.getInstanceId().ToString());
                    }
                    data.Add("inputs", inputs);

                    List<string> outputs = new List<string>(control.outputs.Count);
                    foreach (BaseControl output in control.outputs)
                    {
                        outputs.Add(output.getInstanceId().ToString());
                    }
                    data.Add("outputs", outputs);

                    dict.Add(control.getInstanceId().ToString(), data);
                }

                // now: xml
                System.Runtime.Serialization.DataContractSerializer serializer = new System.Runtime.Serialization.DataContractSerializer(dict.GetType());

                String outputString;

                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
                    {
                        // add formatting so the XML is easy to read in the log
                        writer.Formatting = System.Xml.Formatting.Indented;

                        serializer.WriteObject(writer, dict);

                        writer.Flush();

                        outputString = sw.ToString();
                    }
                }

                System.IO.StreamWriter file = null;

                try
                {
                    file = new System.IO.StreamWriter(saveFileDialog.FileName);
                    file.WriteLine(outputString);
                    file.Close();
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("An error occurred while writing the file, sorry!");
                }
                finally
                {
                    if (file != null)
                        file.Close();
                    MessageBox.Show("Save file successfully created!");
                }
            }
        }

        private void clearCanvas()
        {
            this.controls.Clear();
            this.controls = new List<Control>();
            this.activeControls.Clear();
            this.activeControls = new List<Control>();
            this.canvas.Controls.Clear();
            this.canvas.Invalidate();
        }

        private BaseControl getControlByInstanceId(String instanceId)
        {
            foreach (BaseControl control in this.controls)
            {
                if (control.getInstanceId().ToString() == instanceId)
                    return control;
            }
            return null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                System.IO.StreamReader file = null;
                String xmlString = "";

                try
                {
                    file = new System.IO.StreamReader(openFileDialog.OpenFile());
                    xmlString = file.ReadToEnd();
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("An error occurred while reading the file, sorry!");
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }

                System.Runtime.Serialization.DataContractSerializer deserializer = null;

                using (System.IO.Stream stream = new System.IO.MemoryStream())
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(xmlString);
                    stream.Write(data, 0, data.Length);
                    stream.Position = 0;

                    Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>(this.controls.Count);
                    deserializer = new System.Runtime.Serialization.DataContractSerializer(dict.GetType());

                    // clear the workspace
                    this.clearCanvas();

                    // in the first round, create all the controls

                    try
                    {

                        foreach (KeyValuePair<string, Dictionary<string, List<string>>> control in (Dictionary<string, Dictionary<string, List<string>>>)deserializer.ReadObject(stream))
                        {
                            Dictionary<string, List<string>> controlData = control.Value;

                            BaseControl controlObj = new BaseControl();

                            switch (controlData["type"].First())
                            {
                                case "OOD2.AndControl":
                                    controlObj = new AndControl();
                                    break;
                                case "OOD2.OrControl":
                                    controlObj = new OrControl();
                                    break;
                                case "OOD2.XorControl":
                                    controlObj = new XorControl();
                                    break;
                                case "OOD2.NotControl":
                                    controlObj = new NotControl();
                                    break;
                                case "OOD2.BaseSink":
                                    controlObj = new BaseSink();
                                    break;
                                case "OOD2.BaseSource":
                                    controlObj = new BaseSource();
                                    break;
                            }

                            controlObj.Location = new Point(Convert.ToInt32(controlData["x"].First()), Convert.ToInt32(controlData["y"].First()));
                            controlObj.currentState = Convert.ToInt32(controlData["currentState"].First());
                            controlObj.setInstanceId(control.Key);

                            // draw it on the canvas
                            controlObj.draw(controlObj.Location, this.canvas);
                            controlObj.MouseClick -= new MouseEventHandler(controlClickHandler);
                            controlObj.MouseDown -= new MouseEventHandler(connectControlsStart);
                            controlObj.MouseUp -= new MouseEventHandler(connectControlsEnd);
                            controlObj.MouseClick += new MouseEventHandler(controlClickHandler);
                            controlObj.MouseDown += new MouseEventHandler(connectControlsStart);
                            controlObj.MouseUp += new MouseEventHandler(connectControlsEnd);

                            this.controls.Add(controlObj);
                        }

                        // reset stream
                        stream.Position = 0;

                        // in the second round, create all the connections
                        foreach (KeyValuePair<string, Dictionary<string, List<string>>> control in (Dictionary<string, Dictionary<string, List<string>>>)deserializer.ReadObject(stream))
                        {
                            Dictionary<string, List<string>> controlData = control.Value;

                            BaseControl controlObj = this.getControlByInstanceId(control.Key);

                            foreach (String output in controlData["outputs"])
                            {
                                BaseControl outputObj = this.getControlByInstanceId(output);
                                controlObj.outputs.Add(outputObj);
                            }

                            foreach (String input in controlData["inputs"])
                            {
                                BaseControl inputObj = this.getControlByInstanceId(input);
                                controlObj.inputs.Add(inputObj);
                            }
                        }

                    } 
                    catch (Exception) 
                    {
                        MessageBox.Show("An error occurred while loading the file. Make sure its an .designersav file!");
                    }
                    finally 
                    {
                        this.canvas.Invalidate();
                        this.run();
                    }
                        
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the canvas without saving?", null, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.clearCanvas();
            }
        }
    }
}