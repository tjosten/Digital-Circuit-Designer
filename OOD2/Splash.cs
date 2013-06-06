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
    public partial class Splash : Form
    {

        delegate void hideCallback();

        public Splash()
        {
            InitializeComponent();

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(hideSplash);
            timer.Start();
        }

        void doHideSplash()
        {
            if (this.InvokeRequired)
            {
                hideCallback d = new hideCallback(doHideSplash);
                this.Invoke(d);
            }
            else
            {
                this.Hide();
                this.Dispose();
            }
        }

        void hideSplash(Object sender, System.Timers.ElapsedEventArgs e)
        {
            this.doHideSplash();
            ((System.Timers.Timer)sender).Stop();
            ((System.Timers.Timer)sender).Dispose();
        }
    }
}
