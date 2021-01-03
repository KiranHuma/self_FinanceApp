using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace self_FinanceApp
{
    public partial class userregFrm : Form
    {                
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
       
        string str;
        SqlCommand com;
        
        String cs = "Data Source=XENO;Initial Catalog=db_selfFinace;Integrated Security=True";
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
        // account creation
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
                label7.Visible = true;
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
        public void update_intial_predicted_values()
        {
            // Query string
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Update db_auth Set Your_Balance_with_Recursion='0',Your_Balnc_withou_Recurring='0',Total_Balance='0',Predict_balnce='0',Predict_Date='" + txtDate.Text + "' where Username= '" + txtUsername.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            accountcreated();
            update_intial_predicted_values();
            MessageBox.Show("Account Created Successfully");
            loginFrm lg = new loginFrm();
            this.Hide();
            lg.Show();
            
        }
        // for unique username
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
                label7.Visible = true;
                label7.Text = "Sorry! you can't take this username";
                label7.ForeColor = Color.Red;
                //label7.Text = "";
            }
            else
            {
                label7.Text = "";
                
            }
            
        }
        // match the password of two textboxes
        private void txtPassAgain_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtPass.Text == txtPassAgain.Text)
                {
                    label8.Visible = true;
                    label8.Text = "Match";
                    label8.ForeColor = Color.Green;
                }
                else
                {
                    label8.Visible = true;
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
           
            loginFrm lg = new loginFrm();
            this.Close();
            lg.Show();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtEmail.Text))
                {

                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmail.SelectAll();

                    e.Cancel = true;

                }

            }
        }
    }
}
