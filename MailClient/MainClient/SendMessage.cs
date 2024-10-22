﻿using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using System.Windows.Forms;
using MainClient.Properties;
using System.IO;
using MailKit;
using System.Drawing;
using System.Drawing.Text;
using Microsoft.VisualBasic;

namespace MainClient
{
    public partial class SendMessage : Form
    {
        string AttachmentFile = "";
        MainForm mainForm;
        string UserEmail, UserPassword;
        int ID;
        WorkWithDatabase workWithDatabase;
        Crypto crypto;
        bool MessageFromDraft;
        string StartTegs = "";
        string EndTegs = "";
        public SendMessage(string email, string password, int IDUser, MainForm mainForm1, bool IsMessageFromDraft)
        {
            InitializeComponent();
            mainForm = mainForm1;
            UserEmail = email;
            UserPassword = password;
            ID = IDUser;
            MessageFromDraft = IsMessageFromDraft;
            workWithDatabase = new WorkWithDatabase();
            crypto = new Crypto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                AttachmentFile = FD.FileName;
                AttachmentFileLabel.Text = Path.GetFileName(FD.FileName);
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

                        string[] temp = crypto.ReturnEncryptRijndaelString(TextLetter.Text).Split(new string[] { "^&*" }, StringSplitOptions.None); /*временный массив для формирования зашифрованного сообщения согласно заданной последовательности*/

                        string pbKey = workWithDatabase.GetPublicKeyForUser(ID);  /*"Берём public ключ из базы"*/

                        temp[1] = crypto.Encrypt(temp[1], pbKey);   /*Шифруем ключ при помощи алгоритма RSA*/

                        string EncryptText = "";

                        for (int i = 0; i < temp.Length; i++)    /*Формируем конечную строку*/
                        {
                            if (i < temp.Length - 1)
                                EncryptText += $"{temp[i]}^&*";
                            else
                                EncryptText += temp[i];
                        }

                        builder.TextBody = EncryptText;

                        if (AttachmentFile != "")
                        {
                            builder.Attachments.Add(AttachmentFile);
                        }
                        message.Body = builder.ToMessageBody();
                        if (!MessageFromDraft)
                        {
                            workWithDatabase.AddMessageInDB(crypto.ReturnEncryptRijndaelString(email_client.Text),
                                crypto.ReturnEncryptRijndaelString(theme.Text),
                                crypto.ReturnEncryptRijndaelString(TextLetter.Text), 
                                "DFT", 
                                ID);
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
            if((TextLetter.Font.Style & FontStyle.Bold) != 0)
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Regular);
                StartTegs = StartTegs.Replace("<b>","");
                EndTegs = EndTegs.Replace("</b>", "");
            }
            else
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Bold);
                if (StartTegs.IndexOf("<b>") == -1)
                {
                    StartTegs = "<b>";
                    EndTegs = "</b>";
                }
                else
                    return;
            }
        }

        private void ItalicButton_Click(object sender, EventArgs e)
        {
            if ((TextLetter.Font.Style & FontStyle.Italic) != 0)
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Regular);
                StartTegs = StartTegs.Replace("<i>", "");
                EndTegs = EndTegs.Replace("</i>", "");
            }
            else
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Italic);
                if (StartTegs.IndexOf("<i>") == -1)
                {
                    StartTegs = "<i>";
                    EndTegs = "</i>";
                }
                else
                    return;
            }
        }

        private void UnderlineButton_Click(object sender, EventArgs e)
        {
            if ((TextLetter.Font.Style & FontStyle.Underline) != 0)
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Regular);
                StartTegs = StartTegs.Replace("<u>", "");
                EndTegs = EndTegs.Replace("</u>", "");
            }
            else
            {
                TextLetter.Font = new Font(TextLetter.Font, FontStyle.Underline);
                if (StartTegs.IndexOf("<u>") == -1)
                {
                    StartTegs = "<u>";
                    EndTegs = "</u>";
                }
                else
                    return;
            }
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
            FontsComboBox.SelectedItem = "Consolas";
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
                        workWithDatabase.AddMessageInDB(crypto.ReturnEncryptRijndaelString(email_client.Text), 
                            crypto.ReturnEncryptRijndaelString(theme.Text),
                            crypto.ReturnEncryptRijndaelString(TextLetter.Text), 
                            "DFT", 
                            ID);
                        email_client.Text = theme.Text = TextLetter.Text = "";
                        return;
                    default:
                        Close();
                        break;
                }
            }

            /*Шифрование происходит здесь!*/
            string pbKey = workWithDatabase.GetPublicKeyForUser(email_client.Text);  /*Берём public ключ из базы*/
            string prKey = workWithDatabase.GetPrivateKeyForUser(ID);  /*Берём private ключ из базы*/
            if (!string.IsNullOrWhiteSpace(pbKey))
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(UserEmail));
                message.To.Add(new MailboxAddress(email_client.Text));
                message.Subject = theme.Text;
                var builder = new BodyBuilder();

                string inputText = $"<p align=\"{TextLetter.TextAlign}\">{StartTegs}<font size=\"{Convert.ToInt32(UserFontSize.Value / 2)}\" face=\"{FontsComboBox.SelectedItem.ToString()}\">{TextLetter.Text}{EndTegs}</p>";

                string[] temp = crypto.ReturnEncryptRijndaelString(inputText).Split(new string[] { "^&*" }, StringSplitOptions.None); /*временный массив для формирования зашифрованного сообщения согласно заданной последовательности*/

                temp[1] = crypto.Encrypt(temp[1], pbKey);   /*Шифруем ключ при помощи алгоритма RSA*/

                string EncryptText = "";

                for (int i = 0; i < temp.Length; i++)    /*Формируем конечную строку*/
                {
                    EncryptText += $"{temp[i]}^&*";
                }

                string digitalSignature = crypto.Hesh(inputText);
                EncryptText += digitalSignature;


                builder.TextBody = EncryptText;
                builder.HtmlBody = EncryptText;

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
                            workWithDatabase.AddMessageInDB(crypto.ReturnEncryptRijndaelString(email_client.Text),
                            crypto.ReturnEncryptRijndaelString(theme.Text),
                            crypto.ReturnEncryptRijndaelString(TextLetter.Text),
                            "SNT", 
                            ID);
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
                            workWithDatabase.EditMessageInDB(crypto.ReturnEncryptRijndaelString(email_client.Text),
                            crypto.ReturnEncryptRijndaelString(theme.Text),
                            crypto.ReturnEncryptRijndaelString(TextLetter.Text), 
                            "SNT", 
                            ID);
                        }
                        MessageBox.Show("Письмо отправленно!", "Доставка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        email_client.Text = theme.Text = TextLetter.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    mainForm.toolStripStatusLabel1.Text = "Ошибка: " + ex.Message;
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                switch (MessageBox.Show("Для данного пользователя у вас отсутствует публичный ключ! Хотите ввести ключ?", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.OK:
                        pbKey = Interaction.InputBox("Введите публичный ключ в текстовое поле и нажмите \"ОК\"", "Ввод ключа", "");
                        if (!string.IsNullOrWhiteSpace(pbKey))
                            workWithDatabase.AddUser(email_client.Text, pbKey);
                        else
                        {
                            MessageBox.Show("Вы не ввели публичный ключ!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
        }
    }
}