using System;

namespace Payment_Bills
{
    partial class Client_table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_table));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Facial_Score = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Fam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Ph = new System.Windows.Forms.TextBox();
            this.buttonEditClient = new System.Windows.Forms.Button();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.buttonReturnMenu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Mod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Square_M = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(433, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(1022, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(87, 39);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddClient.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddClient.Location = new System.Drawing.Point(6, 33);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(323, 32);
            this.buttonAddClient.TabIndex = 13;
            this.buttonAddClient.Text = "Добавить плательщика";
            this.buttonAddClient.UseVisualStyleBackColor = false;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Управляющая компания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Лицевой счет";
            // 
            // Facial_Score
            // 
            this.Facial_Score.Location = new System.Drawing.Point(11, 141);
            this.Facial_Score.MaxLength = 20;
            this.Facial_Score.Name = "Facial_Score";
            this.Facial_Score.Size = new System.Drawing.Size(266, 31);
            this.Facial_Score.TabIndex = 17;
            this.Facial_Score.TextChanged += new System.EventHandler(this.Facial_Score_TextChanged);
            this.Facial_Score.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Facial_Score_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(303, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "ФИО";
            // 
            // Fam
            // 
            this.Fam.Location = new System.Drawing.Point(307, 60);
            this.Fam.MaxLength = 50;
            this.Fam.Name = "Fam";
            this.Fam.Size = new System.Drawing.Size(206, 31);
            this.Fam.TabIndex = 19;
            this.Fam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fam_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(303, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Телефон";
            // 
            // Ph
            // 
            this.Ph.Location = new System.Drawing.Point(307, 141);
            this.Ph.MaxLength = 11;
            this.Ph.Name = "Ph";
            this.Ph.Size = new System.Drawing.Size(206, 31);
            this.Ph.TabIndex = 21;
            this.Ph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ph_KeyPress);
            // 
            // buttonEditClient
            // 
            this.buttonEditClient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonEditClient.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditClient.Location = new System.Drawing.Point(6, 80);
            this.buttonEditClient.Name = "buttonEditClient";
            this.buttonEditClient.Size = new System.Drawing.Size(323, 32);
            this.buttonEditClient.TabIndex = 22;
            this.buttonEditClient.Text = "Изменить плательщика";
            this.buttonEditClient.UseVisualStyleBackColor = false;
            this.buttonEditClient.Click += new System.EventHandler(this.buttonEditClient_Click);
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDeleteClient.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteClient.Location = new System.Drawing.Point(6, 128);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(323, 32);
            this.buttonDeleteClient.TabIndex = 23;
            this.buttonDeleteClient.Text = "Удалить плательщика";
            this.buttonDeleteClient.UseVisualStyleBackColor = false;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // buttonReturnMenu
            // 
            this.buttonReturnMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonReturnMenu.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReturnMenu.Location = new System.Drawing.Point(900, 4);
            this.buttonReturnMenu.Name = "buttonReturnMenu";
            this.buttonReturnMenu.Size = new System.Drawing.Size(87, 39);
            this.buttonReturnMenu.TabIndex = 24;
            this.buttonReturnMenu.Text = "Меню";
            this.buttonReturnMenu.UseVisualStyleBackColor = false;
            this.buttonReturnMenu.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddClient);
            this.groupBox1.Controls.Add(this.buttonEditClient);
            this.groupBox1.Controls.Add(this.buttonDeleteClient);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(772, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 185);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Функции";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Mod);
            this.groupBox2.Controls.Add(this.Ph);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Square_M);
            this.groupBox2.Controls.Add(this.Facial_Score);
            this.groupBox2.Controls.Add(this.Fam);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(5, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 185);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Mod
            // 
            this.Mod.FormattingEnabled = true;
            this.Mod.Location = new System.Drawing.Point(11, 60);
            this.Mod.Name = "Mod";
            this.Mod.Size = new System.Drawing.Size(266, 31);
            this.Mod.TabIndex = 22;
            this.Mod.SelectedIndexChanged += new System.EventHandler(this.Mod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(545, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Площадь";
            // 
            // Square_M
            // 
            this.Square_M.Location = new System.Drawing.Point(549, 59);
            this.Square_M.MaxLength = 50;
            this.Square_M.Name = "Square_M";
            this.Square_M.Size = new System.Drawing.Size(206, 31);
            this.Square_M.TabIndex = 19;
            this.Square_M.TextChanged += new System.EventHandler(this.Square_M_TextChanged);
            this.Square_M.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Square_M_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(702, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 27;
            this.textBox1.Visible = false;
            // 
            // Client_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 623);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReturnMenu);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Client_table";
            this.Text = "Учет оплаты ЖКХ | База плательщиков";
            this.Load += new System.EventHandler(this.Client_table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Facial_Score;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Fam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Ph;
        private System.Windows.Forms.Button buttonEditClient;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button buttonReturnMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Square_M;
        private System.Windows.Forms.ComboBox Mod;
    }
}