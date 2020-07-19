using System;
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
   public class fou
    {

        
        int[,] mat;
        private Point pos;
        PictureBox[] picbox;
        int playernum;
        Point[] kingplaces;
        int[] kings;
        int[] rooks;
        private Point start;
        private PictureBox picbox_2;
        private Point[] kingsplace;


        public fou(Point pos, int[,] mat, PictureBox[] pics, int playernum, Point[] kingplaces, int[] kings, int[] rooks)
        {
            // TODO: Complete member initialization
            this.pos = pos;
            this.mat = mat;
            this.picbox=pics;
            this.playernum = playernum;
            this.kingplaces = kingplaces;
            this.kings = kings;
            this.rooks = rooks;
        }

        public fou(Point start, int[,] mat, PictureBox picbox_2, int playernum, Point[] kingsplace, int[] kings, int[] rooks)
        {
            // TODO: Complete member initialization
            this.start = start;
            this.mat = mat;
            this.picbox_2 = picbox_2;
            this.playernum = playernum;
            this.kingsplace = kingsplace;
            this.kings = kings;
            this.rooks = rooks;
        }

        public List<Point> placestomove()
        {
            List<Point> lst = new List<Point>();
            int x = this.pos.X;
            int y = this.pos.Y;
            Node<Point> nd = lst.GetFirst();
          

            int i;
            //fou black
            if (playernum == 1)
            {
                for (i = 1; i < 8; i++)
                {
                    if (x + i < 8 && y + i < 8)
                    {
                        if (mat[x + i, y + i] == 0 || mat[x + i, y + i] < 0 && mat[x + i, y + i] > -6)
                        {

                        
                            lst.Insert(nd, new Point(x + i, y + i));
                            if (mat[x + i, y + i] < 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x + i < 8 && y - i >= 0)
                    {
                        if (mat[x + i, y - i] == 0 || mat[x + i, y - i] < 0 && mat[x + i, y - i] > -6)
                        {
                            lst.Insert(nd, new Point(x + i, y - i));
                            if (mat[x + i, y - i] < 0) break;
                        }

                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x - i >= 0 && y + i < 8)
                    {
                        if (mat[x - i, y + i] == 0 || mat[x - i, y + i] < 0 && mat[x - i, y + i] > -6)
                        {
                            lst.Insert(nd, new Point(x - i, y + i));
                            if (mat[x - i, y + i] < 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if (mat[x - i, y - i] == 0 || mat[x - i, y - i] < 0 && mat[x - i, y - i] > -6)
                        {
                            lst.Insert(nd, new Point(x - i, y - i));
                            if (mat[x - i, y - i] < 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }

                return lst;
            }
                //fou whith
            else {


                for (i = 1; i < 8; i++)
                {
                    if (x + i < 8 && y + i < 8)
                    {
                        if ((mat[x + i, y + i] == 0 || mat[x + i, y + i] > 0) && mat[x + i, y + i] < 6)
                        {
                            lst.Insert(nd, new Point(x + i, y + i));
                            if (mat[x + i, y + i] > 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x + i < 8 && y - i >= 0)
                    {
                        if ((mat[x + i, y - i] == 0 || mat[x + i, y - i] > 0) && mat[x + i, y - i] < 6)
                        {
                            lst.Insert(nd, new Point(x + i, y - i));
                            if (mat[x + i, y - i] > 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x - i >= 0 && y + i < 8)
                    {
                        if ((mat[x - i, y + i] == 0 || mat[x - i, y + i] > 0) && mat[x - i, y + i] < 6)
                        {
                            lst.Insert(nd, new Point(x - i, y + i));
                            if (mat[x - i, y + i] > 0) break;
                        }

                        else
                            break;
                    }
                    else
                        break;
                }
                for (i = 1; i < 8; i++)
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if ((mat[x - i, y - i] == 0 || mat[x - i, y - i] > 0) && mat[x - i, y - i] < 6)
                        {
                            lst.Insert(nd, new Point(x - i, y - i));
                            if (mat[x - i, y - i] > 0) break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }

                return lst;
            
            
            }
        }









        public void showGreenplaces(int i, int j, PictureBox[] pics)
        {
            Node<Point> np = null;
            Point pos = new Point(i, j);
            List<Point> lst2 = new List<Point>();
            Point pt = new Point();
            fou r1 = new fou(pos, mat, pics, playernum, kingplaces, kings, rooks);
            if (playernum == -1)
                pt = kingplaces[0];
            else
                pt = kingplaces[1];
            king k = new king(pt, mat, picbox, playernum, kings, rooks);
            bool t = k.deathofking(pt.X, pt.Y, mat, picbox, kings, rooks, playernum * -1);
            try
            {
                lst2 = r1.placestomove();
                Point pp = lst2.GetFirst().GetInfo();
                np = lst2.GetFirst();
            }
            catch (Exception)
            {


            }

            int[,] help = new int[8, 8];
            for (int ii = 0; ii < 8; ii++)
                for (int jj = 0; jj < 8; jj++)
                {
                    help[ii, jj] = mat[ii, jj];
                }

            while (np != null)
            {
                int x = np.GetInfo().X;
                int y = np.GetInfo().Y;
                int n = x * 10 + y - 2 * x;
                int v = help[x, y];
                help[x, y] = playernum;
                if (k.toking(pt.X, pt.Y, help, picbox, playernum * -1) == new Point(-1, -1))
                {
                    pics[n].BackColor = Color.Green;
                    pics[n].Enabled = true;
                    pics[n].Visible = true;
                }
                else
                {
                    pics[n].BackColor = Color.Red;
                    pics[n].Enabled = false;
                    pics[n].Visible = true;
                }
                help[x, y] = v;
                np = np.GetNext();
            }
        }




    }
}













