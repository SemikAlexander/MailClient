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
        MainForm mainForm;
        string UserEmail, UserPassword;
        int ID;
        WorkWithDatabase workWithDatabase;
        public SendMessage(string email, string password, int IDUser, MainForm mainForm1)
        {
            InitializeComponent();
            mainForm = mainForm1;
            UserEmail = email;
            UserPassword = password;
            ID = IDUser;
            workWithDatabase = new WorkWithDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                AttachmentFile = FD.FileName;
            }
        }

        private void SendMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TextLetter.Text.Length!=0 || email_client.Text.Length!=0 || theme.Text.Length != 0)
            {
                switch (MessageBox.Show("Сохранить сообщение в черновики?", "Сохранить", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.OK:
                        workWithDatabase.AddMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "DFT", ID);
                        Hide();
                        break;
                    default:
                        Close();
                        break;
                }
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
                    workWithDatabase.AddMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "SND", ID);
                    MessageBox.Show("Письмо отправленно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    email_client.Text = theme.Text = TextLetter.Text = "";
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