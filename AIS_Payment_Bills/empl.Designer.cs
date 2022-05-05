namespace Payment_Bills
{
    partial class empl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empl));
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fio = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.com1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button4.Location = new System.Drawing.Point(788, 498);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(289, 32);
            this.button4.TabIndex = 40;
            this.button4.Text = "Удалить пользователя";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button3.Location = new System.Drawing.Point(788, 450);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(289, 32);
            this.button3.TabIndex = 39;
            this.button3.Text = "Редактировать пользователя";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // addr
            // 
            this.addr.Location = new System.Drawing.Point(503, 436);
            this.addr.MaxLength = 150;
            this.addr.Multiline = true;
            this.addr.Name = "addr";
            this.addr.Size = new System.Drawing.Size(178, 58);
            this.addr.TabIndex = 38;
            this.addr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addr_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 37;
            this.label5.Text = "Адрес";
            // 
            // spec
            // 
            this.spec.Location = new System.Drawing.Point(503, 390);
            this.spec.MaxLength = 20;
            this.spec.Name = "spec";
            this.spec.Size = new System.Drawing.Size(178, 28);
            this.spec.TabIndex = 36;
            this.spec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spec_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Описание";
            // 
            // phon
            // 
            this.phon.Location = new System.Drawing.Point(137, 431);
            this.phon.MaxLength = 11;
            this.phon.Name = "phon";
            this.phon.Size = new System.Drawing.Size(194, 28);
            this.phon.TabIndex = 34;
            this.phon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phon_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "Телефон";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "ФИО";
            // 
            // fio
            // 
            this.fio.Location = new System.Drawing.Point(137, 388);
            this.fio.MaxLength = 50;
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(194, 28);
            this.fio.TabIndex = 31;
            this.fio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fio_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.Location = new System.Drawing.Point(788, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(289, 32);
            this.button2.TabIndex = 30;
            this.button2.Text = "Добавить пользователя";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 333);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(356, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 21);
            this.textBox2.TabIndex = 44;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(977, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 42;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(826, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 37);
            this.button5.TabIndex = 41;
            this.button5.Text = "Меню";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(137, 477);
            this.log.MaxLength = 20;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(194, 28);
            this.log.TabIndex = 46;
            this.log.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.log_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 45;
            this.label2.Text = "Логин";
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(137, 521);
            this.pass.MaxLength = 20;
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(194, 28);
            this.pass.TabIndex = 48;
            this.pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pass_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 24);
            this.label6.TabIndex = 47;
            this.label6.Text = "Пароль";
            // 
            // com1
            // 
            this.com1.FormattingEnabled = true;
            this.com1.Location = new System.Drawing.Point(503, 518);
            this.com1.Name = "com1";
            this.com1.Size = new System.Drawing.Size(178, 30);
            this.com1.TabIndex = 49;
            this.com1.SelectedIndexChanged += new System.EventHandler(this.com1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 521);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 50;
            this.label7.Text = "Статус";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 51;
            this.textBox1.Visible = false;
            // 
            // empl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1092, 598);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.com1);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.addr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "empl";
            this.Text = "Payment_Bills";
            this.Load += new System.EventHandler(this.empl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox addr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox spec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox com1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}