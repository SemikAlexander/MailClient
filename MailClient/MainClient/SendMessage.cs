using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;
using MainClient.Properties;
using System.IO;

namespace MainClient
{
    public partial class SendMessage : Form
    {
        string AttachmentFile = "";
        public MimeMessage MimeMessage;
        MainForm mainForm;
        string UserEmail, UserPassword;
        public SendMessage(string email, string password, MainForm mainForm1)
        {
            InitializeComponent();
            mainForm = mainForm1;
            UserEmail = email;
            UserPassword = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                AttachmentFile = FD.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check check = new Check();
            if (!check.IsValidEmail(email_client.Text))
            {
                MessageBox.Show("Email неверный!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TextLetter.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cодержимое письма пусто!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(UserEmail));
            message.To.Add(new MailboxAddress(email_client.Text));
            message.Subject = theme.Text;
            var builder = new BodyBuilder();
            builder.TextBody = TextLetter.Text;
            if (AttachmentFile != "")
            {
                builder.Attachments.Add(AttachmentFile);
            }
            message.Body = builder.ToMessageBody();
            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["SMTPAdress"].ToString(), Convert.ToInt32(Settings.Default["SMTPPort"]), true);
                    client.Authenticate(UserEmail, UserPassword);
                    client.Send(message);
                    client.Disconnect(true);
                    DialogResult dialogResult = MessageBox.Show("Письмо отправленно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                mainForm.toolStripStatusLabel1.Text = "Ошибка: " + ex.Message;
                MessageBox.Show(ex.Message);
            }
        }
    }
}