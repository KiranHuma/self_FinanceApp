namespace self_FinanceApp
{
    partial class Manage_income_expensesFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_income_expensesFrm));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_blncdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_income = new System.Windows.Forms.Label();
            this.btn_addincome_expense = new System.Windows.Forms.Button();
            this.btn_recurring = new System.Windows.Forms.Button();
            this.lbl_recurr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(22, 72);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Balance on";
            // 
            // txt_blncdate
            // 
            this.txt_blncdate.AutoSize = true;
            this.txt_blncdate.Location = new System.Drawing.Point(98, 267);
            this.txt_blncdate.Name = "txt_blncdate";
            this.txt_blncdate.Size = new System.Drawing.Size(30, 13);
            this.txt_blncdate.TabIndex = 3;
            this.txt_blncdate.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(501, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 33);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(228, 206);
            this.dataGridView1.TabIndex = 7;
            // 
            // lbl_income
            // 
            this.lbl_income.AutoSize = true;
            this.lbl_income.BackColor = System.Drawing.Color.Black;
            this.lbl_income.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_income.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_income.ForeColor = System.Drawing.Color.White;
            this.lbl_income.Location = new System.Drawing.Point(345, 470);
            this.lbl_income.Name = "lbl_income";
            this.lbl_income.Size = new System.Drawing.Size(154, 16);
            this.lbl_income.TabIndex = 10;
            this.lbl_income.Text = "Add expense\\income";
            this.lbl_income.Visible = false;
            // 
            // btn_addincome_expense
            // 
            this.btn_addincome_expense.BackColor = System.Drawing.SystemColors.Control;
            this.btn_addincome_expense.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addincome_expense.BackgroundImage")));
            this.btn_addincome_expense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addincome_expense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addincome_expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addincome_expense.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_addincome_expense.Location = new System.Drawing.Point(501, 460);
            this.btn_addincome_expense.Name = "btn_addincome_expense";
            this.btn_addincome_expense.Size = new System.Drawing.Size(39, 33);
            this.btn_addincome_expense.TabIndex = 11;
            this.btn_addincome_expense.UseVisualStyleBackColor = false;
            this.btn_addincome_expense.Visible = false;
            this.btn_addincome_expense.Click += new System.EventHandler(this.btn_addincome_expense_Click);
            // 
            // btn_recurring
            // 
            this.btn_recurring.BackColor = System.Drawing.SystemColors.Control;
            this.btn_recurring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_recurring.BackgroundImage")));
            this.btn_recurring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_recurring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recurring.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recurring.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_recurring.Location = new System.Drawing.Point(501, 408);
            this.btn_recurring.Name = "btn_recurring";
            this.btn_recurring.Size = new System.Drawing.Size(39, 33);
            this.btn_recurring.TabIndex = 12;
            this.btn_recurring.UseVisualStyleBackColor = false;
            this.btn_recurring.Visible = false;
            // 
            // lbl_recurr
            // 
            this.lbl_recurr.AutoSize = true;
            this.lbl_recurr.BackColor = System.Drawing.Color.Black;
            this.lbl_recurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_recurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recurr.ForeColor = System.Drawing.Color.White;
            this.lbl_recurr.Location = new System.Drawing.Point(276, 418);
            this.lbl_recurr.Name = "lbl_recurr";
            this.lbl_recurr.Size = new System.Drawing.Size(219, 16);
            this.lbl_recurr.TabIndex = 13;
            this.lbl_recurr.Text = "Add recurring expense\\income";
            this.lbl_recurr.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(535, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Manage_income_expensesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 570);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_recurr);
            this.Controls.Add(this.btn_recurring);
            this.Controls.Add(this.btn_addincome_expense);
            this.Controls.Add(this.lbl_income);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_blncdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_income_expensesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage_income_expensesFrm";
            this.Load += new System.EventHandler(this.Manage_income_expensesFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_blncdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_income;
        private System.Windows.Forms.Button btn_addincome_expense;
        private System.Windows.Forms.Button btn_recurring;
        private System.Windows.Forms.Label lbl_recurr;
        private System.Windows.Forms.Label label4;
    }
}