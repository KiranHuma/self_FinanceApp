﻿namespace self_FinanceApp
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
            this.txt_amnt = new System.Windows.Forms.TextBox();
            this.txt_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_addincome_expense = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_contacts = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_balnce = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_des = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(655, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_user.Location = new System.Drawing.Point(401, 26);
            this.lbl_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(36, 17);
            this.lbl_user.TabIndex = 16;
            this.lbl_user.Text = "user";
            this.lbl_user.Visible = false;
            // 
            // rbtn_income
            // 
            this.rbtn_income.AutoSize = true;
            this.rbtn_income.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_income.ForeColor = System.Drawing.Color.Green;
            this.rbtn_income.Location = new System.Drawing.Point(45, 356);
            this.rbtn_income.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_income.Name = "rbtn_income";
            this.rbtn_income.Size = new System.Drawing.Size(90, 24);
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
            this.radiobtn_expense.Location = new System.Drawing.Point(45, 398);
            this.radiobtn_expense.Margin = new System.Windows.Forms.Padding(4);
            this.radiobtn_expense.Name = "radiobtn_expense";
            this.radiobtn_expense.Size = new System.Drawing.Size(101, 24);
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
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description";
            // 
            // txt_amnt
            // 
            this.txt_amnt.Location = new System.Drawing.Point(62, 254);
            this.txt_amnt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_amnt.Name = "txt_amnt";
            this.txt_amnt.Size = new System.Drawing.Size(213, 22);
            this.txt_amnt.TabIndex = 21;
            this.txt_amnt.Text = "0";
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(439, 371);
            this.txt_date.Margin = new System.Windows.Forms.Padding(4);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(241, 22);
            this.txt_date.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 351);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(64, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label6.Location = new System.Drawing.Point(78, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Add Income";
            // 
            // btn_addincome_expense
            // 
            this.btn_addincome_expense.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_addincome_expense.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addincome_expense.BackgroundImage")));
            this.btn_addincome_expense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addincome_expense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addincome_expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addincome_expense.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_addincome_expense.Location = new System.Drawing.Point(23, 10);
            this.btn_addincome_expense.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addincome_expense.Name = "btn_addincome_expense";
            this.btn_addincome_expense.Size = new System.Drawing.Size(52, 31);
            this.btn_addincome_expense.TabIndex = 26;
            this.btn_addincome_expense.UseVisualStyleBackColor = false;
            this.btn_addincome_expense.Click += new System.EventHandler(this.btn_addincome_expense_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(161, 436);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 30);
            this.label7.TabIndex = 27;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(57, 167);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "Contacts/Source";
            // 
            // txt_contacts
            // 
            this.txt_contacts.FormattingEnabled = true;
            this.txt_contacts.Location = new System.Drawing.Point(62, 187);
            this.txt_contacts.Margin = new System.Windows.Forms.Padding(4);
            this.txt_contacts.Name = "txt_contacts";
            this.txt_contacts.Size = new System.Drawing.Size(212, 24);
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
            this.button2.Location = new System.Drawing.Point(629, 417);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 49);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.ForeColor = System.Drawing.Color.Honeydew;
            this.lbl_name.Location = new System.Drawing.Point(482, 26);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 17);
            this.lbl_name.TabIndex = 32;
            this.lbl_name.Visible = false;
            // 
            // lbl_balnce
            // 
            this.lbl_balnce.AutoSize = true;
            this.lbl_balnce.ForeColor = System.Drawing.Color.White;
            this.lbl_balnce.Location = new System.Drawing.Point(225, 310);
            this.lbl_balnce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_balnce.Name = "lbl_balnce";
            this.lbl_balnce.Size = new System.Drawing.Size(16, 17);
            this.lbl_balnce.TabIndex = 39;
            this.lbl_balnce.Text = "0";
            this.lbl_balnce.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(86, 310);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 17);
            this.label12.TabIndex = 40;
            this.label12.Text = "Your Balance";
            this.label12.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_des);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_addincome_expense);
            this.panel1.Controls.Add(this.lbl_balnce);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_amnt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_contacts);
            this.panel1.Controls.Add(this.lbl_user);
            this.panel1.Controls.Add(this.label4);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 346);
            this.panel1.TabIndex = 41;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(292, 190);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 21);
            this.radioButton1.TabIndex = 46;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Get Contacts";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(304, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "user";
            this.label1.Visible = false;
            // 
            // txt_des
            // 
            this.txt_des.Location = new System.Drawing.Point(62, 101);
            this.txt_des.Name = "txt_des";
            this.txt_des.Size = new System.Drawing.Size(353, 63);
            this.txt_des.TabIndex = 41;
            this.txt_des.Text = "";
            // 
            // Add_IncomeExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 505);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.radiobtn_expense);
            this.Controls.Add(this.rbtn_income);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add_IncomeExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_IncomeExpense";
            this.Load += new System.EventHandler(this.Add_IncomeExpense_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.RadioButton rbtn_income;
        private System.Windows.Forms.RadioButton radiobtn_expense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_amnt;
        private System.Windows.Forms.DateTimePicker txt_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addincome_expense;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txt_contacts;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_balnce;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txt_des;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}