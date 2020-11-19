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
    public partial class userregFrm : Form
    {                
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
       
        string str;
        SqlCommand com;
        int count;
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
            public userregFrm()
        {
            InitializeComponent();
        }

        private void userregFrm_Load(object sender, EventArgs e)
        {
            dbaccessconnection();
            txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy ");
           

        }
        public void dbaccessconnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                cmd.Connection = con;
               
              //  MessageBox.Show("Connected");
            }
            catch (Exception )
            {
              
                MessageBox.Show("Database not Connected");
            }
        }
        public void accountcreated()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                
               // string Entry_no = txtentry.Text;
                string Username = txtUsername.Text;
                string Name = txtName.Text;
                string Password = txtPass.Text;
                string passagain = txtPassAgain.Text;
                string Gender = CmboGender.Text;
                string Contact_no = txtContact.Text;
                string Email = txtEmail.Text;
                string Account_Creation_Date = txtDate.Text;
              
                string sqlquery = ("insert into db_auth(Username,Name,Password,Gender,Contact_no,Email,Account_Creation_Date)values('" + txtUsername.Text + "','" + txtName.Text + "','" + txtPass.Text + "','" + CmboGender.Text + "','" + txtEmail.Text + "','" + txtContact.Text + "','" + txtDate.Text + "')");
                SqlCommand command = new SqlCommand(sqlquery, connection);

               // command.Parameters.AddWithValue("Entry_no", Entry_no);
                command.Parameters.AddWithValue("Username", Username);
                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Password", Password);
                command.Parameters.AddWithValue("Gender", Gender);
                command.Parameters.AddWithValue("Contact_no", Contact_no);
                command.Parameters.AddWithValue("Email", Email);
                command.Parameters.AddWithValue("Account_Creation_Date", Account_Creation_Date);
     

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                label7.Text = "Account not Created Successfully";
                MessageBox.Show(ex.Message);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loginFrm lg = new loginFrm();
            this.Hide();
            lg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accountcreated();


        }
        public void namecheck()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            str = "select count(*)from db_auth where Username='" + txtUsername.Text + "'";
            com = new SqlCommand(str, con);
            int count = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                label7.Text = "Sorry! you can't take this username";
                label7.ForeColor = Color.Red;
                //label7.Text = "";
            }
            else
            {
                label7.Text = "";
                
            }
            
        }
        private void txtPassAgain_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtPass.Text == txtPassAgain.Text)
                {
                    label8.Text = "Match";
                    label8.ForeColor = Color.Green;
                }
                else
                {
                    label8.Text = "Not match";
                    label8.ForeColor = Color.Red;
                }
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            namecheck();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
