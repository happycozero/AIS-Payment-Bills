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
using Ionic.Zip;
using Payment_Bills;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace Payment_Bills
{
    public partial class Backup : MetroForm
    {
        public Backup()
        {
            InitializeComponent();
        }

        readonly FolderBrowserDialog db = new FolderBrowserDialog();

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Zip files (*.zip)|*.zip"
            };
            if (textBox1.Text != "" && sfd.ShowDialog() == DialogResult.OK)
            {
                ZipFile zf = new ZipFile(sfd.FileName);
                zf.AddDirectory(db.SelectedPath);
                zf.Save();
                MessageBox.Show("Резервное копирование прошло успешно.", "Выполнено");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = db.SelectedPath;
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
