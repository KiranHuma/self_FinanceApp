using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace self_FinanceApp
{
    public partial class Manage_income_expensesFrm : Form
    {


        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        public static string SetValueForText3 = "";


        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public Manage_income_expensesFrm()
        {
            InitializeComponent();
        }

        private void Manage_income_expensesFrm_Load(object sender, EventArgs e)
        {
            label2.Text = loginFrm.SetValueForText1;
            txt_blncdate.Text = DateTime.Now.ToString("MMM-dd ");
            label9.Text = DateTime.Now.ToString("MM-dd-yyyy");
            get_income();
            get_expenses();
            get_incomesum();
            getdata_income();
            getdata_expenses();
        }


        // get the data of User in grid
        public void getdata_income()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Income,Entry_Date from db_incomeexpenses where Income IS NOT NULL AND Entry_Date='" + label9.Text + "' AND Username='" + label2.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    getincome_Grid.DataSource = dt;
                    getincome_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        // get the data of User in grid
        public void getdata_expenses()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Expense,Entry_Date from db_incomeexpenses where Expense IS NOT NULL AND Entry_Date='" + label9.Text + "' AND Username='" + label2.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    getexpense_Grid.DataSource = dt;
                    getexpense_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        //get sum of income
        public void get_income()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income) as incomeamount FROM db_incomeexpenses where Username='" + label2.Text + "'  AND Username='" + label2.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label7.Text = (read["incomeamount"].ToString());

                    }
                    read.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    this.Dispose();
                }
            }
        }
        //get sum of expenses
        public void get_expenses()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Expense) as expensesamount FROM db_incomeexpenses where Username='" + label2.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label8.Text = (read["expensesamount"].ToString());

                    }
                    read.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    this.Dispose();
                }
            }
        }
        //get sum of income and function for calculating the total balance
        public void get_incomesum()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income)-SUM(Expense) as incomeamount FROM db_incomeexpenses where Username='" + label2.Text + "'  AND Username='" + label2.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label3.Text = (read["incomeamount"].ToString());

                    }
                    read.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    this.Dispose();
                }
            }
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            btn_addincome_expense.Visible = true;
            getexpense_Grid.Visible = false;
            getincome_Grid.Visible = false;
            lbl_income.Visible = true;
            btn_recurring.Visible = true;
            lbl_recurr.Visible = true;
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Add_IncomeExpense addIE = new Add_IncomeExpense();
            this.Hide();
            addIE.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label9.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            getdata_income();
            getdata_expenses();
        }

        private void getincome_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
            }
       
      
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Incomeexpense_editFrm obj = new Incomeexpense_editFrm();
            obj.label1.Text = this.getincome_Grid.CurrentRow.Cells[0].Value.ToString();
            obj.txt_des.Text = this.getincome_Grid.CurrentRow.Cells[1].Value.ToString();
           
            obj.txt_amnt.Text = this.getincome_Grid.CurrentRow.Cells[2].Value.ToString();
            obj.txt_date.Text = this.getincome_Grid.CurrentRow.Cells[3].Value.ToString();
           obj.rbtn_income.Visible = true;
            this.Hide();
            obj.ShowDialog();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            //to delete the selected row
            foreach (DataGridViewRow item in this.getincome_Grid.SelectedRows)
            {
                getincome_Grid.Rows.RemoveAt(item.Index);
            }
            Manage_income_expensesFrm refreshh = new Manage_income_expensesFrm();
            this.Hide();
            refreshh.Show();
        
        }

        private void getexpense_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Incomeexpense_editFrm obj = new Incomeexpense_editFrm();
            obj.label1.Text = this.getexpense_Grid.CurrentRow.Cells[0].Value.ToString();
            obj.txt_des.Text = this.getexpense_Grid.CurrentRow.Cells[1].Value.ToString();
            obj.txt_amnt.Text = this.getexpense_Grid.CurrentRow.Cells[2].Value.ToString();
            obj.txt_date.Text = this.getexpense_Grid.CurrentRow.Cells[3].Value.ToString();
            obj.radiobtn_expense.Visible = true;
            this.Hide();
            obj.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //to delete the selected row
            foreach (DataGridViewRow item in this.getexpense_Grid.SelectedRows)
            {
                getexpense_Grid.Rows.RemoveAt(item.Index);
            }
            Manage_income_expensesFrm refreshh = new Manage_income_expensesFrm();
            this.Hide();
            refreshh.Show();
        }

        private void getincome_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void getexpense_Grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            Manage_contacts MC = new Manage_contacts();
            this.Hide();
            MC.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SetValueForText3 = label2.Text;
            SummaryFrm MC = new SummaryFrm();
            this.Hide();
            MC.Show();
        }
    }
    }

