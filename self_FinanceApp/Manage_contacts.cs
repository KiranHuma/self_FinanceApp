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
    public partial class Manage_contacts : Form
    {

        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();



        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public Manage_contacts()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Function for database connection
        public void dbaccessconnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                cmd.Connection = con;

                  MessageBox.Show("Connected");
            }
            catch (Exception)
            {

                MessageBox.Show("Database not Connected");
            }
        }
        private void Manage_contacts_Load(object sender, EventArgs e)
        {
            getdata_contacts();
        }
        //insert the values of income and expenses in database
        public void insert_contacts()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                //string idd= textBox2.Text;
                string Namee = txt_name.Text;
                string Phone_Numberr = txt_phoneNumber.Text;
                string Contact_Emaill = txt_Email.Text;
                string Contact_Descriptionn = txt_des.Text;
                string Creation_Datee = txt_date.Text;

                string sqlquery = ("insert into manage_contacts(Contact_Name,Phone_Number,Contact_Email,Contact_Description,Creation_Date)values('" + txt_name.Text + "','" + txt_phoneNumber.Text + "','" + txt_Email.Text + "','" + txt_des.Text + "','" + txt_date.Value + "')");
                SqlCommand command = new SqlCommand(sqlquery, connection);
               // command.Parameters.AddWithValue("Entry_no", idd);
                command.Parameters.AddWithValue("Contact_Name", Namee);
                command.Parameters.AddWithValue("Phone_Number", Phone_Numberr);
                command.Parameters.AddWithValue("Contact_Email", Contact_Emaill);
                command.Parameters.AddWithValue("Contact_Description", Contact_Descriptionn);
                command.Parameters.AddWithValue("Creation_Date", Creation_Datee);
                command.ExecuteNonQuery();
                label7.Text = "Contact  Created Successfully";
                connection.Close();
                getdata_contacts();
            }
            catch (Exception ex)
            {
                label7.Text = "Contact not Created Successfully";
                MessageBox.Show(ex.Message);

            }
        }
        //to edit the  contacts
        public void contacts_edit()
        {
            

            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "Update  manage_contacts Set Contact_Name='" + txt_name.Text + "',Phone_Number='" + txt_phoneNumber.Text + "',Contact_Email='" + txt_Email.Text + "' ,Contact_Description='" + txt_des.Text + "',Creation_Date='" + txt_date.Value + "' where Entry_no='" + txt_entry.Text + "'";
            cmd.ExecuteNonQuery();
            //getincome_Grid.Rows.Remove(getincome_Grid.CurrentRow);
            MessageBox.Show("Data Updated");

            con.Close();
            getdata_contacts();


        }
        public void delete_contacts()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("delete manage_contacts where Entry_no=@Entry_no", con);

            cmd.Parameters.AddWithValue("@Entry_no", int.Parse(txt_entry.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully!");
            getdata_contacts();
        }
        // get the data of User in grid
        public void getdata_contacts()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select * from manage_contacts", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    getdata_contacts_Grid.DataSource = dt;
                    getdata_contacts_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        //to empty the textbox for new entry
        private void btnadd_Click(object sender, EventArgs e)
        {
            txt_name.Text = "";
            txt_phoneNumber.Text = "";
            txt_des.Text = "";
            txt_Email.Text = "";
            Entry_No.Visible = false;
            txt_entry.Visible = false;
            //  get_contacts();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            insert_contacts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contacts_edit();
        }

        private void GetInEx_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Entry_No.Visible = true;
            txt_entry.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.getdata_contacts_Grid.Rows[e.RowIndex];
                txt_entry.Text = row.Cells["Entry_no"].Value.ToString();
                txt_phoneNumber.Text = row.Cells["Contact_Name"].Value.ToString();
                txt_name.Text = row.Cells["Phone_Number"].Value.ToString();
                txt_Email.Text = row.Cells["Contact_Email"].Value.ToString();
                txt_des.Text = row.Cells["Contact_Description"].Value.ToString();
                txt_date.Text = row.Cells["Creation_Date"].Value.ToString();

            }
        }
       
        private void btndel_Click(object sender, EventArgs e)
        {
            delete_contacts();
        }
//search by textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str;
            try
            {
                var con = new SqlConnection(cs);
                con.Open();
                str = "Select * from manage_contacts where Contact_Name like '" + search_name.Text + "%'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "manage_contacts");
                con.Close();
                getdata_contacts_Grid.DataSource = ds;
                getdata_contacts_Grid.DataMember = "manage_contacts";
                getdata_contacts_Grid.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed: Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            this.Hide();
            Mie.Show();
        }
    }
    
}
