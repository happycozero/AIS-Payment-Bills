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
    public partial class Clients : Form
    {
        string ID = "";

        public Clients()
        {
            InitializeComponent();
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            if (string.IsNullOrWhiteSpace(Mod.Text) || string.IsNullOrWhiteSpace(Facial_Score.Text) || string.IsNullOrWhiteSpace(Fam.Text) || string.IsNullOrWhiteSpace(Ph.Text) || string.IsNullOrWhiteSpace(Square_M.Text))
            {
            MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
            return;
            }
                Random rnd = new Random();
                int id = rnd.Next(8, 50000000);

                string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                using (OleDbConnection oleDbConn = new OleDbConnection(con))
                {
                    oleDbConn.Open();
                    using (OleDbCommand sql = new OleDbCommand("INSERT INTO Client (id, management, facial_score, full_name, phone, square) VALUES (@id, @organ, @own, @activ, @addr, @square)", oleDbConn))
                    {
                        sql.Parameters.AddWithValue("@id", id);
                        sql.Parameters.AddWithValue("@organ", Mod.Text.Trim());
                        sql.Parameters.AddWithValue("@own", Facial_Score.Text.Trim());
                        sql.Parameters.AddWithValue("@activ", Fam.Text.Trim());
                        sql.Parameters.AddWithValue("@addr", Ph.Text.Trim());
                        sql.Parameters.AddWithValue("@square", Square_M.Text.Trim());
                        sql.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Запись в базу добавлена", "Сообщение пользователю", MessageBoxButtons.OK);
                UpdatedataGridViewScore();

                Mod.SelectedIndex = - 1;
                Facial_Score.Clear();
                Fam.Clear();
                Ph.Clear();
                Square_M.Clear();
                }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении записи в базу: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Fill()
        {
            string s = nuls.str;
            string con12 = "Data Source=db.mdb;"; // строка подключения
            try
            {
                using (OleDbConnection connection = new OleDbConnection(con12))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand("SELECT full_name FROM Customers WHERE login = @login", connection))
                    {
                        command.Parameters.AddWithValue("@login", s);
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dt12 = new DataTable(); // создаем таблицу
                            adapter.Fill(dt12);
                            if (dt12.Rows.Count > 0)
                            {
                                string fullName = dt12.Rows[0]["full_name"].ToString();
                                // Делайте что-то со значением полного имени
                            }
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                // Обрабатываем ошибку подключения к базе данных или выполнения запроса
                MessageBox.Show("Произошла ошибка при работе с базой данных: " + ex.Message);
            }

        }
        public void UpdatedataGridViewScore()
        {
            try
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                DataTable dataTable = new DataTable();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Client;", connection);
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }

                dataTable.Columns["management"].ColumnName = "Управляющая компания";
                dataTable.Columns["facial_score"].ColumnName = "Лицевой счет";
                dataTable.Columns["full_name"].ColumnName = "ФИО";
                dataTable.Columns["phone"].ColumnName = "Телефон";
                dataTable.Columns["square"].ColumnName = "Площадь";

                dgv.DataSource = dataTable;
                dgv.Columns[0].Visible = false;

                // Автоматически подгоняем размер столбцов под содержимое
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mod.Text == "" || Facial_Score.Text == "" || Fam.Text == "" || Ph.Text == "" || Square_M.Text == "")
                {
                    MessageBox.Show("Ошибка! Заполните все поля!", "Сообщение", MessageBoxButtons.OK);
                }
                else
                {
                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand("UPDATE Client SET management=@management, facial_score=@facial_score, full_name=@full_name, phone=@phone, square=@square WHERE id=@id;", connection);
                        command.Parameters.AddWithValue("@management", Mod.Text);
                        command.Parameters.AddWithValue("@facial_score", Facial_Score.Text);
                        command.Parameters.AddWithValue("@full_name", Fam.Text);
                        command.Parameters.AddWithValue("@phone", Ph.Text);
                        command.Parameters.AddWithValue("@square", Square_M.Text);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(ID));
                        command.ExecuteNonQuery();
                    }

                    UpdatedataGridViewScore();

                    Mod.Text = "";
                    Facial_Score.Text = "";
                    Fam.Text = "";
                    Ph.Text = "";
                    Square_M.Text = "";

                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                button3.Enabled = true;
                button4.Enabled = true;
                ID = dgv.SelectedCells[0].Value.ToString();

                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                DataTable dataTable = new DataTable();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Client WHERE id=@id;", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(ID));
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }

                Mod.Text = dataTable.Rows[0]["management"].ToString();
                Facial_Score.Text = dataTable.Rows[0]["facial_score"].ToString();
                Fam.Text = dataTable.Rows[0]["full_name"].ToString();
                Ph.Text = dataTable.Rows[0]["phone"].ToString();
                Square_M.Text = dataTable.Rows[0]["square"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                button4.Enabled = false;
                button3.Enabled = false;
                ID = dgv.SelectedCells[0].Value.ToString();

                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("DELETE FROM Client WHERE id=@id;", connection);
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(ID));
                    command.ExecuteNonQuery();
                }

                UpdatedataGridViewScore();

                Mod.Text = "";
                Facial_Score.Text = "";
                Fam.Text = "";
                Ph.Text = "";
                Square_M.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void Mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || (e.KeyChar == ' ') || (e.KeyChar == '.') || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void Facial_Score_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void Fam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'а') && (e.KeyChar <= 'я')) || ((e.KeyChar >= 'А') && (e.KeyChar <= 'Я')) || (e.KeyChar == ' ') || (e.KeyChar == '.') || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void Ph_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void Square_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)) return;
            else
                e.Handled = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Facial_Score.Text == "")
                {
                    MessageBox.Show("Ошибка! Заполните поле 'Лицевой счет'");
                }
                else
                {

                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                    DataTable dataTable = new DataTable();

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand("SELECT * FROM Client WHERE facial_score=@facial_score;", connection);
                        command.Parameters.AddWithValue("@facial_score", Convert.ToInt32(Facial_Score.Text));
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }

                    dataTable.Columns["management"].ColumnName = "Управляющая компания";
                    dataTable.Columns["facial_score"].ColumnName = "Лицевой счет";
                    dataTable.Columns["full_name"].ColumnName = "ФИО";
                    dataTable.Columns["phone"].ColumnName = "Телефон";
                    dataTable.Columns["square"].ColumnName = "Площадь";

                    dgv.DataSource = dataTable;
                    dgv.Columns[0].Visible = false;

                    // Автоматически подгоняем размер столбцов под содержимое
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // Установка максимальной длины для различных полей
            Mod.MaxLength = 40;
            Facial_Score.MaxLength = 9;
            Fam.MaxLength = 50;
            Ph.MaxLength = 11;
            Square_M.MaxLength = 4;

            // Отключение возможности редактирования textBox2

            try
            {
                // Установка строки подключения к базе данных
                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";

                // Создание объекта DataTable для хранения данных из таблицы Client
                DataTable dt1 = new DataTable();

                using (OleDbConnection oleDbConn1 = new OleDbConnection(con1))
                {
                    oleDbConn1.Open();

                    // Создание команды для выборки всех данных из таблицы Client
                    using (OleDbCommand sql1 = new OleDbCommand("SELECT * FROM Client;", oleDbConn1))
                    {
                        // Выполнение команды на сервере и получение данных в объект DataTable
                        using (OleDbDataReader reader = sql1.ExecuteReader())
                        {
                            dt1.Load(reader);
                        }
                    }

                    dt1.Columns["management"].ColumnName = "Управляющая компания";
                    dt1.Columns["facial_score"].ColumnName = "Лицевой счет";
                    dt1.Columns["full_name"].ColumnName = "ФИО";
                    dt1.Columns["phone"].ColumnName = "Телефон";
                    dt1.Columns["square"].ColumnName = "Площадь";

                    dgv.DataSource = dt1;
                    dgv.Columns[0].Visible = false;

                    // Автоматически подгоняем размер столбцов под содержимое
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    // Запрет добавления новых строк в DataGridView и отключение кнопок button3 и button4
                    dgv.AllowUserToAddRows = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения, вывод сообщения об ошибке
                MessageBox.Show("Произошла ошибка при работе с базой данных: " + ex.Message);
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
