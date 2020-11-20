using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace self_FinanceApp
{
    public partial class Manage_income_expensesFrm : Form
    {
        public Manage_income_expensesFrm()
        {
            InitializeComponent();
        }

        private void Manage_income_expensesFrm_Load(object sender, EventArgs e)
        {
            txt_blncdate.Text = DateTime.Now.ToString("MMM-dd ");
        }
    }
}
