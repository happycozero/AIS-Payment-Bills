﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Visible = false;
            authorization.ShowDialog();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            if (nuls.state == 0)
            {
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
            }
            Fill();

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
            AccessDatabase accessDatabase = new AccessDatabase(connectionString);
            accessDatabase.OpenConnection();

            string query = "SELECT * FROM Service";
            DataTable dt1 = accessDatabase.ExecuteQuery(query);

            dt1.Columns["service"].ColumnName = "Услуга";
            dt1.Columns["cost"].ColumnName = "Цена";

            dgv.DataSource = dt1;
            dgv.Columns[0].Visible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            accessDatabase.CloseConnection();

            dgv.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clients Client = new Clients();
            this.Visible = false;
            Client.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();
            this.Visible = false;
            ed.ShowDialog();
        }

        public void Fill()
        {
            string s = nuls.str;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;";
            AccessDatabase accessDatabase = new AccessDatabase(connectionString);
            accessDatabase.OpenConnection();

            string query = "SELECT full_name FROM Customers WHERE login = '" + s + "'";
            DataTable dt12 = accessDatabase.ExecuteQuery(query);

            accessDatabase.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receipt rec = new Receipt();
            this.Visible = false;
            rec.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports rec = new Reports();
            this.Visible = false;
            rec.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customers empl = new Customers();
            this.Visible = false;
            empl.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            this.Visible = false;
            service.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BackupDB backup = new BackupDB();
            this.Visible = false;
            backup.ShowDialog();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
