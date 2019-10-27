using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;

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
                {
                    try
                    {
                        using (var client = new SmtpClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                            client.Connect("smtp.yandex.ru", 465, true);
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
    }
}