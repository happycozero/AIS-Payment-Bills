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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }
        string s = nuls.str;
        int ID = 0;
        int id_e = 0;
        int idr = 0;
        private void Edit_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox1.Enabled = false;
            com1.DropDownStyle = ComboBoxStyle.DropDownList;
            com2.DropDownStyle = ComboBoxStyle.DropDownList;
            com3.DropDownStyle = ComboBoxStyle.DropDownList;
            com4.DropDownStyle = ComboBoxStyle.DropDownList;
            com5.DropDownStyle = ComboBoxStyle.DropDownList;
            fil();
            if (nuls.state == 0)
            {
                button3.Visible = false;
            }
            string con12 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn12 = new OleDbConnection(con12); // создаем подключение
            DataTable dt12 = new DataTable(); // создаем таблицу
            oleDbConn12.Open(); // открываем подкл
            OleDbCommand sql = new OleDbCommand("SELECT id FROM Employee_table WHERE login = '" + s + "';");
            OleDbDataAdapter da12 = new OleDbDataAdapter(sql);
            sql.Connection = oleDbConn12; // привязываем запрос к конекту
            sql.ExecuteNonQuery(); //выполнение
            da12.Fill(dt12);
            id_e = Convert.ToInt32(dt12.Rows[0].ItemArray.GetValue(0));
            oleDbConn12.Close();

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Client_table", conn);
            OleDbDataReader DR1 = cmd.ExecuteReader();
            while (DR1.Read())
            {
                com1.Items.Add(DR1.GetValue(3).ToString() + " - " + DR1.GetValue(1).ToString());
            }
            conn.Close();

            //-------------------------------------------------------------

            com3.Items.Add("");

            OleDbConnection conn3 = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
            conn.Open();
            OleDbCommand cmd3 = new OleDbCommand("Select * from Client_table", conn);
            OleDbDataReader DR3 = cmd.ExecuteReader();
            while (DR3.Read())
            {
                com3.Items.Add(DR3.GetValue(3).ToString() + " - " + DR3.GetValue(1).ToString());
            }
            conn.Close();

            //-------------------------------------------------------------

            OleDbConnection conn2 = new OleDbConnection();
            conn2.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
            conn2.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select * from Service_table", conn2);
            OleDbDataReader DR2 = cmd2.ExecuteReader();
            while (DR2.Read())
            {
                com2.Items.Add(DR2.GetValue(1).ToString() + " - " + DR2.GetValue(2).ToString() + " руб");
            }
            conn2.Close();

            //-----------------------------------------------------------
            
            label11.Text = "Выберите запись, чтобы изменить статус";
            com5.Items.Add("");
            com5.Items.Add("Принятый");
            com5.Items.Add("Выполненный");
            UpdatedataGridViewBooks();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string reader = com1.SelectedItem.ToString();
                string book = com2.SelectedItem.ToString();

                string[] r = reader.Split('-');
                string[] b = book.Split('-');
                //------------------------------------------------------------------------------------------
                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                DataTable dt11 = new DataTable(); // создаем таблицу
                oleDbConn1.Open(); // открываем подключение к базе
                OleDbCommand sql1 = new OleDbCommand("SELECT id FROM Client_table WHERE full_name = '" + r[0] + "';"); // создаем запрос
                OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                sql1.Connection = oleDbConn1; // привязываем запрос к конекту
                sql1.ExecuteNonQuery(); //выполнение
                da1.Fill(dt11);
                int id_b = Convert.ToInt32(dt11.Rows[0].ItemArray.GetValue(0));
                oleDbConn1.Close();
                //----------------------------------------------------------------------------------------------
                string con12 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn12 = new OleDbConnection(con12); // создаем подключение
                DataTable dt12 = new DataTable(); // создаем таблицу
                oleDbConn12.Open(); // открываем подключение к базе
                OleDbCommand sql12 = new OleDbCommand("Select id from Service_table where service = '" + b[0] + "';"); // создаем запрос
                OleDbDataAdapter da12 = new OleDbDataAdapter(sql12);
                sql12.Connection = oleDbConn12; // привязываем запрос к конекту
                sql12.ExecuteNonQuery(); //выполнение
                da12.Fill(dt12);
                int id_r = Convert.ToInt32(dt12.Rows[0].ItemArray.GetValue(0));
                oleDbConn12.Close();
                //--------------------------------------------------------------------------------------
                int id = 0;
                Random rnd = new Random();
                id = rnd.Next(8, 5000000);
                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn = new OleDbConnection(con); // создаем подключение
                oleDbConn.Open(); // открываем подключение к базе
                OleDbCommand sql = new OleDbCommand("INSERT INTO Recording (id, id_client, id_eplo, id_service, data, status) VALUES (" + id + "," + id_b + "," + id_e + "," + id_r + ",'" + DateTime.Now.ToString("dd:MM:yyyy") + "', " + 0 + ");"); // создаем запрос
                sql.Connection = oleDbConn; // привязываем запрос к конекту
                sql.ExecuteNonQuery(); //выполнение
                oleDbConn.Close();
                UpdatedataGridViewBooks();
                MessageBox.Show("Машина записана", "Сообщение пользователю", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите машину и услугу", "Сообщение пользователю");
            }
            
        }

        public void UpdatedataGridViewBooks()
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
            DataTable dt1 = new DataTable(); // создаем таблицу 

            oleDbConn1.Open(); // открываем подключение к базе
            OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Марка, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИ_кл, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_кл, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status), (id) FROM Recording;"); // создаем запрос
            sql1.Connection = oleDbConn1; // привязываем запрос к конекту
            sql1.ExecuteNonQuery(); //выполнение

            // кол-во записей
            DataTable dt2_count = new DataTable();
            OleDbCommand sql2 = new OleDbCommand("SELECT COUNT(*) FROM Client_table;");
            sql2.Connection = oleDbConn1; // привязываем запрос к конекту
            sql2.ExecuteNonQuery(); //выполнение
            OleDbDataAdapter da2_count = new OleDbDataAdapter(sql1);
            da2_count.Fill(dt2_count);
            int count = dt2_count.Rows.Count;
            dgv.AllowUserToAddRows = false;
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            da1.Fill(dt1);
            dgv.DataSource = dt1;

            //устанавливает размеры колонок
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 170;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 165;
            dgv.Columns[5].Width = 155;
            dgv.Columns[6].Width = 170;
            dgv.Columns[7].Width = 105;
            dgv.Columns[8].Width = 75;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;
            int counts = dgv.DisplayedRowCount(true);
            for (int i = 0; i < counts; i++)
            {
                if (dt1.Rows[i].ItemArray.GetValue(9).ToString() == "1")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }


            oleDbConn1.Close();
            com4.Items.Clear();
            com3.Text = "";
            com1.Text = "";
            com2.Text = "";
            com4.Text = "";
            com5.Text = "";
            label12.Visible = false;
            com5.Visible = false;
            label11.Visible = true;
            if (nuls.state == 1)
            {
                button3.Enabled = false;
            }
            button4.Enabled = false;
            groupBox3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
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

        private void com3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com3.Text == "")
            {
                UpdatedataGridViewBooks();
            }
            else
            {
                string book = com3.SelectedItem.ToString();
                string[] r = book.Split('-');

                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn = new OleDbConnection(con); // создаем подключение
                DataTable dt = new DataTable(); // создаем таблицу
                oleDbConn.Open(); // открываем подключение к базе
                OleDbCommand sql = new OleDbCommand("SELECT id FROM Client_table WHERE full_name = '" + r[0] + "';"); // создаем запрос
                OleDbDataAdapter da = new OleDbDataAdapter(sql);
                sql.Connection = oleDbConn; // привязываем запрос к конекту
                sql.ExecuteNonQuery(); //выполнение
                da.Fill(dt);
                idr = Convert.ToInt32(dt.Rows[0].ItemArray.GetValue(0));
                oleDbConn.Close();

                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                DataTable dt1 = new DataTable(); // создаем таблицу 

                oleDbConn1.Open(); // открываем подключение к базе
                OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Марка, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИ_кл, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_кл, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status), (id) FROM Recording WHERE id_client = " + idr + ";"); // создаем запрос
                sql1.Connection = oleDbConn1; // привязываем запрос к конекту
                sql1.ExecuteNonQuery(); //выполнение

                // кол-во записей
                DataTable dt2_count = new DataTable();
                OleDbCommand sql2 = new OleDbCommand("SELECT COUNT(*) FROM Client_table;");
                sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                sql2.ExecuteNonQuery(); //выполнение
                OleDbDataAdapter da2_count = new OleDbDataAdapter(sql1);
                da2_count.Fill(dt2_count);
                int count = dt2_count.Rows.Count;
                dgv.AllowUserToAddRows = false;
                OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                da1.Fill(dt1);
                dgv.DataSource = dt1;
                dgv.Columns[9].Visible = false;
                dgv.Columns[10].Visible = false;
                int counts = dgv.DisplayedRowCount(true);
                for (int i = 0; i < counts; i++)
                {
                    if (dt1.Rows[i].ItemArray.GetValue(9).ToString() == "1")
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                com4.Items.Clear();
                com4.Text = "";
                com4.Items.Add("");
                OleDbConnection conn4 = new OleDbConnection();
                conn4.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
                conn4.Open();
                OleDbCommand cmd4 = new OleDbCommand("SELECT DISTINCT data from Recording WHERE id_client =" + idr + ";", conn4);
                OleDbDataReader DR4 = cmd4.ExecuteReader();
                while (DR4.Read())
                {
                    com4.Items.Add(DR4.GetValue(0).ToString());
                }
                conn4.Close();

                groupBox3.Visible = false;
                oleDbConn1.Close();
            }
        }

        private void com4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com4.Text == "")
            {
                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                DataTable dt1 = new DataTable(); // создаем таблицу 

                oleDbConn1.Open(); // открываем подключение к базе
                OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Марка, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИ_кл, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_кл, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status), (id) FROM Recording WHERE id_client = " + idr + ";"); // создаем запрос
                sql1.Connection = oleDbConn1; // привязываем запрос к конекту
                sql1.ExecuteNonQuery(); //выполнение

                // кол-во записей
                DataTable dt2_count = new DataTable();
                OleDbCommand sql2 = new OleDbCommand("SELECT COUNT(*) FROM Client_table;");
                sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                sql2.ExecuteNonQuery(); //выполнение
                OleDbDataAdapter da2_count = new OleDbDataAdapter(sql1);
                da2_count.Fill(dt2_count);
                int count = dt2_count.Rows.Count;
                dgv.AllowUserToAddRows = false;
                OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                da1.Fill(dt1);
                dgv.DataSource = dt1;
                dgv.Columns[9].Visible = false;
                dgv.Columns[10].Visible = false;
                int counts = dgv.DisplayedRowCount(true);
                for (int i = 0; i < counts; i++)
                {
                    if (dt1.Rows[i].ItemArray.GetValue(9).ToString() == "1")
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                oleDbConn1.Close();
            }
            else
            {
                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                DataTable dt1 = new DataTable(); // создаем таблицу 

                oleDbConn1.Open(); // открываем подключение к базе
                OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Марка, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИ_кл, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_кл, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status), (id) FROM Recording WHERE id_client = " + idr + " AND data = '" + com4.SelectedItem + "';"); // создаем запрос
                sql1.Connection = oleDbConn1; // привязываем запрос к конекту
                sql1.ExecuteNonQuery(); //выполнение

                // кол-во записей
                DataTable dt2_count = new DataTable();
                OleDbCommand sql2 = new OleDbCommand("SELECT COUNT(*) FROM Client_table;");
                sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                sql2.ExecuteNonQuery(); //выполнение
                OleDbDataAdapter da2_count = new OleDbDataAdapter(sql1);
                da2_count.Fill(dt2_count);
                int count = dt2_count.Rows.Count;
                dgv.AllowUserToAddRows = false;
                OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                da1.Fill(dt1);
                dgv.DataSource = dt1;
                dgv.Columns[9].Visible = false;
                dgv.Columns[10].Visible = false;
                int counts = dgv.DisplayedRowCount(true);
                for (int i = 0; i < counts; i++)
                {
                    if (dt1.Rows[i].ItemArray.GetValue(9).ToString() == "1")
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                double a = 0;
                double summ = 0;
                for (int i = 0; i < count; i++)
                {
                    a = Convert.ToDouble(dt2_count.Rows[i].ItemArray.GetValue(8));
                    summ = summ + a;
                }

                label8.Text = "Итого: " + Convert.ToString(summ) + " руб.";

                groupBox3.Visible = true;
                oleDbConn1.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (com5.Text == "")
            {
                UpdatedataGridViewBooks();
            }
            else
            {
                string con = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                OleDbConnection oleDbConn = new OleDbConnection(con); // создаем подключение
                oleDbConn.Open(); // открываем подключение к базе
                OleDbCommand sql = new OleDbCommand("");
                if (com5.Text == "Принятый")
                {
                    sql = new OleDbCommand("UPDATE Recording SET status= " + 0 + " WHERE id = " + ID + ";"); // создаем запрос
                }
                if (com5.Text == "Выполненный")
                {
                    sql = new OleDbCommand("UPDATE Recording SET status= " + 1 + " WHERE id = " + ID + ";"); // создаем запрос
                }
                sql.Connection = oleDbConn; // привязываем запрос к конекту
                sql.ExecuteNonQuery(); //выполнение
                oleDbConn.Close();
                UpdatedataGridViewBooks();
                MessageBox.Show("Статус изменен", "Сообщение пользователю", MessageBoxButtons.OK);
            }
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dgv.SelectedCells[10].Value.ToString());
            label11.Visible = false;
            label12.Visible = true;
            com5.Visible = true;
            
            button4.Enabled = true;
            if (nuls.state == 1)
            {
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
            OleDbConnection oleDbConn1 = new OleDbConnection(con1);
            DataTable dt1 = new DataTable();

            oleDbConn1.Open();
            OleDbCommand sql1 = new OleDbCommand("DELETE * FROM Recording Where id = " + Convert.ToInt32(ID) + ";");
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            sql1.Connection = oleDbConn1;
            sql1.ExecuteNonQuery();

            da1.Fill(dt1);

            oleDbConn1.Close();

            UpdatedataGridViewBooks();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
