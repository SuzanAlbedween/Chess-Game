using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unit4.CollectionsLib;
namespace chess
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string db, sql1;
                db = "\\chess.mdb";
                sql1 = (" SELECT TOP 5 * FROM winerstocomputer order by minttime ;");
                dataGridView1.DataSource = Dbase.SelectFromTable(sql1, db);


           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string db, sql1;
            db = "\\chess.mdb";
            sql1 = (" SELECT TOP 5 * FROM winerstowplayers order by mintetime ;");
            dataGridView2.DataSource = Dbase.SelectFromTable(sql1, db);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }


      

      
    }
}
