using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.SQLite;
using MainClient.Properties;

namespace MainClient
{
    public partial class Authorization : Form
    {
        Check check;
        int IDUser;
        public Authorization()
        {
            InitializeComponent();
            check = new Check();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crypto crypto = new Crypto();
            WorkWithDatabase workWithDatabase = new WorkWithDatabase();
            if(!string.IsNullOrWhiteSpace(mailTextBox.Text) & !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                #region Get name mail server
                string[] name = mailTextBox.Text.Split('@');
                string nameServer = name[1];
                nameServer = nameServer.Substring(0, nameServer.IndexOf('.'));
                #endregion

                if (!check.IsValidEmail(mailTextBox.Text))
                {
                    MessageBox.Show("Email неверный!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!check.IsMailServerKnown(nameServer))
                {
                    switch (MessageBox.Show("Данный почтового сервис неизвестен. Хотите добавить настройки для него?", "Неизвестный сревис", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                    {
                        case DialogResult.OK:
                            SettingsForm settingsForm = new SettingsForm("Add");
                            settingsForm.Show();
                            break;
                    }
                }
                else
                {
                    GetConfigurationForConnection(mailTextBox.Text, nameServer);    /*Проверка на то, что с файлом БД всё впорядке*/
                    try
                    {
                        using (var client = new SmtpClient())
                        {
                            if (Text == "Авторизация")
                            {
                                client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                                client.Connect(Settings.Default["SMTPAdress"].ToString(), Convert.ToInt32(Settings.Default["SMTPPort"]), true); //https://www.google.com/settings/security/lesssecureapps
                                client.Authenticate(mailTextBox.Text, passwordTextBox.Text);
                                client.Disconnect(true);
                                if (workWithDatabase.AuthUser(crypto.Hesh(mailTextBox.Text), crypto.Hesh(passwordTextBox.Text), out IDUser))
                                {
                                    MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text, IDUser);
                                    mainForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    var keys = crypto.GenerateKeys(Crypto.RSAKeySize.Key2048);  /*Генерация ключей под конкретного пользователя*/
                                    workWithDatabase.AddUser(crypto.Hesh(mailTextBox.Text), crypto.Hesh(passwordTextBox.Text), keys.PublicKey, keys.PrivateKey, out IDUser);
                                    MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text, IDUser);
                                    mainForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                if (workWithDatabase.GetUser(crypto.Hesh(mailTextBox.Text), crypto.Hesh(mailTextBox.Text), out IDUser))
                                {
                                    MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text, IDUser);
                                    mainForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Вы не были авторизированны в программе. Подключитесь к интернету и повторите попытку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
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

        private void Authorization_Load(object sender, EventArgs e)
        {
            if (check.IsInternetConnected())
                Text = "Авторизация";
            else
                Text = "Авторизация (offline mode)";
        }

        public void GetConfigurationForConnection(string userMail, string nameMailServer)  /*get ports and adress for connection*/
        {
            string pathToDBFileFromInternet = Path.GetFullPath(@"MailClientDB.db");
            if (!File.Exists(pathToDBFileFromInternet))
            {
                using(var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/SemikAlexander/MailClient/blob/master/MailClient/MainClient/bin/MailClientDB.db", pathToDBFileFromInternet);
                }
            }
            else
            {
                using(SQLiteConnection connection = new SQLiteConnection($"Data Source={pathToDBFileFromInternet}"))
                {
                    using(SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        connection.Open();
                        command.CommandText = $"SELECT IMAPAdress, POP3Adress, SMTPAdress, IMAPPort, POP3Port, SMTPPort FROM MailServers WHERE NameServer='{nameMailServer}'";
                        command.ExecuteNonQuery();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Settings.Default["IMAPAdress"] = (string)reader["IMAPAdress"];
                                Settings.Default["POP3Adress"] = (string)reader["POP3Adress"];
                                Settings.Default["SMTPAdress"] = (string)reader["SMTPAdress"];
                                Settings.Default["IMAPPort"] = Convert.ToInt32(reader["IMAPPort"]);
                                Settings.Default["POP3Port"] = Convert.ToInt32(reader["POP3Port"]);
                                Settings.Default["SMTPPort"] = Convert.ToInt32(reader["SMTPPort"]);
                            }
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}