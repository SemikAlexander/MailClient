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
using System.Text.RegularExpressions;
using System.Linq;

namespace MainClient
{
    public partial class MainForm : Form
    {
        int Letter = 0, LastIndex = 0;
        string email, password, button = "";
        int ID;
        Check check = new Check();
        Crypto crypto = new Crypto();
        struct StructMessage
        {
            public string RecipientAdress, Subject, Text, UnicID, SeenMessage;
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
            MessageWorker.WorkerReportsProgress = true;
            MessageWorker.WorkerSupportsCancellation = true;
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
            menuPanel.Enabled = functionalPanel.Enabled = false;
            if (check.IsInternetConnected())
            {
                MessageWorker.DoWork += (c, ex) => draftMessageWorker_DoWork(c, ex, "Отправленные");
                if (!MessageWorker.IsBusy)
                {
                    MessageWorker.RunWorkerAsync();
                }
            }
            else
                DataGridOutputMessages("SNT");
        }

        private void DraftMessages_Click(object sender, EventArgs e)
        {
            button = DraftMessages.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            menuPanel.Enabled = functionalPanel.Enabled = false;
            if (check.IsInternetConnected())
            {
                MessageWorker.DoWork += (c, ex) => draftMessageWorker_DoWork(c, ex, "Черновик");
                if (!MessageWorker.IsBusy)
                {
                    MessageWorker.RunWorkerAsync();
                }
            }
            else
                DataGridOutputMessages("DFT");
        }

        private void DeleteMessage_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            button = DeleteMessage.Text.Trim(' ');
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            menuPanel.Enabled = functionalPanel.Enabled = false;
            if (check.IsInternetConnected())
            {
                MessageWorker.DoWork += (c, ex) => draftMessageWorker_DoWork(c, ex, "Удалённые");
                if (!MessageWorker.IsBusy)
                {
                    MessageWorker.RunWorkerAsync();
                }
            }
            else
                DataGridOutputMessages("DEL");
            
        }

        private void JunkMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            EditMessageButton.Visible = EditMessageButton.Visible = RestoreMessageButton.Visible = DeleteMessageButton.Visible = false;
            button = OutgoingMessages.Text.Trim(' ');
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            menuPanel.Enabled = functionalPanel.Enabled = false;
            if (check.IsInternetConnected())
            {
                MessageWorker.DoWork += (c, ex) => draftMessageWorker_DoWork(c, ex, "Спам");
                if (!MessageWorker.IsBusy)
                {
                    MessageWorker.RunWorkerAsync();
                }
            }
            else
                DataGridOutputMessages("JNK");
        }

        private void InboxMessages_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Идёт загрузка...";
            DeleteMessageButton.Visible = EditMessageButton.Visible = false;
            button = InboxMessages.Text.Trim(' ');
            arrayMessagesFromMailServer.Clear();
            UserMessagesTable.Rows.Clear();
            if (check.IsInternetConnected() & (UserMessageFromMailServer() > workWithDatabase.CountInboxMessages("INB") | UserMessageFromMailServer() < workWithDatabase.CountInboxMessages("INB")))
            {
                inboxMessageWorker.DoWork += (c, ex) => inboxMessageWorker_DoWork(c, ex, Convert.ToBoolean(Settings.Default["POP3Checked"]));
                if (!inboxMessageWorker.IsBusy)
                {
                    inboxMessageWorker.RunWorkerAsync();
                }
            }
            else
                DataGridOutputMessages("INB");
        }

        private void UserMessagesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadMessage readMessage = new ReadMessage();
            #region Get message from net
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
                            readMessage.theme.Text = crypto.ReturnDecryptRijndaelString(message.Subject);
                            
                            string prKey = workWithDatabase.GetPrivateKeyForUser(ID);
                            var textForOutput = (string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : crypto.Decrypt(message.TextBody, prKey);

                            WebBrowser wb = new WebBrowser();
                            wb.Navigate("about:blank");
                            wb.Document.Write(textForOutput);
                            wb.Document.ExecCommand("SelectAll", false, null);
                            wb.Document.ExecCommand("Copy", false, null);
                            readMessage.TextLetter.SelectAll();
                            readMessage.TextLetter.Paste();

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
                            IMailFolder inbox;
                            string OutputType = "";
                            switch (button)
                            {
                                case "Спам":
                                    inbox = client.GetFolder(SpecialFolder.Junk);
                                    OutputType = "JNK";
                                    break;
                                case "Входящие":
                                    inbox = client.Inbox;
                                    OutputType = "INB";
                                    break;
                                case "Отправленные":
                                    inbox = client.GetFolder(SpecialFolder.Sent);
                                    OutputType = "SNT";
                                    break;
                                case "Черновик":
                                    inbox = client.GetFolder(SpecialFolder.Drafts);
                                    OutputType = "DFT";
                                    break;
                                case "Удалённые":
                                    inbox = client.GetFolder(SpecialFolder.Trash);
                                    OutputType = "DEL";
                                    break;
                                default:
                                    inbox = client.Inbox;
                                    OutputType = "INB";
                                    break;
                            }
                            inbox.Open(FolderAccess.ReadOnly);
                            if (LastIndex < 0) LastIndex = 0;
                            var message = inbox.GetMessage(LastIndex + UserMessagesTable.CurrentCell.RowIndex);
                            readMessage.email_client.Text = message.From.ToString();

                            readMessage.theme.Text = crypto.ReturnDecryptRijndaelString(message.Subject);

                            string prKey = workWithDatabase.GetPrivateKeyForUser(ID);
                            var textForOutput = (string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : message.TextBody;
                            string[] temp = textForOutput.Split(new string[] { "^&*" }, StringSplitOptions.None);
                            temp[1] = crypto.Decrypt(temp[1], prKey);
                            string DecryptText = "";
                            for (int i = 0; i < temp.Length; i++)    /*Формируем конечную строку*/
                                if (i < temp.Length - 1)
                                    DecryptText += $"{temp[i]}^&*";
                                else
                                    DecryptText += temp[i];
                            textForOutput = crypto.ReturnDecryptRijndaelString(DecryptText);
                            WebBrowser wb = new WebBrowser();
                            wb.Navigate("about:blank");
                            wb.Document.Write(textForOutput);
                            wb.Document.ExecCommand("SelectAll", false, null);
                            wb.Document.ExecCommand("Copy", false, null);
                            readMessage.TextLetter.SelectAll();
                            readMessage.TextLetter.Paste();

                            readMessage.MimeMessage = message;
                            toolStripStatusLabel1.Text = "Готово!";
                            client.Disconnect(true);

                            MarkMessageAsRead(UserMessagesTable.CurrentRow.Index);
                            workWithDatabase.MarkMessageAsReadInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                                UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                                UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                                "INB",
                                ID);

                            DataGridOutputMessages(OutputType);

                            readMessage.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = $"Ошибка: {ex.Message}";
                }
            }
            else
            {
                readMessage.email_client.Text = (UserMessagesTable.CurrentRow.Cells[0].Value == null) ? "" : UserMessagesTable.CurrentRow.Cells[0].Value.ToString();
                readMessage.email_client.Text = (UserMessagesTable.CurrentRow.Cells[1].Value == null) ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString();
                readMessage.email_client.Text = (UserMessagesTable.CurrentRow.Cells[2].Value == null) ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString();
                readMessage.ShowDialog();
                toolStripStatusLabel1.Text = "Готово!";
            }
            #endregion
            
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
                    workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                        "DEL",
                        ID);
                    MarkMessageAsDelete(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString());
                    DataGridOutputMessages("INB");
                    break;
                case "Отправленные":
                    workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                        "DEL",
                        ID);
                    DataGridOutputMessages("SNT");
                    break;
                case "Черновик":
                    workWithDatabase.EditMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                        "DEL",
                        ID);
                    MarkMessageAsDelete(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString());
                    DataGridOutputMessages("DFT");
                    break;
                case "Удалённые":
                    workWithDatabase.DeleteMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                        ID);
                    DataGridOutputMessages("DEL");
                    DeleteByIndex(UserMessagesTable.CurrentRow.Index);  /*Окончательное удаление письма*/
                    break;
                case "Спам":
                    workWithDatabase.DeleteMessageInDB(UserMessagesTable.CurrentRow.Cells[0].Value.ToString(),
                        UserMessagesTable.CurrentRow.Cells[1].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[1].Value.ToString().Replace("'", ""),
                        UserMessagesTable.CurrentRow.Cells[2].Value == null ? "" : UserMessagesTable.CurrentRow.Cells[2].Value.ToString().Replace("'", ""),
                        ID);
                    DataGridOutputMessages("DEL");
                    DeleteByIndex(UserMessagesTable.CurrentRow.Index);  /*Окончательное удаление письма*/
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
            DataGridOutputMessages("DFT");
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
            //foreach (var info in arrayMessagesFromMailServer)
            //    UserMessagesTable.Rows.Add(info.RecipientAdress, info.Subject, info.Text, info.UnicID, info.SeenMessage);
            menuPanel.Enabled = functionalPanel.Enabled = true;
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
        #region For other type of messages
        private void draftMessageWorker_DoWork(object sender, DoWorkEventArgs e, string TypeGetMessange)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            switch (TypeGetMessange)
            {
                case "Отправленные":
                    GetSentMessages(worker);
                    break;
                case "Удалённые":
                    GetTrashMessages(worker);
                    break;
                case "Спам":
                    GetJunkMessages(worker);
                    break;
                case "Черновик":
                    GetDraftMessages(worker);
                    break;
            }
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
            menuPanel.Enabled = functionalPanel.Enabled = true;
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
                            if (row.Cells[4].Value == null)
                            {
                                continue;
                            }
                            row.DefaultCellStyle.ForeColor = row.Cells[4].Value.ToString() == "+" ? Color.DimGray : Color.Black;                           
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
            if (check.IsInternetConnected() & UserMessageFromMailServer() > workWithDatabase.CountInboxMessages("INB"))
            {
                menuPanel.Enabled = functionalPanel.Enabled = false;
                inboxMessageWorker.DoWork += (c, ex) => inboxMessageWorker_DoWork(c, ex, Convert.ToBoolean(Settings.Default["POP3Checked"]));
                if (!inboxMessageWorker.IsBusy)
                {
                    inboxMessageWorker.RunWorkerAsync();
                }
            }
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
                        messageFromMailServer.Text = (string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : message.TextBody;
                        messageFromMailServer.UnicID = Convert.ToString(item.UniqueId);
                        workWithDatabase.AddMessageInDB(messageFromMailServer.RecipientAdress.Replace("'", ""), 
                            messageFromMailServer.Subject.Replace("'", ""), 
                            StripHTML((string.IsNullOrWhiteSpace(message.TextBody)) ? message.HtmlBody : message.TextBody).Replace("'", ""), 
                            "INB", 
                            messageFromMailServer.UnicID, 
                            ID, 
                            messageFromMailServer.SeenMessage);
                        if (item.Flags.Value.HasFlag(MessageFlags.Seen))
                        {
                            messageFromMailServer.SeenMessage = "+";
                            uniqueIds.Add(Convert.ToString(item.UniqueId));
                        }
                        else
                            messageFromMailServer.SeenMessage = "-";
                        arrayMessagesFromMailServer.Add(messageFromMailServer);
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
                                messageFromMailServer.RecipientAdress = (string.IsNullOrWhiteSpace(Convert.ToString(draftMessages.From))) ? "" : Convert.ToString(draftMessages.From);
                                messageFromMailServer.Subject = (string.IsNullOrWhiteSpace(draftMessages.Subject)) ? "" : draftMessages.Subject;
                                messageFromMailServer.Text = (string.IsNullOrWhiteSpace(draftMessages.TextBody)) ? draftMessages.HtmlBody : draftMessages.TextBody;
                                messageFromMailServer.UnicID = draftMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
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
        public void GetJunkMessages(BackgroundWorker worker)
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
                    var draftFolder = client.GetFolder(SpecialFolder.Junk);
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
                                messageFromMailServer.RecipientAdress = (string.IsNullOrWhiteSpace(Convert.ToString(draftMessages.From))) ? "" : Convert.ToString(draftMessages.From);
                                messageFromMailServer.Subject = (string.IsNullOrWhiteSpace(draftMessages.Subject)) ? "" : draftMessages.Subject;
                                messageFromMailServer.Text = (string.IsNullOrWhiteSpace(draftMessages.TextBody)) ? draftMessages.HtmlBody : draftMessages.TextBody;
                                messageFromMailServer.UnicID = draftMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                workWithDatabase.AddMessageInDB(messageFromMailServer.RecipientAdress.Replace("'", ""), messageFromMailServer.Subject, messageFromMailServer.Text.Replace("'", ""), "JNK", ID);
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
                                messageFromMailServer.RecipientAdress = (string.IsNullOrWhiteSpace(Convert.ToString(sentMessages.From))) ? "" : Convert.ToString(sentMessages.From);
                                messageFromMailServer.Subject = (string.IsNullOrWhiteSpace(sentMessages.Subject)) ? "" : sentMessages.Subject;
                                messageFromMailServer.Text = (string.IsNullOrWhiteSpace(sentMessages.TextBody)) ? sentMessages.HtmlBody : sentMessages.TextBody;
                                messageFromMailServer.UnicID = sentMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                workWithDatabase.AddMessageInDB(messageFromMailServer.RecipientAdress.Replace("'", ""), messageFromMailServer.Subject, messageFromMailServer.Text.Replace("'", ""), "SNT", ID);
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
                                messageFromMailServer.RecipientAdress = (string.IsNullOrWhiteSpace(Convert.ToString(trashMessages.From))) ? "" : Convert.ToString(trashMessages.From);
                                messageFromMailServer.Subject = (string.IsNullOrWhiteSpace(trashMessages.Subject)) ? "" : trashMessages.Subject;
                                messageFromMailServer.Text = (string.IsNullOrWhiteSpace(trashMessages.TextBody)) ? trashMessages.HtmlBody : trashMessages.TextBody;
                                messageFromMailServer.UnicID = trashMessages.MessageId;
                                arrayMessagesFromMailServer.Add(messageFromMailServer);
                                workWithDatabase.AddMessageInDB(messageFromMailServer.RecipientAdress.Replace("'", ""), messageFromMailServer.Subject, messageFromMailServer.Text.Replace("'", ""), "DEL", ID);
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
        public void DataGridOutputMessages(string TypeMessage)
        {
            workWithDatabase.GetMessage(ID, TypeMessage, out messages);
            UserMessagesTable.Rows.Clear();
            if (messages.Count > 0)
                foreach (var arraySendMessages in messages)
                    UserMessagesTable.Rows.Add(arraySendMessages.RecipientAdress, arraySendMessages.Subject, arraySendMessages.Text, arraySendMessages.MessId, arraySendMessages.Seen);
            else
                toolStripStatusLabel1.Text = "Эта папка пуста.";
        }
        public void DeleteByIndex(int index)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadWrite);
                    inbox.AddFlags(index, MessageFlags.Deleted, true);
                    inbox.Expunge();
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
        public void MarkMessageAsRead(int index)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadWrite);
                    inbox.AddFlags(index, MessageFlags.Seen, true);
                    inbox.Expunge();
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
        public void MarkMessageAsDelete(string RecAdress, string Subject, string Text)
        {
            string[] adress = RecAdress.Split('<');
            RecAdress = adress[1].Replace(">", "");
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                    client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                    client.Authenticate(email, password);

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(RecAdress));
                    message.To.Add(new MailboxAddress(email));
                    message.Subject = Subject;
                    var builder = new BodyBuilder();
                    builder.TextBody = Text;
                    message.Body = builder.ToMessageBody();
                    var TrashFolder = client.GetFolder(SpecialFolder.Trash);
                    if (TrashFolder != null)
                    {
                        TrashFolder.Open(FolderAccess.ReadWrite);
                        TrashFolder.Append(message, MessageFlags.None);
                        TrashFolder.Expunge();
                    }
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ошибка: " + ex.Message;
            }
        }
        public int UserMessageFromMailServer()
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                client.Authenticate(email, password);
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                var result = inbox.Count;
                client.Disconnect(true);
                return result;
            }
        }
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}