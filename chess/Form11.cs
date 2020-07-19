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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
   
        public static int playernum;

        public  static string level,fname,lname,date;
             

       

        private void button2_Click(object sender, EventArgs e)
        {
            playernum = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playernum = -1;

        }

     

        

       
        private void button7_Click(object sender, EventArgs e)
        {
            playernum = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fname = textBox1.Text;
            lname = textBox2.Text;
            date = dateTimePicker1.MinDate.Date.ToShortDateString();
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

       
      

       
    }
}
