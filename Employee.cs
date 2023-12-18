using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_system
{
    public partial class Employee : Form
    {
        Functions Con;
        public Employee()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            String Query = "Select * from EmployeeTable";
            EmpList.DataSource = Con.GetData(Query);
        }

            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Em_DOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GetDepartment()
        {
            string Query = "select * from DepartmentTable";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);


                    string Query = "Insert into EmployeeTable values('{0}','{1}',{2},'{3}','{4}',{5})";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added...");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
       
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);


                    string Query = "Update EmployeeTable set EmpName = '{0}',EmpGen = '{1}',EmpDep = {2},EmpDOB = '{3}',EmpJDate = '{4}',EmpSalary = {5} where EmpId = {6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary,Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added...");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0 )
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                   


                    string Query = "Delete from EmployeeTable where EmpId = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Deleted..!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key = 0;
        private void EmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if any rows are selected
            if (EmpList.SelectedRows.Count > 0)
            {
                EmpNameTb.Text = EmpList.SelectedRows[0].Cells[1].Value.ToString();
                GenCb.Text = EmpList.SelectedRows[0].Cells[2].Value.ToString();
                DepCb.SelectedValue  = EmpList.SelectedRows[0].Cells[3].Value.ToString();
                DOBTb.Text = EmpList.SelectedRows[0].Cells[4].Value.ToString();
                JDateTb.Text = EmpList.SelectedRows[0].Cells[5].Value.ToString();
                DailySalTb.Text = EmpList.SelectedRows[0].Cells[6].Value.ToString();

                if (EmpNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(EmpList.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            else
            {
                // Handle the case where no rows are selected
                // You might want to display a message or perform some other action
                MessageBox.Show("No rows are selected.");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Employee  Obj = new Employee ();
            Obj.Show();
            this.Hide();
        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Department  Obj = new Department();
            Obj.Show();
            this.Hide();
        }

        private void SalLbl_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void LogOutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            EmpNameTb.Text = "";
            GenCb.Text = "";
            DepCb.Text = "";
            DOBTb.Text = "";
            JDateTb.Text = "";
            DailySalTb.Text = "";
        }
    }
}
