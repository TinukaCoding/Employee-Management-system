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
    public partial class Department : Form
    {
        Functions Con;
        public Department()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }

        private void ShowDepartments()
        {
            String Query = "Select * from DepartmentTable";
            DepList.DataSource = Con.GetData(Query);
            
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Insert into DepartmentTable values('{0}')";
                    Query = string.Format(Query, DepNameTb.Text);
                   Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department  Added...");
                    DepNameTb.Text = "";
                }

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelWindow1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int Key = 0;
        private void DepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if any rows are selected
            if (DepList.SelectedRows.Count > 0)
            {
                DepNameTb.Text = DepList.SelectedRows[0].Cells[1].Value.ToString();

                if (DepNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(DepList.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            else
            {
                // Handle the case where no rows are selected
                // You might want to display a message or perform some other action
                MessageBox.Show("No rows are selected.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Delete from DepartmentTable  where DepId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department  Deleted!!!");
                    DepNameTb.Text = "";
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Update DepartmentTable set DepName = '{0}' where DepId = {1}";
                    Query = string.Format(Query, DepNameTb.Text, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department  Updated...");
                    DepNameTb.Text = "";
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employee obj = new Employee();
            obj.Show();
            this.Hide();
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void SalaryLbl_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void LogOutLbl_Click(object sender, EventArgs e)
        {
            Login   Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
