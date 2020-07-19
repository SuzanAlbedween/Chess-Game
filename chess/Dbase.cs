using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace chess
{

  public class Dbase
    {
  


        //פונקציה שמקבלת שם בסיס הניתונים ופותחת את בסיס הניתוה
        public static OleDbConnection MakeConnection(string dbFile)
        {
            string filePath = Application.StartupPath + dbFile;


          //  string connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";";

            OleDbConnection c = new OleDbConnection();
        
            c.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + filePath + ";";
        //    c.Open();
            
            return c;
        }

        // פונקציה שמקבלת שם בסיס ניתונים ושאילתה הפונקציה מתציגה את הניתונים בטבלה וסוגרת בסיס הניתונים  
        public static DataTable SelectFromTable(string strSql, string FileName)
        {
            OleDbConnection c = MakeConnection(FileName);
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSql;
            comm.Connection = c;
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(dt);
            c.Close();
            return dt;
        }


        public static void ChangeTable(string strSql, string FileName)
        {
            int n;
             OleDbConnection c = MakeConnection(FileName);
            OleDbCommand comm = new OleDbCommand(strSql,c);
          
            c.Open();
         n= comm.ExecuteNonQuery();

            c.Close();
         if (n > 0)
            MessageBox.Show("record inserted");
          
            else
           MessageBox.Show("insertion failed!!!!!!!!!!");
       
           
        }
       
    
    }
}
