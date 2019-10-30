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
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(mailTextBox.Text) & !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                if (!IsValidEmail(mailTextBox.Text))
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
                            client.Connect(Settings.Default["SMTPAdress"].ToString(), Convert.ToInt32(Settings.Default["SMTPPort"]), true);
                            client.Authenticate(mailTextBox.Text, passwordTextBox.Text);
                            MainForm mainForm = new MainForm(mailTextBox.Text, passwordTextBox.Text);
                            mainForm.Show();
                            this.Hide();
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
            if (IsInternetConnected())
                this.Text = "Авторизация";
            else
                this.Text = "Авторизация  (offline mode)";
        }

        public bool IsInternetConnected()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    this.Text = "Авторизация";
                return true;
            }
            catch
            {
                this.Text = "Авторизация  (offline mode)";
                return false;
            }
        }    
        bool IsValidEmail(string email)
        {
            try
            {
                var adress = new System.Net.Mail.MailAddress(email);
                return adress.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void GetConfigurationForConnection(string userMail)
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
                string NameServer = temp.Substring(0, index);
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
                //using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
                //{
                //    connection.Open();
                //    SQLiteCommand command = new SQLiteCommand
                //    {
                //        Connection = connection,
                //        CommandText = $"SELECT IMAPAdress, POP3Adress, SMTPAdress, IMAPPort, POP3Port, SMTPPort FROM MailServers WHERE NameServer='{NameServer}'"
                        
                //    };
                //    SQLiteDataReader sqlReader = command.ExecuteReader();
                //    Settings.Default["IMAPAdress"] = (string)sqlReader["IMAPAdress"];
                //    Settings.Default["POP3Adress"] = (string)sqlReader["POP3Adress"];
                //    Settings.Default["SMTPAdress"] = (string)sqlReader["SMTPAdress"];
                //    Settings.Default["IMAPPort"] = (int)sqlReader["IMAPPort"];
                //    Settings.Default["POP3Port"] = (int)sqlReader["POP3Port"];
                //    Settings.Default["SMTPPort"] = (int)sqlReader["SMTPPort"];
                //    Settings.Default["POP3Checked"] = true;
                //    Settings.Default["IMAPChecked"] = false;
                //    connection.Close();
                //}
            }
        }
    }
}