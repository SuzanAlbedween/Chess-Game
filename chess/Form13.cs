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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        public int towplayer, computerplye, makegame;
        public  string level;

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();

        }

        private void Form13_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
                groupBox1.Visible = false;
            computerplye = 0;
            makegame = 0;
            towplayer = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            towplayer = 0;
            makegame = 0;
            computerplye = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            computerplye = 0;
            towplayer = 0;
            makegame = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (towplayer == 1)
            {
                Form1 f1 = new Form1();
                f1.playernum = Form11.playernum;
                f1.colorplay = Form11.playernum;
                f1.fname = Form11.fname;
                f1.lname = Form11.lname;
                f1.date = Form11.date;
                f1.Show();
            }
            else
                if (computerplye == 1)
                {
                    if (radioButton1.Checked == true)
                    {
                        Form8 f8 = new Form8();
                        level = "easy";
                        f8.level = level;
                        f8.playernum = Form11.playernum;
                        f8.colorplay = Form11.playernum;
                        f8.fname = Form11.fname;
                        f8.lname = Form11.lname;
                        f8.date = Form11.date;

                        f8.Show();

                    }
                    else
                    {
                        Form2 f2 = new Form2();
                        f2.playernum = Form11.playernum; 
                        level = "diffuclt";
                        f2.level = level;
                        f2.colorplay = Form11.playernum;
                        f2.fname = Form11.fname;
                        f2.lname = Form11.lname;
                        f2.date = Form11.date;
                        f2.Show();

                    }


                }

            if (makegame == 1)
            {
                Form5 f5 = new Form5();
                Form1 f1 = new Form1();
                f5.playernum = Form11.playernum;
                f1.colorplay = Form11.playernum;
                f1.fname = Form11.fname;
                f1.lname = Form11.lname;
                f1.date = Form11.date;
                f5.Show();
            }




            if (makegame == 0 && computerplye == 0 && towplayer == 0)
                MessageBox.Show("Chose the type of game");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

       

       
    }
}
