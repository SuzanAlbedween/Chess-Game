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
    class chess_power
    {

    private int[,] mat;
     public    Point befor;
    public     Point after;
        int playernum;
        int[] kings;
        int[] rooks;
         PictureBox []picbox;
      Point[] kingsplace;


         public chess_power(int[,] mat,Point befor,Point after,int playernum,PictureBox []picbox,int[] kings,int[] rooks,Point[] kingsplace) {

             this.mat = mat;
             this.befor = befor;
             this.after = after;
             this.picbox = picbox;
             this.playernum = playernum;
             this.kings = kings;
             this.rooks = rooks;
             this.kingsplace = kingsplace;
          
         
         }

//  اذا كانت القطعه ملك وهو مهددتعيد90 واذا كانت قطعه اخرى وتستطيع مساعده الملك في المكان الجديد تعيد 100 ,والا تعيد -50 وغير ذلك تعيد 0 
         public int my_king_is_threated()// good
         {
             List<Point> lst = new List<Point>();
             int x, y;
             int[,] help = new int[8, 8];
             if (playernum == -1) // that the king point
             {
                 x = kingsplace[0].X;
                 y = kingsplace[0].Y;
             }
             else
             {
                 x = kingsplace[1].X;
                 y = kingsplace[1].Y;
             }
             king k = new king(new Point(x, y), mat, picbox, playernum, kings, rooks);
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             if (help[befor.X, befor.Y] == 6 * playernum)// if this item king
             {
                 if (k.toking(befor.X, befor.Y, help, picbox, playernum*-1) == new Point(-1, -1)) //no threated king
                     return 0;
                 else//threated king
                 {
                     help[after.X, after.Y] = help[befor.X, befor.Y];
                     help[befor.X, befor.Y] = 0;
                     if (k.toking(after.X, after.Y, help, picbox, playernum*-1) == new Point(-1, -1))
                         return 90;
                     else return -50;
                 }
             }
             else // the item not king
             {
                 
                 if (k.toking(x, y, help, picbox, playernum*-1) != new Point(-1, -1))// the king is threated
                 {
                     help[after.X, after.Y] = help[befor.X, befor.Y];
                     help[befor.X, befor.Y] = 0;
                     if (k.toking(x, y, help, picbox, playernum*-1) == new Point(-1, -1))// after move item king not threted
                         return 100;
                     else return -50; // the king is threated & item can't help
                 }
             }

             return 0; // no threteds 


         }
        //بعد التحريك للمقطه الجديده هل يكون الملك مهددا اذا نعم تعيد -100وغير ذلك 0
         public int after_click()//good
         {
             int x1, y1;
             int[,] help = new int[8, 8];
             if (playernum == -1)
             {
                 x1 = kingsplace[0].X;
                 y1 = kingsplace[0].Y;
             }
             else
             {
                 x1 = kingsplace[1].X;
                 y1 = kingsplace[1].Y;
             }
             king k = new king(new Point(x1, y1), mat, picbox, playernum, kings, rooks);
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             help[after.X, after.Y] = help[befor.X, befor.Y];
             help[befor.X, befor.Y] = 0;
             if (k.toking(x1, y1, help, picbox, playernum*-1) != new Point(-1, -1))
                 return -100;
             else
                 return 0;
            
         
         }
        //عند انتقال القطعه للمكان الجديد هل تكن مهدده من قطع اخرى اذا كانت نعم مهدده تعيد-50وغير ذلك تعيد 50
       
         public int after_click_threatened()// good
         {
             int x1, y1;
             int[,] help = new int[8, 8];
             if (playernum == -1)
             {
                 x1 = kingsplace[0].X;
                 y1 = kingsplace[0].Y;
             }
             else
             {
                 x1 = kingsplace[1].X;
                 y1 = kingsplace[1].Y;
             }
             king k = new king(new Point(x1, y1), mat, picbox, playernum, kings, rooks);
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             help[after.X, after.Y] = help[befor.X, befor.Y];
             help[befor.X, befor.Y] = 0;
             if (k.toking(after.X, after.Y, help, picbox, playernum*-1) != new Point(-1, -1))
                 return -50;
             else
                 return 50;
            
             
         
         }

         
        //اذا حركنا القطعه للمكان الجديد هل يكون ملك العدو مهدد تعيد 70 وغير ذلك 0
         public int enemyking_threatened()// good
         {

             int x1, y1;
             int[,] help = new int[8, 8];
             if (playernum == -1)
             {
                 x1 = kingsplace[1].X;
                 y1 = kingsplace[1].Y;
             }
             else
             {
                 x1 = kingsplace[0].X;
                 y1 = kingsplace[0].Y;
             }
             king k = new king(new Point(x1, y1), mat, picbox, playernum, kings, rooks);
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             if (k.toking(x1, y1, help, picbox, playernum*-1) != new Point(-1, -1)) // king enemy are threated before
                 return 0;
             else// king enemy not threated before
             {
                 help[after.X, after.Y] = help[befor.X, befor.Y];
                 help[befor.X, befor.Y] = 0;
                 if (k.toking(after.X, after.Y, help, picbox, playernum*-1) != new Point(-1, -1)) // king enemy is threted after
                     return 70;
                 else
                     return 0;
             }

            

         }
        //اذا كانت القطعه او عند انتقالها للمكان الجديد تستطيع قتل قطع من قطع العو تعيد حسب اهميته جندي 60 وغير ذلك 0
         public int killer() // good
         {
             game_main aaa = new game_main();
             aaa.refreshcolors(picbox, playernum, mat);// no color
             switch (mat[befor.X, befor.Y]) // show color green before move the item
             {
                 case -1:case 1: Pawn p2 = new Pawn(befor, mat, picbox, playernum, kingsplace, kings, rooks);
                     p2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 case -2: case 2: rook r2 = new rook(befor, mat, picbox, playernum, kingsplace, kings, rooks);
                     r2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 case -3: case 3: knight kn2 = new knight(befor, mat, picbox, playernum, kingsplace, kings, rooks);
                      kn2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 case -4: case 4: fou f2 = new fou(befor, mat, picbox, playernum, kingsplace, kings, rooks);
                     f2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 case -5: case 5: queen q2 = new queen(befor, mat, picbox, playernum, kingsplace, kings, rooks);
                     q2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 case -6: case 6: king k2 = new king(befor, mat, picbox, playernum, kings, rooks);
                     k2.showGreenplaces(befor.X, befor.Y, picbox); break;
                 default: break;
             }
             if(picbox[after.X*10+after.Y-2*after.X].BackColor==Color.Green)// new point is green?
                 if (mat[after.X, after.Y] != 0)// new pos in mat(orginal) not 0 
                 {
                     switch (Math.Abs(mat[after.X, after.Y]))
                     {
                         case-1: case 1: aaa.refreshcolors(picbox, playernum, mat); return 60;
                         case-2: case 2: aaa.refreshcolors(picbox, playernum, mat); return 62;
                         case-3: case 3: aaa.refreshcolors(picbox, playernum, mat); return 64;
                         case-4: case 4: aaa.refreshcolors(picbox, playernum, mat); return 66;
                         case-5: case 5: aaa.refreshcolors(picbox, playernum, mat); return 68;
                         default: break;
                     }
                 }
                 
             return 0;


         }
        //عند انتقال القطعه للمكان الجديد نفحص عدد القطع التي تستطيع القطعه تهديدها ونعيدها واذا ولا قطعه نعيد 0
         public int count_piesethreated()//good
         {
             game_main aaa = new game_main();
             int[,] help = new int[8, 8];
             int k=0,c=0;
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             help[after.X, after.Y] = help[befor.X, befor.Y];
             help[befor.X, befor.Y] = 0;
             aaa.refreshcolors(picbox, playernum, help);
             switch (help[after.X, after.Y])
             {
                 case 1:case -1: Pawn p2 = new Pawn(after, help, picbox, playernum, kingsplace, kings, rooks);
                     p2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 2: case -2: rook r2 = new rook(after, help, picbox, playernum, kingsplace, kings, rooks);
                     r2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 3: case -3: knight kn2 = new knight(after, help, picbox, playernum, kingsplace, kings, rooks);
                     kn2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 4:  case -4: fou f2 = new fou(after, help, picbox, playernum, kingsplace, kings, rooks);
                     f2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 5:  case -5: queen q2 = new queen(after, help, picbox, playernum, kingsplace, kings, rooks);
                     q2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 6:  case -6: king k2 = new king(after, help, picbox, playernum, kings, rooks);
                     k2.showGreenplaces(after.X, after.Y, picbox); break;
                 default: break;

             }
             for (int d = 0; d < 8; d++)
             {
                 for (int e = 0; e < 8; e++)
                 {
                     if (picbox[k].BackColor == Color.Green)
                        if (help[d, e] != 0) c++;
                     k++;
                 }

             }
             aaa.refreshcolors(picbox, playernum, help);
             return c*10;
         
         }
         
        //داله تعيد عدد الاماكن الخضراء 
         public int count_greenplace()//good
         {

             int count = 0;
             int[,] help = new int[8, 8];
             for (int i = 0; i < 8; i++)
             {
                 for (int j = 0; j < 8; j++)
                 {
                     help[i, j] = mat[i, j];
                 }
             }
             help[after.X, after.Y] = help[befor.X, befor.Y];
             help[befor.X, befor.Y] = 0;
             game_main aaa = new game_main();
             aaa.refreshcolors(picbox, playernum, mat);
             switch (help[after.X, after.Y])
             {
                 case 1: case -1: Pawn p2 = new Pawn(after, help, picbox, playernum, kingsplace, kings, rooks);
                     p2.showGreenplaces(after.X, after.Y , picbox);  break;
                 case 2:  case -2: rook r2 = new rook(after, help, picbox, playernum, kingsplace, kings, rooks);
                   r2.showGreenplaces(after.X, after.Y, picbox);  break;
                 case 3:case -3: knight kn2 = new knight(after, help, picbox, playernum, kingsplace, kings, rooks);
                   kn2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 4: case -4: fou f2 = new fou(after, help, picbox, playernum, kingsplace, kings, rooks);
                   f2.showGreenplaces(after.X, after.Y, picbox); break;
                 case 5: case -5: queen q2 = new queen(after, help, picbox, playernum, kingsplace, kings, rooks);
                      q2.showGreenplaces(after.X, after.Y, picbox);break;
                 case -6: king k2 = new king(after, help, picbox, playernum, kings, rooks);
                   k2.showGreenplaces(after.X, after.Y, picbox); break;
                 default: break;

             }

         for (int i = 0; i < 8; i++)
             for (int j = 0; j < 8; j++)
                 if (picbox[i * 10 + j - 2 * i].BackColor == Color.Green)
                     count++;
         return count;
         }


// اذا القطعه كانت مهدده وعند انتقالها للمكان الجديد تكون غير مهدد تعيد حسب اهميتها مثلا جندي 60 القلعه 65 وغير ذلك 0
      public int not_threatened()//good
      {
             int[,] help = new int[8, 8];
             int p1, p2;
             if (playernum == -1)
             {
                 p1 = kingsplace[0].X;
                 p2 = kingsplace[0].Y;
             }
             else
             {
                 p1 = kingsplace[1].X;
                 p2 = kingsplace[1].Y;
             }
             king k = new king(new Point(p1, p2), mat, picbox, playernum, kings, rooks);
             if (k.toking(befor.X,befor.Y, mat, picbox, playernum*-1) != new Point(-1, -1))
             {
                 for (int i = 0; i < 8; i++)
                 {
                     for (int j = 0; j < 8; j++)
                     {
                         help[i, j] = mat[i, j];
                     }
                 }
                 help[after.X, after.Y] = help[befor.X, befor.Y];
                 help[befor.X, befor.Y] = 0;
                 if (k.toking(after.X, after.Y, help, picbox, playernum*-1) == new Point(-1, -1))
                 {

                     switch (help[after.X, after.Y])
                     {
                         case 1: case -1: return 60;
                         case 2: case -2: return 65;
                         case 3:  case -3: return 70;
                         case 4: case -4: return 75;
                         case 5: case -5: return 80;
                         case 6: case -6: return 85;
                         default: break;
                     }

                 }
                 else
                     return 0;
             }
             return 0;
         }


         public int totalscour() {
           //  string sum = " "; 
             int sum=0;
             int item = mat[befor.X, befor.Y];
             sum += my_king_is_threated() ;
             sum += after_click();
             sum += after_click_threatened();
             sum += enemyking_threatened();
             sum += killer();
             sum += count_piesethreated();
            // sum += count_greenplace();
             sum += not_threatened();
           
             return sum;

         }




    }
}
