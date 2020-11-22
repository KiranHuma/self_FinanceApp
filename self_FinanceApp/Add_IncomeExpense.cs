﻿using System;
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
    public partial class Add_IncomeExpense : Form
    {

        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
       


        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public Add_IncomeExpense()
        {
            InitializeComponent();
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            this.Hide();
            Mie.Show();
            get_incomesum();// to update the balance
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        //insert the values of income and expenses in database
        public void insert_incomeexpenses()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();

                string Usernamee = lbl_user.Text;
                string Name = lbl_name.Text;
                string Des = txt_des.Text;
                string Contact = txt_contacts.Text;
                //string amnt = txt_amnt.Text;
                string amnt = txt_amnt.Text;
                string expense = radiobtn_expense.Text;
                string blnc = lbl_balnce.Text;
                string datee = txt_date.Text;
                if (rbtn_income.Checked)
                {
                  double addd;
                    addd = double.Parse(txt_amnt.Text) + double.Parse(lbl_balnce.Text);
                    lbl_balnce.Text = Convert.ToString(addd);
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Income,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + txt_date.Value + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                   
                    command.Parameters.AddWithValue("Income", amnt);
                   
                    command.Parameters.AddWithValue("Entry_Date", datee);
                   // get_incomesum();
                    command.ExecuteNonQuery();
                  
                    label7.Text = "Income added Successfully";
                    label7.ForeColor = System.Drawing.Color.DarkGreen;

                }
                else
                {
                    double subtrct;
                    subtrct = Math.Abs(double.Parse(txt_amnt.Text) - (double.Parse(lbl_balnce.Text)));
                    lbl_balnce.Text = Convert.ToString(subtrct);
                    subtrct = Math.Abs(subtrct);
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Expense,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + txt_date.Value + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    // command.Parameters.AddWithValue("Amount", amnt);
                    command.Parameters.AddWithValue("Expense", amnt);
                   // command.Parameters.AddWithValue("Your_Balance", blnc);
                    command.Parameters.AddWithValue("Entry_Date", datee);
                   // get_incomesum();
                    command.ExecuteNonQuery();
                   
                    // radiobtn_expense.Text = "Expense";
                    label7.Text = "Expenses added Successfully";
                    label7.ForeColor = System.Drawing.Color.DarkGreen;
                }

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }
      
        private void Add_IncomeExpense_Load(object sender, EventArgs e)
        {
            lbl_user.Text = loginFrm.SetValueForText1;
            
            get_name();
            
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            insert_incomeexpenses();
            label7.Visible = true;
        }
        
    
        //get sum of income and function for calculating the total balance
        public void get_incomesum()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income)-SUM(Expense) as incomeamount FROM db_incomeexpenses where Username='" + lbl_user.Text + "'", connection);
                    connection.Open(); 
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        lbl_balnce.Text = (read["incomeamount"].ToString());

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
      
        //Function to get data from the database into textboxes for geting the name for expense/income
        public void get_name()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("select * from db_auth where Username='" + lbl_user.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        lbl_name.Text = (read["Name"].ToString());
                     

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
        //get the contacts
        public void get_contacts()
        {
            try
            {
                string constr = @cs;
                // using (SqlConnection conn = new SqlConnection(@"Data Source=SHARKAWY;Initial Catalog=Booking;Persist Security Info=True;User ID=sa;Password=123456"))
                using (SqlConnection conn = new SqlConnection(@cs))
                {
                    try
                    {
                        string query = "SELECT  Contact_Name FROM manage_contacts";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        conn.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds, "manage_contacts");
                        txt_contacts.DisplayMember = "Contact_Name";
                        //txt_contacts.ValueMember = "Entry_no";
                        txt_contacts.DataSource = ds.Tables["manage_contacts"];
                    }
                    catch (Exception ex)
                    {
                        // write exception info to log or anything else
                        MessageBox.Show(ex.Message);
                    }
                }
            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Failed:Retrieving RecentNames " + ex.Message);
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_income_CheckedChanged(object sender, EventArgs e)
        {
           
          
        }

        private void radiobtn_expense_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            get_contacts();
        }
    }
}
