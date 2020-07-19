using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unit4.CollectionsLib;
using System.Media;
using System.Data.OleDb;
//
// 
namespace chess
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

   public     int[,] mat = {     {2,3,4,5,6,4,3,2},
                            {1,1,1,1,1,1,1,1},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {-1,-1,-1,-1,-1,-1,-1,-1},
                            {-2,-3,-4,-5,-6,-4,-3,-2} };

        public PictureBox[] picbox;
        public int playernum = 1;
        public Point lastclick = new Point();
        public int[] kings = { 0, 0 };
        public int[] rooks = { 0, 0 };
        public Point[] kingsplace = { new Point(7, 4), new Point(0, 4) };
        public WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();
    public  int h1, min1, s1, m1 = 0, m2 = 0, h2, min2, s2;

    public int canx, cany, replace = 1, colorplay, winer, savepac;
        public Point befor1, befor2, after1, after2;  
     public   bool flage = true,savegame=false;
        public int c,steps;
        public string fname, lname, date, lossw, lossb, result;
        public static int backp;
        public int plycolor
        {
            get { return colorplay; }
            set { colorplay = value; }
        }

        public string fnameuser
        {
            get { return fname; }
            set { fname = value; }
        }

        public string lnameuser
        {
            get { return lname; }
            set { lname = value; }
        }


        public string datetime
        {
            get { return date; }
            set { date = value; }
        }



        // פונקציה הזות מקבלת שני פרמטרים שלמים ובודקת מה סוג של הקטע שקבלנו לפי מערך דומימדי
        public void Wathitem(int i, int j)
        {
            if (playernum == -1)
                timer1.Start();
            else
                timer2.Start();

            
            switch (mat[i, j])// pwan +
            {
                case 1: Pawn p1 = new Pawn(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    p1.showGreenplaces(i, j, picbox); break;
                case 2: rook r1 = new rook(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    r1.showGreenplaces(i, j, picbox); break;
                case 3: knight kn1 = new knight(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    kn1.showGreenplaces(i, j, picbox); break;
                case 4: fou f1 = new fou(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    f1.showGreenplaces(i, j, picbox); break;
                case 5: queen q1 = new queen(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    q1.showGreenplaces(i, j, picbox); break;
                case 6: king k1 = new king(new Point(i, j), mat, picbox, playernum, kings, rooks);
                    k1.showGreenplaces(i, j, picbox); k1.showorangeplace(); break;
                case -1: Pawn p2 = new Pawn(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    p2.showGreenplaces(i, j, picbox); break;
                case -2: rook r2 = new rook(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    r2.showGreenplaces(i, j, picbox); break;
                case -3: knight kn2 = new knight(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    kn2.showGreenplaces(i, j, picbox); break;
                case -4: fou f2 = new fou(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    f2.showGreenplaces(i, j, picbox); break;
                case -5: queen q2 = new queen(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                    q2.showGreenplaces(i, j, picbox); break;
                case -6: king k2 = new king(new Point(i, j), mat, picbox, playernum, kings, rooks);
                    k2.showGreenplaces(i, j, picbox); k2.showorangeplace(); break;
                default: break;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string stimw="",stimb="";
            c = 0;
            replace = 1;
            game_main pppp = new game_main();
       
            if (passing_value.bdika == 1)
            {

                mat = passing_value.newmat;
                playernum = passing_value.playernum;
            }
            if (putmat.check == 1)
            {
                mat = putmat.pushmat;
                label7.Text = Form14.timw;
                stimw = label7.Text;

                puttime(stimw, -1);
                label9.Text = Form14.timb;

                stimb = label9.Text;
                puttime(stimb, 1);
                label5.Text = Form14.step2p;

                getlossers(putmat.pushpace);
            }
          
            // wp.URL = pppp.imageurl("sound\\sound.mp3");
            // wp.controls.play();
            PictureBox[] picbox2 = { p00, p01, p02, p03, p04, p05, p06, p07, p10, p11, p12, p13, p14, p15, p16, p17, p20, p21, p22, p23, p24, p25, p26, p27, p30, p31, p32, p33, p34, p35, p36, p37, p40, p41, p42, p43, p44, p45, p46, p47, p50, p51, p52, p53, p54, p55, p56, p57, p60, p61, p62, p63, p64, p65, p66, p67, p70, p71, p72, p73, p74, p75, p76, p77 };
            picbox = picbox2;
            int p = 0;
           
           
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (mat[i, j] != 0)
                    {
                        picbox2[p].ImageLocation = pppp.chessimage(mat[i, j]);
                        picbox2[p].SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else picbox[p].Image = null;
                    picbox2[p].Visible = true;
                    p++;
                }
    
            pppp.playerrole(playernum, picbox, mat);

        }
        void getlossers(int[] a)
        {
            int c1 = 0,c2=0;
            game_main pppp = new game_main();
            PictureBox[] picbox1 = { pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10, pp11, pp12, pp13, pp14, pp15, pp16 };
            PictureBox[] picbox2 = { pw1, pw2, pw3, pw4, pw5, pw6, pw7, pw8, pw9, pw10, pw11, pw12, pw13, pw14, pw15, pw16 };
            for (int ii = 0; ii < 32; ii++)
            {
                if (a[ii] > 0)
                {


                    if (picbox1[c1].Image == null)
                    {
                        picbox1[c1].ImageLocation = pppp.chessimage(a[ii]);
                        picbox1[c1].SizeMode = PictureBoxSizeMode.CenterImage;
                        c1++;
                    

                    }




                }
                else if (a[ii] < 0)
                {

                    if (picbox2[c2].Image == null)
                    {
                        picbox2[c2].ImageLocation = pppp.chessimage(a[ii]);
                        picbox2[c2].SizeMode = PictureBoxSizeMode.CenterImage;
                      
                        c2++;
                    }

                }


            }

            

        }
        public void puttime(string stt,int h)
        {
            int[] a = new int[4];
            int c = 0, num = 0, b;
            for (int i = 0; i <stt.Length;i++)
            {
                if (stt.Substring(i, 1) != ":")
                {
                    b = int.Parse(stt.Substring(i, 1));
                  
                    num *= 10;
                  num += b;
                }
                else
                {
                    a[c] = num;
                    num = 0;
                    c++;
                }
            }
            if (h > 0)
            {
                h2 = a[0];
                min2 = a[1];
                s2 = a[2];
                m2 = a[3];
            }
            else if(h<0)
            {
                h1 = a[0];
                min1 = a[1];
                s1 = a[2];
                m1 = a[3];

            }

        }
        public  void setlosser()
        {
            PictureBox[] picbox3 = { pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10, pp11, pp12, pp13, pp14, pp15, pp16 };
            PictureBox[] picbox4 = { pw1, pw2, pw3, pw4, pw5, pw6, pw7, pw8, pw9, pw10, pw11, pw12, pw13, pw14, pw15, pw16 };
            
            game_main pppp = new game_main();

            for (int i = 0; i < 16; i++)
            {


                if (game_main.loss > 0)
                {
                   
                       
                    if (picbox3[i].Image == null)
                    {
                        picbox3[i].ImageLocation = pppp.chessimage(game_main.loss);
                        picbox3[i].SizeMode = PictureBoxSizeMode.CenterImage;
                        
                        break;

                    }
                  
                   


                }
                else if (game_main.loss < 0)
                {
                   
                    if (picbox4[i].Image == null)
                    {
                        picbox4[i].ImageLocation = pppp.chessimage(game_main.loss);
                        picbox4[i].SizeMode = PictureBoxSizeMode.CenterImage;
                        break;

                    }

                }

            }
            
        }
        void gooo(int x, int y)
        {
            game_main.loss = 0;
            if (playernum == 1)
                timer1.Start();
            else
            {
                timer2.Start();

            }

            if (flage == true)
            {
                canx = x;
                cany = y;
                flage = false;
            }
            if (steps == 40)
            {
                for (int i = 0; i < 64; i++)
                    picbox[i].Enabled = false;
                MessageBox.Show("equality ");
                result = "drow";
                winer = 3;

            }

            game_main pppp = new game_main();
            computerplayer comp = new computerplayer();
          
            if (picbox[x * 10 + y - 2 * x].BackColor == Color.Green || picbox[x * 10 + y - 2 * x].BackColor == Color.Yellow)
            {

                pppp.IFgreenmovelastItem(lastclick, picbox, mat, x, y, pppp.chessimage(mat[lastclick.X, lastclick.Y]), kings, rooks, kingsplace);
                      setlosser();
                      if (game_main.loss > 0)
                          lossb += game_main.loss + ",";
                      else if(game_main.loss!=0)
                          lossw += game_main.loss + ",";
                    
                history(x, y, canx, cany);
                flage = true;

                pppp.refreshcolors(picbox, playernum, mat);
                if (Form2.justkings(mat) == true)
                    steps++;
                                                                
                playernum = playernum * -1;
            
               pppp.playerrole(playernum, picbox, mat);
              
            }
            else
            {
                pppp.refreshcolors(picbox, playernum, mat);

                Wathitem(x, y);

            }
         if (playernum == 1)
            {
                timer1.Stop();
                timer2.Start();

            }
            else
            {
                timer2.Stop();
                timer1.Start();


            }


            int x1 = kingsplace[0].X;
            int y1 = kingsplace[0].Y;
            int x2 = kingsplace[1].X;
            int y2 = kingsplace[1].Y;
            Point kp = new Point(-1, -1);
            king k1 = new king(new Point(x1, y1), mat, picbox, playernum, kings, rooks);
            king k2 = new king(new Point(x2, y2), mat, picbox, playernum, kings, rooks);
            if (k1.toking(x1, y1, mat, picbox, 1) != new Point(-1, -1)) { k1.redtoging(new Point(x1, y1), picbox, -1); }
            if (k2.toking(x2, y2, mat, picbox, -1) != new Point(-1, -1)) { k2.redtoging(new Point(x2, y2), picbox, 1); }
            if (k1.toking(x1, y1, mat, picbox, 1) != new Point(-1, -1) && playernum == -1) k1.shah(x1, y1, picbox, mat, -1);
            if (k2.toking(x2, y2, mat, picbox, -1) != new Point(-1, -1) && playernum == 1) k2.shah(x2, y2, picbox, mat, 1);

            if (k1.deathofking(x1, y1, mat, picbox, kings, rooks, 1) == true)
                if (k1.helping(1, mat, x1, y1, picbox, kings, rooks).IsEmpty() == true)
                {
                    timer1.Stop();
                    timer2.Stop();
                    k1.shahmeet("wihte lose!");
                    result = "1";
                    winer = 1;

                }



            if (k2.deathofking(x2, y2, mat, picbox, kings, rooks, -1) == true)
                if (k2.helping(-1, mat, x2, y2, picbox, kings, rooks).IsEmpty() == true)
                {
                    timer1.Stop();
                    timer2.Stop();
                    k2.shahmeet("blcak lose!");
                    result = "-1";
                    winer = -1;
                    
                }


            lastclick = new Point(x, y);
          

        }




        public void history(int x, int y, int oldx11, int oldy11)
        {

            switch (oldy11)
            {

                case 7: label5.Text += "A " + oldx11.ToString() + " -  "; break;
                case 6: label5.Text += "B " + oldx11.ToString() + " -  "; break;
                case 5: label5.Text += "C " + oldx11.ToString() + " -  "; break;
                case 4: label5.Text += "D " + oldx11.ToString() + " -  "; break;
                case 3: label5.Text += "D " + oldx11.ToString() + " -  "; break;
                case 2: label5.Text += "F " + oldx11.ToString() + " -  "; break;
                case 1: label5.Text += "G " + oldx11.ToString() + " -  "; break;
                case 0: label5.Text += "H " + oldx11.ToString() + " -  "; break;
                default: break;

            }


            switch (y)
            {

                case 7: label5.Text += "A" + x.ToString() + "\n"; break;
                case 6: label5.Text += "B" + x.ToString() + "\n"; break;
                case 5: label5.Text += "C" + x.ToString() + "\n"; break;
                case 4: label5.Text += "D" + x.ToString() + "\n"; break;
                case 3: label5.Text += "E" + x.ToString() + "\n"; break;
                case 2: label5.Text += "F" + x.ToString() + "\n"; break;
                case 1: label5.Text += "G" + x.ToString() + "\n"; break;
                case 0: label5.Text += "H" + x.ToString() + "\n"; break;
                default: break;


            }


        }



        private void p16_Click(object sender, EventArgs e)
        {
            int x = 1, y = 6;

            gooo(x, y);
        }

        private void p00_Click(object sender, EventArgs e)
        {

            game_main pppp = new game_main();


            int x = 0, y = 0;

            gooo(x, y);
        }

        private void p10_Click(object sender, EventArgs e)
        {
            wp.controls.stop();
            int x = 1, y = 0;

            gooo(x, y);
        }

        private void p01_Click(object sender, EventArgs e)
        {
            int x = 0, y = 1;

            gooo(x, y);
        }

        private void p02_Click(object sender, EventArgs e)
        {
            int x = 0, y = 2;

            gooo(x, y);
        }

        private void p03_Click(object sender, EventArgs e)
        {
            int x = 0, y = 3;

            gooo(x, y);
        }

        private void p04_Click(object sender, EventArgs e)
        {
            int x = 0, y = 4;

            gooo(x, y);
        }

        private void p05_Click(object sender, EventArgs e)
        {
            int x = 0, y = 5;

            gooo(x, y);
        }

        private void p06_Click(object sender, EventArgs e)
        {
            int x = 0, y = 6;

            gooo(x, y);
        }

        private void p07_Click(object sender, EventArgs e)
        {
            int x = 0, y = 7;

            gooo(x, y);
        }

        private void p11_Click(object sender, EventArgs e)
        {
            int x = 1, y = 1;

            gooo(x, y);
        }

        private void p12_Click(object sender, EventArgs e)
        {
            int x = 1, y = 2;

            gooo(x, y);
        }

        private void p13_Click(object sender, EventArgs e)
        {
            int x = 1, y = 3;

            gooo(x, y);
        }

        private void p14_Click(object sender, EventArgs e)
        {
            int x = 1, y = 4;

            gooo(x, y);
        }

        private void p15_Click(object sender, EventArgs e)
        {
            int x = 1, y = 5;

            gooo(x, y);
        }

        private void p17_Click(object sender, EventArgs e)
        {
            int x = 1, y = 7;

            gooo(x, y);
        }

        private void p20_Click(object sender, EventArgs e)
        {
            int x = 2, y = 0;

            gooo(x, y);
        }

        private void p21_Click(object sender, EventArgs e)
        {
            int x = 2, y = 1;

            gooo(x, y);
        }

        private void p22_Click(object sender, EventArgs e)
        {
            int x = 2, y = 2;

            gooo(x, y);
        }

        private void p23_Click(object sender, EventArgs e)
        {
            int x = 2, y = 3;

            gooo(x, y);
        }

        private void p24_Click(object sender, EventArgs e)
        {
            int x = 2, y = 4;

            gooo(x, y);
        }

        private void p25_Click(object sender, EventArgs e)
        {
            int x = 2, y = 5;

            gooo(x, y);
        }

        private void p26_Click(object sender, EventArgs e)
        {
            int x = 2, y = 6;

            gooo(x, y);
        }

        private void p27_Click(object sender, EventArgs e)
        {
            int x = 2, y = 7;

            gooo(x, y);
        }

        private void p30_Click(object sender, EventArgs e)
        {
            int x = 3, y = 0;

            gooo(x, y);
        }

        private void p31_Click(object sender, EventArgs e)
        {
            int x = 3, y = 1;

            gooo(x, y);
        }

        private void p32_Click(object sender, EventArgs e)
        {
            int x = 3, y = 2;

            gooo(x, y);
        }

        private void p33_Click(object sender, EventArgs e)
        {
            int x = 3, y = 3;

            gooo(x, y);
        }

        private void p34_Click(object sender, EventArgs e)
        {
            int x = 3, y = 4;

            gooo(x, y);
        }

        private void p35_Click(object sender, EventArgs e)
        {
            int x = 3, y = 5;

            gooo(x, y);
        }

        private void p36_Click(object sender, EventArgs e)
        {
            int x = 3, y = 6;

            gooo(x, y);
        }

        private void p37_Click(object sender, EventArgs e)
        {
            int x = 3, y = 7;

            gooo(x, y);
        }

        private void p40_Click(object sender, EventArgs e)
        {
            int x = 4, y = 0;

            gooo(x, y);
        }

        private void p41_Click(object sender, EventArgs e)
        {
            int x = 4, y = 1;

            gooo(x, y);
        }

        private void p42_Click(object sender, EventArgs e)
        {
            int x = 4, y = 2;

            gooo(x, y);
        }

        private void p43_Click(object sender, EventArgs e)
        {
            int x = 4, y = 3;

            gooo(x, y);
        }

        private void p44_Click(object sender, EventArgs e)
        {
            int x = 4, y = 4;

            gooo(x, y);
        }

        private void p45_Click(object sender, EventArgs e)
        {
            int x = 4, y = 5;

            gooo(x, y);
        }

        private void p46_Click(object sender, EventArgs e)
        {
            int x = 4, y = 6;

            gooo(x, y);
        }

        private void p47_Click(object sender, EventArgs e)
        {
            int x = 4, y = 7;

            gooo(x, y);
        }

        private void p50_Click(object sender, EventArgs e)
        {
            int x = 5, y = 0;

            gooo(x, y);
        }

        private void p51_Click(object sender, EventArgs e)
        {
            int x = 5, y = 1;

            gooo(x, y);
        }

        private void p52_Click(object sender, EventArgs e)
        {
            int x = 5, y = 2;

            gooo(x, y);
        }

        private void p53_Click(object sender, EventArgs e)
        {
            int x = 5, y = 3;

            gooo(x, y);
        }

        private void p54_Click(object sender, EventArgs e)
        {
            int x = 5, y = 4;

            gooo(x, y);
        }

        private void p55_Click(object sender, EventArgs e)
        {
            int x = 5, y = 5;

            gooo(x, y);
        }

        private void p56_Click(object sender, EventArgs e)
        {
            int x = 5, y = 6;

            gooo(x, y);
        }

        private void p57_Click(object sender, EventArgs e)
        {
            int x = 5, y = 7;

            gooo(x, y);
        }

        private void p60_Click(object sender, EventArgs e)
        {
            int x = 6, y = 0;

            gooo(x, y);
        }

        private void p61_Click(object sender, EventArgs e)
        {
            int x = 6, y = 1;

            gooo(x, y);
        }

        private void p62_Click(object sender, EventArgs e)
        {
            int x = 6, y = 2;

            gooo(x, y);
        }

        private void p63_Click(object sender, EventArgs e)
        {
            int x = 6, y = 3;

            gooo(x, y);
        }

        private void p64_Click(object sender, EventArgs e)
        {
            int x = 6, y = 4;

            gooo(x, y);
        }

        private void p65_Click(object sender, EventArgs e)
        {
            int x = 6, y = 5;

            gooo(x, y);
        }

        private void p66_Click(object sender, EventArgs e)
        {
            int x = 6, y = 6;

            gooo(x, y);
        }

        private void p67_Click(object sender, EventArgs e)
        {
            int x = 6, y = 7;

            gooo(x, y);
        }

        private void p70_Click(object sender, EventArgs e)
        {
            int x = 7, y = 0;

            gooo(x, y);
        }

        private void p71_Click(object sender, EventArgs e)
        {
            int x = 7, y = 1;

            gooo(x, y);
        }

        private void p72_Click(object sender, EventArgs e)
        {
            int x = 7, y = 2;

            gooo(x, y);
        }

        private void p73_Click(object sender, EventArgs e)
        {
            int x = 7, y = 3;

            gooo(x, y);
        }

        private void p74_Click(object sender, EventArgs e)
        {
            int x = 7, y = 4;

            gooo(x, y);
        }

        private void p75_Click(object sender, EventArgs e)
        {
            int x = 7, y = 5;

            gooo(x, y);
        }

        private void p76_Click(object sender, EventArgs e)
        {
            int x = 7, y = 6;

            gooo(x, y);
        }

        private void p77_Click(object sender, EventArgs e)
        {
            int x = 7, y = 7;

            gooo(x, y);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

                public string convertmat(int[,] mat)
    {
        string str = "";
             
        for (int i = 0; i <8; i++)
        {
            if (i != 0)
                str += "-";
            for (int j = 0; j < 8; j++)
            {
                if (j < 7)
                    str += mat[i, j].ToString() + ".";
                else
                    str += mat[i, j].ToString();

            }
        }
        return str;

    }

       
    

          
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            label7.Text = h1 + ":" + min1 + ":" + s1 + ":" + m1.ToString();
            m1++;
            if (m1 > 10)
            {
                s1++;
                m1 = 0;
            }
            else
                m1++;
            if (s1 > 60)
            {
                min1++;
                s1 = 0;
            }
            if (min1 > 60)
            {
                h1++;
                min1 = 0;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            label9.Text = h2 + ":" + min2 + ":" + s2 + ":" + m2.ToString();
            m2++;
            if (m2 > 10)
            {
                s2++;
                m2 = 0;
            }
            else
                m2++;
            if (s2 > 60)
            {
                min2++;
                s2 = 0;
            }
            if (min2 > 60)
            {
                h2++;
                min2 = 0;
            }
        }

        
       


       //  פונקציה הזות הופכת מערך דו מימדי למחרוזת
 


    



        private void button5_Click(object sender, EventArgs e)
        {
            string wt;
            if (winer == 1)
             wt=label9.Text;
            else
               wt=label7.Text;
            string str = "\\chess.accdb";
            string sql = "INSERT INTO winerstowplayers(id_winertowplayers,id_user,fname,time_winer,id_gametowplayers,result) VALUES ('" + 12 + "','" + 51 + "','" + fname + "','" + wt + "','" + 2 + "','" +  result+ "')";
            Dbase.ChangeTable(sql, str);
        }
        
       


        public int cnvrtnum(string stt)
        {
            int[] a = new int[4];
            int c = 0, num = 0, b, finalnum;
            for (int i = 0; i < stt.Length; i++)
            {
                if (stt.Substring(i, 1) != ":")
                {
                    b = int.Parse(stt.Substring(i, 1));

                    num *= 10;
                    num += b;
                }
                else
                {
                    a[c] = num;
                    num = 0;
                    c++;
                }
            }

            finalnum = a[3] + a[2] + a[1] * 60 + a[0] * 3600;
            return finalnum;


        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegame = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            int x1, x2, x3, x4,resutmin;
            string db, sql1, sql2, sql3, inser1, inser2, inser3, stmat, wt, winername;
            stmat = convertmat(mat);
            db = "\\chess.mdb";

            sql1 = "select max (id_user) from users";
            try
            {
                x1 = int.Parse(Dbase.SelectFromTable(sql1, db).Rows[0][0].ToString());
                x1 = x1 + 1;
            }
            catch (Exception)
            {
                x1 = 0;

            }

            sql2 = "select max (id_gametowply) from gamepp";
            try
            {
                x2 = int.Parse(Dbase.SelectFromTable(sql2, db).Rows[0][0].ToString());
                x2 = x2 + 1;
            }
            catch (Exception)
            {
                x2 = 0;

            }




            inser1 = "INSERT INTO users(id_user,fname,lname,id_game,colorGame,Date_Game,id_gmaecomputer) VALUES (" + x1 + ",'" + fname + "','" + lname + "'," + x2 + "," + colorplay + ",'" + date + "'," + 0 + ")";
            Dbase.SelectFromTable(inser1, db);
            x4 = idselect.selectid(sql1, db);
            inser2 = "insert into  gamepp(id_gametowply,id_user1,matofGame,time_white,time_black,history_of_steps,id_user2,Chess_piecesw,Chess_piecesb)values ('" + x2 + "','" + x1 + "','" + stmat + "','" + label7.Text + "','" + label9.Text + "','" + label5.Text + "','" + 0 + "','" + lossw + "','" + lossb + "')";
            Dbase.ChangeTable(inser2, db);
            if (savegame == false)
            {
                sql3 = "select max (id_winertowplayers) from winerstowplayers";
                try
                {
                    x3 = int.Parse(Dbase.SelectFromTable(sql3, db).Rows[0][0].ToString());
                    x3 = x3 + 1;
                }
                catch (Exception)
                {
                    x3 = 0;

                }

                
                if (winer == 1)
                    wt = label9.Text;
                else
                    wt = label7.Text;

                resutmin = cnvrtnum(wt);
                if (winer == 3)
                {
                    winername = "draw";
                }
                else
                {
                    if (winer == colorplay)
                        winername = fname;
                    else
                        winername = "No" + fname ;
                }
                inser3 = "INSERT INTO winerstowplayers(id_winertowplayers,id_user,fname,time_winer,id_gametowplayers,result,mintetime) VALUES ('" + x3 + "','" + x1 + "','" + fname + "','" + wt + "','" + x2 + "','" + winername  +"','" + resutmin + "')";
                Dbase.ChangeTable(inser3, db);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            winer = 1;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
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
