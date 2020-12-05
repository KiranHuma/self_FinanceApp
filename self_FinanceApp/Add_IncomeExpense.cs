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
        // get contacts
        public void getdata_contacts()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Contact_Name from manage_contacts where userid='" + lbl_user.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    Contact_Grid.DataSource = dt;
                    Contact_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

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
            //get_contacts();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            txt_contacts.Text = "No Contacts";
        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void Contact_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_contacts.Text = this.Contact_Grid.CurrentRow.Cells[0].Value.ToString();
            Contact_Grid.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_name_TextChanged(object sender, EventArgs e)
        {
             string str;
            try
            {
                var con = new SqlConnection(cs);
                con.Open();
                str = "Select Contact_Name from manage_contacts where Contact_Name like '" + search_name.Text + "%' AND userid='" + lbl_user.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "manage_contacts");
                con.Close();
                Contact_Grid.DataSource = ds;
                Contact_Grid.DataMember = "manage_contacts";
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed: Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            Contact_Grid.Visible = true;
            panel2.Visible = false;
            panel3.Visible = true;
            getdata_contacts();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }
        
    }
}
