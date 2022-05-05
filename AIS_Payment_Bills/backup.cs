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

namespace Payment_Bills
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        FolderBrowserDialog db = new FolderBrowserDialog();

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Zip files (*.zip)|*.zip";
            if (textBox1.Text != "" && sfd.ShowDialog() == DialogResult.OK)
            {
                ZipFile zf = new ZipFile(sfd.FileName);
                zf.AddDirectory(db.SelectedPath);
                zf.Save();
                MessageBox.Show("Резервное копирование прошло успешно.", "Выполнено");
            }
        }

        private void buttonFileSelection_Click(object sender, EventArgs e)
        {
            if (db.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = db.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Visible = false;
            menu.ShowDialog();
        }
    }
}
