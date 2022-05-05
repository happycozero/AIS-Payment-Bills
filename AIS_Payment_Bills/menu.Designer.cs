namespace Payment_Bills
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonPaymentDocuments = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonTablePayers = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonTableUsers = new System.Windows.Forms.Button();
            this.buttonUtilityTariffs = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBackup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(307, 379);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тарифы ЖКХ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(490, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(147, 38);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPaymentDocuments
            // 
            this.buttonPaymentDocuments.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonPaymentDocuments.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPaymentDocuments.Location = new System.Drawing.Point(338, 212);
            this.buttonPaymentDocuments.Name = "buttonPaymentDocuments";
            this.buttonPaymentDocuments.Size = new System.Drawing.Size(299, 32);
            this.buttonPaymentDocuments.TabIndex = 5;
            this.buttonPaymentDocuments.Text = "Платежные документы";
            this.buttonPaymentDocuments.UseVisualStyleBackColor = false;
            this.buttonPaymentDocuments.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonReport.Enabled = false;
            this.buttonReport.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReport.Location = new System.Drawing.Point(338, 250);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(299, 32);
            this.buttonReport.TabIndex = 6;
            this.buttonReport.Text = "Отчёты";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonTablePayers
            // 
            this.buttonTablePayers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonTablePayers.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTablePayers.Location = new System.Drawing.Point(338, 136);
            this.buttonTablePayers.Name = "buttonTablePayers";
            this.buttonTablePayers.Size = new System.Drawing.Size(299, 32);
            this.buttonTablePayers.TabIndex = 7;
            this.buttonTablePayers.Text = "Таблица плательщиков";
            this.buttonTablePayers.UseVisualStyleBackColor = false;
            this.buttonTablePayers.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button5.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(338, 174);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(299, 32);
            this.button5.TabIndex = 9;
            this.button5.Text = "Выбор услуг";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonTableUsers
            // 
            this.buttonTableUsers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonTableUsers.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTableUsers.Location = new System.Drawing.Point(338, 288);
            this.buttonTableUsers.Name = "buttonTableUsers";
            this.buttonTableUsers.Size = new System.Drawing.Size(300, 32);
            this.buttonTableUsers.TabIndex = 10;
            this.buttonTableUsers.Text = "Таблица пользователей";
            this.buttonTableUsers.UseVisualStyleBackColor = false;
            this.buttonTableUsers.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonUtilityTariffs
            // 
            this.buttonUtilityTariffs.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonUtilityTariffs.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUtilityTariffs.Location = new System.Drawing.Point(338, 326);
            this.buttonUtilityTariffs.Name = "buttonUtilityTariffs";
            this.buttonUtilityTariffs.Size = new System.Drawing.Size(299, 32);
            this.buttonUtilityTariffs.TabIndex = 11;
            this.buttonUtilityTariffs.Text = "Тарифы ЖКХ";
            this.buttonUtilityTariffs.UseVisualStyleBackColor = false;
            this.buttonUtilityTariffs.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(338, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 12;
            this.textBox1.Visible = false;
            // 
            // buttonBackup
            // 
            this.buttonBackup.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonBackup.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackup.Location = new System.Drawing.Point(338, 364);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(299, 68);
            this.buttonBackup.TabIndex = 11;
            this.buttonBackup.Text = "Резервное копирование БД";
            this.buttonBackup.UseVisualStyleBackColor = false;
            this.buttonBackup.Click += new System.EventHandler(this.button8_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(649, 436);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.buttonUtilityTariffs);
            this.Controls.Add(this.buttonTableUsers);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonTablePayers);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonPaymentDocuments);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Menu";
            this.Text = "Учет оплаты ЖКХ | Меню";
            this.Load += new System.EventHandler(this.menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonPaymentDocuments;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonTablePayers;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonTableUsers;
        private System.Windows.Forms.Button buttonUtilityTariffs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBackup;
    }
}