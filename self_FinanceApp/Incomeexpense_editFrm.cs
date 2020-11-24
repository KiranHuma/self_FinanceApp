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
    public partial class Incomeexpense_editFrm : Form
    {

        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();



        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";

        public Incomeexpense_editFrm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            this.Hide();
            Mie.Show();
            get_incomesum();
        }
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

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //to edit the  expenses
        public void income_edit()
        {
            double addd;
            addd = double.Parse(txt_amnt.Text) + double.Parse(lbl_balnce.Text);
            lbl_balnce.Text = Convert.ToString(addd);

            // Query string
            SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "Update  db_incomeexpenses Set Description='" + txt_des.Text + "',Name_or_source='" + txt_contacts.Text + "',Income='" + txt_amnt.Text + "' ,Entry_Date='" + txt_date.Value + "' where Entry_no='" + label1.Text + "'";
                    cmd.ExecuteNonQuery();
                    //getincome_Grid.Rows.Remove(getincome_Grid.CurrentRow);
                    MessageBox.Show("Data Updated");
                    con.Close();
                

            
        }
        //to edit the  expenses
        public void expense_edit()
        {
            double addd;
            addd = double.Parse(txt_amnt.Text) + double.Parse(lbl_balnce.Text);
            lbl_balnce.Text = Convert.ToString(addd);

            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "Update  db_incomeexpenses Set Description='" + txt_des.Text + "',Name_or_source='" + txt_contacts.Text + "',Expense='" + txt_amnt.Text + "' ,Entry_Date='" + txt_date.Value + "' where Entry_no='" + label1.Text + "'";
            cmd.ExecuteNonQuery();
            //getincome_Grid.Rows.Remove(getincome_Grid.CurrentRow);
            MessageBox.Show("Data Updated");
            con.Close();



        }
       
        private void button2_Click(object sender, EventArgs e)
        {
        
            if (rbtn_income.Visible == true)
            {
              
                income_edit();
            }
            else
            {
               
                expense_edit();
            }
          
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
         
        }
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

            private void Incomeexpense_editFrm_Load(object sender, EventArgs e)
        {

            get_contactforEdit();
          //  radiobtn_expense.Visible = false;
        }
            //get sum of income
            public void get_contactforEdit()
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        SqlCommand command =
                        new SqlCommand("SELECT Name_or_source FROM db_incomeexpenses where Entry_no='" + label1.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            txt_contacts.Text = (read["Name_or_source"].ToString());

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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            get_contacts();
        }
    }
}
