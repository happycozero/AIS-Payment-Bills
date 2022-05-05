namespace Payment_Bills
{
    partial class Service
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonReturnMenu = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.phon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fio = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteService = new System.Windows.Forms.Button();
            this.buttonEditService = new System.Windows.Forms.Button();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(264, 1);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 21);
            this.textBox2.TabIndex = 42;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(598, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(82, 37);
            this.buttonExit.TabIndex = 40;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReturnMenu
            // 
            this.buttonReturnMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonReturnMenu.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReturnMenu.Location = new System.Drawing.Point(480, 3);
            this.buttonReturnMenu.Name = "buttonReturnMenu";
            this.buttonReturnMenu.Size = new System.Drawing.Size(82, 37);
            this.buttonReturnMenu.TabIndex = 39;
            this.buttonReturnMenu.Text = "Меню";
            this.buttonReturnMenu.UseVisualStyleBackColor = false;
            this.buttonReturnMenu.Click += new System.EventHandler(this.button5_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 64);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(304, 414);
            this.dgv.TabIndex = 43;
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            // 
            // phon
            // 
            this.phon.Location = new System.Drawing.Point(107, 89);
            this.phon.MaxLength = 10;
            this.phon.Name = "phon";
            this.phon.Size = new System.Drawing.Size(194, 29);
            this.phon.TabIndex = 47;
            this.phon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phon_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 46;
            this.label3.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 45;
            this.label1.Text = "Услуга";
            // 
            // fio
            // 
            this.fio.Location = new System.Drawing.Point(107, 49);
            this.fio.MaxLength = 50;
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(194, 29);
            this.fio.TabIndex = 44;
            this.fio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fio_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fio);
            this.groupBox1.Controls.Add(this.phon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(350, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 157);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDeleteService.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteService.Location = new System.Drawing.Point(420, 341);
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.Size = new System.Drawing.Size(201, 32);
            this.buttonDeleteService.TabIndex = 51;
            this.buttonDeleteService.Text = "Удалить услугу";
            this.buttonDeleteService.UseVisualStyleBackColor = false;
            this.buttonDeleteService.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonEditService
            // 
            this.buttonEditService.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonEditService.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditService.Location = new System.Drawing.Point(420, 293);
            this.buttonEditService.Name = "buttonEditService";
            this.buttonEditService.Size = new System.Drawing.Size(201, 32);
            this.buttonEditService.TabIndex = 50;
            this.buttonEditService.Text = "Изменить услугу";
            this.buttonEditService.UseVisualStyleBackColor = false;
            this.buttonEditService.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAddService
            // 
            this.buttonAddService.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddService.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddService.Location = new System.Drawing.Point(420, 246);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(201, 32);
            this.buttonAddService.TabIndex = 49;
            this.buttonAddService.Text = "Добавить услугу";
            this.buttonAddService.UseVisualStyleBackColor = false;
            this.buttonAddService.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 52;
            this.textBox1.Visible = false;
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 493);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDeleteService);
            this.Controls.Add(this.buttonEditService);
            this.Controls.Add(this.buttonAddService);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReturnMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Service";
            this.Text = "Учет оплаты ЖКХ | Услуги ЖКХ";
            this.Load += new System.EventHandler(this.service_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonReturnMenu;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox phon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.Button buttonEditService;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.TextBox textBox1;
    }
}