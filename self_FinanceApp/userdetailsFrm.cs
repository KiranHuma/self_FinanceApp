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
        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
       
       
       
        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public userdetailsFrm()
        {
            InitializeComponent();
        }
        //The function call on Form Load
        private void userdetailsFrm_Load(object sender, EventArgs e)
        {
            label1.Text = loginFrm.SetValueForText1;
            txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy ");
            getdata();
        }
        //Function for database connection
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
        // get the data of User in grid
        public void getdata()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select * from db_incomeexpenses ", con);
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
        //Function to get data from the database into textboxes
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
        //Function call on get button
        private void button1_Click(object sender, EventArgs e)
        {
            getcred();
        }
        //Close form
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //function for updating the credentials
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
        //Function call on updatebutton for the credentials
        private void btnupdate_Click(object sender, EventArgs e)
        {
            updatecred();
        }
      
        ///for matching the password.If the password in both textboxes matches the label will show "MATCH" otherwise Not Match
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
       //to add new records.All the texboxes will empty on clicking add new button
        private void btnadd_Click(object sender, EventArgs e)
        {
            txt_INEX_Username.Text = "";
           txt_INEX_name.Text="";
            txt_INEX_Contact.Text="";
            txt_Income.Text="";
            txt_expense.Text="";
             txt_balnce.Text="";
           
        }

        //insert the values of income and expenses in database
        public void insert_incomeexpenses()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();

               string Usernamee = txt_INEX_Username.Text;
                 string Name = txt_INEX_name.Text;
                string Contact= txt_INEX_Contact.Text;
                string Income = txt_Income.Text;
                 string Expense = txt_expense.Text;
                 string Balance= txt_balnce.Text;
                string datee = txt_date.Text;
               

                string sqlquery = ("insert into db_incomeexpenses(Username,Name,Name_or_source,Income,Expenses,Your_Balance,Entry_Date)values('" + txt_INEX_Username.Text + "','" + txt_INEX_name.Text + "','" + txt_INEX_Contact.Text + "','" + txt_Income.Text + "','" + txt_expense.Text + "','" + txt_balnce.Text + "','" + txt_date.Value + "')");
                SqlCommand command = new SqlCommand(sqlquery, connection);
                command.Parameters.AddWithValue("Username", Usernamee);
                command.Parameters.AddWithValue("Name", Name);
                command.Parameters.AddWithValue("Name_or_source", Contact);
                command.Parameters.AddWithValue("Income", Income);
                command.Parameters.AddWithValue("Expenses", Expense);
                command.Parameters.AddWithValue("Your_Balance", Balance);
               command.Parameters.AddWithValue("Entry_Date", datee);


                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                label7.Text = "Account not Created Successfully";
                MessageBox.Show(ex.Message);

            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            insert_incomeexpenses();
        }
        public void your_balance()
        {
            double addd;
            addd = double.Parse(txt_Income.Text) - double.Parse(txt_expense.Text);
            txt_balnce.Text = Convert.ToString(addd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            your_balance();
        }
    }
}
