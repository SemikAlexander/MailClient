using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using System.Windows.Forms;
using MainClient.Properties;
using System.IO;
using MailKit;
using System.Drawing;
using System.Drawing.Text;

namespace MainClient
{
    public partial class SendMessage : Form
    {
        string AttachmentFile = "";
        MainForm mainForm;
        string UserEmail, UserPassword;
        int ID;
        WorkWithDatabase workWithDatabase;
        bool MessageFromDraft;
        public SendMessage(string email, string password, int IDUser, MainForm mainForm1, bool IsMessageFromDraft)
        {
            InitializeComponent();
            mainForm = mainForm1;
            UserEmail = email;
            UserPassword = password;
            ID = IDUser;
            MessageFromDraft = IsMessageFromDraft;
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
            if (TextLetter.Text.Length != 0 || email_client.Text.Length != 0 || theme.Text.Length != 0)
            {
                switch (MessageBox.Show("Сохранить сообщение в черновики?", "Сохранить", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.OK:
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
                        if (!MessageFromDraft)
                        {
                            workWithDatabase.AddMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "DFT", ID);
                            try
                            {
                                using (var client1 = new ImapClient())
                                {
                                    client1.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                                    client1.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                                    client1.Authenticate(UserEmail, UserPassword);

                                    var draftFolder = client1.GetFolder(SpecialFolder.Drafts);
                                    if (draftFolder != null)
                                    {
                                        draftFolder.Open(FolderAccess.ReadWrite);
                                        draftFolder.Append(message, MessageFlags.Draft);
                                        draftFolder.Expunge();
                                    }
                                    client1.Disconnect(true);
                                }
                                MessageBox.Show("Письмо сохранено в черновики!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                email_client.Text = theme.Text = TextLetter.Text = "";

                            }
                            catch (Exception ex)
                            {
                                mainForm.toolStripStatusLabel1.Text = "Ошибка: " + ex.Message;
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                            workWithDatabase.EditMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "DFT", ID);
                        Hide();
                        break;
                    case DialogResult.Cancel:
                        email_client.Text = theme.Text = TextLetter.Text = "";
                        Close();
                        break;
                }
            }
        }

        #region Text format
        private void BoldButton_Click(object sender, EventArgs e)
        {
            TextLetter.Font = ((TextLetter.Font.Style & FontStyle.Bold) != 0) ? new Font(TextLetter.Font, FontStyle.Regular) : new Font(TextLetter.Font, FontStyle.Bold);
        }

        private void ItalicButton_Click(object sender, EventArgs e)
        {
            TextLetter.Font = ((TextLetter.Font.Style & FontStyle.Italic) != 0) ? new Font(TextLetter.Font, FontStyle.Regular) : new Font(TextLetter.Font, FontStyle.Italic);
        }

        private void UnderlineButton_Click(object sender, EventArgs e)
        {
            TextLetter.Font = ((TextLetter.Font.Style & FontStyle.Underline) != 0) ? new Font(TextLetter.Font, FontStyle.Regular) : new Font(TextLetter.Font, FontStyle.Underline);
        }

        private void AlginLeft_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Left;
        }

        private void AlginCenter_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Center;
        }

        private void AlginRight_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Right;
        }       

        private void UserFontSize_ValueChanged(object sender, EventArgs e)
        {
            TextLetter.Font = new System.Drawing.Font(FontsComboBox.SelectedItem.ToString(), (float)UserFontSize.Value);
        }

        private void FontsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextLetter.Font = new System.Drawing.Font(FontsComboBox.SelectedItem.ToString(), (float)UserFontSize.Value);
            }
            catch(Exception)
            {

            }
        }
        #endregion

        private void SendMessage_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] UserFonts = fonts.Families;
            foreach (var allFonts in UserFonts)
            {
                FontsComboBox.Items.Add(allFonts.Name);
            }
            FontsComboBox.SelectedItem = UserFonts[0].Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check check = new Check();
            if (!check.IsValidEmail(email_client.Text))
            {
                MessageBox.Show("Email неверный!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(TextLetter.Text))
            {
                MessageBox.Show("Cодержимое письма пусто!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!check.IsInternetConnected())
            {
                switch (MessageBox.Show("Подключение с интернет отсутствует! Сохранить сообщение в черновики?", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    case DialogResult.OK:
                        workWithDatabase.AddMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "DFT", ID);
                        email_client.Text = theme.Text = TextLetter.Text = "";
                        return;
                    default:
                        Close();
                        break;
                }
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
                    if (!MessageFromDraft)
                    {
                        workWithDatabase.AddMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "SNT", ID);
                        using (var client1 = new ImapClient())
                        {
                            client1.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                            client1.Connect(Settings.Default["IMAPAdress"].ToString(), Convert.ToInt32(Settings.Default["IMAPPort"]), true);
                            client1.Authenticate(UserEmail, UserPassword);
                            var draftFolder = client1.GetFolder(SpecialFolder.Sent);
                            if (draftFolder != null)
                            {
                                draftFolder.Open(FolderAccess.ReadWrite);
                                draftFolder.Append(message, MessageFlags.None);
                                draftFolder.Expunge();
                            }
                            client1.Disconnect(true);
                        }
                    }
                    else
                    {
                        workWithDatabase.EditMessageInDB(email_client.Text, theme.Text, TextLetter.Text, "SNT", ID);
                    }
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