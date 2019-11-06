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
                if (!check.IsValidEmail(mailTextBox.Text))
                {
                    MessageBox.Show("Email неверный!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    GetConfigurationForConnection(mailTextBox.Text);
                    try
                    {
                        using (var client = new SmtpClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, ex) => true;
                            client.Connect(Settings.Default["SMTPAdress"].ToString(), Convert.ToInt32(Settings.Default["SMTPPort"]), true); //https://www.google.com/settings/security/lesssecureapps
                            client.Authenticate(mailTextBox.Text, passwordTextBox.Text);
                            client.Disconnect(true);
                            crypto.Hesh(mailTextBox.Text);
                            if (workWithDatabase.GetUser(crypto.Hesh(mailTextBox.Text), crypto.Hesh(mailTextBox.Text)))
                            {
                                MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                workWithDatabase.AddUser(crypto.Hesh(mailTextBox.Text), crypto.Hesh(mailTextBox.Text));
                                MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text);
                                mainForm.Show();
                                this.Hide();
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
                this.Text = "Авторизация";
            else
                this.Text = "Авторизация (offline mode)";
        }

        public void GetConfigurationForConnection(string userMail)  /*get ports and adress for connection*/
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
                int index = userMail.IndexOf('@');
                string temp = userMail.Substring(index + 1);
                index = temp.IndexOf(".");
                string NameServer = temp.Substring(0, index);   /*get name server (yandex, gmail, mail)*/
                using(SQLiteConnection connection = new SQLiteConnection($"Data Source={pathToDBFileFromInternet}"))
                {
                    using(SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        connection.Open();
                        command.CommandText = $"SELECT IMAPAdress, POP3Adress, SMTPAdress, IMAPPort, POP3Port, SMTPPort FROM MailServers WHERE NameServer='{NameServer}'";
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