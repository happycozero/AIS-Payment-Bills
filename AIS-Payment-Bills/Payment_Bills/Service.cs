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
using Payment_Bills;

namespace Payment_Bills
{
    public partial class Service : Form
    {
        string ID = "";

        public Service()
        {
            InitializeComponent();
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void service_Load(object sender, EventArgs e)
        {
            Fill();
            UpdatedataGridViewBooks();
        }

        public void Fill()
        {
            try
            {
                string s = nuls.str;
                string con12 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                AccessDatabase accessDatabase = new AccessDatabase(con12); // создаем объект AccessDatabase
                accessDatabase.OpenConnection(); // открываем соединение с базой данных

                DataTable dt12 = accessDatabase.ExecuteQuery("SELECT full_name FROM Customers WHERE login = '" + s + "';");

                accessDatabase.CloseConnection(); // закрываем соединение с базой данных

                if (dt12.Rows.Count > 0)
                {
                    string fullName = dt12.Rows[0]["full_name"].ToString();
                    // использование полученного значения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdatedataGridViewBooks()
        {
            try
            {
                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                AccessDatabase accessDatabase = new AccessDatabase(con1); // создаем объект AccessDatabase
                accessDatabase.OpenConnection(); // открываем соединение с базой данных

                DataTable dt1 = accessDatabase.ExecuteQuery("SELECT * FROM Service;");

                accessDatabase.CloseConnection(); // закрываем соединение с базой данных

                dt1.Columns[1].ColumnName = "Услуга";
                dt1.Columns[2].ColumnName = "Цена";

                button3.Enabled = false;
                button4.Enabled = false;
                dgv.DataSource = dt1;
                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                button3.Enabled = true;
                button4.Enabled = true;
                ID = dgv.SelectedCells[0].Value.ToString();

                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                AccessDatabase accessDatabase = new AccessDatabase(con1); // создаем объект AccessDatabase
                accessDatabase.OpenConnection(); // открываем соединение с базой данных

                DataTable dt1 = accessDatabase.ExecuteQuery("SELECT * FROM Service Where id = " + Convert.ToInt32(ID) + ";");

                accessDatabase.CloseConnection();  // закрываем соединение с базой данных

                fio.Text = dt1.Rows[0].ItemArray.GetValue(1).ToString();
                phon.Text = dt1.Rows[0].ItemArray.GetValue(2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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

                    string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                    AccessDatabase accessDatabase = new AccessDatabase(con); // создаем объект AccessDatabase
                    accessDatabase.OpenConnection(); // открываем соединение с базой данных

                    string query = "INSERT INTO Service ([id], [service], [cost]) VALUES (" + id + ", '" + fio1 + "', " + phon1 + ")";
                    accessDatabase.ExecuteNonQuery(query);

                    accessDatabase.CloseConnection(); // закрываем соединение с базой данных

                    MessageBox.Show("Запись в базу добавлена", "Сообщение пользователю", MessageBoxButtons.OK);
                    UpdatedataGridViewBooks();
                    fio.Clear();
                    phon.Clear();
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
                if (fio.Text == "" || phon.Text == "")
                {
                    MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
                }
                else
                {
                    string fio1 = fio.Text.ToString();
                    string phon1 = phon.Text.ToString();

                    string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                    AccessDatabase accessDatabase = new AccessDatabase(con); // создаем объект AccessDatabase
                    accessDatabase.OpenConnection(); // открываем соединение с базой данных

                    string query = "UPDATE Service SET [service] = '" + fio1 + "', [cost] = '" + phon1 + "' WHERE [id] = " + Convert.ToInt32(ID) + ";";
                    accessDatabase.ExecuteNonQuery(query);

                    accessDatabase.CloseConnection(); // закрываем соединение с базой данных

                    UpdatedataGridViewBooks();
                    fio.Clear();
                    phon.Clear();
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
                string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                AccessDatabase accessDatabase = new AccessDatabase(con);
                accessDatabase.OpenConnection();

                string query = "DELETE * FROM Service Where id = " + Convert.ToInt32(ID) + ";";
                accessDatabase.ExecuteNonQuery(query);

                accessDatabase.CloseConnection();

                UpdatedataGridViewBooks();
                fio.Clear();
                phon.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
