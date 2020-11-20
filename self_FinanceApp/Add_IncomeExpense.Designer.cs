namespace self_FinanceApp
{
    partial class Add_IncomeExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_IncomeExpense));
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.rbtn_income = new System.Windows.Forms.RadioButton();
            this.radiobtn_expense = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_des = new System.Windows.Forms.TextBox();
            this.txt_amnt = new System.Windows.Forms.TextBox();
            this.txt_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_addincome_expense = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_contacts = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_balnce = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(519, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(341, 24);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(27, 13);
            this.lbl_user.TabIndex = 16;
            this.lbl_user.Text = "user";
            this.lbl_user.Visible = false;
            // 
            // rbtn_income
            // 
            this.rbtn_income.AutoSize = true;
            this.rbtn_income.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_income.ForeColor = System.Drawing.Color.Green;
            this.rbtn_income.Location = new System.Drawing.Point(33, 327);
            this.rbtn_income.Name = "rbtn_income";
            this.rbtn_income.Size = new System.Drawing.Size(76, 20);
            this.rbtn_income.TabIndex = 17;
            this.rbtn_income.TabStop = true;
            this.rbtn_income.Text = "Income";
            this.rbtn_income.UseVisualStyleBackColor = true;
            this.rbtn_income.CheckedChanged += new System.EventHandler(this.rbtn_income_CheckedChanged);
            // 
            // radiobtn_expense
            // 
            this.radiobtn_expense.AutoSize = true;
            this.radiobtn_expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_expense.ForeColor = System.Drawing.Color.Red;
            this.radiobtn_expense.Location = new System.Drawing.Point(33, 361);
            this.radiobtn_expense.Name = "radiobtn_expense";
            this.radiobtn_expense.Size = new System.Drawing.Size(86, 20);
            this.radiobtn_expense.TabIndex = 18;
            this.radiobtn_expense.TabStop = true;
            this.radiobtn_expense.Text = "Expense";
            this.radiobtn_expense.UseVisualStyleBackColor = true;
            this.radiobtn_expense.CheckedChanged += new System.EventHandler(this.radiobtn_expense_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description";
            // 
            // txt_des
            // 
            this.txt_des.Location = new System.Drawing.Point(46, 121);
            this.txt_des.Name = "txt_des";
            this.txt_des.Size = new System.Drawing.Size(161, 20);
            this.txt_des.TabIndex = 20;
            // 
            // txt_amnt
            // 
            this.txt_amnt.Location = new System.Drawing.Point(46, 227);
            this.txt_amnt.Name = "txt_amnt";
            this.txt_amnt.Size = new System.Drawing.Size(161, 20);
            this.txt_amnt.TabIndex = 21;
            this.txt_amnt.Text = "0";
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(267, 121);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(193, 20);
            this.txt_date.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SeaGreen;
            this.label6.Location = new System.Drawing.Point(53, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Add Income";
            // 
            // btn_addincome_expense
            // 
            this.btn_addincome_expense.BackColor = System.Drawing.SystemColors.Control;
            this.btn_addincome_expense.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addincome_expense.BackgroundImage")));
            this.btn_addincome_expense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addincome_expense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addincome_expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addincome_expense.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_addincome_expense.Location = new System.Drawing.Point(12, 8);
            this.btn_addincome_expense.Name = "btn_addincome_expense";
            this.btn_addincome_expense.Size = new System.Drawing.Size(39, 25);
            this.btn_addincome_expense.TabIndex = 26;
            this.btn_addincome_expense.UseVisualStyleBackColor = false;
            this.btn_addincome_expense.Click += new System.EventHandler(this.btn_addincome_expense_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "label7";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(344, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 36);
            this.button1.TabIndex = 28;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Contacts/Source";
            // 
            // txt_contacts
            // 
            this.txt_contacts.FormattingEnabled = true;
            this.txt_contacts.Location = new System.Drawing.Point(46, 172);
            this.txt_contacts.Name = "txt_contacts";
            this.txt_contacts.Size = new System.Drawing.Size(160, 21);
            this.txt_contacts.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(408, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 46);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(402, 24);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(55, 13);
            this.lbl_name.TabIndex = 32;
            this.lbl_name.Text = "Nameuser";
            this.lbl_name.Visible = false;
            // 
            // lbl_balnce
            // 
            this.lbl_balnce.AutoSize = true;
            this.lbl_balnce.Location = new System.Drawing.Point(168, 272);
            this.lbl_balnce.Name = "lbl_balnce";
            this.lbl_balnce.Size = new System.Drawing.Size(13, 13);
            this.lbl_balnce.TabIndex = 39;
            this.lbl_balnce.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(151, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Your Balance";
            this.label12.Visible = false;
            // 
            // Add_IncomeExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 410);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_balnce);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_contacts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_addincome_expense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_amnt);
            this.Controls.Add(this.txt_des);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radiobtn_expense);
            this.Controls.Add(this.rbtn_income);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_IncomeExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_IncomeExpense";
            this.Load += new System.EventHandler(this.Add_IncomeExpense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.RadioButton rbtn_income;
        private System.Windows.Forms.RadioButton radiobtn_expense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_des;
        private System.Windows.Forms.TextBox txt_amnt;
        private System.Windows.Forms.DateTimePicker txt_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addincome_expense;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txt_contacts;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_balnce;
        private System.Windows.Forms.Label label12;
    }
}