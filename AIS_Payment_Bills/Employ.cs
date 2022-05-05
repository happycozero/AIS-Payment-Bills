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

namespace Payment_Bills
{
    public partial class Employ : Form
    {
        string ID = "";
        public Employ()
        {
            InitializeComponent();
        }

        private void empl_Load(object sender, EventArgs e)
        {
            com1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.ReadOnly = true;
            textBox1.Enabled = false;
            fil();
            UpdatedataGridViewBooks();
            
            com1.Items.Add("Диспетчер");
            com1.Items.Add("Администратор");
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
            OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Employee_table;");
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            da1.Fill(dt1);
            
            dt1.Columns[1].ColumnName = "ФИО";
            dt1.Columns[2].ColumnName = "Телефон";
            dt1.Columns[3].ColumnName = "Адрес";
            dt1.Columns[4].ColumnName = "Специальность";
            dt1.Columns[5].ColumnName = "Логин";
            dt1.Columns[6].ColumnName = "Пароль";
            


            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            button3.Enabled = false;
            button4.Enabled = false;
            oleDbConn1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            ID = dataGridView1.SelectedCells[0].Value.ToString();

            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();

            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Employee_table Where id = " + Convert.ToInt32(ID) + ";");
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();

            da1.Fill(dt1);

            fio.Text = dt1.Rows[0].ItemArray.GetValue(1).ToString();
            phon.Text = dt1.Rows[0].ItemArray.GetValue(2).ToString();
            spec.Text = dt1.Rows[0].ItemArray.GetValue(4).ToString();
            addr.Text = dt1.Rows[0].ItemArray.GetValue(3).ToString();
            log.Text = dt1.Rows[0].ItemArray.GetValue(5).ToString();
            pass.Text = dt1.Rows[0].ItemArray.GetValue(6).ToString();

            if (dt1.Rows[0].ItemArray.GetValue(7).ToString() == "1")
            {
                com1.Text = "Администратор";
            }
            if (dt1.Rows[0].ItemArray.GetValue(7).ToString() == "0")
            {
                com1.Text = "Диспетчер";
            }
            

            oleDbConn1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fio.Text == "" || phon.Text == "" || spec.Text == "" || addr.Text == "" || log.Text == "" || pass.Text == "" || com1.Text == "")
            {
                MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                string fio1 = fio.Text.ToString();
                string phon1 = phon.Text.ToString();
                string spec1 = spec.Text.ToString();
                string addr1 = addr.Text.ToString();
                string log1 = log.Text.ToString();
                string pass1 = pass.Text.ToString();
                int stat = 0;
                if (com1.Text == "Администратор")
                {
                    stat = 1;
                }
                if (com1.Text == "Диспетчер")
                {
                    stat = 0;
                }
                int id = 0;
                Random rnd = new Random();
                id = rnd.Next(8, 50000000);

                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                OleDbConnection oleDbConn = new OleDbConnection(con);
                oleDbConn.Open();
                OleDbCommand sql = new OleDbCommand("INSERT INTO Employee_table ([id], [full_name], [phone], [address], [specialty], [login], [password], [state]) VALUES (" + id + ",'" + fio1 + "','" + phon1 + "', '" + addr1 + "', '" + spec1 + "', '" + log1 + "', '" + pass1 + "', " + stat + ");");
                sql.Connection = oleDbConn;
                sql.ExecuteNonQuery();
                oleDbConn.Close();
                MessageBox.Show("Запись в базу добавлена", "Сообщение пользователю", MessageBoxButtons.OK);
                UpdatedataGridViewBooks();
                fio.Clear();
                phon.Clear();
                spec.Clear();
                addr.Clear();
                log.Clear();
                pass.Clear();
                com1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fio.Text == "" || phon.Text == "" || spec.Text == "" || addr.Text == "" || log.Text == "" || pass.Text == "" || com1.Text == "")
            {
                MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                string fio1 = fio.Text.ToString();
                string phon1 = phon.Text.ToString();
                string spec1 = spec.Text.ToString();
                string addr1 = addr.Text.ToString();
                string log1 = log.Text.ToString();
                string pass1 = pass.Text.ToString();
                int stat = 0;
                if (com1.Text == "Администратор")
                {
                    stat = 1;
                }
                if (com1.Text == "Диспетчер")
                {
                    stat = 0;
                }
                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                OleDbConnection oleDbConn = new OleDbConnection(con);
                oleDbConn.Open();
                OleDbCommand sql = new OleDbCommand("UPDATE Employee_table SET [full_name] = '" + fio1 + "', [phone] = '" + phon1 + "', [address] = '" + addr1 + "', [specialty] = '" + spec1 + "', [login] = '" + log1 + "', [password] = '" + pass1 + "', [state] = " + stat + " WHERE [id] = " + Convert.ToInt32(ID) + ";"); // создаем запрос
                sql.Connection = oleDbConn;
                sql.ExecuteNonQuery();

                oleDbConn.Close();

                UpdatedataGridViewBooks();

                fio.Clear();
                phon.Clear();
                spec.Clear();
                addr.Clear();
                log.Clear();
                pass.Clear();
                com1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();

            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("DELETE * FROM Employee_table Where id = " + Convert.ToInt32(ID) + ";");
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();

            da1.Fill(dt1);

            oleDbConn1.Close();

            UpdatedataGridViewBooks();

            fio.Clear();
            phon.Clear();
            spec.Clear();
            addr.Clear();
            log.Clear();
            pass.Clear();
            com1.Text = "";
        }

        private void fio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || (e.KeyChar == ' ') || (e.KeyChar == '.') || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void phon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void log_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || ((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')))
                e.Handled = true;
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || ((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')))
                e.Handled = true;
        }

        private void spec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || (e.KeyChar == ' ') || (e.KeyChar == '-') || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void addr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || ((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8) || (e.KeyChar == '.')) return;
            else
                e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void com1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
