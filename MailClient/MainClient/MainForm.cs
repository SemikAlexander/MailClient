using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainClient
{
    public partial class MainForm : Form
    {
        string email, password;
        public MainForm(string UserEmail, string UserPassword)
        {
            InitializeComponent();
            email = UserEmail;
            password = UserPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuPanel.Width == 180)
                menuPanel.Width = 45;
            else
                menuPanel.Width = 180;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm("Edit");
            settings.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var closeMainForm = MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (closeMainForm == DialogResult.OK)
                Application.Exit();
            else
                e.Cancel = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = email.Replace("@yandex.ua", "");    /*Тут будет выборкка из базы данных. Пока Яндекс*/
        }
    }
}