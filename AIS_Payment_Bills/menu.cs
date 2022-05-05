using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Ionic.Zip;
using AIS_Payment_Bills;

namespace Payment_Bills
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            if (nuls.state == 0)
            {
                button3.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
            }
            fil();
            textBox2.ReadOnly = true;
            textBox1.Enabled = false;
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();
            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Service_table;");
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            da1.Fill(dt1);

            dt1.Columns["service"].ColumnName = "Услуга";
            dt1.Columns["cost"].ColumnName = "Цена";

            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 60;


            oleDbConn1.Close();

            dataGridView1.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Client_table Client = new Client_table();
            this.Visible = false;
            Client.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();
            this.Visible = false;
            ed.ShowDialog();
        }

        public void fil()
        {
            textBox2.Text = nuls.dat;
            string s = nuls.str;
            string con12 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn12 = new OleDbConnection(con12); // создаем подключение
            DataTable dt12 = new DataTable(); // создаем таблицу
            oleDbConn12.Open(); // открываем подкл
            OleDbCommand sql = new OleDbCommand("SELECT full_name FROM Employee_table WHERE login = '" + s + "';");
            OleDbDataAdapter da12 = new OleDbDataAdapter(sql);
            sql.Connection = oleDbConn12; // привязываем запрос к конекту
            sql.ExecuteNonQuery(); //выполнение
            da12.Fill(dt12);
            textBox1.Text = Convert.ToString(dt12.Rows[0].ItemArray.GetValue(0));
            oleDbConn12.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receipt rec = new Receipt();
            this.Visible = false;
            rec.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reports rec = new reports();
            this.Visible = false;
            rec.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Employ empl = new Employ();
            this.Visible = false;
            empl.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            this.Visible = false;
            service.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            this.Visible = false;
            backup.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
