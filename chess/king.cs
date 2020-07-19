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
    public class king
    {

        int[,] mat;
        private Point pos;
        PictureBox[] picbox;
        int playernum;
        int[] kings;
        int[] rooks;
        private Point point;
        private PictureBox picbox_2;
        private int plyername;
     

        public king()
        {
            
        }
        public king(Point pos, int[,] mat, PictureBox[] pics, int playernum,int [] kings, int[] rooks)
        {
            // TODO: Complete member initialization
            this.pos = pos;
            this.mat = mat;
            this.picbox=pics;
            this.playernum = playernum;
            this.kings = kings;
            this.rooks = rooks;
        }

        public king(Point pos, int[,] mat, PictureBox[] picbox, int playernum)
        {
            // TODO: Complete member initialization
            this.pos = pos;
            this.mat = mat;
            this.picbox = picbox;
            this.playernum = playernum;
           
        }

        public king(Point point, int[,] mat, PictureBox picbox_2, int plyername, int[] kings, int[] rooks)
        {
            // TODO: Complete member initialization
            this.point = point;
            this.mat = mat;
            this.picbox_2 = picbox_2;
            this.plyername = plyername;
            this.kings = kings;
            this.rooks = rooks;
        }
       
        public List<Point> placestomove()
        {
            List<Point> lst = new List<Point>();
            int x = this.pos.X;
            int y = this.pos.Y;
            Node<Point> nd = lst.GetFirst();

            if (x - 1 >= 0 && y - 1 >= 0) if ((mat[x - 1, y - 1] == 0 || mat[x - 1, y - 1] * playernum < 0) && mat[x - 1, y - 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x - 1, y-1));
            if (x - 1 >= 0) if ((mat[x - 1, y] == 0 || mat[x - 1, y] * playernum < 0) && mat[x - 1, y] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x - 1, y));
            if (x - 1 >= 0 && y + 1 <= 7) if ((mat[x - 1, y + 1] == 0 || mat[x - 1, y + 1] * playernum < 0) && mat[x - 1, y + 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x - 1, y+1));
            if (y - 1 >= 0) if ((mat[x, y - 1] == 0 || mat[x, y - 1] * playernum < 0) && mat[x, y - 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x, y-1));
            if (y + 1 <= 7) if ((mat[x, y + 1] == 0 || mat[x, y + 1] * playernum < 0) && mat[x, y + 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x, y+1));
            if (x + 1 <= 7 && y - 1 >= 0) if ((mat[x + 1, y - 1] == 0 || mat[x + 1, y - 1] * playernum < 0) && mat[x + 1, y - 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x + 1, y-1));
            if (x + 1 <= 7) if ((mat[x + 1, y] == 0 || mat[x + 1, y] * playernum < 0) && mat[x + 1, y] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x+1, y));
            if (x + 1 <= 7 && y + 1 <= 7) if ((mat[x + 1, y + 1] == 0 || mat[x + 1, y + 1] * playernum < 0) && mat[x + 1, y + 1] * (playernum * -1) < 6)
                lst.Insert(nd, new Point(x +1, y+1));

                return lst;
            
            
        }
  

       public void showorangeplace()
        { 
       if(playernum==-1)//with
        {
            if (mat[7, 4] == 6 * playernum && mat[7, 5] == 0 && mat[7, 6] == 0 && mat[7, 7] == 2 * playernum )
            {
                picbox[7*10+5-2*7].BackColor = Color.Green;
                picbox[7 * 10 + 6 - 2 * 7].BackColor = Color.Orange;
                picbox[7 * 10 + 7 - 2 * 7].BackColor = Color.Yellow;
            }
        }
        if (playernum == 1)//black
        {
            if (mat[0, 4] == 6 * playernum && mat[0, 5] == 0 && mat[0, 6] == 0 && mat[0, 7] == 2 * playernum )
            {
                picbox[0 * 10 + 5 - 0 * 7].BackColor = Color.Green;
                picbox[0 * 10 + 6 - 0 * 7].BackColor = Color.Orange;
                picbox[0 * 10 + 7 - 0 * 7].BackColor = Color.Yellow;
            }
        }
        }





        //להציג מקומות האפשריות בצבע ירוק 

        public void showGreenplaces(int i, int j, PictureBox[] pics)
        {
            Node<Point> np = null;
            Point pos = new Point(i, j);
            List<Point> lst2 = new List<Point>();
            
           king k1 = new king(pos, mat, pics,playernum,kings,rooks);

            try
            {
                lst2 = k1.placestomove();
                Point pp = lst2.GetFirst().GetInfo();
                np = lst2.GetFirst();
            }
            catch (Exception)
            {


            }
            
            while (np != null)
            {
                int x = np.GetInfo().X;
                int y = np.GetInfo().Y;
                int n = x * 10 + y - 2 * x;
                if (k1.toking(x, y, mat, picbox, playernum * -1) == new Point(-1, -1))
                {
                    pics[n].BackColor = Color.Green;
                    pics[n].Enabled = true;
                   
                }
                else
                {
                    pics[n].BackColor = Color.Red;
                   
                   
                    
                }
                pics[n].Enabled = true;
                pics[n].Visible = true;
                np = np.GetNext();
            }
            
        }
        
        public void redtoging(Point pt,PictureBox[] pics,int playernum)
        {
            int n = pt.X * 10 + pt.Y - 2 * pt.X;
            pics[n].BackColor = Color.Red;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int p = i * 10 + j - 2 * i;
                    if (playernum > 0)
                    {
                        if (mat[i, j] > 0 && mat[i, j] != 6) 
                            pics[p].Enabled = false;
                    }
                    else
                        if (mat[i, j] < 0 && mat[i, j] != -6) pics[p].Enabled = false;
                }
            }
        }
        public Point toking(int x, int y, int[,] mat, PictureBox[] pics, int k)
        {
            // int k=0;
            //if (mat[x, y] == 6) k = -1;
            //if (mat[x, y] == -6) k = 1;
            int i, j, t;
            

            //   hours
            if (x - 2 >= 0 && y - 1 >= 0)
                if (mat[x - 2, y - 1] == (3 * k) && mat[x - 2, y - 1] != 0 && mat[x - 2, y - 1] != 6 * k)
                {
                 return  new Point(x - 2, y - 1);
                   

                }
            if (x - 2 >= 0 && y + 1 < 8)
                if (mat[x - 2, y + 1] == (3 * k) && mat[x - 2, y + 1] != 0 && mat[x - 2, y + 1] != 6 * k)
                {
                    return new Point(x - 2, y + 1);
                }
                    
                    if (x - 1 >= 0 && y - 2 >= 0)
                        if (mat[x - 1, y - 2] == (3 * k)) if (mat[x - 1, y - 2] != 0 && mat[x - 1, y - 2] != 6 * k)
                            {
                               return  new Point(x - 1, y - 2);
                               
                            }
                    if (x - 1 >= 0 && y + 2 < 8)
                        if (mat[x - 1, y + 2] == (3 * k) && mat[x - 1, y + 2] != 0 && mat[x - 1, y + 2] != 6 * k)
                        {
                         return   new Point(x - 1, y + 2);
                           
                        }

                    if (x + 1 < 8 && y - 2 >= 0)
                        if (mat[x + 1, y - 2] == (3 * k) && mat[x + 1, y - 2] != 0 && mat[x + 1, y - 2] != 6 * k)
                        {
                           return  new Point(x + 1, y - 2);

                          
                        }
                    if (x + 1 < 8 && y + 2 < 8)
                        if (mat[x + 1, y + 2] == (3 * k) && mat[x + 1, y + 2] != 0 && mat[x + 1, y + 2] != 6 * k)
                        {
                           return  new Point(x + 1, y + 2);

                           
                        }
                    if (x + 2 < 8 && y - 1 >= 0)
                        if (mat[x + 2, y - 1] == (3 * k) && mat[x + 2, y - 1] != 0 && mat[x + 2, y - 1] != 6 * k)
                        {
                           return new Point(x + 2, y - 1);
                     
                        }
                    if (x + 2 < 8 && y + 1 < 8)
                        if (mat[x + 2, y + 1] == (3 * k) && mat[x + 2, y + 1] != 0 && mat[x + 2, y + 1] != 6 * k)
                        {
                         return  new Point(x + 2, y + 1);
                          
                        }
                    //  elefant

                    for (i = 1; i < 8; i++)
                    {
                        if (x + i < 8 && y + i < 8)
                        {
                            if (mat[x + i, y + i] == (4 * k))
                            {
                               return  new Point(x + i, y + i);
                            
                            }
                            if (mat[x + i, y + i] != 0 || mat[x + i, y + i] == 6 * k)
                                break;
                        }
                        else
                            break;
                    }
                    for (i = 1; i < 8; i++)
                    {
                        if (x + i < 8 && y - i >= 0)
                        {
                            if (mat[x + i, y - i] == (4 * k))
                            {
                          return  new Point(x + i, y - i);
                             
                            }
                            if (mat[x + i, y - i] != 0 || mat[x + i, y - i] == 6 * k)
                                break;
                        }
                        else
                            break;
                    }
                    for (i = 1; i < 8; i++)
                    {
                        if (x - i >= 0 && y + i < 8)
                        {
                            if (mat[x - i, y + i] == (4 * k))
                            {
                                return new Point(x - i, y + i);
                                
                            }
                            if (mat[x - i, y + i] != 0 || mat[x - i, y + i] == 6 * k)
                                break;
                        }
                        else
                            break;
                    }
                    for (i = 1; i < 8; i++)
                    {

                        if (x - i >= 0 && y - i >= 0)
                        {
                            if (mat[x - i, y - i] == (4 * k))
                            {
                              return  new Point(x - i, y - i);
                             
                            }
                            if (mat[x - i, y - i] != 0 || mat[x - i, y - i] == 6 * k)
                                break;
                        }
                        else
                            break;
                    }
                    // rook
                    for (j = x - 1; j > -1; j--)
                    {
                        if (mat[j, y] == (2 * k))
                        {
                          return   new Point(j, y);
                            
                        }
                        if (mat[j, y] != 0 && mat[j, y] != 6 * k)
                            break;
                    }
                    for (j = x + 1; j < 8; j++)
                    {

                        if (mat[j, y] == (2 * k))
                        {
                          return new Point(j, y);
                         
                        }
                        if (mat[j, y] != 0 && mat[j, y] != 6 * k)
                            break;
                    }

                    for (j = y - 1; j > -1; j--)
                    {
                        if (mat[x, j] == (2 * k))
                        {
                       return  new Point(x, j);
                         
                        }
                        if (mat[x, j] != 0 && mat[x, j] != 6 * k)
                            break;
                    }

                    for (j = y + 1; j < 8; j++)
                    {
                        if (mat[x, j] == (2 * k))
                        {
                           return new Point(x, j);
                           
                        }
                        if (mat[x, j] != 0 && mat[x, j] != 6 * k)
                            break;
                    }

                    //pawen balack
                    if (k == -1)
                    {

                        if (x + 1 < 8 && y - 1 >= 0)
                            if (mat[x + 1, y - 1] == -1)
                            {
                               return new Point(x + 1, y - 1);
                              
                            }
                        if (x + 1 < 8 && y + 1 < 8)
                            if (mat[x + 1, y + 1] == -1)
                            {
                              return new Point(x + 1, y + 1);
                               
                            }

                    }
                    //pawen with
                    if (k == 1)
                    {

                        if (x - 1 >= 0 && y - 1 >= 0)
                            if (mat[x - 1, y - 1] == 1)
                            {
                              return new Point(x - 1, y - 1);
                              
                            }
                        if (x - 1 >= 0 && y + 1 < 8)
                            if (mat[x - 1, y + 1] == 1)
                            {
                                return new Point(x - 1, y + 1);
                              
                            }

                    }





                    //queen     

                    for (t = 1; t < 8; t++)
                    {
                        if (x + t < 8 && y + t < 8)
                        {
                            if (mat[x + t, y + t] == (5 * k))
                            {
                               return  new Point(x + t, y + t);
                              
                            }
                            if (mat[x + t, y + t] != 0 || mat[x + t, y + t] == k * 6)
                                break;
                        }
                        else
                            break;
                    }
                    for (t = 1; t < 8; t++)
                    {
                        if (x + t < 8 && y - t >= 0)
                        {
                            if (mat[x + t, y - t] == (5 * k))
                            {
                                return new Point(x + t, y - t);
                             
                            }
                            if (mat[x + t, y - t] != 0 || mat[x + t, y - t] == k * 6)
                                break;
                        }
                        else
                            break;
                    }
                    for (t = 1; t < 8; t++)
                    {
                        if (x - t >= 0 && y + t < 8)
                        {
                            if (mat[x - t, y + t] == (5 * k))
                            {
                             return new Point(x - t, y + t);

                            }
                            if (mat[x - t, y + t] != 0 || mat[x - t, y + t] == k * 6)
                                break;
                        }
                        else
                            break;
                    }
                    for (t = 1; t < 8; t++)
                    {
                        if (x - t >= 0 && y - t >= 0)
                        {
                            if (mat[x - t, y - t] == (5 * k))
                            {
                               return new Point(x - t, y - t);
                              
                            }

                            if (mat[x - t, y - t] != 0 || mat[x - t, y - t] == 6 * k)
                                break;
                        }
                        else
                            break;
                    }
                    for (t = x - 1; t > -1; t--)
                    {
                        if (mat[t, y] == (5 * k))
                        {
                           return new Point(t, y);
                         
                        }
                        if (mat[t, y] != 0 && mat[t, y] != 6 * k)
                            break;


                    }
                    for (t = x + 1; t < 8; t++)
                    {

                        if (mat[t, y] == (5 * k))
                        {

                         return new Point(t, y);
                            
                        }
                        if (mat[t, y] != 0 && mat[t, y] != k * 6)
                            break;
                    }

                    for (t = y - 1; t > -1; t--)
                    {
                        if (mat[x, t] == (5 * k))
                        {

                          return new Point(x, t);
                          
                        }

                        if (mat[x, t] != 0 && mat[x, t] != 6 * k)
                            break;
                    }

                    for (t = y + 1; t < 8; t++)
                    {
                        if (mat[x, t] == (5 * k))
                        {

                          return  new Point(x, t);
                          
                        }
                        if (mat[x, t] != 0 && mat[x, t] != 6 * k)
                            break;
                    }
                    //king
                    if (mat[x, y] == (-6 * k))
                    {
                        if (x - 1 >= 0 && y - 1 >= 0) if (mat[x - 1, y - 1] == (6 * k) && mat[x - 1, y - 1] != 0)
                            {

                                return new Point(x - 1, y - 1);
                               
                            }
                        if (x - 1 >= 0) if (mat[x - 1, y] == (6 * k) && mat[x - 1, y] != 0)
                            {


                             return new Point(x - 1, y);
                              
                            }

                        if (x - 1 >= 0 && y + 1 <= 7) if (mat[x - 1, y + 1] == (6 * k) && mat[x - 1, y + 1] != 0)
                            {

                               return new Point(x - 1, y + 1);
                               
                            }
                        if (y - 1 >= 0) if (mat[x, y - 1] == (6 * k) && mat[x, y - 1] != 0)
                            {


                              return new Point(x, y - 1);
                             
                        }
                        if (y + 1 <= 7) if (mat[x, y + 1] == (6 * k) && mat[x, y + 1] != 0)
                            {

                              return new Point(x, y + 1);
                               
                            }
                        if (x + 1 <= 7 && y - 1 >= 0) if (mat[x + 1, y - 1] == (6 * k) && mat[x + 1, y - 1] != 0)
                            {


                              return new Point(x + 1, y - 1);
                               
                            }
                        if (x + 1 <= 7) if (mat[x + 1, y] == (6 * k) && mat[x + 1, y] != 0)
                            {

                               return new Point(x + 1, y);
                              
                            }
                        if (x + 1 <= 7 && y + 1 <= 7) if (mat[x + 1, y + 1] == (6 * k) && mat[x + 1, y + 1] != 0)
                            {

                              return new Point(x + 1, y + 1);
                               
                            }
                    }

                    //  n = x * 10 + y - 2 * x;
                    //pics[n].BackColor = Color.Transparent;



                    return new Point(-1, -1);
                }
        

        public bool deathofking(int i1, int j1,int[,] mat2,PictureBox[] picbox2,int[] kings2,int[] rooks2 ,int k11)
        {
         
            Node<Point> np1 = null;
            Point pos1 = new Point(i1, j1);
            List<Point> lst3 = new List<Point>();
            
            king k12 = new king(pos1, mat2, picbox2, k11*-1, kings2, rooks2);
            if (k12.toking(i1, j1, mat2, picbox2, k11) == new Point(-1, -1)) return false;
            try
            {
                lst3 = k12.placestomove();
                Point pp1 = lst3.GetFirst().GetInfo();
                np1 = lst3.GetFirst();
            }
            catch (Exception)
            {


            }
            while(np1!=null)
            {
                if (k12.toking(np1.GetInfo().X, np1.GetInfo().Y, mat2, picbox2, k11) != new Point(-1, -1))
                    np1 = lst3.Remove(np1);
                else break;

            }
            if (lst3.IsEmpty() == true)
                return true;
            else
                return false;

       }

       public  void shah(int x ,int y , PictureBox[] pics,int[,] mat, int playernum)
        {

           
            king k = new king(new Point(x, y), mat, picbox, playernum, kings, rooks);
            List<Point> lst = k.helping(playernum*-1 , mat, x, y, picbox, kings, rooks);
          Node<Point> pos = lst.GetFirst();
            for (int i = 0; i < 64; i++)
            {
                if (picbox[i].BackColor == Color.Green) picbox[i].Enabled = true;
                    else
                picbox[i].Enabled = false;
            }
            while (pos != null)
            {
                picbox[pos.GetInfo().X * 10 + pos.GetInfo().Y - 2 * pos.GetInfo().X].Enabled = true;
                pos = pos.GetNext();
            }

            picbox[x * 10 + y - 2 * x].Enabled = true;
        
            MessageBox.Show("shaaaaaaaaaaaaaaaaaaaa7");

        }

        public void shahmeet( string shahmeet)
       {
           for (int i = 0; i < 64; i++)
            picbox[i].Enabled = false;

           MessageBox.Show("shahmeeeeeeeeeeeeeeeeeeeeeeeeeet  " + shahmeet);

       }

       public List<Point> helping(int kk, int[,] mat4, int x11, int y11, PictureBox[] picbox3, int[] kings3, int[] rooks3)
       {
        
           int[,] help = new int[8, 8];
         
     
           Point pos11 = new Point(x11, y11);
           

           king k13 = new king(pos11, mat4, picbox3, kk, kings3, rooks3);
          
           Point poo = new Point();
           Point po = k13.toking(x11, y11, mat4, picbox3, kk);
           List<Point> lst5 = new List<Point>();
           Node<Point> nd5 = lst5.GetFirst();
       

           for (int i = 0; i < 8; i++)
           {
               for (int j = 0; j < 8; j++)
               {
                   help[i, j] = mat4[i, j]; 
               }
           }
           help[x11, y11] = kk;
           if (k13.toking(po.X, po.Y, help, picbox3, kk * -1) == new Point(-1, -1))
               return lst5;
           else
           {
               poo = k13.toking(po.X, po.Y, help, picbox3, kk * -1);
               nd5 = lst5.Insert(nd5, poo);
               help[poo.X, poo.Y] = kk;
               while (k13.toking(po.X, po.Y, help, picbox3, kk * -1) != new Point(-1, -1))
               {
                   Point pt = k13.toking(po.X, po.Y, help, picbox3, kk * -1);
                   nd5 = lst5.Insert(nd5, pt);
                   help[pt.X, pt.Y] = kk;

               }


            
           }
            Node<Point> pos = lst5.GetFirst();
               
               while(pos!=null)
               {
                   picbox3[pos.GetInfo().X * 10 + pos.GetInfo().Y - 2 * pos.GetInfo().X].Enabled = true;
                   pos= pos.GetNext();
               }

               return lst5;


           }

       }
       
    }




    

