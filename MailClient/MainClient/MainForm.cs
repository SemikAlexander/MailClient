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
using System.Drawing;

namespace MainClient
{
    public partial class MainForm : Form
    {
        int Letter = 0, LastIndex = 0, CountBack = 0;
        string email, password, button = "";
        int ID;
        Check check = new Check();
        struct StructMessage
        {
            public string RecipientAdress, Subject, Text, UnicID;
        }
        WorkWithDatabase workWithDatabase;
        List<WorkWithDatabase.Message> messages = new List<WorkWithDatabase.Message>();
        StructMessage messageFromMailServer;
        List<StructMessage> arrayMessagesFromMailServer = new List<StructMessage>();
        List<string> uniqueIds = new List<string>();
        public MainForm(string UserEmail, string UserPassword, int IDUser)
        {
            InitializeComponent();
            email = UserEmail;
            password = UserPassword;
            ID = IDUser;
            workWithDatabase = new WorkWithDatabase();
            inboxMessageWorker.WorkerReportsProgress = true;
            inboxMessageWorker.WorkerSupportsCancellation = true;
            draftMessageWorker.WorkerReportsProgress = true;
            draftMessageWorker.WorkerSupportsCancellation = true;
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
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            if (check.IsInternetConnected())
            {
                sentMessageWorker.DoWork += (c, ex) => sentMessageWorker_DoWork(c, ex);
                if (!sentMessageWorker.IsBusy)
                {
                    sentMessageWorker.RunWorkerAsync();
                }
            }
            else
            {
                workWithDatabase.GetMessage(ID, "SNT", out messages);
                UserMessagesTable.Rows.Clear();
                if (messages.Count > 0)
                    foreach (var arraySendMessages in messages)
                        UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                else
                    toolStripStatusLabel1.Text = "Эта папка пуста.";
            }
        }

        private void DraftMessages_Click(object sender, EventArgs e)
        {
            button = DraftMessages.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            if (check.IsInternetConnected())
            {
                draftMessageWorker.DoWork += (c, ex) => draftMessageWorker_DoWork(c, ex);
                if (!draftMessageWorker.IsBusy)
                {
                    draftMessageWorker.RunWorkerAsync();
                }
            }
            else
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
        }

        private void DeleteMessage_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            button = DeleteMessage.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            if (check.IsInternetConnected())
            {
                trashMessageWorker.DoWork += (c, ex) => trashMessageWorker_DoWork(c, ex);
                if (!trashMessageWorker.IsBusy)
                {
                    trashMessageWorker.RunWorkerAsync();
                }
            }
            else
            {
                workWithDatabase.GetMessage(ID, "DEL", out messages);
                UserMessagesTable.Rows.Clear();
                if (messages.Count > 0)
                    foreach (var arraySendMessages in messages)
                        UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                else
                    toolStripStatusLabel1.Text = "Эта папка пуста.";
            }
            
        }

        private void InboxMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Идёт загрузка...";
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            button = InboxMessages.Text.Trim(' ');
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            if (check.IsInternetConnected())
            {
                inboxMessageWorker.DoWork += (c, ex) => inboxMessageWorker_DoWork(c, ex, Convert.ToBoolean(Settings.Default["POP3Checked"]));
                if (!inboxMessageWorker.IsBusy)
                {
                    inboxMessageWorker.RunWorkerAsync();
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                workWithDatabase.GetMessage(ID, "INB", out messages);
                UserMessagesTable.Rows.Clear();
                if (messages.Count > 0)
                    foreach (var arraySendMessages in messages)
                        UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text);
                else
                    toolStripStatusLabel1.Text = "Эта папка пуста.";
            }
        }

        private void UserMessagesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadMessage readMessage = new ReadMessage();
            #region Get inbox message from net
            if (button == "Входящие")
            {
                if (check.IsInternetConnected())
                {
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
                    catch (Exception ex)
                    {
                        toolStripStatusLabel1.Text = $"Ошибка: {ex.Message}";
                    }
                }
            }
            #endregion
            else
            {
                if (UserMessagesTable.CurrentRow.Cells[0].Value == null)
                    readMessage.email_client.Text = "";
                else
                    readMessage.email_client.Text = UserMessagesTable.CurrentRow.Cells[0].Value.ToString();
                if (UserMessagesTable.CurrentRow.Cells[1].Value == null)
                    readMessage.theme.Text = "";
                else
                    readMessage.theme.Text = UserMessagesTable.CurrentRow.Cells[1].Value.ToString();
                if (UserMessagesTable.CurrentRow.Cells[2].Value == null)
                    readMessage.TextLetter.Text = "";
                else
                    readMessage.TextLetter.Text = UserMessagesTable.CurrentRow.Cells[2].Value.ToString();
                readMessage.ShowDialog();
                toolStripStatusLabel1.Text = "Готово!";
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
                    workWithDatabase.GetMessage(ID, "SNT", out messages);
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

        private void SettingsButton_Click(object sender, EventArgs e)
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
        #region For inbox messages
        private void inboxMessageWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Идёт загрузка...{(e.ProgressPercentage.ToString() + "%")}";
        }

        private void inboxMessageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Готово!";
            foreach (var info in arrayMessagesFromMailServer)
                UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID);
        }

        private void inboxMessageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e, bool TypeProtocol)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (TypeProtocol)
                GetMessageByPOP3();
            else
                GetMessagesByIMAP(worker);
        }
        #endregion
        #region For draft messages
        private void draftMessageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            GetDraftMessages(worker);
        }

        private void draftMessageWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Идёт загрузка...{(e.ProgressPercentage.ToString() + "%")}";
        }

        private void draftMessageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Готово!";
            foreach (var info in arrayMessagesFromMailServer)
                UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID);
        }
        #endregion
        #region For sent message
        private void sentMessageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            GetSentMessages(worker);
        }

        private void sentMessageWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Идёт загрузка...{(e.ProgressPercentage.ToString() + "%")}";
        }

        private void sentMessageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Готово!";
            foreach (var info in arrayMessagesFromMailServer)
                UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID);
        }
        #endregion
        #region For trash message
        private void trashMessageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            GetTrashMessages(worker);
        }

        private void trashMessageWorker_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Идёт загрузка...{(e.ProgressPercentage.ToString() + "%")}";
        }

        private void trashMessageWorker_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Готово!";
            foreach (var info in arrayMessagesFromMailServer)
                UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID);
        }
        #endregion
        #endregion

        private void UserMessagesTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (button == "Входящие")
            {
                foreach (DataGridViewRow row in UserMessagesTable.Rows)
                {
                    foreach (var id in uniqueIds)
                    {
                        try
                        {
                            if (row.Cells[3].Value.ToString() == id)
                            {
                                row.DefaultCellStyle.ForeColor = Color.DimGray;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int index = email.IndexOf("@");
            Text = email.Substring(0, index);
            toolStripStatusLabel1.Text = "";
        }

        #region Get messages
        public void GetMessagesByIMAP(BackgroundWorker worker)
        {
            workWithDatabase.DeleteAllMessageByTypeInDB("INB", ID);
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
                        messageFromMailServer.RecipientAdress = Convert.ToString(message.From);
                        messageFromMailServer.Subject = message.Subject;
                        messageFromMailServer.Text = message.TextBody;
                        messageFromMailServer.UnicID = Convert.ToString(item.UniqueId);
                        arrayMessagesFromMailServer.Add(messageFromMailServer);
                        if (item.Flags.Value.HasFlag(MessageFlags.Seen))
                            uniqueIds.Add(Convert.ToString(item.UniqueId));
                        if (message.Subject == null)
                            workWithDatabase.AddMessageInDB(Convert.ToString(message.From).Replace("'", ""), "", message.TextBody.Replace("'", ""), "INB", Convert.ToString(item.UniqueId), ID);
                        else if (message.TextBody == null)
                            workWithDatabase.AddMessageInDB(Convert.ToString(message.From).Replace("'", ""), message.Subject.Replace("'", ""), "", "INB", Convert.ToString(item.UniqueId), ID);
                        else
                            workWithDatabase.AddMessageInDB(Convert.ToString(message.From).Replace("'", ""), message.Subject.Replace("'", ""), message.TextBody.Replace("'", ""), "INB", Convert.ToString(item.UniqueId), ID);
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

        public void GetDraftMessages(BackgroundWorker worker)
        {
            workWithDatabase.DeleteAllMessageByTypeInDB("DFT", ID);
            try
            {
                arrayMessagesFromMailServer.Clear();
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var draftFolder = client.GetFolder(SpecialFolder.Drafts);
                    if (draftFolder != null)
                    {
                        draftFolder.Open(FolderAccess.ReadOnly);
                        if (draftFolder.Count == 0)
                        {
                            toolStripStatusLabel1.Text = "Эта папка пуста.";
                        }
                        else
                        {
                            double numMessagesForPersent = (double)draftFolder.Count / 100;
                            int countProcesses = 0;
                            for (int i = 0; i < draftFolder.Count; i++)
                            {
                                var draftMessages = draftFolder.GetMessage(i);
                                messageFromMailServer.RecipientAdress = Convert.ToString(draftMessages.From);
                                messageFromMailServer.Subject = draftMessages.Subject;
                                messageFromMailServer.Text = draftMessages.TextBody;
                                messageFromMailServer.UnicID = draftMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                if (draftMessages.Subject == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(draftMessages.From).Replace("'", ""), "", draftMessages.TextBody.Replace("'", ""), "DFT", ID);
                                else if (draftMessages.TextBody == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(draftMessages.From).Replace("'", ""), draftMessages.Subject.Replace("'", ""), "", "DFT", ID);
                                else
                                    workWithDatabase.AddMessageInDB(Convert.ToString(draftMessages.From).Replace("'", ""), draftMessages.Subject.Replace("'", ""), draftMessages.TextBody.Replace("'", ""), "DFT", ID);
                                countProcesses++;
                                if (countProcesses >= numMessagesForPersent)
                                    worker.ReportProgress((int)(countProcesses / numMessagesForPersent));
                            }
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Папки \"Черновик\" нет на этом почтовом сервере.";
                    }
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
        public void GetSentMessages(BackgroundWorker worker)
        {
            workWithDatabase.DeleteAllMessageByTypeInDB("SNT", ID);
            try
            {
                arrayMessagesFromMailServer.Clear();
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var sentFolder = client.GetFolder(SpecialFolder.Sent);
                    if (sentFolder != null)
                    {
                        sentFolder.Open(FolderAccess.ReadOnly);
                        if (sentFolder.Count == 0)
                        {
                            toolStripStatusLabel1.Text = "Эта папка пуста.";
                        }
                        else
                        {
                            double numMessagesForPersent = (double)sentFolder.Count / 100;
                            int countProcesses = 0;
                            for (int i = 0; i < sentFolder.Count; i++)
                            {
                                var sentMessages = sentFolder.GetMessage(i);
                                messageFromMailServer.RecipientAdress = Convert.ToString(sentMessages.From);
                                messageFromMailServer.Subject = sentMessages.Subject;
                                messageFromMailServer.Text = sentMessages.TextBody;
                                messageFromMailServer.UnicID = sentMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                if (sentMessages.Subject == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(sentMessages.From).Replace("'", ""), "", sentMessages.TextBody.Replace("'", ""), "SNT", ID);
                                else if (sentMessages.TextBody == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(sentMessages.From).Replace("'", ""), sentMessages.Subject.Replace("'", ""), "", "SNT", ID);
                                else
                                    workWithDatabase.AddMessageInDB(Convert.ToString(sentMessages.From).Replace("'", ""), sentMessages.Subject.Replace("'", ""), sentMessages.TextBody.Replace("'", ""), "SNT", ID);
                                countProcesses++;
                                if (countProcesses >= numMessagesForPersent)
                                    worker.ReportProgress((int)(countProcesses / numMessagesForPersent));
                            }
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Папки \"Отправленные\" нет на этом почтовом сервере.";
                    }
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
        public void GetTrashMessages(BackgroundWorker worker)
        {
            workWithDatabase.DeleteAllMessageByTypeInDB("DEL", ID);
            try
            {
                arrayMessagesFromMailServer.Clear();
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var trashFolder = client.GetFolder(SpecialFolder.Trash);
                    if (trashFolder != null)
                    {
                        trashFolder.Open(FolderAccess.ReadOnly);
                        if (trashFolder.Count == 0)
                        {
                            toolStripStatusLabel1.Text = "Эта папка пуста.";
                        }
                        else
                        {
                            double numMessagesForPersent = (double)trashFolder.Count / 100;
                            int countProcesses = 0;
                            for (int i = 0; i < trashFolder.Count; i++)
                            {
                                var trashMessages = trashFolder.GetMessage(i);
                                messageFromMailServer.RecipientAdress = Convert.ToString(trashMessages.From);
                                messageFromMailServer.Subject = trashMessages.Subject;
                                messageFromMailServer.Text = trashMessages.TextBody;
                                messageFromMailServer.UnicID = trashMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                if (trashMessages.Subject == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(trashMessages.From).Replace("'", ""), "", trashMessages.TextBody.Replace("'", ""), "DEL", ID);
                                else if (trashMessages.TextBody == null)
                                    workWithDatabase.AddMessageInDB(Convert.ToString(trashMessages.From).Replace("'", ""), trashMessages.Subject.Replace("'", ""), "", "DEL", ID);
                                else
                                    workWithDatabase.AddMessageInDB(Convert.ToString(trashMessages.From).Replace("'", ""), trashMessages.Subject.Replace("'", ""), trashMessages.TextBody.Replace("'", ""), "DEL", ID);
                                countProcesses++;
                                if (countProcesses >= numMessagesForPersent)
                                    worker.ReportProgress((int)(countProcesses / numMessagesForPersent));
                            }
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Папки \"Корзина\" нет на этом почтовом сервере.";
                    }
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
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