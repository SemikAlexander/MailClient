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

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = email.Replace("@yandex.ua", "");
        }
    }
}
