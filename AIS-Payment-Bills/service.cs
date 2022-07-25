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
using System.IO;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace Payment_Bills
{
    public partial class Service : MetroForm
    {
        string ID = "";
        public Service()
        {
            InitializeComponent();
        }

        private void service_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox1.Enabled = false;
            fil();
            UpdatedataGridViewBooks();
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

        public void UpdatedataGridViewBooks()
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();
            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Service_table;");
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            da1.Fill(dt1);

            dt1.Columns[1].ColumnName = "Услуга";
            dt1.Columns[2].ColumnName = "Цена";

            button3.Enabled = false;
            button4.Enabled = false;
            dgv.DataSource = dt1;
            dgv.Columns[0].Visible = false;
 
            oleDbConn1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            ID = dgv.SelectedCells[0].Value.ToString();

            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();

            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Service_table Where id = " + Convert.ToInt32(ID) + ";");
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();

            da1.Fill(dt1);

            fio.Text = dt1.Rows[0].ItemArray.GetValue(1).ToString();
            phon.Text = dt1.Rows[0].ItemArray.GetValue(2).ToString();

            oleDbConn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fio.Text == "" || phon.Text == "")
            {
                MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                string fio1 = fio.Text.ToString();
                string phon1 = phon.Text.ToString();

                int id = 0;
                Random rnd = new Random();
                id = rnd.Next(8, 50000000);

                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                OleDbConnection oleDbConn = new OleDbConnection(con);
                oleDbConn.Open();
                OleDbCommand sql = new OleDbCommand("INSERT INTO Service_table ([id], [service], [cost]) VALUES (" + id + ",'" + fio1 + "'," + phon1 + ");");
                sql.Connection = oleDbConn;
                sql.ExecuteNonQuery();
                oleDbConn.Close();
                MessageBox.Show("Запись в базу добавлена", "Сообщение пользователю", MessageBoxButtons.OK);
                UpdatedataGridViewBooks();
                fio.Clear();
                phon.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fio.Text == "" || phon.Text == "")
            {
                MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                string fio1 = fio.Text.ToString();
                string phon1 = phon.Text.ToString();

                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                OleDbConnection oleDbConn = new OleDbConnection(con);
                oleDbConn.Open();
                OleDbCommand sql = new OleDbCommand("UPDATE Service_table SET [service] = '" + fio1 + "', [cost] = '" + phon1 + "' WHERE [id] = " + Convert.ToInt32(ID) + ";"); // создаем запрос
                sql.Connection = oleDbConn;
                sql.ExecuteNonQuery();

                oleDbConn.Close();

                UpdatedataGridViewBooks();

                fio.Clear();
                phon.Clear();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();

            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("DELETE * FROM Service_table Where id = " + Convert.ToInt32(ID) + ";");
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();

            da1.Fill(dt1);

            oleDbConn1.Close();

            UpdatedataGridViewBooks();

            fio.Clear();
            phon.Clear();
        }

        private void fio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || (e.KeyChar == ' ') || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void phon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
