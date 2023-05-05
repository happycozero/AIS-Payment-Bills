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
using Payment_Bills;

namespace Payment_Bills
{
    public partial class Customers : Form
    {
        string ID = "";

        public Customers()
        {
            InitializeComponent();
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void empl_Load(object sender, EventArgs e)
        {
            com1.DropDownStyle = ComboBoxStyle.DropDownList;
            Fill();
            UpdatedataGridViewBooks();
            
            com1.Items.Add("Диспетчер");
            com1.Items.Add("Администратор");
        }

        public void Fill()
        {
            string s = nuls.str;
            string con12 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn12 = new OleDbConnection(con12); // создаем подключение
            DataTable dt12 = new DataTable(); // создаем таблицу

            oleDbConn12.Open(); // открываем подключение

            OleDbCommand sql = new OleDbCommand("SELECT full_name FROM Customers WHERE login = '" + s + "';");
            sql.Connection = oleDbConn12; // привязываем запрос к коннекту

            OleDbDataAdapter da12 = new OleDbDataAdapter(sql);
            da12.Fill(dt12);

            sql.ExecuteNonQuery(); // выполнение
            oleDbConn12.Close();
        }

        public void UpdatedataGridViewBooks()
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            AccessDatabase accessDatabase = new AccessDatabase(con1);

            try
            {
                accessDatabase.OpenConnection();
                DataTable dt1 = accessDatabase.ExecuteQuery("SELECT * FROM Customers");
                dt1.Columns[1].ColumnName = "ФИО";
                dt1.Columns[2].ColumnName = "Телефон";
                dt1.Columns[3].ColumnName = "Адрес";
                dt1.Columns[4].ColumnName = "Описание";
                dt1.Columns[5].ColumnName = "Логин";
                dt1.Columns[6].ColumnName = "Пароль";

                dgv.DataSource = dt1;
                dgv.Columns[0].Visible = false;
                dgv.Columns[7].Visible = false;

                // Автоматически подстраиваем ширину столбцов под содержимое
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                button3.Enabled = false;
                button4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                accessDatabase.CloseConnection();
            }
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

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;

            try
            {
                ID = dgv.SelectedCells[0].Value.ToString();

                string query = "SELECT * FROM Customers Where id = " + Convert.ToInt32(ID) + ";";
                AccessDatabase accessDb = new AccessDatabase("Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;");
                accessDb.OpenConnection();
                DataTable dt = accessDb.ExecuteQuery(query);
                accessDb.CloseConnection();

                fio.Text = dt.Rows[0]["full_name"].ToString();
                phon.Text = dt.Rows[0]["phone"].ToString();
                spec.Text = dt.Rows[0]["address"].ToString();
                addr.Text = dt.Rows[0]["specialty"].ToString();
                log.Text = dt.Rows[0]["login"].ToString();
                pass.Text = dt.Rows[0]["password"].ToString();

                if (dt.Rows[0]["state"].ToString() == "1")
                {
                    com1.Text = "Администратор";
                }
                if (dt.Rows[0]["state"].ToString() == "0")
                {
                    com1.Text = "Диспетчер";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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

                    string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                    AccessDatabase accessDatabase = new AccessDatabase(con1);
                    accessDatabase.OpenConnection();

                    string query = "INSERT INTO Customers ([id], [full_name], [phone], [address], [specialty], [login], [password], [state]) VALUES (" + id + ",'" + fio1 + "','" + phon1 + "', '" + addr1 + "', '" + spec1 + "', '" + log1 + "', '" + pass1 + "', " + stat + ");";

                    accessDatabase.ExecuteNonQuery(query);

                    accessDatabase.CloseConnection();

                    MessageBox.Show("Пользователь добавлен в базу ", "Сообщение пользователю", MessageBoxButtons.OK);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
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

                    string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                    AccessDatabase accessDatabase = new AccessDatabase(con1);
                    accessDatabase.OpenConnection();

                    string query = "UPDATE Customers SET [full_name] = '" + fio1 + "', [phone] = '" + phon1 + "', [address] = '" + addr1 + "', [specialty] = '" + spec1 + "', [login] = '" + log1 + "', [password] = '" + pass1 + "', [state] = " + stat + " WHERE [id] = " + Convert.ToInt32(ID) + ";";

                    accessDatabase.ExecuteNonQuery(query);

                    accessDatabase.CloseConnection();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string con1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                using (OleDbConnection oleDbConn1 = new OleDbConnection(con1))
                {
                    oleDbConn1.Open();
                    using (OleDbCommand sql1 = new OleDbCommand("DELETE FROM Customers WHERE id=?", oleDbConn1))
                    {
                        sql1.Parameters.AddWithValue("@id", Convert.ToInt32(ID));
                        sql1.ExecuteNonQuery();
                    }
                }

                UpdatedataGridViewBooks();

                fio.Clear();
                phon.Clear();
                spec.Clear();
                addr.Clear();
                log.Clear();
                pass.Clear();
                com1.Text = "";
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверный формат ID: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Employ_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
