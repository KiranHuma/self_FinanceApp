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
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,Income,Entry_Date from db_incomeexpenses where Income IS NOT NULL  AND Username='" + label1.Text + "'", con);
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
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,Expense,Entry_Date from db_incomeexpenses where Expense IS NOT NULL  AND Username='" + label1.Text + "'", con);
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
        public void balnc_check()
        {
            foreach (DataGridViewRow row in GetInEx_Grid.Rows)
            {
                if (decimal.TryParse(row.Cells["Income"]?.Value?.ToString(), out decimal Income)
                    && decimal.TryParse(row.Cells["Expense"]?.Value?.ToString(), out decimal Expense))
                {
                    var avg = (Income - Income) ;
                    row.Cells["Your_Balance"].Value = avg;

                    
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
                    var da = new SqlDataAdapter("Select Entry_no,Username,Name,Description,Name_or_source,Income,Expense,Entry_Date from db_incomeexpenses  where  Username='" + label1.Text + "'", con);
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
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,Income,Entry_Date from db_incomeexpenses where Income IS NOT NULL AND Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
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
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,Expense,Entry_Date from db_incomeexpenses where Expense IS NOT NULL AND Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
            var da = new SqlDataAdapter(str, con);
            da.Fill(dt);
            getexpense_Grid.DataSource = dt;
            con.Close();
            getexpense_Grid.Refresh();

        }
        private void SummaryFrm_Load(object sender, EventArgs e)
        {
            label1.Text = Manage_income_expensesFrm.SetValueForText3;
            getdata_income();
            getdata_expense();
            getdata_summary();
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
            balnc_check();
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
            string str = "SELECT Entry_no,Username,Name,Description,Name_or_source,Income,Expense,Entry_Date from db_incomeexpenses where Username='" + label1.Text + "' AND Entry_Date >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
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
    }
}
