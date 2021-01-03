using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace self_FinanceApp
{
    public partial class ReprtForm : Form
    {//Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        // public static string SetValueForText3 = "";
        ReportDocument cryrpt = new ReportDocument();

        //Database Connection String
        String cs = "Data Source=XENO;Initial Catalog=db_selfFinace;Integrated Security=True";
        SqlConnection conn = new SqlConnection("Data Source=XENO;Initial Catalog=db_selfFinace;Integrated Security=True");
        public ReprtForm()
        {
            InitializeComponent();
        }

        private void ReprtForm_Load(object sender, EventArgs e)
        {
            label1.Text = loginFrm.SetValueForText2;//for admin
            label2.Text = loginFrm.SetValueForText1;//for user
            if (label1.Text == "Admin")
            {
                button2.Visible = true;
                button1.Visible = false;
                fullreportt();
            }
            else
            {
                button1.Visible = true;
                button2.Visible = false;
                crystalReportViewer1.Visible = false;
            }
        }

        private void label4_Click(object sender, System.EventArgs e)
        {
            this.Close();
            
        }

        private void btn_addincome_expense_Click(object sender, System.EventArgs e)
        {
            Manage_income_expensesFrm Mie = new Manage_income_expensesFrm();
            this.Dispose();
            Mie.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
        }
        public void fullreportt()
        {
              try
            {
                Cursor = Cursors.WaitCursor;
                incomeReport rprot = new incomeReport(); // The report you created.
                SqlConnection myConnection;
                var MyCommand = new SqlCommand();
                var myDA = new SqlDataAdapter();
                var myDS = new db_selfFinaceDataSet(); // The DataSet you created.
                myConnection = new SqlConnection(cs);
                DateTime dfrom = dateTimePicker1.Value;
                DateTime dto = dateTimePicker2.Value;
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from db_incomeexpenses ";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "db_incomeexpenses");
                rprot.SetDataSource(myDS);
                //rprot.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\pdffiles\" + textBox1.Text + ".pdf");
                //incomeexpenseReportForm ud = new incomeexpenseReportForm();

                crystalReportViewer1.ReportSource = rprot;

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void button2_Click(object sender, System.EventArgs e)
        {
             try
            {
                Cursor = Cursors.WaitCursor;
                incomeReport rprot = new incomeReport(); // The report you created.
                SqlConnection myConnection;
                var MyCommand = new SqlCommand();
                var myDA = new SqlDataAdapter();
                var myDS = new db_selfFinaceDataSet(); // The DataSet you created.
                myConnection = new SqlConnection(cs);
                DateTime dfrom = dateTimePicker1.Value;
                DateTime dto = dateTimePicker2.Value;
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from db_incomeexpenses where  Entry_Date  >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "db_incomeexpenses");
                rprot.SetDataSource(myDS);
                rprot.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\pdffiles\" + textBox1.Text + ".pdf");
                //incomeexpenseReportForm ud = new incomeexpenseReportForm();

                crystalReportViewer1.ReportSource = rprot;

                MessageBox.Show("Report Created Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //user
            try
            {
                Cursor = Cursors.WaitCursor;
                incomeReport rprot = new incomeReport(); // The report you created.
                SqlConnection myConnection;
                var MyCommand = new SqlCommand();
                var myDA = new SqlDataAdapter();
                var myDS = new db_selfFinaceDataSet(); // The DataSet you created.

                myConnection = new SqlConnection(cs);
                DateTime dfrom = dateTimePicker1.Value;
                DateTime dto = dateTimePicker2.Value;
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from db_incomeexpenses where  Username='" + label2.Text + "' AND Entry_Date  >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "db_incomeexpenses");
                rprot.SetDataSource(myDS);
                // for pdf 
                rprot.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\pdffiles\" + textBox1.Text + ".pdf");
                //  incomeexpenseReportForm ud = new incomeexpenseReportForm();
                crystalReportViewer1.Visible = true;
                crystalReportViewer1.ReportSource = rprot;
                //  ud.Show();
                MessageBox.Show("Report Created Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        
    }
}
