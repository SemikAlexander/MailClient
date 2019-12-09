using System;
using System.Windows.Forms;
using System.IO;

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

        private void библиотекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\LibraryInfo.txt",FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void алгоритмRSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\RSAInfo.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void алгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\RijndaelInfo.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void отправкаСообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\SendMessageInfo.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void синхронизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\SynchronizationInfo.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Info\\DBInfo.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
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