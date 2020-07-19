using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Unit4.CollectionsLib;

namespace chess
{
    class tootalscoor
    {
       
        int playernum;
        int[] kings;
        int[] rooks;
        int[,] mat;
        PictureBox[] picbox;
        Point[] kingsplace;
        int i = 0;

        public tootalscoor(PictureBox[] picbox, int[] kings, int playernum, int[] rooks, int[,] mat, Point[] kingsplace)
        {


            this.picbox = picbox;
            this.playernum = playernum;
            this.kings = kings;
            this.rooks = rooks;
            this.mat = mat;
            this.kingsplace = kingsplace;


        }
      //רוזמרין   اقليل الجبل 

        public void Filllist(int n, Point[] pt, List<Point>[] lpt)
        {
            if (n >= 0)
            {
                List<Point> lst = new List<Point>();
                Node<Point> np1 = lst.GetFirst();
                Point pp = pt[n - 1];
                int x = pp.X;
                int y = pp.Y;
                if (mat[x, y] * playernum > 0)//>
                {
                    switch (mat[x, y])
                    {

                        case 1:
                        case -1: Pawn p2 = new Pawn(new Point(x, y), mat, picbox, playernum, kingsplace, kings, rooks);
                            p2.showGreenplaces(x, y, picbox); break;
                        case 2:
                        case -2: rook r2 = new rook(new Point(x, y), mat, picbox, playernum, kingsplace, kings, rooks);
                            r2.showGreenplaces(x, y, picbox); break;
                        case 3:
                        case -3: knight kn2 = new knight(new Point(x, y), mat, picbox, playernum, kingsplace, kings, rooks);
                            kn2.showGreenplaces(x, y, picbox); break;
                        case 4:
                        case -4: fou f2 = new fou(new Point(x, y), mat, picbox, playernum, kingsplace, kings, rooks);
                            f2.showGreenplaces(x, y, picbox); break;
                        case 5:
                        case -5: queen q2 = new queen(new Point(x, y), mat, picbox, playernum, kingsplace, kings, rooks);
                            q2.showGreenplaces(x, y, picbox); break;
                        case -6: king k2 = new king(new Point(x, y), mat, picbox, playernum, kings, rooks);
                            k2.showGreenplaces(x, y, picbox); break;
                        default: break;



                    }

                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            if (picbox[i * 10 + j - 2 * i].BackColor == Color.Green)
                                np1 = lst.Insert(np1, new Point(i, j));
                    game_main gm = new game_main();
                    gm.refreshcolors(picbox, playernum, mat);


                }
                lpt[n - 1] = lst;
                if (n > 1)
                    Filllist(n - 1, pt, lpt);
            }
        }


        public void filllistinchess_power(int n, Point[] pt, List<Point>[] lpt,List<chess_power> cplst )
        {
            if (n >= 0)
            {
                Node<chess_power> chnd = cplst.GetFirst();
                List<Point> lst = lpt[n - 1];

                Node<Point> nd = lst.GetFirst();
                while (chnd != null) chnd = chnd.GetNext();
                while (nd != null)
                {
                    chess_power cp = new chess_power(mat, pt[n - 1], nd.GetInfo(), playernum, picbox, kings, rooks, kingsplace);
                    chnd = cplst.Insert(chnd, cp);
                    nd = nd.GetNext();
                }
                if (n > 1)
                    filllistinchess_power(n - 1, pt, lpt, cplst);
            }
        }


     
        //// تكملة الكود

        public int getmaxtotalscore(List<chess_power> cplst) {

            Node<chess_power> chnd = cplst.GetFirst();
            int max = chnd.GetInfo().totalscour();
            while (chnd != null) {
                if (max < chnd.GetInfo().totalscour())
                    max = chnd.GetInfo().totalscour();
                chnd = chnd.GetNext();
            
            }

            return max;
        }


        public List<chess_power> whatthebestpaice(List<chess_power> cplst)
        {
      
            int max = getmaxtotalscore(cplst);
            Node<chess_power> chnd = cplst.GetFirst();

              List<chess_power> thebest=new List<chess_power>();
                Node<chess_power> best = thebest.GetFirst();
            

            while (chnd != null)
            {
                int score = chnd.GetInfo().totalscour();
                int item = mat[chnd.GetInfo().befor.X, chnd.GetInfo().befor.Y];
                if (chnd.GetInfo().totalscour() == max)
                {
                  
                    best = thebest.Insert(best, chnd.GetInfo());
                    best = best.GetNext();
                }
                chnd = chnd.GetNext();

            }

            return thebest;

               

        
        }

        public chess_power whatthemorbestpaice(List<chess_power> cplst) {

            
            Node<chess_power> cpnd = cplst.GetFirst();
            chess_power cp = cpnd.GetInfo();
            chess_power cpmin = new chess_power(mat, cp.befor, cp.after, playernum, picbox, kings, rooks, kingsplace);
            int min=Math.Abs(mat[cp.befor.X, cp.befor.Y]);
            while(cpnd!=null)
            {
                cp = cpnd.GetInfo();
                 int scour = cp.totalscour();
                 int item = Math.Abs(mat[cp.befor.X, cp.befor.Y]);
                if (Math.Abs(mat[cp.befor.X, cp.befor.Y]) < min)
                {
                    min = Math.Abs(mat[cp.befor.X, cp.befor.Y]);
                    cpmin = new chess_power(mat, cp.befor, cp.after, playernum, picbox, kings, rooks, kingsplace);
                }
              cpnd=  cpnd.GetNext();
                
            }
            return cpmin;
        
        
        
        }
      

         


    }
}
