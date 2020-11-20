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



        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        public Manage_income_expensesFrm()
        {
            InitializeComponent();
        }

        private void Manage_income_expensesFrm_Load(object sender, EventArgs e)
        {
            label2.Text = loginFrm.SetValueForText1;
            txt_blncdate.Text = DateTime.Now.ToString("MMM-dd ");
            get_blncc();
        }
        //get sum of income
        public void get_blncc()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command =
                    new SqlCommand("SELECT Your_Balance FROM db_incomeexpenses where Username='" + label2.Text + "'", connection);
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
        private void button1_Click(object sender, EventArgs e)
        {
            btn_addincome_expense.Visible = true;
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
    }
}
