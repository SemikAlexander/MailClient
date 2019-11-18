using System;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using System.Windows.Forms;
using MainClient.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using MailKit.Security;

namespace MainClient
{
    public partial class MainForm : Form
    {
        int Letter = 0, LastIndex = 0, CountBack = 0;
        string email, password, button = "";
        int ID;

        struct InboxForThread
        {
            public string RecipientAdress, Subject, Text, UnicID;
        }
        WorkWithDatabase workWithDatabase;
        List<WorkWithDatabase.Message> messages = new List<WorkWithDatabase.Message>();
        InboxForThread structInboxMessage;
        List<InboxForThread> inboxes = new List<InboxForThread>();
        List<string> uniqueIds = new List<string>();
        public MainForm(string UserEmail, string UserPassword, int IDUser)
        {
            InitializeComponent();
            email = UserEmail;
            password = UserPassword;
            ID = IDUser;
            workWithDatabase = new WorkWithDatabase();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            if (menuPanel.Width == 180)
                menuPanel.Width = 45;
            else
                menuPanel.Width = 180;
        }

        private void writeMessage_Click(object sender, EventArgs e)
        {
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            SendMessage sendMessage = new SendMessage(email, password, ID, this, false);
            sendMessage.Show();
        }

        private void OutgoingMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            button = OutgoingMessages.Text.Trim(' ');
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
            button = DraftMessages.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
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
            button = DeleteMessage.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
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
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            button = InboxMessages.Text.Trim(' ');
            inboxes.Clear();
            backgroundWorker1.DoWork += (c, ex) => backgroundWorker1_DoWork(c, ex, Convert.ToBoolean(Settings.Default["POP3Checked"]));
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
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
                        readMessage.TextLetter.Text = (string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : message.TextBody;
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
                        readMessage.TextLetter.Text = (string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : message.TextBody;
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

        private void InfoButton_Click(object sender, EventArgs e)
        {
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
        }

        private void DeleteMessageButton_Click(object sender, EventArgs e)
        {
            switch (button)
            {
                case "Входящие":
                    
                    break;
                case "Отправленные":
                    workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value.ToString(),
                        "DEL",
                        ID);
                    workWithDatabase.GetMessage(ID, "SND", out messages);
                    UserMessagesTable.Rows.Clear();
                    if (messages.Count > 0)
                        foreach (var arraySendMessages in messages)
                            UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                    else
                        toolStripStatusLabel1.Text = "Эта папка пуста.";
                    break;
                case "Черновик":
                    workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value.ToString(),
                        "DEL",
                        ID);
                    workWithDatabase.GetMessage(ID, "DFT", out messages);
                    UserMessagesTable.Rows.Clear();
                    if (messages.Count > 0)
                        foreach (var arraySendMessages in messages)
                            UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                    else
                        toolStripStatusLabel1.Text = "Эта папка пуста.";
                    break;
                case "Удалённые":
                    workWithDatabase.DeleteMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value.ToString(),
                        ID);
                    workWithDatabase.GetMessage(ID, "DEL", out messages);
                    UserMessagesTable.Rows.Clear();
                    if (messages.Count > 0)
                        foreach (var arraySendMessages in messages)
                            UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                    else
                        toolStripStatusLabel1.Text = "Эта папка пуста.";
                    break;
            }
        }

        private void EditMessageButton_Click(object sender, EventArgs e)
        {
            if (button != "Входящие")
            {
                SendMessage sendMessage = new SendMessage(email, password, ID, this, true);
                sendMessage.email_client.Text = UserMessagesTable.CurrentRow.Cells[0].Value.ToString();
                sendMessage.theme.Text = UserMessagesTable.CurrentRow.Cells[1].Value.ToString();
                sendMessage.TextLetter.Text = UserMessagesTable.CurrentRow.Cells[2].Value.ToString();
                sendMessage.ShowDialog();
            }
        }

        private void UserMessagesTable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int currentMouseOverRow = UserMessagesTable.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    switch (button)
                    {
                        case "Входящие":
                            DeleteMessageButton.Visible = true;
                            break;
                        case "Отправленные":
                            DeleteMessageButton.Visible = true;
                            break;
                        case "Черновик":
                            DeleteMessageButton.Visible = EditMessageButton.Visible = true;
                            break;
                        case "Удалённые":
                            DeleteMessageButton.Visible = EditMessageButton.Visible = true;
                            break;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            SettingsForm settings = new SettingsForm("Edit");
            settings.Show();
        }

        private void RestoreMessageButton_Click(object sender, EventArgs e)
        {
            workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value.ToString(),
                        "DFT",
                        ID);
            workWithDatabase.GetMessage(ID, "DFT", out messages);
            UserMessagesTable.Rows.Clear();
            if (messages.Count > 0)
                foreach (var arraySendMessages in messages)
                    UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
            else
                toolStripStatusLabel1.Text = "Эта папка пуста.";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                case DialogResult.OK:
                    Application.Exit();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        #region Thread
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Идёт загрузка...{(e.ProgressPercentage.ToString() + "%")}";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Готово!";
            foreach (var info in inboxes)
                UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e, bool TypeProtocol)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (TypeProtocol)
                GetMessageByPOP3();
            else
                GetMessagesByIMAP(worker);
        }
        #endregion
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            int index = email.IndexOf("@");
            Text = email.Substring(0, index);
            toolStripStatusLabel1.Text = "";
        }

        #region Get messages
        public void GetMessagesByIMAP(BackgroundWorker worker)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var items = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.Flags);
                    double numMessagesForPersent = (double)items.Count / 100;
                    int countProcesses = 0;
                    foreach (var item in items)
                    {
                        var message = inbox.GetMessage(item.UniqueId);
                        structInboxMessage.RecipientAdress = Convert.ToString(message.From);
                        structInboxMessage.Subject = message.Subject;
                        structInboxMessage.Text = message.TextBody;
                        structInboxMessage.UnicID = Convert.ToString(item.UniqueId);
                        inboxes.Add(structInboxMessage);
                        if (item.Flags.Value.HasFlag(MessageFlags.Seen))
                            uniqueIds.Add(Convert.ToString(item.UniqueId));
                        countProcesses++;
                        if (countProcesses >= numMessagesForPersent)
                            worker.ReportProgress((int)(countProcesses / numMessagesForPersent));
                    }
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
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody, message.MessageId);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody, message.MessageId);
                        }
                        Letter = count + Letter;
                    }
                    else
                    {
                        for (int i = Letter; i < client.Count - Letter; i++)
                        {
                            var message = client.GetMessage(i);
                            if (message.Subject != "")
                                UserMessagesTable.Rows.Add(message.From, message.Subject, message.TextBody, message.MessageId);
                            else
                                UserMessagesTable.Rows.Add(message.From, "", message.TextBody, message.MessageId);
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
        public bool IsMessageRead(string IDMessage)
        {
            foreach(var id in uniqueIds)
            {
                if (id == IDMessage)
                    return true;
            }
            return false;
        }
    }
}