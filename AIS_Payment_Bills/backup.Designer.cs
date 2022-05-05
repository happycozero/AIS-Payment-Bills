namespace Payment_Bills
{
    partial class Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup));
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFileSelection = new System.Windows.Forms.Button();
            this.buttonReturnMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(13, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 88);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сохранить архив";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonFileSelection
            // 
            this.buttonFileSelection.BackColor = System.Drawing.Color.LemonChiffon;
            this.buttonFileSelection.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFileSelection.Location = new System.Drawing.Point(13, 119);
            this.buttonFileSelection.Name = "buttonFileSelection";
            this.buttonFileSelection.Size = new System.Drawing.Size(245, 48);
            this.buttonFileSelection.TabIndex = 4;
            this.buttonFileSelection.Text = "Выбрать файл";
            this.buttonFileSelection.UseVisualStyleBackColor = false;
            this.buttonFileSelection.Click += new System.EventHandler(this.buttonFileSelection_Click);
            // 
            // buttonReturnMenu
            // 
            this.buttonReturnMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonReturnMenu.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReturnMenu.Location = new System.Drawing.Point(163, 12);
            this.buttonReturnMenu.Name = "buttonReturnMenu";
            this.buttonReturnMenu.Size = new System.Drawing.Size(95, 34);
            this.buttonReturnMenu.TabIndex = 7;
            this.buttonReturnMenu.Text = "Меню";
            this.buttonReturnMenu.UseVisualStyleBackColor = false;
            this.buttonReturnMenu.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(108, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Путь";

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFileSelection;
        private System.Windows.Forms.Button buttonReturnMenu;
        private System.Windows.Forms.Label label1;
    }
}