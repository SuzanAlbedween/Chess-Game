using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Unit4.CollectionsLib;
using System.Threading;

namespace chess
{
   class computerplayer
    {
   public static Point lx, nx,oldstep,newstep;
    public static int loscomp;
      
 public void computerplayer1(int playernum, int[] kings, int[] rooks, Point[] kingsplace, PictureBox[] picbox, int[,] mat)
        {
           

   Point last = new Point();
    Random rd = new Random();
     game_main pppp = new game_main();
     int i, j, newx, newy, found = 0, c = 0, a, m = 0, p,timer;
      List<Point> lst = new List<Point>();

            List<Point> lst2 = new List<Point>();
            Node<Point> np = lst2.GetFirst();
            Node<Point> np2;
            timer = rd.Next(3) + 1;    
 TimeSpan interval= new TimeSpan(0, 0, timer);


            for (i = 0; i < 8 && found == 0; i++)
            {
                c = 0;
                found = 0;
                for (j = 0; j < 8 && found == 0; j++)
                {


                    if (mat[i, j] *playernum> 0)
                    {
                        last = new Point(i, j);

                        switch (mat[i, j])
                        {
                            case -1:case 1: Pawn p2 = new Pawn(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                                p2.showGreenplaces(i, j, picbox); lst = p2.placestomove(); break;
                            case -2:case 2: rook r2 = new rook(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                                r2.showGreenplaces(i, j, picbox); lst = r2.placestomove(); break;
                            case -3:case 3: knight kn2 = new knight(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                                kn2.showGreenplaces(i, j, picbox); lst = kn2.placestomove(); break;
                            case -4:case 4: fou f2 = new fou(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                                f2.showGreenplaces(i, j, picbox); lst = f2.placestomove(); break;
                            case -5:case 5: queen q2 = new queen(new Point(i, j), mat, picbox, playernum, kingsplace, kings, rooks);
                                q2.showGreenplaces(i, j, picbox); lst = q2.placestomove(); break;
                            case -6:case 6: king k2 = new king(new Point(i, j), mat, picbox, playernum, kings, rooks);
                                k2.showGreenplaces(i, j, picbox); lst = k2.placestomove(); break;

                            default: break;

                        }

                    }
                    if (lst.IsEmpty() == false)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            for (int t = 0; t < 8; t++)
                            {

                                if (picbox[k * 10 + t - 2 * k].BackColor == Color.Green)
                                {
                                    np = lst2.Insert(np, new Point(k, t));
                                    c++;
                                }


                            }



                        }
                        if (lst2.IsEmpty() == false)
                            found = 1;


                    }
                }
            }


            a = rd.Next(c + 1);
            m = 0;
            np2 = lst2.GetFirst();
            while (a != m)
            {
                np2 = np2.GetNext();
                m++;
            }


            int b1 = last.X;
            int b2 = last.Y;
            lx = new Point(b1, b2);
            computerplayer.oldstep = new Point(b1, b2);
            newx = np.GetInfo().X;
            newy = np.GetInfo().Y;
            computerplayer.newstep=new Point(newx, newy);
            nx = new Point(newx, newy);
            if (mat[newx, newy] != 0)
            {
                computerplayer.loscomp = mat[newx, newy];


            }
            if (newx == 7*playernum && mat[b1, b2] == 1*playernum)
            {
                mat[b1, b2] = 0;
              
                mat[newx, newy] = 5;  
             
                picbox[b1 * 10 + b2 - 2 * b1].ImageLocation = null;
                Thread.Sleep(interval);
                Application.DoEvents();
                picbox[newx * 10 + newy - 2 * newx].ImageLocation = pppp.chessimage(5);
             
                picbox[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;
                pppp.refreshcolors(picbox, playernum, mat);
            }


            else if (newx == 0 && mat[b1, b2]*playernum == -1*playernum)
            {
                mat[b1, b2] = 0;
               
                mat[newx, newy] = -5;
             
                picbox[b1 * 10 + b2 - 2 * b1].ImageLocation = null;
                Thread.Sleep(interval);
              Application.DoEvents();
                picbox[newx * 10 + newy - 2 * newx].ImageLocation = pppp.chessimage(-5);
             
                picbox[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;
                pppp.refreshcolors(picbox, playernum, mat);
            }
            else
            {
                p = mat[b1, b2];
                mat[b1, b2] = 0;
              
                mat[newx, newy] = p;

                picbox[b1 * 10 + b2 - 2 * b1].ImageLocation = null;
               Thread.Sleep(interval);
                Application.DoEvents(); 
                
                picbox[newx * 10 + newy - 2 * newx].ImageLocation = pppp.chessimage(p); 
            
                picbox[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;
             
                pppp.refreshcolors(picbox, playernum, mat);
                
            }
           
     
             }

    }
}



