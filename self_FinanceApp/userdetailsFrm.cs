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
    public partial class userdetailsFrm : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();

        string str;
        SqlCommand com;
        int count;
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public userdetailsFrm()
        {
            InitializeComponent();
        }

        private void userdetailsFrm_Load(object sender, EventArgs e)
        {
            label1.Text = loginFrm.SetValueForText1;
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
            catch (Exception)
            {

                MessageBox.Show("Database not Connected");
            }
        }
        public void getcred()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {


                    SqlCommand command =
                    new SqlCommand("select * from db_auth where Username='" + label1.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        txtentry.Text = (read["Entry_no"].ToString());
                        txtUsername.Text = (read["Username"].ToString());
                        txtName.Text = (read["Name"].ToString());
                        txtPass.Text = (read["Password"].ToString());
                        CmboGender.Text = (read["Gender"].ToString());
                        txtContact.Text = (read["Contact_no"].ToString());
                        txtEmail.Text = (read["Email"].ToString());
                        txtDate.Text = (read["Account_Creation_Date"].ToString());

                    }
                    read.Close();

                }
                catch (Exception ex)
                {
                    // MsgBox(("Failed:Autoincrement of Service ID Entry" + ex.Message));
                    MessageBox.Show(ex.Message);
                    this.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getcred();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            updatecred();
        }
        public void updatecred()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);

                connection.Open();


                string sqlquery = ("Update db_auth set Username=@Usernamee,Name=@Namee,Password=@Passwordd,Gender=@Genderr,Contact_no=@Contact_noo,Email=@Emaill where Entry_no=@Entry_noo");
                SqlCommand command = new SqlCommand(sqlquery, connection);
                command.Parameters.AddWithValue("@Entry_noo", txtentry.Text);
                command.Parameters.AddWithValue("@Usernamee", txtUsername.Text);
                command.Parameters.AddWithValue("@Namee", txtName.Text);
                command.Parameters.AddWithValue("@Passwordd", txtPass.Text);
                command.Parameters.AddWithValue("@Genderr", CmboGender.Text);
                command.Parameters.AddWithValue("@Contact_noo", txtContact.Text);
                command.Parameters.AddWithValue("@Emaill", txtEmail.Text);
   


                command.ExecuteNonQuery();
                label12.Text = "Data  updated Successfully";
            }
            catch (Exception ex)
            {
                label12.Text = "Data not updated Successfully";
                MessageBox.Show(ex.Message);

            }
        }

        private void txtPassAgain_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtPass.Text == txtPassAgain.Text)
                {
                    label12.Text = "Match";
                    label12.ForeColor = Color.Green;
                }
                else
                {
                    label12.Text = "Not match";
                    label2.ForeColor = Color.Red;
                }
            }
        }
    }
}
