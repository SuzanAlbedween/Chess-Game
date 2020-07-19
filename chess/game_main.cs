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
    class game_main
    {
        public string imageurl(string url)
        {
            return System.IO.Path.Combine(System.Environment.CurrentDirectory, url);
        }
        public static int loss;
        public string chessimage(int num)
        {
            string image = "";
            switch (num)
            {
                case 0: image = ""; return imageurl(image); 
                case 1: image = "images\\1.png"; return imageurl(image); 
                case 2: image = "images\\2.png"; return imageurl(image); 
                case 3: image = "images\\3.png"; return imageurl(image); 
                case 4: image = "images\\4.png"; return imageurl(image); 
                case 5: image = "images\\5.png"; return imageurl(image); 
                case 6: image = "images\\6.png"; return imageurl(image); 
                case -1: image = "images\\-1.png"; return imageurl(image); 
                case -2: image = "images\\-2.png"; return imageurl(image);
                case -3: image = "images\\-3.png"; return imageurl(image); 
                case -4: image = "images\\-4.png"; return imageurl(image); 
                case -5: image = "images\\-5.png"; return imageurl(image); 
                case -6: image = "images\\-6.png"; return imageurl(image); 
                default: image = "images\\erroe.png"; return imageurl(image);
            }
        }
        public void IFgreenmovelastItem(Point lastpt, PictureBox[] pics, int[,] mat,int newx, int newy,string image,int [] kings, int[] rooks,Point [] kingsplaces)
        {
            game_main pppp = new game_main();
            int x = lastpt.X;
            int y = lastpt.Y;


            if (pics[newx * 10 + newy - 2 * newx].BackColor == Color.Green)
            {

                int p = mat[x, y];
                mat[x, y] = 0;
                pics[x * 10 + y - 2 * x].ImageLocation = "";
                pics[x * 10 + y - 2 * x].SizeMode = PictureBoxSizeMode.CenterImage;

                if (mat[newx, newy] != 0)
                    game_main.loss = mat[newx, newy];
                
                if (newx == 7 && p == 1)
                {
                    mat[newx, newy] = 5;
                    pics[newx * 10 + newy - 2 * newx].ImageLocation = pppp.chessimage(5);
                    pics[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;
                }
                if (newx == 0 && p == -1)
                {
                    mat[newx, newy] = -5;
                    pics[newx * 10 + newy - 2 * newx].ImageLocation = pppp.chessimage(-5);
                    pics[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;
                }
              
                if (!(newx == 7 && p == 1) && !(newx == 0 && p == -1))
                {
                    mat[newx, newy] = p;
                    pics[newx * 10 + newy - 2 * newx].ImageLocation = image;
                    pics[newx * 10 + newy - 2 * newx].SizeMode = PictureBoxSizeMode.CenterImage;

                }
                if (p == -6) { kings[0]++; kingsplaces[0] = new Point(newx, newy); }
                if (p == 6) { kings[1]++; kingsplaces[1] = new Point(newx, newy); }

                if (p == -2 && y == 7) rooks[0] = rooks[0] + 1;//rook - wit

                if (p == 2 && y == 7) rooks[1] = rooks[1] + 1;//rook + blk

            }
            if (pics[newx * 10 + newy - 2 * newx].BackColor == Color.Yellow)
            {
                int p = mat[x, y];
                int t = mat[newx, newy];
                mat[x, y] = 0; mat[newx, newy] = 0;
                int m = 0, r = 0;
                pics[x * 10 + y - 2 * x].ImageLocation = "";
                pics[newx * 10 + newy - newx * 2].ImageLocation = "";

                mat[x, y + 2] = p;
                mat[newx, newy - 2] = t;
                m = x * 10 + (y + 2) - 2 * x;
                r = newx * 10 + (newy - 2) - 2 * newx;



                pics[m].ImageLocation = "";
                pics[r].ImageLocation = "";

                pics[m].ImageLocation = chessimage(p);
                pics[r].ImageLocation = chessimage(t);
                pics[m].SizeMode = PictureBoxSizeMode.CenterImage;
                pics[r].SizeMode = PictureBoxSizeMode.CenterImage;
            }
           

        }
        public void refreshcolors(PictureBox[] pics, int numplayer, int[,] mat)
        {
            for (int i = 0; i < pics.Length; i++)
            {
                pics[i].BackColor = Color.Transparent;
                pics[i].Visible = true;
            }
           

        }
        public void playerrole(int num, PictureBox[] pics,int [,] mat)
        {
            int k =0;
            for (int i = 0; i < mat.GetLength(0); i++)
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (num > 0) // ++++ black
                    {
                        if (mat[i, j] > 0)
                            pics[k].Enabled = true;
                        else
                            pics[k].Enabled = false;
                    }
                    else//// ---- white
                    {
                        if (mat[i, j] < 0)
                            pics[k].Enabled = true;
                        else
                            pics[k].Enabled = false;
                    }
                    k++;
                }
            
        }



       
    }
}
