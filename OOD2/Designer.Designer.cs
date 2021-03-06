﻿namespace OOD2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.baseAndControl = new OOD2.AndControl();
            this.baseOrControl = new OOD2.OrControl();
            this.baseSink = new OOD2.BaseSink();
            this.baseXorControl = new OOD2.XorControl();
            this.baseSource = new OOD2.BaseSource();
            this.baseNotControl = new OOD2.NotControl();
            this.testControl1 = new OOD2.BaseControl();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseAndControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOrControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseNotControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Ivory;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(151, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(446, 703);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(25, 639);
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
            this.btnDelete.Location = new System.Drawing.Point(25, 610);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete control(s)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baseAndControl);
            this.groupBox1.Controls.Add(this.baseOrControl);
            this.groupBox1.Controls.Add(this.baseSink);
            this.groupBox1.Controls.Add(this.baseXorControl);
            this.groupBox1.Controls.Add(this.baseSource);
            this.groupBox1.Controls.Add(this.baseNotControl);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 389);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(25, 693);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 23);
            this.btnHelp.TabIndex = 12;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(25, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "save.designersav";
            this.saveFileDialog.Filter = "Designer Save files|.designersav";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(25, 542);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(101, 23);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // baseAndControl
            // 
            this.baseAndControl.AllowDrop = true;
            this.baseAndControl.Image = ((System.Drawing.Image)(resources.GetObject("baseAndControl.Image")));
            this.baseAndControl.Location = new System.Drawing.Point(28, 29);
            this.baseAndControl.Name = "baseAndControl";
            this.baseAndControl.Size = new System.Drawing.Size(75, 50);
            this.baseAndControl.TabIndex = 4;
            this.baseAndControl.TabStop = false;
            this.baseAndControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseOrControl
            // 
            this.baseOrControl.AllowDrop = true;
            this.baseOrControl.Image = ((System.Drawing.Image)(resources.GetObject("baseOrControl.Image")));
            this.baseOrControl.Location = new System.Drawing.Point(28, 85);
            this.baseOrControl.Name = "baseOrControl";
            this.baseOrControl.Size = new System.Drawing.Size(75, 50);
            this.baseOrControl.TabIndex = 5;
            this.baseOrControl.TabStop = false;
            this.baseOrControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseSink
            // 
            this.baseSink.AllowDrop = true;
            this.baseSink.Image = global::OOD2.Properties.Resources.input_on;
            this.baseSink.Location = new System.Drawing.Point(47, 307);
            this.baseSink.Name = "baseSink";
            this.baseSink.Size = new System.Drawing.Size(37, 58);
            this.baseSink.TabIndex = 9;
            this.baseSink.TabStop = false;
            this.baseSink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseXorControl
            // 
            this.baseXorControl.AllowDrop = true;
            this.baseXorControl.Image = ((System.Drawing.Image)(resources.GetObject("baseXorControl.Image")));
            this.baseXorControl.Location = new System.Drawing.Point(28, 141);
            this.baseXorControl.Name = "baseXorControl";
            this.baseXorControl.Size = new System.Drawing.Size(75, 50);
            this.baseXorControl.TabIndex = 6;
            this.baseXorControl.TabStop = false;
            this.baseXorControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // baseSource
            // 
            this.baseSource.AllowDrop = true;
            this.baseSource.Image = ((System.Drawing.Image)(resources.GetObject("baseSource.Image")));
            this.baseSource.Location = new System.Drawing.Point(47, 253);
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
            this.baseNotControl.Location = new System.Drawing.Point(28, 197);
            this.baseNotControl.Name = "baseNotControl";
            this.baseNotControl.Size = new System.Drawing.Size(75, 50);
            this.baseNotControl.TabIndex = 7;
            this.baseNotControl.TabStop = false;
            this.baseNotControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
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
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(25, 664);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear canvas";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 727);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.canvas);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(626, 766);
            this.MinimumSize = new System.Drawing.Size(626, 766);
            this.Name = "Designer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Designer";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baseAndControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOrControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseNotControl)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;





    }
}

