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
    public partial class RecurringFrm : Form
    {

        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();

        public static string SetValueForaddrecurring = "";
      

        //Database Connection String
        String cs = "Data Source=XENO;Initial Catalog=db_selfFinace;Integrated Security=True";
        public RecurringFrm()
        {
            InitializeComponent();
        }
        //insert the values of rcurrincome and rcurrexpenses in database
        public void insert_Recuring_incomeexpenses()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();

                string Usernamee = lbl_user.Text;
                string Name = lbl_name.Text;
                string Des = txt_des.Text;
                string Contact = txt_contacts.Text;
                string amnt = txt_amnt.Text;
               string Recurring_Date = recurring_date.Text;
                string Recurring_Interval = recurring_txt.Text;
                string Record_update = label19.Text;

               string Entry_Date = txt_date.Text;
               string Date_of_entry = txt_date.Text;
               // DateTime Recurring_Date = recurring_date.Value.Date;
               // DateTime Entry_Date = txt_date.Value.Date;
                if (rbtn_income.Checked)
                {
                    double addd;
                    addd = double.Parse(txt_amnt.Text) + double.Parse(lbl_balnce.Text);
                    lbl_balnce.Text = Convert.ToString(addd);

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Date_of_Entry,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + recurring_date.Text + "','" + recurring_txt.Text + "','" + label19.Text + "','" + txt_date.Text + "','" + txt_date.Text + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Income", amnt);
                    command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Record_update);
                    command.Parameters.AddWithValue("Date_of_Entry", Date_of_entry);
                    command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    label7.Text = "Recurring Income added Successfully";
                    label7.ForeColor = System.Drawing.Color.DarkGreen;
                    MessageBox.Show("Recurring Income Successfully");
                }
                else
                {
                    double subtrct;
                    subtrct = Math.Abs(double.Parse(txt_amnt.Text) - (double.Parse(lbl_balnce.Text)));
                    lbl_balnce.Text = Convert.ToString(subtrct);
                    subtrct = Math.Abs(subtrct);
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Date_of_Entry,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + recurring_date.Value.Date + "','" + recurring_txt.Text + "','" + label19.Text + "','" + txt_date.Text + "','" + txt_date.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", amnt);
                    command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Record_update);
                    command.Parameters.AddWithValue("Date_of_Entry", Date_of_entry);
                    command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label7.Text = "Recurring Expenses added Successfully";
                    MessageBox.Show("Recurring Expenses Successfully");
                    label7.ForeColor = System.Drawing.Color.DarkGreen;
                }

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }
      // to insert the today record
        //insert the values of rcurrincome and rcurrexpenses in database
        public void insert_todayRecuring_incomeexpenses()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();

                string Usernamee = lbl_user.Text;
                string Name = lbl_name.Text;
                string Des = txt_des.Text;
                string Contact = txt_contacts.Text;
                string amnt = txt_amnt.Text;
                string Recurring_Date = txt_date.Text;
                string Recurring_Interval = recurring_txt.Text;
                string Record_update = label9.Text;

                string Entry_Date = txt_date.Text;
                string Date_of_entry = txt_date.Text;
              
                if (rbtn_income.Checked)
                {
                    double addd;
                    addd = double.Parse(txt_amnt.Text) + double.Parse(lbl_balnce.Text);
                    lbl_balnce.Text = Convert.ToString(addd);

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Date_of_Entry,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + txt_date.Text + "','" + recurring_txt.Text + "','" + label9.Text + "','" + txt_date.Text + "','" + txt_date.Text + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Income", amnt);
                    command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Record_update);
                    command.Parameters.AddWithValue("Date_of_Entry", Date_of_entry);
                    command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    label7.Text = "Recurring Income added Successfully";
                    label7.ForeColor = System.Drawing.Color.DarkGreen;
                  
                }
                else
                {
                    double subtrct;
                    subtrct = Math.Abs(double.Parse(txt_amnt.Text) - (double.Parse(lbl_balnce.Text)));
                    lbl_balnce.Text = Convert.ToString(subtrct);
                    subtrct = Math.Abs(subtrct);
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Date_of_Entry,Entry_Date)values('" + lbl_user.Text + "','" + lbl_name.Text + "','" + txt_des.Text + "','" + txt_contacts.Text + "','" + txt_amnt.Text + "','" + txt_date.Text + "','" + recurring_txt.Text + "','" + label9.Text + "','" + txt_date.Text + "','" + txt_date.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", amnt);
                    command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Record_update);
                    command.Parameters.AddWithValue("Date_of_Entry", Date_of_entry);
                    command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label7.Text = "Recurring Expenses added Successfully";
                    label7.ForeColor = System.Drawing.Color.DarkGreen;
                    
                }

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }
      
        private void RecurringFrm_Load(object sender, EventArgs e)
        {
          
           
            label13.Text = Manage_income_expensesFrm.SetValueForedit;
            lbl_user.Text = loginFrm.SetValueForText1;
            label14.Text = loginFrm.SetValueForText1;
            if (label13.Text == "editrecurring_frommanage")
            {
               
                get_contactforEdit();
               // label13.Text = "statusediting";
            }
            else
            {


                recurring_date.Value = DateTime.Today;
                txt_date.Value = DateTime.Today;
                get_name();
 
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
        private void button2_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(this.recurring_txt.Text) || string.IsNullOrWhiteSpace(this.recurring_txt.Text))
            {
                MessageBox.Show("Please enter Interval");

            }
            else
            {
                insert_todayRecuring_incomeexpenses();

                insert_Recuring_incomeexpenses();
            }
        }
        // add the date depending on interval
        public void change_interval_for_rcurring()
        {
            if (recurring_txt.Text == "Every day")
            {


                // DateTime dt = DateTime.Now;  //it will add for today date, not user defined
                DateTime dt = txt_date.Value;    //it will select the chosen date in datetimepicker
                recurring_date.Value = dt.AddDays(1); //add the days to the date which the user choose
                // dateTimePicker1.Value = dt.ToString();  //send the date to label
            }
            else if (recurring_txt.Text == "Every week")
            {
               
               
                DateTime dt = txt_date.Value;    
                recurring_date.Value = dt.AddDays(7);  //add 7 days to the selected date
               
            }
             else if (recurring_txt.Text == "Every 2 weeks")
            {
                
              
                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddDays(14);  //add 14 days to the selected date
                
            }
             else if (recurring_txt.Text == "Every 3 weeks")
            {
              
               
                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddDays(21); //add 21 days to the selected date
               
            }
              else if (recurring_txt.Text == "Every 4 weeks")
            {
              
               
                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddDays(28); //add 28 days to the selected date
               
            }
             else if (recurring_txt.Text == "Every 3 Months") 
            {


                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddMonths(3); //add 3 months to the selected date
               

            }
            else if (recurring_txt.Text == "Every 6 Months")
            {

                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddMonths(6); //add 6 months to the selected date
               

            }
            else if (recurring_txt.Text == "Every Month")
            {

                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddMonths(1); //add 1 months to the selected date
                

            }
            else if (recurring_txt.Text == "Every year")
            {
                DateTime dt = txt_date.Value;
                recurring_date.Value = dt.AddYears(1); //add 1 year to the selected date
              
            }
            else
            {
                DateTime dt = DateTime.Now;
                recurring_date.Value = dt;
            }
        
        }
        private void recurring_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_interval_for_rcurring();

        }

        private void txt_date_ValueChanged(object sender, EventArgs e)
        {
            change_interval_for_rcurring();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            this.Hide();
            this.Dispose();
            Mie.Show();
        }
        // update the record
        public void expense_edit()
        {
            

            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "Update db_incomeexpenses Set Description='" + txt_des.Text + "',Name_or_source='" + txt_contacts.Text + "',Recurring_Expense='" + txt_amnt.Text + "' ,Recurring_Date='" + recurring_date.Value + "',Recurring_Interval='" + recurring_txt.Text + "',Record_update='" + label9.Text + "',Entry_Date='" + txt_date.Value + "' where Entry_no='" + label11.Text + "'";
            cmd.ExecuteNonQuery();
            //getincome_Grid.Rows.Remove(getincome_Grid.CurrentRow);
            MessageBox.Show("Data Updated");
            con.Close();
            

          
        }
        public void income_edit()
        {
           

            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "Update  db_incomeexpenses Set Description='" + txt_des.Text + "',Name_or_source='" + txt_contacts.Text + "',Recurring_Income='" + txt_amnt.Text + "' ,Recurring_Date='" + recurring_date.Value + "',Recurring_Interval='" + recurring_txt.Text + "',Record_update='" + label9.Text + "',Entry_Date='" + txt_date.Value + "' where Entry_no='" + label11.Text + "'";
            cmd.ExecuteNonQuery();
            //getincome_Grid.Rows.Remove(getincome_Grid.CurrentRow);
            MessageBox.Show("Data Updated");
            con.Close();
            


        }
        //get the entry date and  recurring date for update
        public void get_contactforEdit()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT Username,Entry_Date,Recurring_Date FROM db_incomeexpenses where Entry_no='" + label11.Text + "'", connection);
                    connection.Open();
                   cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        txt_date.Text = (read["Entry_Date"].ToString());
                        recurring_date.Text = (read["Recurring_Date"].ToString());
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
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.recurring_txt.Text) || string.IsNullOrWhiteSpace(this.recurring_txt.Text))
            
              {
                MessageBox.Show("Please enter Interval");
               
            }
            else
            {
                if (rbtn_income.Visible == true)
                {

                    income_edit();
                    insert_Recuring_incomeexpenses();
                }
                else
                {
                    expense_edit();
                    insert_Recuring_incomeexpenses();
                }
            }
           
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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
        private void edit_INEXP_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_contacts.Text = this.edit_INEXP_Grid.CurrentRow.Cells[0].Value.ToString();
            edit_INEXP_Grid.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
        }

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

        private void label15_Click_1(object sender, EventArgs e)
        {
            edit_INEXP_Grid.Visible = true;
            panel2.Visible = false;
            panel3.Visible = true;
            getdata_contacts();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }
        
    }
}
