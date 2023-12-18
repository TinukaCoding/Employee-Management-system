using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_system
{
    public partial class Salary : Form
    {
        Functions Con;
        public Salary()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalaries();
            GetEmployees();
        }
        private void GetEmployees()
        {
            string Query = "select * from EmployeeTable";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }
        int DSal = 0;
        string Period = "";
        private void GetSalary()
        {
            string Query = "SELECT * FROM EmployeeTable WHERE EmpId = {0}";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());

            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSalary"].ToString());
            }

            //MessageBox.Show("" + DSal);

            if (DaysTb.Text == "")
            {
                // Assuming d is declared and initialized somewhere in your code
                AmountTb.Text = "" + (d * DSal);
            } else if (Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days can not be greater than 31");
            }
            else
            {
                // Assuming d is declared and initialized somewhere in your code
                d = Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "Rs " + (d * DSal);
            }
        }


        private void ShowSalaries()
        {
            String Query = "Select * from EmployeeTable";
            SalList.DataSource = Con.GetData(Query);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelWindow1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Department Obj = new Department ();
            Obj.Show();
            this.Hide();
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employee  Obj = new Employee ();
            Obj.Show();
            this.Hide();
        }
        int d = 1; 
    
        private void AddBtn_Click(object sender, EventArgs e)
        {
            EmpCb.Text = "";
            DaysTb.Text = "";
            AmountTb.Text = "";
        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }

        private void DaysTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogOutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
