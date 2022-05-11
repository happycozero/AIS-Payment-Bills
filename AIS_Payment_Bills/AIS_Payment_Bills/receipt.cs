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
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace Payment_Bills
{
    public partial class Receipt : MetroForm
    {
        private readonly string FileName = Directory.GetCurrentDirectory() + @"\Resources\квитанция.docx";
        public Receipt()
        {
            InitializeComponent();
        }

        string s = nuls.str;
        int id_e = 0;
        string dat = "";
        

        private void receipt_Load(object sender, EventArgs e)
        {
            com1.DropDownStyle = ComboBoxStyle.DropDownList;
            com2.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.ReadOnly = true;
            fil();           
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Client_table", conn);
            OleDbDataReader DR1 = cmd.ExecuteReader();
            com1.Items.Add("");
            while (DR1.Read())
            {
                com1.Items.Add(DR1.GetValue(3).ToString() + " - " + DR1.GetValue(1).ToString());
            }
            conn.Close();
            UpdateDateGrid();
        }

        public void UpdateDateGrid()
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
            DataTable dt1 = new DataTable(); // создаем таблицу 

            oleDbConn1.Open(); // открываем подключение к базе
            OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Данные, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status) FROM Recording;"); // создаем запрос
            sql1.Connection = oleDbConn1; // привязываем запрос к конекту
            sql1.ExecuteNonQuery(); //выполнение
            dgv.AllowUserToAddRows = false;
            OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
            da1.Fill(dt1);
            dgv.DataSource = dt1;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[9].Visible = false;
            int counts = dgv.DisplayedRowCount(true);
            for (int i = 0; i < counts; i++)
            {
                if (dt1.Rows[i].ItemArray.GetValue(9).ToString() == "1")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 170;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 1;
            dgv.Columns[4].Width = 1;
            dgv.Columns[5].Width = 1;
            dgv.Columns[6].Width = 170;
            dgv.Columns[7].Width = 105;
            dgv.Columns[8].Width = 75;
            oleDbConn1.Close();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (com1.Text == "")
            {
                MessageBox.Show("Выберите плательщика", "Сообщение пользователю");
            }
            else
            {
                if (com2.Text == "")
                {
                    MessageBox.Show("Выберите дату", "Сообщение пользователю");
                }
                else
                {
                    try
                    {
                        string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                        OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                        DataTable dt1 = new DataTable(); // создаем таблицу 

                        oleDbConn1.Open(); // открываем подключение к базе
                        OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Модель, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [facial_score] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ВИН, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Данные, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE id_client = " + id_e + "AND data = '" + dat + "' AND status = " + 1 + ";"); // создаем запрос
                        sql1.Connection = oleDbConn1; // привязываем запрос к конекту
                        sql1.ExecuteNonQuery(); //выполнение

                        OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                        da1.Fill(dt1);
                        string client = "";
                        string phone = "";
                        string car = "";
                        string facial_score = "";
                        string num = "";
                        string edit = "";
                        string price = "";
                        int count = dt1.Rows.Count;
                        int sums = 0;


                        for (int i = 0; i < count; i++)
                        {

                            client = dt1.Rows[i].ItemArray.GetValue(2).ToString();
                            phone = dt1.Rows[i].ItemArray.GetValue(3).ToString();
                            car = dt1.Rows[i].ItemArray.GetValue(0).ToString();
                            facial_score = dt1.Rows[i].ItemArray.GetValue(4).ToString();
                            sums = sums + Convert.ToInt32(dt1.Rows[i].ItemArray.GetValue(9).ToString());

                        }


                        var wordApp = new Word.Application();
                        wordApp.Visible = false;
                        var wordd = wordApp.Documents.Open(FileName);
                        var allCat = edit;

                        Word.Paragraph table = wordd.Paragraphs.Add();
                        Word.Range range = table.Range;
                        Word.Table tab = wordd.Tables.Add(range, count + 1, 3);
                        tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                            = Word.WdLineStyle.wdLineStyleSingle;
                        tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                        Word.Range cellran;

                        cellran = tab.Cell(1, 1).Range;
                        cellran.Text = "№";
                        cellran = tab.Cell(1, 2).Range;
                        cellran.Text = "Наименование услуг";
                        cellran = tab.Cell(1, 3).Range;
                        cellran.Text = "Цена";

                        tab.Rows[1].Range.Bold = 1;
                        tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        for (int i = 0; i < count; i++)
                        {
                            num = Convert.ToString(i + 1);
                            cellran = tab.Cell((i + 2), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt1.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(i + 2, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            price = dt1.Rows[i].ItemArray.GetValue(9).ToString();
                            cellran = tab.Cell(i + 2, 3).Range;
                            cellran.Text = price + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        }

                        Word.Paragraph suma = wordd.Paragraphs.Add();
                        Word.Range sa = suma.Range;
                        sa.Text = "Сумма равна: " + sums + " руб.                  Дата: " + dat;

                        wordApp.Visible = true;
                        
                        ReplaceWordStub("{client}", client, wordd);
                        ReplaceWordStub("{phone}", phone, wordd);
                        ReplaceWordStub("{car}", car, wordd);
                        ReplaceWordStub("{facial_score}", facial_score, wordd);

                        string sum = Convert.ToString(sums) + " руб.";
                        oleDbConn1.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка создания отчета");
                    }
                }
            }
        }
             private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
            
        }

             private void com1_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (com1.Text == "")
                 {
                     UpdateDateGrid();
                 }
                 else
                 {
                     string book = com1.SelectedItem.ToString();
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
                     id_e = Convert.ToInt32(dt.Rows[0].ItemArray.GetValue(0));
                     oleDbConn.Close();

                     string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                     OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
                     DataTable dt1 = new DataTable(); // создаем таблицу 

                     oleDbConn1.Open(); // открываем подключение к базе
                OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Данные, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status), (id) FROM Recording WHERE id_client = " + id_e + ";")
                {
                    Connection = oleDbConn1 // привязываем запрос к конекту
                }; // создаем запрос
                sql1.ExecuteNonQuery(); //выполнение

                     // кол-во записей
                     DataTable dt2_count = new DataTable();
                     OleDbCommand sql2 = new OleDbCommand("SELECT COUNT(*) FROM Client_table;");
                     sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                     sql2.ExecuteNonQuery(); //выполнение
                     OleDbDataAdapter da2_count = new OleDbDataAdapter(sql1);
                     da2_count.Fill(dt2_count);
                     int count = dt2_count.Rows.Count;
                     //label5.Text = "Количество записей " + Convert.ToString(count);
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

                     com2.Items.Clear();
                     OleDbConnection conn = new OleDbConnection();
                     conn.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb";
                     conn.Open();
                     OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT data from Recording WHERE id_client = " + id_e + " AND status = " + 1 + ";", conn);
                     OleDbDataReader DR1 = cmd.ExecuteReader();
                     while (DR1.Read())
                     {
                         com2.Items.Add(DR1.GetValue(0).ToString());
                     }
                     conn.Close();
                 }
             }

             private void com2_SelectedIndexChanged(object sender, EventArgs e)
             {
                 try
                 {
                     if (com1.Text == "")
                     {

                     }
                     else
                     {
                         dat = com2.SelectedItem.ToString();
                     }
                 }
                 catch (Exception)
                 {

                 }
             }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
