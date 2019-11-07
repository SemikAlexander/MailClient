using System;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using System.Threading;
using System.Windows.Forms;
using MainClient.Properties;

namespace MainClient
{
    public partial class MainForm : Form
    {
        int Letter = 0, LastIndex = 0, CountBack = 0, IMAPPort = Convert.ToInt32(Settings.Default["POP3Port"]);
        string email, password, IMAPAdress = Settings.Default["IMAPAdress"].ToString();
        int ID;
        public MainForm(string UserEmail, string UserPassword, int IDUser)
        {
            InitializeComponent();
            email = UserEmail;
            password = UserPassword;
            ID = IDUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuPanel.Width == 180)
                menuPanel.Width = 45;
            else
                menuPanel.Width = 180;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Settings.Default["POP3Checked"]))
            {
                GetMessageByPOP3();
            }
            if (Convert.ToBoolean(Settings.Default["IMAPChecked"]))
            {
                GetMessagesByIMAP();
            }
        }

        private void writeMessage_Click(object sender, EventArgs e)
        {
            SendMessage sendMessage = new SendMessage(email, password, ID, this);
            sendMessage.Show();
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void OutgoingMessages_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm("Edit");
            settings.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
                Application.Exit();
            else
                e.Cancel = true;
        }

        private void MainForm_Load(object sender, EventArgs e)  /*Нужно добавить потоки!*/
        {
            int index = email.IndexOf("@");
            this.Text = email.Substring(0, index);
        }

        #region Get messages
        public void GetMessagesByIMAP(int count = 20)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(IMAPAdress, IMAPPort, true);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    UserMessagesTable.Rows.Clear();
                    if (inbox.Count == 0 | Letter > inbox.Count)
                    {
                        toolStrip1.Text = "Писем нет.";
                        return;
                    }
                    if (Letter + count <= inbox.Count)
                    {
                        for (int i = Letter; i < count + Letter; i++)
                        {
                            var message = inbox.GetMessage(i);
                            if (message.Subject != "")
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody);
                        }
                        Letter = count + Letter;
                    }
                    else
                    {
                        for (int i = Letter; i < inbox.Count - Letter; i++)
                        {
                            var message = inbox.GetMessage(i);

                            if (message.Subject != "")
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody);
                        }
                        Letter = inbox.Count - Letter;
                    }
                    toolStripStatusLabel1.Text = "Готово!";
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
        public void GetMessageByPOP3(int count = 20)
        {
            try
            {
                toolStripStatusLabel1.Text = "Идет загрузка...";
                using (var client = new Pop3Client())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(Settings.Default["POP3Adress"].ToString(), Convert.ToInt32(Settings.Default["POP3Port"]), true);
                    client.Authenticate(email, password);
                    UserMessagesTable.Rows.Clear();
                    if (Letter < 0) Letter = 0;

                    if (client.Count == 0 | Letter > client.Count)
                    {
                        toolStripStatusLabel1.Text = "Писем нет.";
                        return;

                    }
                    LastIndex = Letter;
                    if (Letter + count <= client.Count)
                    {
                        for (int i = Letter; i < count + Letter; i++)
                        {
                            var message = client.GetMessage(i);
                            if (message.Subject != "")
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody);
                        }
                        Letter = count + Letter;
                    }
                    else
                    {
                        for (int i = Letter; i < client.Count - Letter; i++)
                        {
                            var message = client.GetMessage(i);
                            if (message.Subject != "")
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody);
                        }
                        Letter = client.Count - Letter;
                    }
                    toolStripStatusLabel1.Text = "Готово!";

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка: " + ex.Message;
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}