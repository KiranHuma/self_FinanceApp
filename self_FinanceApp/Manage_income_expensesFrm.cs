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
    public partial class Manage_income_expensesFrm : Form
    {


        //Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        public static string SetValueForText3 = "";


        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public Manage_income_expensesFrm()
        {
            InitializeComponent();
        }

        private void Manage_income_expensesFrm_Load(object sender, EventArgs e)
        {
           
            userid.Text = loginFrm.SetValueForText1;
            txt_blncdate.Text = DateTime.Now.ToString("MMM-dd");
            label9.Text = DateTime.Now.ToString("MM-dd-yyyy");
            today_datee.Text = DateTime.Now.ToString("dd-MM-yyyy");
            get_income();
            get_expenses();
            get_incomesum();
            getdata_income();
            getdata_expenses();
            ///for recurring

            update_prev_record();
            ////Every day function call START/////
            Everyday_getRecuring_incomedate();
            Everyday_getRecuring_expensedate();
            update_status_for_everyday();
            insert_recurringincomeexpenses();
            ////Every day function call END/////

            ////Every week function call START/////
            Everyweek_getRecuring_expensedate();
            Everyweek_getRecuring_incomedate();
            update_status_for_everyweek();
            insert_week_recurringincomeexpenses();
            ////Every week function call END/////

            ////Every 2 week function call START/////
            Every_two_week_getRecuring_incomedate();
            Everyweek_two_getRecuring_expensedate();
            update_status_for_everyweek_two();
            insert_two_week_recurringincomeexpenses();
            ////Every2  week function call END/////
        }


        // get the data of User in grid
        public void getdata_income()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Income,Entry_Date from db_incomeexpenses where Income IS NOT NULL AND Entry_Date='" + label9.Text + "' AND Username='" + userid.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    getincome_Grid.DataSource = dt;
                    getincome_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        // get the data of User in grid
        public void getdata_expenses()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Expense,Entry_Date from db_incomeexpenses where Expense IS NOT NULL AND Entry_Date='" + label9.Text + "' AND Username='" + userid.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    getexpense_Grid.DataSource = dt;
                    getexpense_Grid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        //get sum of income
        public void get_income()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income) as incomeamount FROM db_incomeexpenses where Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label7.Text = (read["incomeamount"].ToString());

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
        //get sum of expenses
        public void get_expenses()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Expense) as expensesamount FROM db_incomeexpenses where Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label8.Text = (read["expensesamount"].ToString());

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
        //get sum of income and function for calculating the total balance
        public void get_incomesum()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income)-SUM(Expense) as incomeamount FROM db_incomeexpenses where Username='" + userid.Text + "'  AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label3.Text = (read["incomeamount"].ToString());

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

      
        private void button1_Click(object sender, EventArgs e)
        {
            btn_addincome_expense.Visible = true;
            getexpense_Grid.Visible = false;
            getincome_Grid.Visible = false;
            lbl_income.Visible = true;
            btn_recurring.Visible = true;
            lbl_recurr.Visible = true;
        }

        private void btn_addincome_expense_Click(object sender, EventArgs e)
        {
            Add_IncomeExpense addIE = new Add_IncomeExpense();
            this.Hide();
            addIE.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label9.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            getdata_income();
            getdata_expenses();
        }

        private void getincome_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
            }
      // if(Label9.Text=)
      
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Incomeexpense_editFrm obj = new Incomeexpense_editFrm();
            obj.label1.Text = this.getincome_Grid.CurrentRow.Cells[0].Value.ToString();
            obj.txt_des.Text = this.getincome_Grid.CurrentRow.Cells[1].Value.ToString();
           
            obj.txt_amnt.Text = this.getincome_Grid.CurrentRow.Cells[2].Value.ToString();
            obj.txt_date.Text = this.getincome_Grid.CurrentRow.Cells[3].Value.ToString();
           obj.rbtn_income.Visible = true;
            this.Hide();
            obj.ShowDialog();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            //to delete the selected row
            try
            {
                var ObjConnection = new SqlConnection();
                int i;
               
               
               

                ObjConnection.ConnectionString = cs;
                var ObjCommand = new SqlCommand();
                ObjCommand.Connection = ObjConnection;
                for (i = this.getincome_Grid.SelectedRows.Count - 1; i >= 0; i -= 1)
                {
                    ObjCommand.CommandText = "delete from db_incomeexpenses where Entry_no='" + getincome_Grid.SelectedRows[i].Cells["Entry_no"].Value + "'";
                    ObjConnection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjConnection.Close();
                    this.getincome_Grid.Rows.Remove(this.getincome_Grid.SelectedRows[i]);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed:Deleting Selected Values" + ex.Message);
                this.Dispose();
            }
           
        
        }

        private void getexpense_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Incomeexpense_editFrm obj = new Incomeexpense_editFrm();
            obj.label1.Text = this.getexpense_Grid.CurrentRow.Cells[0].Value.ToString();
            obj.txt_des.Text = this.getexpense_Grid.CurrentRow.Cells[1].Value.ToString();
            obj.txt_amnt.Text = this.getexpense_Grid.CurrentRow.Cells[2].Value.ToString();
            obj.txt_date.Text = this.getexpense_Grid.CurrentRow.Cells[3].Value.ToString();
            obj.radiobtn_expense.Visible = true;
            this.Hide();
            obj.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var ObjConnection = new SqlConnection();
                int i;
                ObjConnection.ConnectionString = cs;
                var ObjCommand = new SqlCommand();
                ObjCommand.Connection = ObjConnection;
                for (i = this.getexpense_Grid.SelectedRows.Count - 1; i >= 0; i -= 1)
                {
                    ObjCommand.CommandText = "delete from db_incomeexpenses where Entry_no='" + getexpense_Grid.SelectedRows[i].Cells["Entry_no"].Value + "'";
                    ObjConnection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ObjConnection.Close();
                    this.getexpense_Grid.Rows.Remove(this.getexpense_Grid.SelectedRows[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed:Deleting Selected Values" + ex.Message);
                this.Dispose();
            }
        }

        private void getincome_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void getexpense_Grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            Manage_contacts MC = new Manage_contacts();
            this.Hide();
            MC.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SetValueForText3 = userid.Text;
            SummaryFrm MC = new SummaryFrm();
            this.Hide();
            MC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            incomeexpenseReportForm ud = new incomeexpenseReportForm();
            ud.Show();
        }


        ////////////////////for Recurring
        public void Everyday_incomeadd()
        {
           
            string a = Recurring_interval.Text;
            int addrec = Convert.ToInt32(label18.Text);
            string b = label18.Text;
            if (a=="Every day" & addrec >= 1)
            {
                double recurincome;
                recurincome = double.Parse(recurring_income.Text) + double.Parse(label3.Text);
                label3.Text = Convert.ToString(recurincome);
                
            }
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||Start RECURRING||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        //////////////////////////////////////////////////////////////////recurring everday///////////////////////////////////////////////////////////////

        //get the recurring everday details
        public void Everyday_getRecuring_incomedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where  Recurring_Income IS NOT NULL AND Recurring_Interval ='Every day' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();
                        
                        while (read.Read())
                        {
                            label24.Text = (read["Entry_no"].ToString());
                            userid.Text = (read["Username"].ToString());
                            namee.Text = (read["Name"].ToString());
                            descr.Text = (read["Description"].ToString());
                            sourcee.Text = (read["Name_or_source"].ToString());
                            recurring_income.Text = (read["Recurring_Income"].ToString());
                            recurring_date.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            Recurring_interval.Text = (read["Recurring_Interval"].ToString());
                            Record_Stauts.Text = (read["Record_update"].ToString());
                            entry_date.Text = (read["Entry_Date"].ToString());
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
        }
        public void Everyday_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        //DateTime dfrom = DateTime.Now;
                        // DateTime dto = dateTimePicker2.Value;
                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every day' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            label30.Text = (read["Entry_no"].ToString());
                            userid.Text = (read["Username"].ToString());
                            namee.Text = (read["Name"].ToString());
                            descr.Text = (read["Description"].ToString());
                            sourcee.Text = (read["Name_or_source"].ToString());
                            recuring_expenses.Text = (read["Recurring_Expense"].ToString());
                            recurring_date.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            Recurring_interval.Text = (read["Recurring_Interval"].ToString());
                            Record_Stauts.Text = (read["Record_update"].ToString());
                            entry_date.Text = (read["Entry_Date"].ToString());
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
        }
        //after the recurring income or expenses there is a need a query to insert next recurr record.so below code is for that
        //insert the values of income and expenses in database
        public void insert_recurringincomeexpenses()
        {
            try
            {
                //Record_Stauts.Text = "Not Updated";
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string Usernamee = userid.Text;
                string Name = namee.Text;
                string Des = descr.Text;
                string Contact = sourcee.Text;
                //string amnt = txt_amnt.Text;
                string recuringincome = recurring_income.Text;
                string recuringexpense = recuring_expenses.Text;

                // string Recurring_Date = dateTimePicker1.Text;
                string Recurring_Interval = Recurring_interval.Text;
                string Record_update = Record_Stauts.Text;

                //string Entry_Date = txt_date.Text;
              
                DateTime Recurring_Date = for_recuringinsert.Value.Date;
                DateTime Entry_Date = dateTimePicker1.Value.Date;
                if (recurring_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + userid.Text + "','" + namee.Text + "','" + descr.Text + "','" + sourcee.Text + "','" + recurring_income.Text + "','" + for_recuringinsert.Value.Date + "','" + Recurring_interval.Text + "','" + Record_Stauts.Text + "','" + dateTimePicker1.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Usernamee);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Description", Des);
                    command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Income", recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
              if (recuring_expenses.Text != "Expenses")
               {
                   string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + userid.Text + "','" + namee.Text + "','" + descr.Text + "','" + sourcee.Text + "','" + recuring_expenses.Text + "','" + for_recuringinsert.Value.Date + "','" + Recurring_interval.Text + "','" + Record_Stauts.Text + "','" + dateTimePicker1.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                  command.Parameters.AddWithValue("Username", Usernamee);
                  command.Parameters.AddWithValue("Name", Name);
                  command.Parameters.AddWithValue("Description", Des);
                  command.Parameters.AddWithValue("Name_or_source", Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", recuringexpense);
                  command.Parameters.AddWithValue("Recurring_Date", Recurring_Date);
                   command.Parameters.AddWithValue("Recurring_Interval", Recurring_Interval);
                   command.Parameters.AddWithValue("Record_update", Record_update);
                  command.Parameters.AddWithValue("Entry_Date", Entry_Date);
                   command.ExecuteNonQuery();
                    // radiobtn_expense.Text = "Expense";
                   label21.Text = "Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;
                }
             // update_status();

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }

        public void update_status_for_everyday()
        {
            
            if (recurring_income.Text != "Income")
            {
               
                if (recurring_date.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + label24.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

            if (recuring_expenses.Text != "Expenses")
            {
                if (recurring_date.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + label30.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //////////////////////////////////////////////////////////////////End recurring everday///////////////////////////////////////////////////////////////
        //****************************************************************************************************///
        //////////////////////////////////////////////////////////////////start recurring everyweek///////////////////////////////////////////////////////////////
        
        //get the recurringincome everdweek details
        public void Everyweek_getRecuring_incomedate()
        {
           
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every week' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            everyweek_entry.Text = (read["Entry_no"].ToString());//diff

                            everyweek_username.Text = (read["Username"].ToString());
                            everyweek_name.Text = (read["Name"].ToString());
                            every_week_description.Text = (read["Description"].ToString());
                            everyweek_source.Text = (read["Name_or_source"].ToString());

                            everyweek_income.Text = (read["Recurring_Income"].ToString());  //diff

                            everyweek_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            everyweek_interval.Text = (read["Recurring_Interval"].ToString());
                            everyweek_record.Text = (read["Record_update"].ToString());
                            everyweek_entrydate.Text = (read["Entry_Date"].ToString());


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
        }
        //get everyweek expense details
        public void Everyweek_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        //DateTime dfrom = DateTime.Now;
                        // DateTime dto = dateTimePicker2.Value;
                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every week' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_expense_week_entrynumbr.Text = (read["Entry_no"].ToString());//diff

                            everyweek_username.Text = (read["Username"].ToString());
                            everyweek_name.Text = (read["Name"].ToString());
                            every_week_description.Text = (read["Description"].ToString());
                            everyweek_source.Text = (read["Name_or_source"].ToString());

                            everyweek_expense.Text = (read["Recurring_Expense"].ToString()); //diff

                            everyweek_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            everyweek_interval.Text = (read["Recurring_Interval"].ToString());
                            everyweek_record.Text = (read["Record_update"].ToString());
                            everyweek_entrydate.Text = (read["Entry_Date"].ToString());
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
        }
        public void update_status_for_everyweek()
        {
            if (everyweek_income.Text != "Income")
            {
                if (everyweek_recDate.Text == today_datee.Text )
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + everyweek_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (everyweek_expense.Text != "Expenses")
            {
                if (everyweek_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + every_expense_week_entrynumbr.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of week recurrincome and expenses in database
        public void insert_week_recurringincomeexpenses()
        {
            try
            {
               
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string week_Usernamee = everyweek_username.Text;
                string week_Name = everyweek_name.Text;
                string week_Des = every_week_description.Text;
                string week_Contact = everyweek_source.Text;
                string week_recuringincome = everyweek_income.Text;
                string week_recuringexpense = everyweek_expense.Text;
                DateTime week_Recurring_Date = for_week_recurring.Value.Date;
                string week_Recurring_Interval = everyweek_interval.Text;
                string week_Record_update = everyweek_record.Text;

                DateTime week_Entry_Date = dateTimePicker2.Value.Date;
                if (everyweek_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + everyweek_username.Text + "','" + everyweek_name.Text + "','" + every_week_description.Text + "','" + everyweek_source.Text + "','" + everyweek_income.Text + "','" + for_week_recurring.Value.Date + "','" + everyweek_interval.Text + "','" + everyweek_record.Text + "','" + dateTimePicker2.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", week_Usernamee);
                    command.Parameters.AddWithValue("Name", week_Name);
                    command.Parameters.AddWithValue("Description", week_Des);
                    command.Parameters.AddWithValue("Name_or_source", week_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", week_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", week_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", week_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (everyweek_expense.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + everyweek_username.Text + "','" + everyweek_name.Text + "','" + every_week_description.Text + "','" + everyweek_source.Text + "','" + everyweek_expense.Text + "','" + for_week_recurring.Value.Date + "','" + everyweek_interval.Text + "','" + everyweek_record.Text + "','" + dateTimePicker2.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", week_Usernamee);
                    command.Parameters.AddWithValue("Name", week_Name);
                    command.Parameters.AddWithValue("Description", week_Des);
                    command.Parameters.AddWithValue("Name_or_source", week_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", week_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", week_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", week_Entry_Date);
                    command.ExecuteNonQuery();
                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;
                }
                // update_status();

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }

        //////////////////////////////////////////////////////////////////End recurring everyweek/////////////////////////////////////////////////////////////// 
                                  //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////start recurring Every 2 weeks///////////////////////////////////////////////////////////////

        //get the recurringincome everdweek details
        public void Every_two_week_getRecuring_incomedate()
        {

            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every 2 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_two_week_entry.Text = (read["Entry_no"].ToString());//diff

                            every_two_week_username.Text = (read["Username"].ToString());
                            every_two_week_name.Text = (read["Name"].ToString());
                            every_two_week_description.Text = (read["Description"].ToString());
                            every_two_week_source.Text = (read["Name_or_source"].ToString());

                            every_two_week_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_two_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_two_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_two_week_record.Text = (read["Record_update"].ToString());
                            every_two_week_entrydate.Text = (read["Entry_Date"].ToString());


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
        }
        //get everyweek expense details
        public void Everyweek_two_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        //DateTime dfrom = DateTime.Now;
                        // DateTime dto = dateTimePicker2.Value;
                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every 2 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            expense_two_week_entrynumbr.Text = (read["Entry_no"].ToString());//diff

                            every_two_week_username.Text = (read["Username"].ToString());
                            every_two_week_name.Text = (read["Name"].ToString());
                            every_two_week_description.Text = (read["Description"].ToString());
                            every_two_week_source.Text = (read["Name_or_source"].ToString());

                            everyweek_two_expenses.Text = (read["Recurring_Expense"].ToString());//diff

                            every_two_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_two_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_two_week_record.Text = (read["Record_update"].ToString());
                            every_two_week_entrydate.Text = (read["Entry_Date"].ToString());
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
        }
        public void update_status_for_everyweek_two()
        {
            if (every_two_week_income.Text != "Income")
            {
                if (every_two_week_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_two_week_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (everyweek_two_expenses.Text != "Expenses")
            {
                if (every_two_week_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + expense_two_week_entrynumbr.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of week recurrincome and expenses in database
        public void insert_two_week_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string two_week_Usernamee = every_two_week_username.Text;
                string two_week_Name = every_two_week_name.Text;
                string two_week_Des = every_two_week_description.Text;
                string two_week_Contact = every_two_week_source.Text;
                string two_week_recuringincome = every_two_week_income.Text;
                string two_week_recuringexpense = everyweek_two_expenses.Text;
                DateTime two_week_Recurring_Date = for_two_week_recurring.Value.Date;
                string two_week_Recurring_Interval = every_two_week_interval.Text;
                string two_week_Record_update = every_two_week_record.Text;

                DateTime two_week_Entry_Date = dateTimePicker3.Value.Date;
                if (every_two_week_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_two_week_username.Text + "','" + every_two_week_name.Text + "','" + every_two_week_description.Text + "','" + every_two_week_source.Text + "','" + every_two_week_income.Text + "','" + for_two_week_recurring.Value.Date + "','" + every_two_week_interval.Text + "','" + every_two_week_record.Text + "','" + dateTimePicker3.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", two_week_Usernamee);
                    command.Parameters.AddWithValue("Name", two_week_Name);
                    command.Parameters.AddWithValue("Description", two_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", two_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", two_week_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", two_week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", two_week_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", two_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", two_week_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (everyweek_two_expenses.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_two_week_username.Text + "','" + every_two_week_name.Text + "','" + every_two_week_description.Text + "','" + every_two_week_source.Text + "','" + everyweek_two_expenses.Text + "','" + for_two_week_recurring.Value.Date + "','" + every_two_week_interval.Text + "','" + every_two_week_record.Text + "','" + dateTimePicker3.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", two_week_Usernamee);
                    command.Parameters.AddWithValue("Name", two_week_Name);
                    command.Parameters.AddWithValue("Description", two_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", two_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", two_week_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", two_week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", two_week_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", two_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", two_week_Entry_Date);
                    command.ExecuteNonQuery();
                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Expenses added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;
                }
                // update_status();

            }
            catch (Exception ex)
            {
                label7.Text = "Data not added Successfully";
                MessageBox.Show(ex.Message);

            }
        }

        //////////////////////////////////////////////////////////////////End recurring every 2 week/////////////////////////////////////////////////////////////// 
        
        
        //////////////////////********update the all records befor today date//////////////////////////
        public void update_prev_record()
        {
            // Query string
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Record_update='Not Updated' AND Recurring_Date < '" + dateTimePicker1.Value + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /////******************************for adding next recurrsion record**************************************////
        public void change_interval_for_rcurring()
        {
            if (Recurring_interval.Text == "Every day")
            {


                // DateTime dt = DateTime.Now;  //it will add for today date, not user defined
                DateTime dt = dateTimePicker1.Value;    //it will select the chosen date in datetimepicker
                for_recuringinsert.Value = dt.AddDays(1); //add the days to the date which the user choose
                // dateTimePicker1.Value = dt.ToString();  //send the date to label
            }
            else if (everyweek_interval.Text == "Every week")
            {


                DateTime dt = dateTimePicker2.Value;
                for_week_recurring.Value = dt.AddDays(7);  //add 7 days to the selected date

            }
            else if (every_two_week_interval.Text == "Every 2 weeks")
            {


                DateTime dt = dateTimePicker3.Value;
                for_two_week_recurring.Value = dt.AddDays(14);  //add 14 days to the selected date

            }
            else if (Recurring_interval.Text == "Every 3 weeks")
            {


                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddDays(21); //add 21 days to the selected date

            }
            else if (Recurring_interval.Text == "Every 4 weeks")
            {


                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddDays(28); //add 28 days to the selected date

            }
            else if (Recurring_interval.Text == "Every 3 Months")
            {


                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddMonths(3); //add 3 months to the selected date


            }
            else if (Recurring_interval.Text == "Every 6 Months")
            {

                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddMonths(6); //add 6 months to the selected date


            }
            else if (Recurring_interval.Text == "Every Month")
            {

                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddMonths(1); //add 1 months to the selected date


            }
            else if (Recurring_interval.Text == "Every year")
            {
                DateTime dt = dateTimePicker1.Value;
                for_recuringinsert.Value = dt.AddYears(1); //add 1 year to the selected date

            }
            else
            {
                DateTime dt = DateTime.Now;
                for_recuringinsert.Value = dt;
            }

        }
        
    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||END RECURRING||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
   
        
        private void button4_Click(object sender, EventArgs e)
        {
            userdetailsFrm ud = new userdetailsFrm();
            ud.Show();
        }

        private void btn_recurring_Click(object sender, EventArgs e)
        {
            RecurringFrm rc= new RecurringFrm();
            rc.Show();
        }
//add the value on specific date
        public void add_rcurr_income()
        {
            
            if (recurring_income.Text !="Income")
            {
              if (recurring_date.Text == today_datee.Text )
            {

               get_blancee();
                  double recurincome;
                recurincome = double.Parse(recurring_income.Text) + double.Parse(label3.Text);
                label3.Text = Convert.ToString(recurincome);
                
               update_status_for_everyday();
                
            } 
              else{
              if (recuring_expenses.Text != "Expenses")
              {
                  if (recurring_date.Text == today_datee.Text)
                  {
                      double recurexpense;
                      recurexpense = double.Parse(recuring_expenses.Text) - double.Parse(label3.Text);
                      label3.Text = Convert.ToString(recurexpense);
                      update_status_for_everyday();
                  } 
              }
                }
            } 
        }
        private void button5_Click(object sender, EventArgs e)
        {
          // add_rcurr_income();
           // Everyday_getRecuring_incomedate();
            get_blancee();
        }
        //update the balnce
       
        public void update_blnce()
        {
            

            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update db_auth Set Your_Balance='" + label3.Text + "' where Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            
           
            
            con.Close();
           


        }

        public void get_blancee()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        //DateTime dfrom = DateTime.Now;
                        // DateTime dto = dateTimePicker2.Value;

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_auth where  Username='" + userid.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            label3.Text = (read["Your_Balance"].ToString());

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
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
       
        private void label3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void entry_date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    }

