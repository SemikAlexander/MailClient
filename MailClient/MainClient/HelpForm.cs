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
    public partial class HelpForm : Form
    {
        int ID = 0;
        string UserLogin = "", UserPassword = "";
        public HelpForm(int IDUser, string Login, string Password)
        {
            InitializeComponent();
            ID = IDUser;
            UserLogin = Login;
            UserPassword = Password;
        }

        private void дляПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkWithDatabase workWithDatabase = new WorkWithDatabase();
            textBox1.Text = $"Email: {UserLogin}\r\n" +
                $"Пароль: {UserPassword}\r\n" +
                $"Публичный ключ: {workWithDatabase.GetPublicKeyForUser(ID)}\r\n" +
                $"Приватный ключ: {workWithDatabase.GetPrivateKeyForUser(ID)}";
        }
    }
}
