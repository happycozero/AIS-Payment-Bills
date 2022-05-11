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
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Payment_Bills
{
    public partial class reports : MetroForm
    {
        private readonly string FileName1 = Directory.GetCurrentDirectory() + @"\Resources\отчет1.docx";
        private readonly string FileName2 = Directory.GetCurrentDirectory() + @"\Resources\отчет2.docx";
        public reports()
        {
            InitializeComponent();
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

        private void reports_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            com1.DropDownStyle = ComboBoxStyle.DropDownList;
            fil();
            UpdateDateGrid();
            com1.Items.Add("День");
            com1.Items.Add("Месяц");
            com1.Items.Add("Квартал");
            com1.Items.Add("Год");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (com1.Text == "")
            {
                MessageBox.Show("Выберите период", "Сообщение пользователю");
            }
            else
            {
                string book = DateTime.Now.ToShortDateString();
                string[] r = book.Split('.');
                string[] c;
                string[] k = book.Split('.');
                string num = "";
                int count = 0;
                int cou = 0;
                int t = 0;
                string edit = "";

                if (com1.Text == "День")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 0 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[0] + c[1] == r[0] + r[1])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName1);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[0] + c[1] == r[0] + r[1])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Квартал")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 0 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    if (r[1] == "01" || r[1] == "02" || r[1] == "03")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "01" || c[1] == "02" || c[1] == "03")
                            {
                                cou++;
                            }
                        }
                        k[0] = "01";
                        k[1] = "02";
                        k[1] = "03";
                    }
                    if (r[1] == "04" || r[1] == "05" || r[1] == "06")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "04" || c[1] == "05" || c[1] == "06")
                            {
                                cou++;
                            }
                        }
                        k[0] = "04";
                        k[1] = "05";
                        k[1] = "06";
                    }
                    if (r[1] == "07" || r[1] == "08" || r[1] == "09")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "07" || c[1] == "08" || c[1] == "09")
                            {
                                cou++;
                            }
                        }
                        k[0] = "07";
                        k[1] = "08";
                        k[1] = "09";
                    }
                    if (r[1] == "10" || r[1] == "11" || r[1] == "12")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "10" || c[1] == "11" || c[1] == "12")
                            {
                                cou++;
                            }
                        }
                        k[0] = "10";
                        k[1] = "11";
                        k[1] = "12";
                    }
                    var wordd = wordApp.Documents.Open(FileName1);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == k[0] || c[1] == k[1] || c[1] == k[2])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Месяц")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 0 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == r[1])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName1);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == r[1])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Год")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 0 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[2] == r[2])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName1);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[2] == r[2])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
            }
        }
        public void UpdateDateGrid()
        {
            string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
            OleDbConnection oleDbConn1 = new OleDbConnection(con1); // создаем подключение
            DataTable dt1 = new DataTable(); // создаем таблицу 

            oleDbConn1.Open(); // открываем подключение к базе
            OleDbCommand sql1 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена, (status) FROM Recording;"); // создаем запрос
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (com1.Text == "")
            {
                MessageBox.Show("Выберите период", "Сообщение пользователю");
            }
            else
            {
                string book = DateTime.Now.ToShortDateString();
                string[] r = book.Split('.');
                string[] c;
                string[] k = book.Split('.');
                string num = "";
                int count = 0;
                int cou = 0;
                int t = 0;
                string edit = "";

                if (com1.Text == "День")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 1 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[0] + c[1] == r[0] + r[1])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName2);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[0] + c[1] == r[0] + r[1])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Квартал")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 1 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    if (r[1] == "01" || r[1] == "02" || r[1] == "03")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "01" || c[1] == "02" || c[1] == "03")
                            {
                                cou++;
                            }
                        }
                        k[0] = "01";
                        k[1] = "02";
                        k[1] = "03";
                    }
                    if (r[1] == "04" || r[1] == "05" || r[1] == "06")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "04" || c[1] == "05" || c[1] == "06")
                            {
                                cou++;
                            }
                        }
                        k[0] = "04";
                        k[1] = "05";
                        k[1] = "06";
                    }
                    if (r[1] == "07" || r[1] == "08" || r[1] == "09")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "07" || c[1] == "08" || c[1] == "09")
                            {
                                cou++;
                            }
                        }
                        k[0] = "07";
                        k[1] = "08";
                        k[1] = "09";
                    }
                    if (r[1] == "10" || r[1] == "11" || r[1] == "12")
                    {
                        for (int y = 0; y < count; y++)
                        {
                            edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                            c = edit.Split(':');
                            if (c[1] == "10" || c[1] == "11" || c[1] == "12")
                            {
                                cou++;
                            }
                        }
                        k[0] = "10";
                        k[1] = "11";
                        k[1] = "12";
                    }
                    var wordd = wordApp.Documents.Open(FileName2);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == k[0] || c[1] == k[1] || c[1] == k[2])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Месяц")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 1 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == r[1])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName2);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[1] == r[1])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
                if (com1.Text == "Год")
                {
                    string con2 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;"; // строка подключения
                    OleDbConnection oleDbConn1 = new OleDbConnection(con2); // создаем подключение
                    DataTable dt2 = new DataTable(); // создаем таблицу 

                    oleDbConn1.Open(); // открываем подключение к базе
                    OleDbCommand sql2 = new OleDbCommand("SELECT (SELECT [management] FROM Client_table WHERE Recording.id_client = Client_table.id) AS УК, (SELECT [full_name] FROM Client_table WHERE Recording.id_client = Client_table.id) AS ФИО_плат, (SELECT [phone] FROM Client_table WHERE Recording.id_client = Client_table.id) AS Телефон_плат, (SELECT [full_name] FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS ФИО_раб, (SELECT specialty FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Специальность, (SELECT phone FROM Employee_table WHERE Recording.id_eplo = Employee_table.id) AS Телефон_раб, (SELECT service FROM Service_table WHERE Recording.id_service = Service_table.id) AS Услуга, (data) AS Дата, (SELECT cost FROM Service_table WHERE Recording.id_service = Service_table.id) AS Цена FROM Recording WHERE status = " + 1 + ";"); // создаем запрос
                    sql2.Connection = oleDbConn1; // привязываем запрос к конекту
                    sql2.ExecuteNonQuery(); //выполнение
                    //dgv.AllowUserToAddRows = false;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sql2);
                    da2.Fill(dt2);
                    count = dt2.Rows.Count;
                    var wordApp = new Word.Application();
                    for (int y = 0; y < count; y++)
                    {
                        edit = dt2.Rows[y].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[2] == r[2])
                        {
                            cou++;
                        }
                    }
                    var wordd = wordApp.Documents.Open(FileName2);
                    wordApp.Visible = false;
                    Word.Paragraph table = wordd.Paragraphs.Add();
                    Word.Range range = table.Range;
                    Word.Table tab = wordd.Tables.Add(range, cou + 1, 10);
                    tab.Borders.InsideLineStyle = tab.Borders.OutsideLineStyle
                        = Word.WdLineStyle.wdLineStyleSingle;
                    tab.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellran;

                    cellran = tab.Cell(1, 1).Range;
                    cellran.Text = "№";
                    cellran = tab.Cell(1, 2).Range;
                    cellran.Text = "УК";
                    cellran = tab.Cell(1, 3).Range;
                    cellran.Text = "ФИ клиента";
                    cellran = tab.Cell(1, 4).Range;
                    cellran.Text = "Телефон клиента";
                    cellran = tab.Cell(1, 5).Range;
                    cellran.Text = "Услуга";
                    cellran = tab.Cell(1, 6).Range;
                    cellran.Text = "Дата";
                    cellran = tab.Cell(1, 7).Range;
                    cellran.Text = "Цена";

                    tab.Rows[1].Range.Bold = 1;
                    tab.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    for (int i = 0; i < count; i++)
                    {
                        edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                        c = edit.Split(':');
                        if (c[2] == r[2])
                        {
                            t++;
                            num = Convert.ToString(t);
                            cellran = tab.Cell((t + 1), 1).Range;
                            cellran.Text = num;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(0).ToString();
                            cellran = tab.Cell(t + 1, 2).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(1).ToString();
                            cellran = tab.Cell(t + 1, 3).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(2).ToString();
                            cellran = tab.Cell(t + 1, 4).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(3).ToString();
                            cellran = tab.Cell(t + 1, 5).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(4).ToString();
                            cellran = tab.Cell(t + 1, 6).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(5).ToString();
                            cellran = tab.Cell(t + 1, 7).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(6).ToString();
                            cellran = tab.Cell(t + 1, 8).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(7).ToString();
                            cellran = tab.Cell(t + 1, 9).Range;
                            cellran.Text = edit;
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                            edit = dt2.Rows[i].ItemArray.GetValue(8).ToString();
                            cellran = tab.Cell(t + 1, 10).Range;
                            cellran.Text = edit + " руб.";
                            cellran.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                    wordApp.Visible = true;
                    oleDbConn1.Close();
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
