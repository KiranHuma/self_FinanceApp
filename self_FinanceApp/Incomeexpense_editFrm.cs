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

       
      
        public static string SetValueForaddincome = "";

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
        // get total income and expense sum for edit
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
            this.Dispose();
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
      

            private void Incomeexpense_editFrm_Load(object sender, EventArgs e)
        {
      
          
            userid.Text = loginFrm.SetValueForText1;
           
           get_contactforEdit();
         
        }
           
            public void get_contactforEdit()
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Entry_no='" + label1.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            txt_contacts.Text = (read["Name_or_source"].ToString());
                            txt_date.Text = (read["Entry_Date"].ToString());
                         
                            label14.Text = (read["Username"].ToString());
                            
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
           
            txt_contacts.Text = "No Contacts";

        }
        // get contacts
        public void getdata_contacts()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Contact_Name from manage_contacts where userid='" + label14.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    edit_INEXP_Grid.DataSource = dt;
                    edit_INEXP_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        private void label10_Click(object sender, EventArgs e)
        {
            
          
        }

        private void Contact_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_contacts.Text = this.edit_INEXP_Grid.CurrentRow.Cells[0].Value.ToString();
            edit_INEXP_Grid.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void txt_contacts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // search contacts by textbox 
        private void search_name_TextChanged(object sender, EventArgs e)
        {
             string str;
            try
            {
                var con = new SqlConnection(cs);
                con.Open();
                str = "Select Contact_Name from manage_contacts where Contact_Name like '" + search_name.Text + "%' AND userid='" + label14.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "manage_contacts");
                con.Close();
                edit_INEXP_Grid.DataSource = ds;
                edit_INEXP_Grid.DataMember = "manage_contacts";
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed: Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            edit_INEXP_Grid.Visible = true;
            panel2.Visible = false;
            panel3.Visible = true;
            getdata_contacts();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }
          
        }
    }

