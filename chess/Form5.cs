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
namespace chess
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public int ch = -1, x, y, c = 0,kbx,kby,kwx,kwy;
        public PictureBox[] picbox;
        public int canx, cany, finsh = 0;
     //int h1, min1, s1, m1 = 0, m2 = 0, h2, min2, s2;
       // bool flage = true;
     
        public int[,] msf = {{0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0} };

       
      
        public int playernum = 1;
        public Point lastclick = new Point();
        public Point kingb = new Point();
        public Point kingw = new Point();

        public int[] kings = { 0, 0 };
        public int[] rooks = { 0, 0 };
        public Point[] kingsplace=new Point [2];



       


     

        public void setpaciec(int x,int y){
             int p = 0;
            PictureBox[] picbox2 = { p00, p01, p02, p03, p04, p05, p06, p07, p10, p11, p12, p13, p14, p15, p16, p17, p20, p21, p22, p23, p24, p25, p26, p27, p30, p31, p32, p33, p34, p35, p36, p37, p40, p41, p42, p43, p44, p45, p46, p47, p50, p51, p52, p53, p54, p55, p56, p57, p60, p61, p62, p63, p64, p65, p66, p67, p70, p71, p72, p73, p74, p75, p76, p77 };
            game_main pppp = new game_main();
            picbox = picbox2;
            if (ch != 0)
            {
                 if (ch == 6){
                    kbx = x;
                    kby=y;
                  }
                else if (ch == -6)
                {
                    kwx = x;
                    kwy = y;
            
                }
                msf[x, y] = ch;
                ch = 0;
                picbox2[x * 10 + y - 2 * x].ImageLocation = pppp.chessimage(msf[x, y]);
                picbox2[x * 10 + y - 2 * x].SizeMode = PictureBoxSizeMode.CenterImage;
                c++;
               
            }

            else
            {
                picbox[p].Image = null;
                picbox2[p].Visible = true;
                p++;

                if (finsh != 1)
                {

                    MessageBox.Show("get another pacise");
                }
            }
        
        
        
        
        }

        private void pic00_Click(object sender, EventArgs e)
        {
            ch = 2;
          
            pic00.Image = null;
        }

        private void pic01_Click(object sender, EventArgs e)
        {
            ch = 3;
         
            pic01.Image = null;

        }

        private void pic02_Click(object sender, EventArgs e)
        {
            ch = 4;
  
            pic02.Image = null;

        }

        private void pic03_Click(object sender, EventArgs e)
        {
            ch = 5;
          
            pic03.Image = null;
         


        }

        private void pic04_Click(object sender, EventArgs e)
        {
            ch = 6;
      
            pic04.Image = null;


        }

        private void p00_Click(object sender, EventArgs e)
        {

            x = 0; y = 0;
            setpaciec(x, y);
           
        }

        private void p01_Click(object sender, EventArgs e)
        {
            x = 0; y = 1;
             setpaciec(x, y);
            
      


        }

        private void p02_Click(object sender, EventArgs e)
        {
            x = 0; y = 2;
            setpaciec(x, y);
           
        }

        private void p03_Click(object sender, EventArgs e)
        {
            x = 0; y = 3;

            setpaciec(x, y);
           
        }

        private void p04_Click(object sender, EventArgs e)
        {
            x = 0; y = 4;
    
            setpaciec(x, y);
           

        }

        private void p05_Click(object sender, EventArgs e)
        {
            x = 0; y = 5;
     
            setpaciec(x, y);
           
        }

        private void p06_Click(object sender, EventArgs e)
        {
            x = 0; y = 6;
     
            setpaciec(x, y);
          


        }

        private void p07_Click(object sender, EventArgs e)
        {
            x = 0; y = 7;
  
            setpaciec(x, y);
          
        }

        private void p10_Click(object sender, EventArgs e)
        {
            x = 1; y = 0;
 
            setpaciec(x, y);
           
        }

        private void p11_Click(object sender, EventArgs e)
        {
            x = 1; y = 1;

            setpaciec(x, y);
           
        }

        private void p12_Click(object sender, EventArgs e)
        {
            x = 1; y = 2;
  
            setpaciec(x, y);
           
        }

        private void p13_Click(object sender, EventArgs e)
        {
            x = 1; y = 3;
            setpaciec(x, y);
          
        }

        private void p14_Click(object sender, EventArgs e)
        {
            x = 1; y = 4;
     
            setpaciec(x, y);
         
        }

        private void p15_Click(object sender, EventArgs e)
        {
            x = 1; y = 5;
  
            setpaciec(x, y);
          

        }

        private void p16_Click(object sender, EventArgs e)
        {
            x = 1; y = 6;
 
            setpaciec(x, y);
          
        }

        private void p17_Click(object sender, EventArgs e)
        {
            x = 1; y = 7;
    
            setpaciec(x, y);
          
        }

        private void p20_Click(object sender, EventArgs e)
        {
            x = 2; y = 0;
            setpaciec(x, y);
          
        }

        private void p21_Click(object sender, EventArgs e)
        {
            x = 2; y = 1;
            setpaciec(x, y);
           
        }

        private void p22_Click(object sender, EventArgs e)
        {
            x = 2; y = 2;
            setpaciec(x, y);
            
        }

        private void p23_Click(object sender, EventArgs e)
        {
            x = 2; y = 3;
            setpaciec(x, y);
           
        }

        private void p24_Click(object sender, EventArgs e)
        {
            x = 2; y = 4;
            setpaciec(x, y);
          
        }

        private void p25_Click(object sender, EventArgs e)
        {
            x = 2; y = 5;
            setpaciec(x, y);
           
        }

        private void p26_Click(object sender, EventArgs e)
        {
            x = 2; y = 6;
            setpaciec(x, y);
           
        }

        private void p27_Click(object sender, EventArgs e)
        {
            x = 2; y = 7;
            setpaciec(x, y);
            
        }

        private void p30_Click(object sender, EventArgs e)
        {
            x = 3; y = 0;
            setpaciec(x, y);
          
        }

        private void p31_Click(object sender, EventArgs e)
        {
            x = 3; y = 1;
            setpaciec(x, y);
        }

        private void p32_Click(object sender, EventArgs e)
        {
            x = 3; y = 2;
            setpaciec(x, y);
          
        }

        private void p33_Click(object sender, EventArgs e)
        {
            x = 3; y = 3;
            setpaciec(x, y);
           
        }

        private void p34_Click(object sender, EventArgs e)
        {
            x = 3; y = 4;
            setpaciec(x, y);
          
        }

        private void p35_Click(object sender, EventArgs e)
        {
            x = 3; y = 5;
            setpaciec(x, y);
          
        }

        private void p36_Click(object sender, EventArgs e)
        {
            x = 3; y = 6;
            setpaciec(x, y);
          
        }

        private void p37_Click(object sender, EventArgs e)
        {
            x = 3; y = 7;
            setpaciec(x, y);
          
        }

        private void p40_Click(object sender, EventArgs e)
        {
            x = 4; y = 0;
            setpaciec(x, y);
           


        }

        private void p41_Click(object sender, EventArgs e)
        {
            x = 4; y = 1;
            setpaciec(x, y);
          
        }

        private void p42_Click(object sender, EventArgs e)
        {

            x = 4; y = 2;
            setpaciec(x, y);
           

        }

        private void p43_Click(object sender, EventArgs e)
        {

            x = 4; y = 3;
            setpaciec(x, y);
          

        }

        private void p44_Click(object sender, EventArgs e)
        {

            x = 4; y = 4;
            setpaciec(x, y);
          
        }

        private void p45_Click(object sender, EventArgs e)
        {

            x = 4; y = 5;
            setpaciec(x, y);
          
        }

        private void p46_Click(object sender, EventArgs e)
        {

            x = 4; y = 6;
            setpaciec(x, y);
          
        }

        private void p47_Click(object sender, EventArgs e)
        {

            x = 4; y = 7;
            setpaciec(x, y);
           
        }

        private void p50_Click(object sender, EventArgs e)
        {

            x = 5; y = 0;
            setpaciec(x, y);
           


        }

        private void p51_Click(object sender, EventArgs e)
        {
            x = 5; y = 1;
            setpaciec(x, y);
         

        }

        private void p52_Click(object sender, EventArgs e)
        {
            x = 5; y = 2;
            setpaciec(x, y);
           

        }

        private void p53_Click(object sender, EventArgs e)
        {
            x = 5; y = 3;
            setpaciec(x, y);
           
        }

        private void p54_Click(object sender, EventArgs e)
        {
            x = 5; y = 4;
            setpaciec(x, y);
           
        }

        private void p55_Click(object sender, EventArgs e)
        {
            x = 5; y = 5;
            setpaciec(x, y);
           


        }

        private void p56_Click(object sender, EventArgs e)
        {
            x = 5; y = 6;
            setpaciec(x, y);
           

        }

        private void p57_Click(object sender, EventArgs e)
        {
            x = 5; y = 7;
            setpaciec(x, y);
           

        }

        private void p60_Click(object sender, EventArgs e)
        {
            x = 6; y = 0;

            setpaciec(x, y);
          

        }

        private void p61_Click(object sender, EventArgs e)
        {
            x = 6; y = 1;
 
            setpaciec(x, y);
          
        }



        private void p62_Click(object sender, EventArgs e)
        {
            x = 6; y = 2;
   
            setpaciec(x, y);
           

        }

        private void p63_Click(object sender, EventArgs e)
        {
            x = 6; y = 3;
     
            setpaciec(x, y);
            
        }

        private void p64_Click(object sender, EventArgs e)
        {
            x = 6; y = 4;
      
            setpaciec(x, y);
            
        }

        private void p65_Click(object sender, EventArgs e)
        {
            x = 6; y = 5;
     
            setpaciec(x, y);
           
        }

        private void p66_Click(object sender, EventArgs e)
        {
            x = 6; y = 6;

            setpaciec(x, y);
           
        }

        private void p67_Click(object sender, EventArgs e)
        {
            x = 6; y = 7;
      
            setpaciec(x, y);
           

        }

        private void p70_Click(object sender, EventArgs e)
        {
            x = 7; y = 0;

            setpaciec(x, y);
          


        }

        private void p71_Click(object sender, EventArgs e)
        {
            x = 7; y = 1;
   
            setpaciec(x, y);
           
        }

        private void p72_Click(object sender, EventArgs e)
        {
            x = 7; y = 2;
       
            setpaciec(x, y);
           

        }

        private void p73_Click(object sender, EventArgs e)
        {
            x = 7; y = 3;
        
            setpaciec(x, y);
           

        }

        private void p74_Click(object sender, EventArgs e)
        {
            x = 7; y = 4;
      
            setpaciec(x, y);
          

        }

        private void p75_Click(object sender, EventArgs e)
        {
            x = 7; y = 5;
         
            setpaciec(x, y);
           

        }

        private void p76_Click(object sender, EventArgs e)
        {
            x = 7; y = 6;
        
            setpaciec(x, y);
          

        }

        private void p77_Click(object sender, EventArgs e)
        {
            x = 7; y = 7;
        
            setpaciec(x, y);
           
        }

        private void pic10_Click(object sender, EventArgs e)
        {
            ch = 1;
          
        
           
           
            pic10.Image = null;
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            ch = 1;
         
              
            
            pic11.Image = null;
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            ch=1;
         
        
            pic12.Image = null;

        }

        private void pic13_Click(object sender, EventArgs e)
        {
            ch = 1;
        
         
            pic13.Image = null;
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            ch = 1;
         
         
            pic14.Image = null;
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            ch = 1;
           
          
            pic15.Image = null;
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            ch = 1;
          
           
            pic16.Image = null;

        }

        private void pic17_Click(object sender, EventArgs e)
        {
            ch = 1;
        
 
            pic17.Image = null;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            ch = -1;
         
          
            pictureBox24.Image = null;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            ch = -1;
         
         

            pictureBox23.Image = null;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            ch = -1;
         
           
            pictureBox22.Image = null;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            ch = -1;
           
            
            pictureBox21.Image = null;
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            ch = -1;
         
           
            pictureBox35.Image = null;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            ch = -1;
         
          
            pictureBox18.Image = null;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            ch = -1;
          
            pictureBox32.Image = null;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            ch = -1;
         
          
            pictureBox19.Image = null;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            ch = -2;
          
            pictureBox29.Image = null;

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            ch = -3;
         
            pictureBox28.Image = null;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            ch = -4;
         
            pictureBox27.Image = null;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            ch = -5;
     
            pictureBox26.Image = null;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            ch = -6;
         
            pictureBox25.Image = null;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            ch = -4;
           
            pictureBox20.Image = null;
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            ch = -3;
        
            pictureBox33.Image = null;

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            ch = -2;
        
            pictureBox34.Image = null;
        }

        private void pic05_Click(object sender, EventArgs e)
        {
            ch = 4;
           
            pic05.Image = null;
        }

        private void pic06_Click(object sender, EventArgs e)
        {
            ch = 3;
   
            pic06.Image = null;
        }

        private void pic07_Click(object sender, EventArgs e)
        {
            ch = 2;
    
          
            pic07.Image = null;
        }

   

      private void Form5_Load(object sender, EventArgs e)
      {
          c = 0;

          for (int i = 0; i < 8; i++)
          {
              for (int j = 0; j < 8; j++)
              {
                  msf[i, j] = 0;
              }
          }





      }

      private void button1_Click(object sender, EventArgs e)
      {
          game_main pppp = new game_main();
        int yes = 0, playerblack = 0,playerwith=0 ;
          for (int i = 0; i <8; i++)
          {
              for (int j = 0; j < 8; j++)
              {
                  switch (msf[i, j]) {
                      case 1: playerblack++; break;
                      case -1: playerwith++; break;
                      case 2: playerblack++; break;
                      case -2: playerwith++; break;
                      case 3: playerblack++; break;
                      case -3:playerwith++;break;
                      case 4: playerblack++; break;
                      case -4: playerwith++; break;
                      case 5: playerblack++; break;
                      case -5: playerwith++; break;
                      case 6: playerblack++; yes++; break;
                      case -6: playerwith++; yes++; break;
                 
                  }
              
              }
          }

          if (yes == 2&&playerwith>0&&playerblack>0)
          {
              finsh = 1;
           passing_value.newmat = msf;
           passing_value.bdika = 1;
           passing_value.playernum = playernum;
     
           
          }
          else
              MessageBox.Show("you must to put king and put paice for every players");



      }


      

      private void button2_Click(object sender, EventArgs e)
      {
          
          Form1 f1 = new Form1(); 
          
          f1.Show();
          this.Hide();//close form5
        

      }

      private void button8_Click(object sender, EventArgs e)
      {
          Form13 f13 = new Form13();
          f13.Show();
          this.Hide();
      }

   
    



    }
    }

