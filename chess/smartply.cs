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
    class smartply
    {
        int[,] mat;
        PictureBox[] picbox;
        int playernum;
        Point[] kingplaces;
        int[] kings;
        int[] rooks;

        public static Point lastx, newx;
        public static int loser;
        public smartply(int[,] mat, PictureBox[] picbox, int playernum, Point[] kingplaces, int[] kings, int[] rooks)
        {
            this.mat = mat;
            this.picbox = picbox;
            this.playernum = playernum;
            this.kingplaces = kingplaces;
            this.kings = kings;
            this.rooks = rooks;
        }
        public void clever(int playernum, int[] kings, int[] rooks, Point[] kingsplace, PictureBox[] picbox, int[,] mat)
        {
           int k=0; // number of items in the game for the playernumber
            
           TimeSpan interval = new TimeSpan(0, 0, 2);
            tootalscoor tc = new tootalscoor(picbox,kings,playernum,rooks,mat,kingsplace);
            for (int i = 0; i < mat.GetLength(0); i++)
                for (int j = 0; j < mat.GetLength(1); j++)
                    if (mat[i, j] * playernum > 0) k++;
            Point[] pt = new Point[k];
            int p=0;
            for (int i = 0; i < mat.GetLength(0); i++)
                for (int j = 0; j < mat.GetLength(1); j++)
                    if (mat[i, j] * playernum > 0)
                    {
                        pt[p] = new Point(i, j);
                        p++;
                    }
            List<Point>[] lpt = new List<Point>[k];
            tc.Filllist(k, pt, lpt);

            List<chess_power> cplst = new List<chess_power>();
            tc.filllistinchess_power(k, pt, lpt, cplst);

         //  int t = 1; // this is just to stop the debug
            int max = tc.getmaxtotalscore(cplst);
            List<chess_power> thebest = new List<chess_power>();
            thebest = tc.whatthebestpaice(cplst);
            chess_power  final = tc.whatthemorbestpaice(thebest);
              if (mat[final.after.X, final.after.Y] != 0)
            {
                smartply.loser = mat[final.after.X, final.after.Y];
            }
            ///////////////////////////////////////
            int old = mat[final.befor.X, final.befor.Y];
            lastx = new Point(final.befor.X,final.befor.Y);
            mat[final.befor.X, final.befor.Y] = 0;
            mat[final.after.X, final.after.Y] = old;
            ////////////////////////////////////////////////
           

            game_main pppp = new game_main();
            picbox[final.befor.X * 10 + final.befor.Y - 2 * final.befor.X].ImageLocation = null;
            Application.DoEvents();
          
            picbox[final.after.X * 10 + final.after.Y - 2 * final.after.X].ImageLocation = pppp.chessimage(old);
            newx = new Point(final.after.X, final.after.Y);
            picbox[final.after.X * 10 + final.after.Y - 2 * final.after.X].SizeMode = PictureBoxSizeMode.CenterImage;
     
            pppp.refreshcolors(picbox, playernum, mat);

        }
    }
}
