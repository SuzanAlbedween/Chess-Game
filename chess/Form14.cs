using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace chess
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        public string getmat, timew, timeb, gsteps, pacisew, pacieb ,level;
        public bool playwithcomputer = false;
        public static string step2p, step1p,timb,timw;
        public int[] pac = new int[32];
        public int[,] reeemat =  {{0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0} };


        public int c1, c2;
        public static bool saved = false ,savedmat=false;
        public static int colorplay; 

        private void button1_Click(object sender, EventArgs e)
        {
          
   
            string db = "\\chess.mdb";

            string sql= ("Select * from  users" + " where fname ='" + textBox1.Text + "';");
            dataGridView1.DataSource = Dbase.SelectFromTable(sql, db);


        



 if (radioButton1.Checked == true)
                playwithcomputer = true;
            else if (radioButton2.Checked == true)
                playwithcomputer = false;
            else MessageBox.Show("chosse kind of game");


            

        }

      


      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int id;
            string db = "\\chess.mdb";  
           
          DataGridViewRow roww = dataGridView1.Rows[i];
          colorplay = int.Parse(roww.Cells[4].Value.ToString());
          if (playwithcomputer == false)
          {
              id = int.Parse(roww.Cells[3].Value.ToString());
             
          }
          else {
              id = int.Parse(roww.Cells[6].Value.ToString());
          
          } 
            
 //label2.Text = id.ToString();
 if (playwithcomputer == false)
 {string sql1 = ("Select * from  gamepp" + " where id_gametowply =" + id + ";");
     getmat = Dbase.SelectFromTable(sql1, db).Rows[0][2].ToString();
     replaymat(getmat);
     timew = Dbase.SelectFromTable(sql1, db).Rows[0][3].ToString();
     timw = timew;
     timeb = Dbase.SelectFromTable(sql1, db).Rows[0][4].ToString();
     timb = timeb;
     gsteps = Dbase.SelectFromTable(sql1, db).Rows[0][5].ToString();
     step2p = gsteps;
     pacisew = Dbase.SelectFromTable(sql1, db).Rows[0][7].ToString();
     setpacess(pacisew,-1);
     pacieb = Dbase.SelectFromTable(sql1, db).Rows[0][8].ToString();
     setpacess(pacieb,1);
     putmat.pushmat = reeemat;
     putmat.check = 1;
     putmat.pushpace = pac;
     putmat.checkpace = 1;
    // label7.Text = "";
    // for(int y=0;y<putmat.pushpace.Length;y++)
    // label7.Text+= putmat.pushpace[y].ToString();
     Form1 f1 = new Form1();
    f1.Show();
     this.Hide();

 }
 else
 {
     string sql2 = ("Select * from hhh" + " where a =" + id + ";");
     level = Dbase.SelectFromTable(sql2, db).Rows[0][2].ToString();
     getmat = Dbase.SelectFromTable(sql2, db).Rows[0][3].ToString();
     replaymat(getmat);
     timew = Dbase.SelectFromTable(sql2, db).Rows[0][4].ToString();
     timw = timew;
     timeb = Dbase.SelectFromTable(sql2, db).Rows[0][5].ToString();
     timb = timeb;
     gsteps = Dbase.SelectFromTable(sql2, db).Rows[0][7].ToString();
     step1p = gsteps;
     pacisew = Dbase.SelectFromTable(sql2, db).Rows[0][8].ToString();
    setpacess(pacisew,-1);
     pacieb = Dbase.SelectFromTable(sql2, db).Rows[0][9].ToString();
     setpacess(pacieb,1);
     putmat.pushmat = reeemat;
   
     putmat.pushpace = pac;
     putmat.checkpace = 2;
     if (level == "diffuclt")
     {
         putmat.check = 3; 
         Form2 f2 = new Form2();
         f2.Show();
         this.Hide();
         
     }
     else {
         putmat.check = 2;
         Form8 f8 = new Form8();
         f8.Show();
         this.Hide();
     }
 }

            
 int[,] gg = new int[2, 16];
 

        }

        public void setpacess(string st,int n)
        {
            
             
            int b;
            string a;
   
        
            for (int i = 0; i < st.Length; i++)
            {
              
                
                if (n < 0)
                {
                    if (st.Substring(i, 1) != "," && st.Substring(i, 1) != "-")
                    {
                      
                        if (st[i] != 0)
                        {
                            a = st.Substring(i, 1);
                            b = int.Parse(a) *-1;
                            pac[c1] = b;
                      
                          c1++;
                          
                        }

                    }

                }
               if(n>0)
                {
                    if (st.Substring(i, 1) != ",")
                    {
                    
                        if (st[i] != 0)
                        {
                            a = st.Substring(i, 1);
                            b = int.Parse(a) ;
                            pac[c1]= b;
                     
                            c1++; 
                           
                        }

                    }
                
                }

            }



            saved = true;


        }
        
        
//לשחזר את המטריצה מבסיס נתונים


      

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }


        public void replaymat(string mat)
        {
            int  k, sub,c=0,saleb;
            int []tt = new int[64];
           
                    for (k = 0; k < mat.Length; k++)
                    { if (mat.Substring(k, 1) != "." && mat.Substring(k, 1) != "-")
                        {
                            sub = int.Parse(mat.Substring(k, 1));

                            tt[c] = sub;

                            c++;
                           
                        }


                        else if ((mat.Substring(k, 1) == "." || mat.Substring(k, 1) != "-") && mat.Substring(k + 1, 1) == "-")
                        {
                           saleb = -1;
                         k += 2;
                            
                            sub = int.Parse(mat.Substring(k, 1)) * saleb;
                           tt[c] = sub;
                           c++;
                          

                        }








                    }
                



            

           
            int s = 0;
            for (int r = 0; r <8; r++)
            {
                for (int n = 0; n <8; n++)
                {
                    reeemat[r, n] = tt[s];
                    s++;
                   
                }
            }

        }

        private void Form14_Load(object sender, EventArgs e)
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
