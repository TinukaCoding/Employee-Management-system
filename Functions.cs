using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_system
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Tinuka Drive\Progamming\C#\Employee Management system\Database_Employee Management System.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(String Query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(Query, ConStr))
                {
                    sda.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                // Handle the SQL exception
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return dt;
        }

        public int SetData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            return cnt;
        }

            

            


    }
}
