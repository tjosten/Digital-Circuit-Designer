namespace OOD2
{
    partial class Designer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Designer));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.baseSink = new OOD2.BaseSink();
            this.baseSource = new OOD2.BaseSource();
            this.baseNotControl = new OOD2.NotControl();
            this.baseXorControl = new OOD2.XorControl();
            this.baseOrControl = new OOD2.OrControl();
            this.baseAndControl = new OOD2.AndControl();
            this.testControl1 = new OOD2.BaseControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseNotControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOrControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseAndControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(151, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(501, 578);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(12, 558);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(101, 23);
            this.btnRedraw.TabIndex = 2;
            this.btnRedraw.Text = "Redraw canvas";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(12, 529);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete control(s)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // baseSink
            // 
            this.baseSink.AllowDrop = true;
            this.baseSink.Image = global::OOD2.Properties.Resources.input_on;
            this.baseSink.Location = new System.Drawing.Point(57, 290);
            this.baseSink.Name = "baseSink";
            this.baseSink.Size = new System.Drawing.Size(37, 58);
            this.baseSink.TabIndex = 9;
            this.baseSink.TabStop = false;
            this.baseSink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseSource
            // 
            this.baseSource.AllowDrop = true;
            this.baseSource.Image = ((System.Drawing.Image)(resources.GetObject("baseSource.Image")));
            this.baseSource.Location = new System.Drawing.Point(57, 236);
            this.baseSource.Name = "baseSource";
            this.baseSource.Size = new System.Drawing.Size(37, 48);
            this.baseSource.TabIndex = 8;
            this.baseSource.TabStop = false;
            this.baseSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseNotControl
            // 
            this.baseNotControl.AllowDrop = true;
            this.baseNotControl.Image = ((System.Drawing.Image)(resources.GetObject("baseNotControl.Image")));
            this.baseNotControl.Location = new System.Drawing.Point(38, 180);
            this.baseNotControl.Name = "baseNotControl";
            this.baseNotControl.Size = new System.Drawing.Size(75, 50);
            this.baseNotControl.TabIndex = 7;
            this.baseNotControl.TabStop = false;
            this.baseNotControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseXorControl
            // 
            this.baseXorControl.AllowDrop = true;
            this.baseXorControl.Image = ((System.Drawing.Image)(resources.GetObject("baseXorControl.Image")));
            this.baseXorControl.Location = new System.Drawing.Point(38, 124);
            this.baseXorControl.Name = "baseXorControl";
            this.baseXorControl.Size = new System.Drawing.Size(75, 50);
            this.baseXorControl.TabIndex = 6;
            this.baseXorControl.TabStop = false;
            this.baseXorControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseOrControl
            // 
            this.baseOrControl.AllowDrop = true;
            this.baseOrControl.Image = ((System.Drawing.Image)(resources.GetObject("baseOrControl.Image")));
            this.baseOrControl.Location = new System.Drawing.Point(38, 68);
            this.baseOrControl.Name = "baseOrControl";
            this.baseOrControl.Size = new System.Drawing.Size(75, 50);
            this.baseOrControl.TabIndex = 5;
            this.baseOrControl.TabStop = false;
            this.baseOrControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseAndControl
            // 
            this.baseAndControl.AllowDrop = true;
            this.baseAndControl.Image = ((System.Drawing.Image)(resources.GetObject("baseAndControl.Image")));
            this.baseAndControl.Location = new System.Drawing.Point(38, 12);
            this.baseAndControl.Name = "baseAndControl";
            this.baseAndControl.Size = new System.Drawing.Size(75, 50);
            this.baseAndControl.TabIndex = 4;
            this.baseAndControl.TabStop = false;
            this.baseAndControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // testControl1
            // 
            this.testControl1.AllowDrop = true;
            this.testControl1.Location = new System.Drawing.Point(38, 12);
            this.testControl1.Name = "testControl1";
            this.testControl1.Size = new System.Drawing.Size(75, 50);
            this.testControl1.TabIndex = 1;
            this.testControl1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 48);
            this.button1.TabIndex = 10;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.run_Click);
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 605);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.baseSink);
            this.Controls.Add(this.baseSource);
            this.Controls.Add(this.baseNotControl);
            this.Controls.Add(this.baseXorControl);
            this.Controls.Add(this.baseOrControl);
            this.Controls.Add(this.baseAndControl);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.canvas);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 632);
            this.MinimumSize = new System.Drawing.Size(672, 632);
            this.Name = "Designer";
            this.Text = "Designer";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseNotControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOrControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseAndControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private BaseControl testControl1;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Button btnDelete;
        private AndControl baseAndControl;
        private OrControl baseOrControl;
        private XorControl baseXorControl;
        private NotControl baseNotControl;
        private BaseSource baseSource;
        private BaseSink baseSink;
        private System.Windows.Forms.Button button1;





    }
}

