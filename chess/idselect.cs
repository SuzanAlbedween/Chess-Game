using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    class idselect
    {



        public static int selectid(string sql, string db)
        {
            int x1;
            try
            {
                x1 = int.Parse(Dbase.SelectFromTable(sql, db).Rows[0][0].ToString());
                x1 = x1 + 1;
            }
            catch (Exception)
            {
                x1 = 0;

            }

            return x1;
        }

    }
}
