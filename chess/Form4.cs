using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace chess
{
    public partial class Form4 : Form
    {
        public WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();
        public Form4()
        {
            InitializeComponent();
           // string path = System.Environment.CurrentDirectory;
           // path += @"\flashvortex (1).swf";
           // axShockwaveFlash1.LoadMovie(0,path);
          //  axShockwaveFlash1.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            wp.controls.play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wp.controls.stop();
        }
       
       
       

       
    }
}
