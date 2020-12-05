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
    public partial class PredictionScreen : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        public static string SetValueForText3 = "";


        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public PredictionScreen()
        {
            InitializeComponent();
        }

        private void PredictionScreen_Load(object sender, EventArgs e)
        {
            userid.Text = loginFrm.SetValueForText1;
            DateTime dt = dateTimePicker11.Value;
            dateTimePicker1.Value = dt.AddDays(-7);
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
            cmd.CommandText = " Update db_incomeexpenses Set Prediction_Start_Date='" + Pre_start + "',Prediction_End_Date='" + pre_end + "' where  Date_of_Entry >='" + Pre_start + "' or Date_of_Entry <='" + pre_end + "' AND Record_update='Updated'  AND Username='" + userid.Text + "';";
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
            cmd.CommandText = " Update db_incomeexpenses Set Prediction_Start_Date=NULL,Prediction_End_Date=NULL where Prediction_Start_Date IS NOT NULL and  Prediction_End_Date IS NOT NULL AND Recurring_Interval IS NOT NULL AND Record_update='Not Updated' AND Username='" + userid.Text + "';";
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
        public void update_no_of_days_with_null()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set No_of_days=NULL where No_of_days!=" + label33.Text + " AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_calculate_no_days_with_null()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_incomeexpenses Set Calculate_no_days=NULL where Calculate_no_days IS NOT NULL AND Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button14_Click(object sender, EventArgs e)
        {  update_values_to_Null_of_previous_prediction();
           update_prdiction_dates();  // to enter prediction dates
            count_numberof_days_entriess();
           update_values_to_Null_of_previous_prediction();
           
            update_no_of_days(); //count number of days from today date to prediction date
            update_no_of_days_with_null();// NUll the prvious record of no.of days prediction
            update_calculate_no_days_with_null(); // NUll the prvious record of calculate_no_days prediction
          update_no_of_days_everyday();
       update_no_of_days_week();
           update_no_of_days_2_week();
          update_no_of_days_3_week();
            update_no_of_days_4_week();
            update_no_of_days_every_month();
          update_no_of_days_3_month();
           update_no_of_days_6_month();
           update_no_of_days_every_year();
           calculate_recINcome_with_no_of_days();

            ////income and expense average
           calculate_income_average_();
           calculate_week_from_no_of_days();
           calculate_average_Expense();
           calculate_week_from_no_of_days();
           get_average_income_expense();
           update_predict_balnce();
        }
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||Update the values of week,2weeks,3weeks,4weeks||||||||||||||||||||||
      //for everyday
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
        // for week
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
        // for 2 weeks
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
        // for three weeks
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
        // for 4 weeks
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
        // for every month
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
        // for 3 month
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
        //for 6 month
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
        // for every year
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

        /// <summary>
        /// update the predicted balnce to the user table and from that table the balnce will show 
        /// </summary>
        public void update_predict_balnce()
        {
            // Query string
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " Update db_auth Set Predict_balnce='" + label19.Text + "',Predict_Date='" + dateTimePicker9.Value + "' where  Username='" + userid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void dateTimePicker11_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void userid_Click(object sender, EventArgs e)
        {

        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||Prediction Algorithm END||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
       // get the number of days from today to user selected date
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
       
        // now multiply the recurring income and expense with no. of days (days,month,week etc)
        public void calculate_recINcome_with_no_of_days()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    DateTime Pre_start = dateTimePicker11.Value;
                    DateTime pre_end = dateTimePicker9.Value;
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Recurring_Income*Calculate_no_days)-SUM(Recurring_Expense*Calculate_no_days)  AS predictblance FROM db_incomeexpenses where Recurring_Income IS NOT NULL or Recurring_Expense IS NOT NULL AND Prediction_End_Date IS NOT NULL  AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label2.Text = (read["predictblance"].ToString());

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
        // get the average of expense
        public void calculate_average_Expense()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    DateTime Pre_start = dateTimePicker1.Value;
                    DateTime pre_end = dateTimePicker11.Value;
                    SqlCommand command =
                    new SqlCommand("SELECT  SUM(Expense)/COUNT(Expense) AS averageexpense FROM db_incomeexpenses where Entry_Date >='" + Pre_start + "' AND Entry_Date <='" + pre_end + "' AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        avg_expense.Text = (read["averageexpense"].ToString());

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
        // average of income
        public void calculate_income_average_()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    DateTime Pre_start = dateTimePicker1.Value;
                    DateTime pre_end = dateTimePicker11.Value;
                    SqlCommand command =
                    new SqlCommand("SELECT SUM(Income)/COUNT(Income) AS averagecount FROM db_incomeexpenses where Entry_Date >='" + Pre_start + "' AND Entry_Date <='" + pre_end + "' AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        avg_income.Text = (read["averagecount"].ToString());

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
        // calculate the  previous 7 days
        public void calculate_week_from_no_of_days()
          
        {
            if (label7.Text =="weekno"){
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    try
                    {
                        DateTime Pre_start = dateTimePicker11.Value;
                        DateTime pre_end = dateTimePicker9.Value;
                        SqlCommand command =
                        new SqlCommand("SELECT TOP 1 Calculate_no_days/7 AS weekscal FROM db_incomeexpenses where Recurring_Interval IS NOT NULL AND Username='" + userid.Text + "'", connection);
                        connection.Open();
                        cmd.Parameters.Clear();
                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            label7.Text = (read["weekscal"].ToString());

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
            else
            {

            
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    DateTime Pre_start = dateTimePicker11.Value;
                    DateTime pre_end = dateTimePicker9.Value;
                    SqlCommand command =
                    new SqlCommand("SELECT TOP 1 Calculate_no_days AS no_ofweeks FROM db_incomeexpenses where Recurring_Interval='Every week' AND Username='" + userid.Text + "'", connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        label7.Text = (read["no_ofweeks"].ToString());

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
        // Get the final balnce by multiplying the 7 days
        // get the predict balnce by adding the average(income)+predicted(income)-averageexpense-(predicted(expense)
        public void get_average_income_expense()
        {
            double multiplyincome;
            multiplyincome = Math.Abs(double.Parse(avg_income.Text) * (double.Parse(label7.Text)));
            label16.Text = Convert.ToString(multiplyincome);
            multiplyincome = Math.Abs(multiplyincome);

            double multiplyexpense;
            multiplyexpense = Math.Abs(double.Parse(avg_expense.Text) * (double.Parse(label7.Text)));
            label17.Text = Convert.ToString(multiplyexpense);
            multiplyexpense = Math.Abs(multiplyexpense);

            double totalincomeexpensePredictblnce;
            totalincomeexpensePredictblnce = Math.Abs(double.Parse(label16.Text) - (double.Parse(label17.Text)));
            label15.Text = Convert.ToString(totalincomeexpensePredictblnce);
            totalincomeexpensePredictblnce = Math.Abs(totalincomeexpensePredictblnce);

            double totalpredictblnce;
            totalpredictblnce = Math.Abs(double.Parse(label2.Text) + (double.Parse(label15.Text)));
            label19.Text = Convert.ToString(totalpredictblnce);
            totalpredictblnce = Math.Abs(totalpredictblnce);
        }
        private void dateTimePicker11_ValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

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
            Mie.Show();
        }
    }
}
