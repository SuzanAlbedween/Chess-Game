using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chess
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            groupBox1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
         
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            if (radioButton2.Checked == true)
            {
                f14.Show();
                this.Hide();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

       
    }
}
