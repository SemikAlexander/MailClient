using System;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using System.Threading;
using System.Windows.Forms;
using MainClient.Properties;
using System.Collections.Generic;

namespace MainClient
{
    public partial class MainForm : Form
    {
        int Letter = 0, LastIndex = 0, CountBack = 0, IMAPPort = Convert.ToInt32(Settings.Default["POP3Port"]);
        string email, password, IMAPAdress = Settings.Default["IMAPAdress"].ToString();
        int ID;
        WorkWithDatabase workWithDatabase;
        List<WorkWithDatabase.Message> messages = new List<WorkWithDatabase.Message>();
        public MainForm(string UserEmail, string UserPassword, int IDUser)
        {
            InitializeComponent();
            email = UserEmail;
            password = UserPassword;
            ID = IDUser;
            workWithDatabase = new WorkWithDatabase();
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
            toolStripStatusLabel1.Text = "";
            workWithDatabase.GetMessage(ID, "SND", out messages);
            UserMessagesTable.Rows.Clear();
            if (messages.Count > 0)
                foreach (var arraySendMessages in messages)
                    UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
            else
                toolStripStatusLabel1.Text = "Эта папка пуста.";
        }

        private void DraftMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            workWithDatabase.GetMessage(ID, "DFT", out messages);
            UserMessagesTable.Rows.Clear();
            if (messages.Count > 0)
                foreach (var arraySendMessages in messages)
                    UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
            else
                toolStripStatusLabel1.Text = "Эта папка пуста.";
        }

        private void DeleteMessage_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            workWithDatabase.GetMessage(ID, "DEL", out messages);
            UserMessagesTable.Rows.Clear();
            if (messages.Count > 0)
                foreach (var arraySendMessages in messages)
                    UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
            else
                toolStripStatusLabel1.Text = "Эта папка пуста.";
        }

        private void InboxMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Идёт загрузка...";
            if (Convert.ToBoolean(Settings.Default["POP3Checked"]))
            {
                GetMessageByPOP3();
            }
            if (Convert.ToBoolean(Settings.Default["IMAPChecked"]))
            {
                GetMessagesByIMAP();
            }
        }

        private void UserMessagesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadMessage readMessage = new ReadMessage();
            try
            {
                toolStripStatusLabel1.Text = "Идет загрузка...";
                if (Convert.ToBoolean(Settings.Default["POP3Checked"]))
                {
                    using (var client = new Pop3Client())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                        client.Connect(Settings.Default["POP3Adress"].ToString(), Convert.ToInt32(Settings.Default["POP3Port"]), true);
                        client.Authenticate(email, password);
                        if (LastIndex < 0) LastIndex = 0;
                        if (client.Count == 0 | LastIndex + UserMessagesTable.CurrentCell.RowIndex > client.Count)
                        {
                            toolStripStatusLabel1.Text = "Письма нет.";
                            return;
                        }
                        var message = client.GetMessage(LastIndex + UserMessagesTable.CurrentCell.RowIndex);
                        readMessage.email_client.Text = message.From.ToString();
                        readMessage.theme.Text = message.Subject;
                        readMessage.TextLetter.Text = (message.TextBody.Trim().Length == 0) ? message.HtmlBody : message.TextBody;
                        readMessage.MimeMessage = message;
                        client.Disconnect(true);
                        readMessage.ShowDialog();
                    }
                }
                if (Convert.ToBoolean(Settings.Default["IMAPChecked"]))
                {
                    using (var client = new ImapClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                        client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                        client.Authenticate(email, password);
                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadOnly);
                        if (LastIndex < 0) LastIndex = 0;
                        var message = inbox.GetMessage(LastIndex + UserMessagesTable.CurrentCell.RowIndex);
                        readMessage.email_client.Text = message.From.ToString();
                        readMessage.theme.Text = message.Subject;
                        readMessage.TextLetter.Text = (message.TextBody == null || message.TextBody.Trim().Length == 0) ? message.HtmlBody : message.TextBody;
                        readMessage.MimeMessage = message;
                        toolStripStatusLabel1.Text = "Готово!";
                        client.Disconnect(true);
                        readMessage.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                toolStripStatusLabel1.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm("Edit");
            settings.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                case DialogResult.OK:
                    Application.Exit();
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int index = email.IndexOf("@");
            Text = email.Substring(0, index);
            toolStripStatusLabel1.Text = "";
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