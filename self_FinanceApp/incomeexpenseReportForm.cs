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
    public partial class incomeexpenseReportForm : Form
    {//Global Variables
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        BindingSource source1 = new BindingSource();
        // public static string SetValueForText3 = "";
        ReportDocument cryrpt=new ReportDocument();

        //Database Connection String
        String cs = "Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-H2H8TNI;Initial Catalog=db_selfFinace;Integrated Security=True");
        SqlDataAdapter sda;
        public incomeexpenseReportForm()
        {
            InitializeComponent();
        }

        private void incomeexpenseReportForm_Load(object sender, EventArgs e)
        {
            label1.Text = loginFrm.SetValueForText2;//for admin
            label2.Text = loginFrm.SetValueForText1;//for user
            if (label1.Text == "Admin")
            {
                button1.Visible = true;
                button2.Visible = false;
               
            }
            else {
                button2.Visible = true;
                button1.Visible = false;
                crystalReportViewer1.Visible = false;
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
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
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void button2_Click(object sender, EventArgs e)
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
                MyCommand.CommandText = "select * from db_incomeexpenses where  Username='" + label2.Text + "' AND Entry_Date  >= '" + dfrom + "' and Entry_Date <='" + dto + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "db_incomeexpenses");
                rprot.SetDataSource(myDS);
                rprot.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\pdffiles\" + textBox1.Text + ".pdf");
              //  incomeexpenseReportForm ud = new incomeexpenseReportForm();
                crystalReportViewer1.Visible = true;
                crystalReportViewer1.ReportSource = rprot;
              //  ud.Show();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}