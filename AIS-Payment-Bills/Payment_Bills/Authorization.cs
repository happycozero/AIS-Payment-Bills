using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payment_Bills;

namespace Payment_Bills
{
    public partial class Authorization : Form
    {
        Menu menus = new Menu();

        public Authorization()
        {
            InitializeComponent();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AuthB_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBox1.Text;
                string password = textBox2.Text;

                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
                AccessDatabase accessDatabase = new AccessDatabase(connectionString);
                accessDatabase.OpenConnection();

                string query = "SELECT login, password, state FROM Customers WHERE login = '" + login + "' AND password = '" + password + "'";
                DataTable dt1 = accessDatabase.ExecuteQuery(query);

                nuls.str = Convert.ToString(dt1.Rows[0].ItemArray.GetValue(0));
                nuls.state = Convert.ToInt32(dt1.Rows[0].ItemArray.GetValue(2));

                this.Visible = false;
                menus.ShowDialog();
                this.Visible = true;

                accessDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                MessageBox.Show("Введен неверный логин или пароль: " + errorMessage, "Ошибка");
            }
        }
    }
}
