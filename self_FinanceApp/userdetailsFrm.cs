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
            label27.Text = loginFrm.SetValueForText2;
            if (label27.Text == "Admin")
            {
                label30.Text = "Admin";
                label28.Visible = true;
                button5.Visible = true;
                label29.Visible = true;
                label8.Visible = false;
                label5.Visible = false;
                label9.Visible = false;
                label6.Visible = false;
                txtName.Visible = false;
                CmboGender.Visible = false;
                txtContact.Visible = false;
                txtEmail.Visible = false;
                txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy ");
                txt_useName_Search.Visible = true;
                label31.Visible = true;
                getdata_foradmin();
                dataGridView1.Visible = true;
              
            }
            else
            {
                label28.Visible = false;
                button5.Visible = false;
                label29.Visible = false;
                txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy ");
                txt_useName_Search.Visible = false;
                label31.Visible = false;
                dataGridView1.Visible = false;
             
            }

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
       
        public void getdata_foradmin()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select * from db_auth ", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
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
            if (label30.Text == "User" | label27.Text == "User")
            {
              
                  getcred();
            }
            else
            {
                MessageBox.Show("Select user from grid"); 
                tabControl1.SelectedTab = tabPage5;
            }
           
            
        }
        //Function to get data from the database into textboxes
        public void get_admincred()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {


                    SqlCommand command =
                    new SqlCommand("select * from db_admin where Role='" + label27.Text + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        txtentry.Text = (read["Entry_no"].ToString());
                        txtUsername.Text = (read["Username"].ToString());
                       
                        txtPass.Text = (read["Password"].ToString());
                        

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
        //update admin cred
        public void Admin_updatecred()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);

                connection.Open();


                string sqlquery = ("Update db_admin set Username=@Usernamee,Password=@Passwordd where Entry_no=@Entry_noo");
                SqlCommand command = new SqlCommand(sqlquery, connection);
                command.Parameters.AddWithValue("@Entry_noo", txtentry.Text);
                command.Parameters.AddWithValue("@Usernamee", txtUsername.Text);
                command.Parameters.AddWithValue("@Passwordd", txtPass.Text);
                
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
            if (label30.Text == "Admin")
            {
                Admin_updatecred();
            }
            else
            {
                updatecred();
            }
           
        }

        ///for matching the password.If the password in both textboxes matches the label will show "MATCH" otherwise Not Match
        private void txtPassAgain_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtPass.Text == txtPassAgain.Text)
                {
                    label12.Visible = true;
                    label12.Text = "Match";
                    label12.ForeColor = Color.Green;
                }
                else
                {
                    label12.Visible = true;
                    label12.Text = "Not match";
                    label2.ForeColor = Color.Red;
                }
            }
        }
        //to add new records.All the texboxes will empty on clicking add new button
        private void btnadd_Click(object sender, EventArgs e)
        {
           
        
        }

     
        private void btnsave_Click(object sender, EventArgs e)
        {
           
        }
        // function to deduct the expenses from income
        public void your_balance()
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        //populate the textboxes from grid to textboxes
        private void GetInEx_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {
           
            }

        private void button4_Click(object sender, EventArgs e)
        {
            

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label30.Text="Admin";
            label8.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label6.Visible = false;
            txtName.Visible = false;
            CmboGender.Visible = false;
            txtContact.Visible = false;
            txtEmail.Visible = false;
            get_admincred();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label30.Text = "User";
            label8.Visible = true;
            label5.Visible = true;
            label9.Visible = true;
            label6.Visible = true;
            txtName.Visible = true;
            CmboGender.Visible = true;
            txtContact.Visible = true;
            txtEmail.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtentry.Text = row.Cells["Entry_no"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                CmboGender.Text = row.Cells["Gender"].Value.ToString();
                txtContact.Text = row.Cells["Contact_no"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                tabControl1.SelectedTab = tabPage4;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to delete the selected row
            try
            {
                var ObjConnection = new SqlConnection();
                int i;
                ObjConnection.ConnectionString = cs;
                var ObjCommand = new SqlCommand();
                ObjCommand.Connection = ObjConnection;
                for (i = this.dataGridView1.SelectedRows.Count - 1; i >= 0; i -= 1)
                {
                    ObjCommand.CommandText = "delete from db_auth where Entry_no='" + dataGridView1.SelectedRows[i].Cells["Entry_no"].Value + "'";
                    ObjConnection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjConnection.Close();
                    this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed:Deleting Selected Values" + ex.Message);
                this.Dispose();
            }
            //refreshh.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string str;
            try
            {
                var con = new SqlConnection(cs);
                con.Open();
                str = "Select * from db_auth where Name like '" + txt_useName_Search.Text + "%'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "db_auth");
                con.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "db_auth";
                dataGridView1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed: Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            
            Mie.Show();
        }
    }
    
}
