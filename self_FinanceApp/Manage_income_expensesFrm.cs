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
            label18.Text = DateTime.Now.ToString("MMM-dd");
            label9.Text = DateTime.Now.ToString("MM-dd-yyyy");
            today_datee.Text = DateTime.Now.ToString("dd-MM-yyyy");
            get_income();
            get_expenses();
            get_incomesum();
            getdata_income();
            getdata_expenses();
            ///for recurring
            getdata_recurring_income();
            getdata_recurring_expense();
            get_recurringincomeSum();
            get_recurringexpensesSum();
            get_total_recursion();
            update_prev_record();
            ////Every day function call START/////
            Everyday_getRecuring_incomedate();  // get the today's date recuring income
            Everyday_getRecuring_expensedate(); // get the today's date recuring expense
            update_status_for_everyday();       //update the record of today
            insert_recurringincomeexpenses();   // insert the record for next recurrsion
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

             ////Every 3 week function call START/////
            Every_three_week_getRecuring_incomedate();
            Everyweek_three_getRecuring_expensedate();
            update_status_for_everyweek_three();
            insert_three_week_recurringincomeexpenses();     
              ////Every 3  week function call END/////

            ////Every 4 week function call START/////
            Every_four_week_getRecuring_incomedate();
            Everyweek_four_getRecuring_expensedate();
           // change_interval_for_rcurring();
            update_status_for_everyweek_four();
            insert_four_week_recurringincomeexpenses();
            ////Every 4  week function call END/////

            ////Every month function call START/////
            Every_Month_getRecuring_incomedate();
            Every_Month_getRecuring_expensedate();
            update_status_for_every_Month();
           insert_every_Month_recurringincomeexpenses();
            ////Every month  week function call END/////

            ////Every 3 month function call START/////
           Every_3_Month_getRecuring_incomedate();
           Every_3_Month_getRecuring_expensedate();
           update_status_for_every_three_Month();
           insert_every_3_Month_recurringincomeexpenses();
            ////Every 3 month  week function call END/////

            ////Every 6 month function call START/////
             Every_6_Month_getRecuring_incomedate();
             Every_6_Month_getRecuring_expensedate();
            update_status_for_every_6_Month();
            insert_every_6_Month_recurringincomeexpenses();
            ////Every 6 month  week function call END/////

            ////Every year function call START/////
              Every_year_getRecuring_incomedate();
            Every_year_getRecuring_expensedate();
                update_status_for_every_year();
               insert_every_year_recurringincomeexpenses();

            ////Every year week function call END/////

            //update balance after all function
               update_blnce();
               get_total_balanc_with_recursion();
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
        
        // get the data of recurring income in grid
        public void getdata_recurring_income()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Recurring_Income,Recurring_Interval,Record_update,Recurring_Date,Entry_Date from db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Date='" + label9.Text + "' AND Username='" + userid.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    recurringINCOME_GRID.DataSource = dt;
                    recurringINCOME_GRID.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        public void getdata_recurring_expense()
        {
            {
                try
                {
                    var con = new SqlConnection(cs);
                    con.Open();
                    var da = new SqlDataAdapter("Select Entry_no,Description,Recurring_Expense,Recurring_Interval,Record_update,Recurring_Date,Entry_Date from db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Date='" + label9.Text + "' AND Username='" + userid.Text + "'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    source1.DataSource = dt;
                    recurringEXPENSE_GRID.DataSource = dt;
                    recurringEXPENSE_GRID.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed:Retrieving Data" + ex.Message);
                    this.Dispose();
                }
            }

        }
        public void get_recurringincomeSum()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Recurring_Income) as Recuringincome FROM db_incomeexpenses where Username='" + userid.Text + "' AND Record_update='Updated'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label13.Text = (read["Recuringincome"].ToString());

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
        //get sum of recurring expenses
        public void get_recurringexpensesSum()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Recurring_Expense) as Recurringexpenses FROM db_incomeexpenses where Username='" + userid.Text + "'AND Record_update='Updated'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label14.Text = (read["Recurringexpenses"].ToString());

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

        // get the data of expenses of user in grid
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
                    new SqlCommand("SELECT SUM(Income)-SUM(Expense) as incomeamount FROM db_incomeexpenses where  Username='" + userid.Text + "'", connection);
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
        // Total balance with recursion
        public void get_total_recursion()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT Sum(Recurring_Income)-SUM(Recurring_Expense) as sumincomeamount FROM db_incomeexpenses where Record_update='Updated' AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label27.Text = (read["sumincomeamount"].ToString());

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
        public void get_total_balanc_with_recursion()
        
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT (Your_Balance_with_Recursion+Your_Balnc_withou_Recurring) as incomeamount FROM db_auth where  Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label32.Text = (read["incomeamount"].ToString());

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
            recurringEXPENSE_GRID.Visible = false;
            recurringINCOME_GRID.Visible = true;
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
            getdata_recurring_income();
            getdata_recurring_expense();
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

                                  //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////start recurring Every 3 weeks///////////////////////////////////////////////////////////////

        //get the recurringincome every 3 week details
        public void Every_three_week_getRecuring_incomedate()
        {
             
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every 3 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_three_week_entry.Text = (read["Entry_no"].ToString());//diff

                            every_three_week_username.Text = (read["Username"].ToString());
                            every_three_week_name.Text = (read["Name"].ToString());
                            every_three_week_description.Text = (read["Description"].ToString());
                            every_three_week_source.Text = (read["Name_or_source"].ToString());

                            every_three_week_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_three_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_three_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_three_week_record.Text = (read["Record_update"].ToString());
                            every_three_week_entrydate.Text = (read["Entry_Date"].ToString());


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
      
        //get every 3 week expense details
        public void Everyweek_three_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        
                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every 3 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            three_week_entry_Expense.Text = (read["Entry_no"].ToString());//diff

                            every_three_week_username.Text = (read["Username"].ToString());
                            every_three_week_name.Text = (read["Name"].ToString());
                            every_three_week_description.Text = (read["Description"].ToString());
                            every_three_week_source.Text = (read["Name_or_source"].ToString());

                            every_three_week_expenses.Text = (read["Recurring_Expense"].ToString());//diff

                            every_three_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_three_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_three_week_record.Text = (read["Record_update"].ToString());
                            every_three_week_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_everyweek_three()
        {
            if (every_three_week_income.Text != "Income")
            {
                if (every_three_week_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_three_week_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (every_three_week_expenses.Text != "Expenses")
            {
                if (every_three_week_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + three_week_entry_Expense.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of week recurrincome and expenses in database
        public void insert_three_week_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string three_week_Usernamee = every_three_week_username.Text;
                string three_week_Name = every_three_week_name.Text;
                string three_week_Des = every_three_week_description.Text;
                string three_week_Contact = every_three_week_source.Text;
                string three_week_recuringincome = every_three_week_income.Text;
                string threeweek_recuringexpense = every_three_week_expenses.Text;
                DateTime three_week_Recurring_Date = for_three_week_recurring.Value.Date;
                string threeweek_Recurring_Interval = every_three_week_interval.Text;
                string three_week_Record_update = every_three_week_record.Text;

                DateTime three_week_Entry_Date = dateTimePicker4.Value.Date;
                if (every_three_week_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_three_week_username.Text + "','" + every_three_week_name.Text + "','" + every_three_week_description.Text + "','" + every_three_week_source.Text + "','" + every_three_week_income.Text + "','" + for_three_week_recurring.Value.Date + "','" + every_three_week_interval.Text + "','" + every_three_week_record.Text + "','" + dateTimePicker4.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", three_week_Usernamee);
                    command.Parameters.AddWithValue("Name", three_week_Name);
                    command.Parameters.AddWithValue("Description", three_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", three_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", three_week_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", three_week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", threeweek_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", three_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", three_week_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (every_three_week_expenses.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_three_week_username.Text + "','" + every_three_week_name.Text + "','" + every_three_week_description.Text + "','" + every_three_week_source.Text + "','" + every_three_week_expenses.Text + "','" + for_three_week_recurring.Value.Date + "','" + every_three_week_interval.Text + "','" + every_three_week_record.Text + "','" + dateTimePicker4.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", three_week_Usernamee);
                    command.Parameters.AddWithValue("Name", three_week_Name);
                    command.Parameters.AddWithValue("Description", three_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", three_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", threeweek_recuringexpense);//diff
                    command.Parameters.AddWithValue("Recurring_Date", three_week_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", threeweek_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", three_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", three_week_Entry_Date);
                    command.ExecuteNonQuery();
                  
                    label21.Text = "Recurring Expenses added Successfully";
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
        //////////////////////////////////////////////////////////////////End recurring every 3 week/////////////////////////////////////////////////////////////// 
                                  //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////Start recurring every 4 week/////////////////////////////////////////////////////////////// 
       
        
        //get the recurringincome every 4 week details
        public void Every_four_week_getRecuring_incomedate()
        {

            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every 4 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_four_week_entry.Text = (read["Entry_no"].ToString());//diff

                            every_four_week_username.Text = (read["Username"].ToString());
                            every_four_week_name.Text = (read["Name"].ToString());
                            every_four_week_description.Text = (read["Description"].ToString());
                            every_four_week_source.Text = (read["Name_or_source"].ToString());

                            every_four_week_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_four_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_four_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_four_week_record.Text = (read["Record_update"].ToString());
                            every_four_week_entrydate.Text = (read["Entry_Date"].ToString());


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

        //get every 4 week expense details
        public void Everyweek_four_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every 4 weeks' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            four_week_Expense_entry.Text = (read["Entry_no"].ToString());//diff

                            every_four_week_username.Text = (read["Username"].ToString());
                            every_four_week_name.Text = (read["Name"].ToString());
                            every_four_week_description.Text = (read["Description"].ToString());
                            every_four_week_source.Text = (read["Name_or_source"].ToString());

                            everyweek_four_expenses.Text = (read["Recurring_Expense"].ToString());//diff

                            every_four_week_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_four_week_interval.Text = (read["Recurring_Interval"].ToString());
                            every_four_week_record.Text = (read["Record_update"].ToString());
                            every_four_week_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_everyweek_four()
        {
            if (every_four_week_income.Text != "Income")
            {
                if (every_four_week_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_four_week_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (everyweek_four_expenses.Text != "Expenses")
            {
                if (every_four_week_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + four_week_Expense_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of week recurrincome and expenses in database
        public void insert_four_week_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string four_week_Usernamee = every_four_week_username.Text;
                string four_week_Name = every_four_week_name.Text;
                string four_week_Des = every_four_week_description.Text;
                string four_week_Contact = every_four_week_source.Text;
                string four_week_recuringincome = every_four_week_income.Text;
                string four_recuringexpense = everyweek_four_expenses.Text;
                DateTime fourweek_Recurring_Date = for_four_week_recurring.Value.Date;
                string four_Recurring_Interval = every_four_week_interval.Text;
                string four_week_Record_update = every_four_week_record.Text;

                DateTime four_week_Entry_Date = dateTimePicker5.Value.Date;
                if (every_four_week_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_four_week_username.Text + "','" + every_four_week_name.Text + "','" + every_four_week_description.Text + "','" + every_four_week_source.Text + "','" + every_four_week_income.Text + "','" + for_four_week_recurring.Value.Date + "','" + every_four_week_interval.Text + "','" + every_four_week_record.Text + "','" + dateTimePicker5.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", four_week_Usernamee);
                    command.Parameters.AddWithValue("Name", four_week_Name);
                    command.Parameters.AddWithValue("Description", four_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", four_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", four_week_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", fourweek_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", four_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", four_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", four_week_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (everyweek_four_expenses.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_four_week_username.Text + "','" + every_four_week_name.Text + "','" + every_four_week_description.Text + "','" + every_four_week_source.Text + "','" + everyweek_four_expenses.Text + "','" + for_four_week_recurring.Value.Date + "','" + every_four_week_interval.Text + "','" + every_four_week_record.Text + "','" + dateTimePicker5.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", four_week_Usernamee);
                    command.Parameters.AddWithValue("Name", four_week_Name);
                    command.Parameters.AddWithValue("Description", four_week_Des);
                    command.Parameters.AddWithValue("Name_or_source", four_week_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", four_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", fourweek_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", four_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", four_week_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", four_week_Entry_Date);
                    command.ExecuteNonQuery();

                    label21.Text = "Recurring Expenses added Successfully";
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

        //////////////////////////////////////////////////////////////////End recurring every 4 week/////////////////////////////////////////////////////////////// 
        //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////Start recurring every MONTH/////////////////////////////////////////////////////////////// 


        //get the recurringincome every Month details
        public void Every_Month_getRecuring_incomedate()
        {

            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every Month' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_month_entry.Text = (read["Entry_no"].ToString());//diff

                            every_month_username.Text = (read["Username"].ToString());
                            every_month_name.Text = (read["Name"].ToString());
                            every_month_description.Text = (read["Description"].ToString());
                            every_mnth_source.Text = (read["Name_or_source"].ToString());

                            every_month_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_month_record.Text = (read["Record_update"].ToString());
                            every_month_entrydate.Text = (read["Entry_Date"].ToString());


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

        //get every Month expense details
        public void Every_Month_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every Month' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_month_Entry_Expense.Text = (read["Entry_no"].ToString());//diff

                            every_month_username.Text = (read["Username"].ToString());
                            every_month_name.Text = (read["Name"].ToString());
                            every_month_description.Text = (read["Description"].ToString());
                            every_mnth_source.Text = (read["Name_or_source"].ToString());

                            month_expense.Text = (read["Recurring_Expense"].ToString());//diff

                            every_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_month_record.Text = (read["Record_update"].ToString());
                            every_month_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_every_Month()
        {
            if (every_month_income.Text != "Income")
            {
                if (every_month_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_month_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (month_expense.Text != "Expenses")
            {
                if (every_month_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + every_month_Entry_Expense.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of every Month recurrincome and expenses in database
        public void insert_every_Month_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string Every_Month_Usernamee = every_month_username.Text;
                string Every_Month_Name = every_month_name.Text;
                string Every_Month_Des = every_month_description.Text;
                string Every_Month_Contact = every_mnth_source.Text;
                string Every_Month_recuringincome = every_month_income.Text;
                string Every_Month_recuringexpense = month_expense.Text;
                DateTime Every_Month_Recurring_Date = for_month_recurring.Value.Date;
                string Every_Month_Recurring_Interval = every_month_interval.Text;
                string Every_Month_Record_update = every_month_record.Text;

                DateTime Every_Month_Entry_Date = dateTimePicker6.Value.Date;
                if (every_month_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_month_username.Text + "','" + every_month_name.Text + "','" + every_month_description.Text + "','" + every_mnth_source.Text + "','" + every_month_income.Text + "','" + for_month_recurring.Value.Date + "','" + every_month_interval.Text + "','" + every_month_record.Text + "','" + dateTimePicker6.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", Every_Month_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", Every_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_Month_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (month_expense.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_month_username.Text + "','" + every_month_name.Text + "','" + every_month_description.Text + "','" + every_mnth_source.Text + "','" + month_expense.Text + "','" + for_month_recurring.Value.Date + "','" + every_month_interval.Text + "','" + every_month_record.Text + "','" + dateTimePicker6.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", Every_Month_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", Every_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_Month_Entry_Date);
                    command.ExecuteNonQuery();

                    label21.Text = "Recurring Expenses added Successfully";
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

        //////////////////////////////////////////////////////////////////End recurring every MONTH/////////////////////////////////////////////////////////////// 
        //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////Start recurring every 3 MONTH/////////////////////////////////////////////////////////////// 


        //get the recurringincome every Month details
        public void Every_3_Month_getRecuring_incomedate()
        {

            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every 3 Months' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_three_month_entry.Text = (read["Entry_no"].ToString());//diff

                            every_three_month_username.Text = (read["Username"].ToString());
                            every_three_month_name.Text = (read["Name"].ToString());
                            every_three_month_description.Text = (read["Description"].ToString());
                            every_three_mnth_source.Text = (read["Name_or_source"].ToString());

                            every_three_month_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_three_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_three_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_three_month_record.Text = (read["Record_update"].ToString());
                            every_three_month_entrydate.Text = (read["Entry_Date"].ToString());
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

        //get every Month expense details
        public void Every_3_Month_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every 3 Months' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_three_mnth_expense_entry.Text = (read["Entry_no"].ToString());//diff

                            every_three_month_username.Text = (read["Username"].ToString());
                            every_three_month_name.Text = (read["Name"].ToString());
                            every_three_month_description.Text = (read["Description"].ToString());
                            every_three_mnth_source.Text = (read["Name_or_source"].ToString());

                            three_month_expense.Text = (read["Recurring_Expense"].ToString());//diff

                            every_three_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_three_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_three_month_record.Text = (read["Record_update"].ToString());
                            every_three_month_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_every_three_Month()
        {
            if (every_three_month_income.Text != "Income")
            {
                if (every_three_month_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_three_month_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (three_month_expense.Text != "Expenses")
            {
                if (every_three_month_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + every_three_mnth_expense_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of every Month recurrincome and expenses in database
        public void insert_every_3_Month_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string Every_3_Month_Usernamee = every_three_month_username.Text;
                string Every_3_Month_Name = every_three_month_name.Text;
                string Every_3_Month_Des = every_three_month_description.Text;
                string Every_3_Month_Contact = every_three_mnth_source.Text;
                string Every_3_Month_recuringincome = every_three_month_income.Text;
                string Every_3_Month_recuringexpense = three_month_expense.Text;
                DateTime Every_3_Month_Recurring_Date = for_three_month_recurring.Value.Date;
                string Every_3_Month_Recurring_Interval = every_three_month_interval.Text;
                string Every_3_Month_Record_update = every_three_month_record.Text;

                DateTime Every_3_Month_Entry_Date = dateTimePicker7.Value.Date;
                if (every_three_month_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_three_month_username.Text + "','" + every_three_month_name.Text + "','" + every_three_month_description.Text + "','" + every_three_mnth_source.Text + "','" + every_three_month_income.Text + "','" + for_three_month_recurring.Value.Date + "','" + every_three_month_interval.Text + "','" + every_three_month_record.Text + "','" + dateTimePicker7.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_3_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_3_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_3_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_3_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", Every_3_Month_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", Every_3_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_3_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_3_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_3_Month_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (three_month_expense.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_three_month_username.Text + "','" + every_three_month_name.Text + "','" + every_three_month_description.Text + "','" + every_three_mnth_source.Text + "','" + every_three_month_income.Text + "','" + for_three_month_recurring.Value.Date + "','" + every_three_month_interval.Text + "','" + every_three_month_record.Text + "','" + dateTimePicker7.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_3_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_3_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_3_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_3_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", Every_3_Month_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", Every_3_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_3_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_3_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_3_Month_Entry_Date);
                    command.ExecuteNonQuery();

                    label21.Text = "Recurring Expenses added Successfully";
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

        //////////////////////////////////////////////////////////////////End recurring every 3 MONTH///////////////////////////////////////////////////////////////                      
                            //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////Start recurring every 6 MONTH/////////////////////////////////////////////////////////////// 


        //get the recurringincome every Month details
        public void Every_6_Month_getRecuring_incomedate()
        {

            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every 6 Months' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_six_month_entry.Text = (read["Entry_no"].ToString());//diff

                            every_six_month_username.Text = (read["Username"].ToString());
                            every_six_month_name.Text = (read["Name"].ToString());
                            every_six_month_description.Text = (read["Description"].ToString());
                            every_six_mnth_source.Text = (read["Name_or_source"].ToString());

                            every_six_month_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_six_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_six_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_six_month_record.Text = (read["Record_update"].ToString());
                            every_six_month_entrydate.Text = (read["Entry_Date"].ToString());
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
       
        //get every Month expense details
        public void Every_6_Month_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every 6 Months' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            six_month_expense_entry.Text = (read["Entry_no"].ToString());//diff

                            every_six_month_username.Text = (read["Username"].ToString());
                            every_six_month_name.Text = (read["Name"].ToString());
                            every_six_month_description.Text = (read["Description"].ToString());
                            every_six_mnth_source.Text = (read["Name_or_source"].ToString());

                            six_month_expense.Text = (read["Recurring_Expense"].ToString());//diff

                            every_six_month_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_six_month_interval.Text = (read["Recurring_Interval"].ToString());
                            every_six_month_record.Text = (read["Record_update"].ToString());
                            every_six_month_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_every_6_Month()
        {
            if (every_six_month_income.Text != "Income")
            {
                if (every_six_month_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_six_month_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (six_month_expense.Text != "Expenses")
            {
                if (every_six_month_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + six_month_expense_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of every Month recurrincome and expenses in database
        public void insert_every_6_Month_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string Every_6_Month_Usernamee = every_six_month_username.Text;
                string Every_6_Month_Name = every_six_month_name.Text;
                string Every_6_Month_Des = every_six_month_description.Text;
                string Every_6_Month_Contact = every_six_mnth_source.Text;
                string Every_6_Month_recuringincome = every_six_month_income.Text;
                string Every_6_Month_recuringexpense = six_month_expense.Text;
                DateTime Every_6_Month_Recurring_Date = for_six_month_recurring.Value.Date;
                string Every_6_Month_Recurring_Interval = every_six_month_interval.Text;
                string Every_6_Month_Record_update = every_six_month_record.Text;

                DateTime Every_6_Month_Entry_Date = dateTimePicker10.Value.Date;
                if (every_six_month_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_six_month_username.Text + "','" + every_six_month_name.Text + "','" + every_six_month_description.Text + "','" + every_six_mnth_source.Text + "','" + every_six_month_income.Text + "','" + for_six_month_recurring.Value.Date + "','" + every_six_month_interval.Text + "','" + every_six_month_record.Text + "','" + dateTimePicker10.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_6_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_6_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_6_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_6_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", Every_6_Month_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", Every_6_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_6_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_6_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_6_Month_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (six_month_expense.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_six_month_username.Text + "','" + every_six_month_name.Text + "','" + every_six_month_description.Text + "','" + every_six_mnth_source.Text + "','" + six_month_expense.Text + "','" + for_six_month_recurring.Value.Date + "','" + every_six_month_interval.Text + "','" + every_six_month_record.Text + "','" + dateTimePicker10.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_6_Month_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_6_Month_Name);
                    command.Parameters.AddWithValue("Description", Every_6_Month_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_6_Month_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", Every_6_Month_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", Every_6_Month_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_6_Month_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_6_Month_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_6_Month_Entry_Date);
                    command.ExecuteNonQuery();

                    label21.Text = "Recurring Expenses added Successfully";
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
        
        //////////////////////////////////////////////////////////////////End recurring every 6 MONTH///////////////////////////////////////////////////////////////                      

        //****************************************************************************************************//
        //////////////////////////////////////////////////////////////////Start recurring every year/////////////////////////////////////////////////////////////// 


        //get the recurringincome every year details
        public void Every_year_getRecuring_incomedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {


                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Income IS NOT NULL AND Recurring_Interval ='Every year' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_year_entry.Text = (read["Entry_no"].ToString());//diff

                            every_year_username.Text = (read["Username"].ToString());
                            every_year_name.Text = (read["Name"].ToString());
                            every_year_description.Text = (read["Description"].ToString());
                            every_year_source.Text = (read["Name_or_source"].ToString());

                            every_year_income.Text = (read["Recurring_Income"].ToString());//diff

                            every_year_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_year_interval.Text = (read["Recurring_Interval"].ToString());
                            every_year_record.Text = (read["Record_update"].ToString());
                            every_year_entrydate.Text = (read["Entry_Date"].ToString());
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
      
        //get every year expense details
        public void Every_year_getRecuring_expensedate()
        {
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {

                        SqlCommand command =
                        new SqlCommand("SELECT * FROM db_incomeexpenses where Recurring_Expense IS NOT NULL AND Recurring_Interval ='Every year' AND Record_update ='Not Updated' AND Username='" + userid.Text + "' AND Recurring_Date='" + label9.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            every_year_expense_entry.Text = (read["Entry_no"].ToString());//diff

                            every_year_username.Text = (read["Username"].ToString());
                            every_year_name.Text = (read["Name"].ToString());
                            every_year_description.Text = (read["Description"].ToString());
                            every_year_source.Text = (read["Name_or_source"].ToString());

                            every_year_expense.Text = (read["Recurring_Expense"].ToString());//diff

                            every_year_recDate.Text = DateTime.Parse(read["Recurring_Date"].ToString()).ToString("dd-MM-yyyy");
                            every_year_interval.Text = (read["Recurring_Interval"].ToString());
                            every_year_record.Text = (read["Record_update"].ToString());
                            every_year_entrydate.Text = (read["Entry_Date"].ToString());
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
        public void update_status_for_every_year()
        {
            if (every_year_income.Text != "Income")
            {
                if (every_year_recDate.Text == today_datee.Text)
                {

                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where Entry_no='" + every_year_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            if (every_year_expense.Text != "Expenses")
            {
                if (every_year_recDate.Text == today_datee.Text)
                {
                    // Query string
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update db_incomeexpenses Set Record_update='Updated' where  Entry_no='" + every_year_expense_entry.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //insert the values of every year recurrincome and expenses in database
        public void insert_every_year_recurringincomeexpenses()
        {
            try
            {

                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                change_interval_for_rcurring();
                string Every_year_Usernamee = every_year_username.Text;
                string Every_year_Name = every_year_name.Text;
                string Every_year_Des = every_year_description.Text;
                string Every_year_Contact = every_year_source.Text;
                string Every_year_recuringincome = every_year_income.Text;
                string Every_year_recuringexpense = every_year_expense.Text;
                DateTime Every_year_Recurring_Date = for_year_recurring.Value.Date;
                string Every_year_Recurring_Interval = every_year_interval.Text;
                string Every_year_Record_update = every_year_record.Text;

                DateTime Every_year_Entry_Date = dateTimePicker8.Value.Date;
                if (every_year_income.Text != "Income")
                {

                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Income,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_year_username.Text + "','" + every_year_name.Text + "','" + every_year_description.Text + "','" + every_year_source.Text + "','" + every_year_income.Text + "','" + for_year_recurring.Value.Date + "','" + every_year_interval.Text + "','" + every_year_record.Text + "','" + dateTimePicker8.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    command.Parameters.AddWithValue("Username", Every_year_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_year_Name);
                    command.Parameters.AddWithValue("Description", Every_year_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_year_Contact);
                    command.Parameters.AddWithValue("Recurring_Income", Every_year_recuringincome);
                    command.Parameters.AddWithValue("Recurring_Date", Every_year_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_year_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_year_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_year_Entry_Date);
                    // get_incomesum();
                    command.ExecuteNonQuery();

                    // radiobtn_expense.Text = "Expense";
                    label21.Text = "Recurring Income added Successfully";
                    label21.ForeColor = System.Drawing.Color.DarkGreen;

                }
                if (every_year_expense.Text != "Expenses")
                {
                    string sqlquery = ("insert into db_incomeexpenses(Username,Name,Description,Name_or_source,Recurring_Expense,Recurring_Date,Recurring_Interval,Record_update,Entry_Date)values('" + every_year_username.Text + "','" + every_year_name.Text + "','" + every_year_description.Text + "','" + every_year_source.Text + "','" + every_year_expense.Text + "','" + for_year_recurring.Value.Date + "','" + every_year_interval.Text + "','" + every_year_record.Text + "','" + dateTimePicker8.Value.Date + "')");
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                   
                    command.Parameters.AddWithValue("Username", Every_year_Usernamee);
                    command.Parameters.AddWithValue("Name", Every_year_Name);
                    command.Parameters.AddWithValue("Description", Every_year_Des);
                    command.Parameters.AddWithValue("Name_or_source", Every_year_Contact);
                    command.Parameters.AddWithValue("Recurring_Expense", Every_year_recuringexpense);
                    command.Parameters.AddWithValue("Recurring_Date", Every_year_Recurring_Date);
                    command.Parameters.AddWithValue("Recurring_Interval", Every_year_Recurring_Interval);
                    command.Parameters.AddWithValue("Record_update", Every_year_Record_update);
                    command.Parameters.AddWithValue("Entry_Date", Every_year_Entry_Date);
                    command.ExecuteNonQuery();

                    label21.Text = "Recurring Expenses added Successfully";
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

        //////////////////////////////////////////////////////////////////End recurring every year///////////////////////////////////////////////////////////////                      
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
            if (everyweek_interval.Text == "Every week")
            {


                DateTime dt = dateTimePicker2.Value;
                for_week_recurring.Value = dt.AddDays(7);  //add 7 days to the selected date

            }
            if (every_two_week_interval.Text == "Every 2 weeks")
            {


                DateTime dt = dateTimePicker3.Value;
                for_two_week_recurring.Value = dt.AddDays(14);  //add 14 days to the selected date

            }
            if (every_three_week_interval.Text == "Every 3 weeks")
            {


                DateTime dt = dateTimePicker4.Value;
                for_three_week_recurring.Value = dt.AddDays(21); //add 21 days to the selected date

            }
            if (every_four_week_interval.Text == "Every 4 weeks")
            {


                DateTime dt = dateTimePicker5.Value;
                for_four_week_recurring.Value = dt.AddDays(28); //add 28 days to the selected date

            }
            if (every_three_month_interval.Text == "Every 3 Months")
            {


                DateTime dt = dateTimePicker7.Value;
                for_three_month_recurring.Value = dt.AddMonths(3); //add 3 months to the selected date


            }
            if (every_six_month_interval.Text == "Every 6 Months")
            {

                DateTime dt = dateTimePicker10.Value;
                for_six_month_recurring.Value = dt.AddMonths(6); //add 6 months to the selected date


            }
            if (every_month_interval.Text == "Every Month")
            {

                DateTime dt = dateTimePicker6.Value;
                for_month_recurring.Value = dt.AddMonths(1); //add 1 months to the selected date


            }
             if (every_year_interval.Text == "Every year")
            {
                DateTime dt = dateTimePicker8.Value;
                for_year_recurring.Value = dt.AddYears(1); //add 1 year to the selected date

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
            cmd.CommandText = "Update db_auth Set Your_Balnc_withou_Recurring='" + label3.Text + "',Your_Balance_with_Recursion='" + label27.Text + "' where Username='" + userid.Text + "'";
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||Prediction Algorithm Start||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        public void update_prdiction_dates()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            DateTime Pre_start = dateTimePicker11.Value;
            DateTime pre_end = dateTimePicker9.Value;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Prediction_Start_Date='" + Pre_start + "',Prediction_End_Date='" + pre_end + "' where  Entry_Date >='" + Pre_start + "' and Entry_Date <='" + pre_end + "' AND Recurring_Interval IS NOT NULL AND Username='" + userid.Text + "';";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update_values_to_Null_of_previous_prediction()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            DateTime Pre_start = dateTimePicker11.Value;
            DateTime pre_end = dateTimePicker9.Value;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Prediction_Start_Date=NULL,Prediction_End_Date=NULL where Prediction_Start_Date IS NOT NULL and  Prediction_End_Date IS NOT NULL AND Recurring_Interval IS NOT NULL AND Username='" + userid.Text + "';";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set No_of_days=" + label33.Text + " where Prediction_Start_Date IS NOT NULL and  Prediction_End_Date IS NOT NULL AND Recurring_Interval IS NOT NULL AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {

           // update_values_to_Null_of_previous_prediction();
            //update_prdiction_dates();  // to enter prediction dates
           // count_numberof_days_entriess();
           // update_no_of_days(); //count number of days from today date to prediction date
            update_no_of_days_everyday();
            update_no_of_days_week();
            update_no_of_days_2_week();
            update_no_of_days_3_week();
            update_no_of_days_4_week();
            update_no_of_days_every_month();
            update_no_of_days_3_month();
            update_no_of_days_6_month();
            update_no_of_days_every_year();
        }

        public void count_numberof_days_entriess()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    DateTime Pre_start = dateTimePicker11.Value;
                    DateTime pre_end = dateTimePicker9.Value;
                    SqlCommand command =
                    new SqlCommand("SELECT DATEDIFF(DAY,Prediction_Start_Date,Prediction_End_Date) AS everdayinterval FROM db_incomeexpenses where Prediction_End_Date IS NOT NULL AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label33.Text = (read["everdayinterval"].ToString());

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

        private void dateTimePicker9_ValueChanged(object sender, EventArgs e)
        {
            
        }

        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||Update the values of week,2weeks,3weeks,4weeks||||||||||||||||||||||
        public void update_no_of_days_everyday()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/1 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every day' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_week()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/7 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every week' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_2_week()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/14 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every 2 weeks' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_3_week()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/21 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every 3 weeks' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_4_week()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/28 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every 4 weeks' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_every_month()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/30.417 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every Month' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_3_month()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/91.251 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every 3 Months' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_no_of_days_6_month()
        {
            // Query stringEvery 6 Months

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/182.502 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every 6 Months' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
         public void update_no_of_days_every_year()
        {
            // Query stringEvery 6 Months

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=No_of_days/365 where Prediction_End_Date IS NOT NULL AND Recurring_Interval='Every year' AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||Prediction Algorithm END||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    }
    }

