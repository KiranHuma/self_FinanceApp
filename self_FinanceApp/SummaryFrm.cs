using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace self_FinanceApp
{
    public partial class SummaryFrm : Form
    {
        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        public static string SetValueForText3 = "";
        

        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public SummaryFrm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // get the data of income of user in grid
        public void getdata_income()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income) as INCOME,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where Username='" + label1.Text + "'", con);
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
        // get the data of expense of user in grid
        public void getdata_expense()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Expense,Recurring_Expense) as EXPENSES,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where Username='" + label1.Text + "'", con);
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

        public void getdata_summary()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses  where  Username='" + label1.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    GetInEx_Grid.DataSource = dt;
                    GetInEx_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        //by date filter 
        public void date_incomefilter()
        {
            con.Close();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime dfrom = dateTimePicker1.Value;
            DateTime dto = dateTimePicker2.Value;
            con.ConnectionString = cs;
            con.Open();
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where  Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            getincome_Grid.DataSource = dt;
            con.Close();
            getincome_Grid.Refresh();

        }
        public void date_expense_search()
        {
            con.Close();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime dfrom = dateTimePicker4.Value;
            DateTime dto = dateTimePicker3.Value;
            con.ConnectionString = cs;
            con.Open();
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where  Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            getexpense_Grid.DataSource = dt;
            con.Close();
            getexpense_Grid.Refresh();

        }
        private void SummaryFrm_Load(object sender, EventArgs e)
        {
            label1.Text = Manage_income_expensesFrm.SetValueForText3;
            label6.Text = loginFrm.SetValueForText2;
           if (label6.Text=="Admin")
           {
               radioButton1.Visible = false;
               radioButton2.Visible = false;
               radioButton3.Visible = false;
               radioButton4.Visible = true;
               radioButton5.Visible = true;
               radioButton6.Visible = true;
               admin_grid();
               admin_incomegrid();
               admin_expensegrid();
           }
           else
           {
            radioButton4.Visible = false;   
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
               
               getdata_income();
               getdata_expense();
               getdata_summary();
           }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            date_incomefilter();
            radioButton1.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            date_expense_search();
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //search summary
        public void search_sum()
        {
            con.Close();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime dfrom = dateTimePicker6.Value;
            DateTime dto = dateTimePicker5.Value;
            con.ConnectionString = cs;
            con.Open();
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            GetInEx_Grid.DataSource = dt;
            con.Close();
            GetInEx_Grid.Refresh();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            search_sum();

            radioButton3.Checked = false;
        }
        //for income report
        public void frm_summary_report_text()
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        // for admin panel
        public void admin_datesummary()
        {
            con.Close();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime dfrom = dateTimePicker6.Value;
            DateTime dto = dateTimePicker5.Value;
            con.ConnectionString = cs;
            con.Open();
            string str = "SELECT  Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            GetInEx_Grid.DataSource = dt;
            con.Close();
            GetInEx_Grid.Refresh();
        }
       
        public void admin_grid()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    GetInEx_Grid.DataSource = dt;
                    GetInEx_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }
        }
        public void admin_incomegrid()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses  ", con);
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
        public void admin_expensegrid()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses ", con);
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
        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            admin_datesummary();
            radioButton4.Checked = false;
        }
        public void admin_incomefilter()
        {
            try
            {
                con.Close();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DateTime dfrom = dateTimePicker1.Value;
                DateTime dto = dateTimePicker2.Value;
                con.ConnectionString = cs;
                con.Open();
                string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,ISNULL(Income,Recurring_Income)as INCOME,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where  Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
                var da = new SqlDataAdapter(str, con);
                da.Fill(dt);
                getincome_Grid.DataSource = dt;
                con.Close();
                getincome_Grid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                this.Dispose();
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            admin_incomefilter();
            radioButton5.Checked = false;
        }
        public void admin_expensefilter()
        {
            try
            {

            con.Close();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime dfrom = dateTimePicker4.Value;
            DateTime dto = dateTimePicker3.Value;
            con.ConnectionString = cs;
            con.Open();
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,ISNULL(Expense,Recurring_Expense)as EXPENSES,Recurring_Date,Recurring_Interval,Record_update,Entry_Date from db_incomeexpenses where Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            getexpense_Grid.DataSource = dt;
            con.Close();
            getexpense_Grid.Refresh();
              }
            catch (Exception ex)
            {
                MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                this.Dispose();
            }

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            admin_expensefilter();
            radioButton6.Checked = false;
        }
    }
    }

