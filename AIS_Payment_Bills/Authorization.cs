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

namespace Payment_Bills
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAcceptEntry_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBox1.Text;
                string password = textBox2.Text;

                string con1 = "Provider= Microsoft.Jet.OLEDB.4.0; Data Source=db.mdb;";
                OleDbConnection oleDbConn1 = new OleDbConnection(con1);
                DataTable dt1 = new DataTable();
                oleDbConn1.Open();
                OleDbCommand sql1 = new OleDbCommand("SELECT login, password, state FROM Employee_table WHERE login = '" + login + "' AND password = '" + password + "';");
                OleDbDataAdapter da1 = new OleDbDataAdapter(sql1);
                sql1.Connection = oleDbConn1;
                sql1.ExecuteNonQuery();
                da1.Fill(dt1);

                nuls.str = Convert.ToString(dt1.Rows[0].ItemArray.GetValue(0));
                nuls.state = Convert.ToInt32(dt1.Rows[0].ItemArray.GetValue(2));

                Menu menu = new Menu();
                this.Visible = false;
                menu.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введен неверный логин или пароль", "Ошибка");
            }
        }

        private void authorization_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}