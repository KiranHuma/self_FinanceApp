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
    public partial class loginFrm : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
       
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public loginFrm()
        {
            InitializeComponent();
        }
        private void loginFrm_Load(object sender, EventArgs e)
        {
            dbaccessconnection();
        }
        public void dbaccessconnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                cmd.Connection = con;

                //  MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Database not Connected");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (selectUser.Text == "User")
            {

                SqlConnection con = new SqlConnection(@cs); // making connection   
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM db_auth WHERE Username='" + txtUser.Text + "' AND Password='" + txtPass.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SetValueForText1 = txtUser.Text;
                    SetValueForText2 = selectUser.Text;
                    /* I have made a new form  called userdeatils . If the user is successfully authenticated then the form will be moved to the next form */
                    this.Hide();
                    new Manage_income_expensesFrm().Show();
                }
                else
                    MessageBox.Show("Invalid username or password");
            }
            else if (selectUser.Text == "Admin")
            {
                SqlConnection con = new SqlConnection(@cs); // making connection   
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM db_admin WHERE Username='" + txtUser.Text + "' AND Password='" + txtPass.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SetValueForText1 = txtUser.Text;
                    SetValueForText2 = selectUser.Text;
                    /* I have made a new form  called userdeatils . If the user is successfully authenticated then the form will be moved to the next form */
                    this.Hide();
                    new Manage_income_expensesFrm().Show();
                
                }
                else
                { 
                    MessageBox.Show("Your username Or password is not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label6.ForeColor = Color.Red;
                    label6.Text = " Not succsessfully login "; 
                }
            }
            else
            {
                MessageBox.Show("Select your choice", "ADMIN or USER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            userregFrm ud = new userregFrm();
            this.Hide();
            ud.Show();
            this.Hide();
        }
    }
}
