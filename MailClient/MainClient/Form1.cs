using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;
using System.Net;

namespace MainClient
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(mailTextBox.Text) & !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                if (!IsValidEmail(mailTextBox.Text))
                {
                    MessageBox.Show("Email неверный!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                    AuthorizationOnServer("smtp.yandex.ru", 465);
            }
            else
            {
                MessageBox.Show("Не все поля заполены!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var adress = new System.Net.Mail.MailAddress(email);
                return adress.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    this.Text = "Авторизация";
            }
            catch
            {
                this.Text = "Авторизация  (offline mode)";
            }
        }

        public void AuthorizationOnServer(string smtpAdress, int smtpPort)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(smtpAdress, smtpPort, true);
                    client.Authenticate(mailTextBox.Text, passwordTextBox.Text);
                    MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text);
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}