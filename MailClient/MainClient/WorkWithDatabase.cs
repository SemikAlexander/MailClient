using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MainClient
{
    class WorkWithDatabase
    {
        public struct Message
        {
            public string RecipientAdress, Subject, Text, Seen;
        }
        Message message;
        public bool GetUser(string UserEmail, string UserPassword, out int IDUser)
        {
            IDUser = -1;
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"SELECT ID AS idUser FROM Users WHERE Login = '{UserEmail}' AND Password = '{UserPassword}'";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDUser = Convert.ToInt32(reader["idUser"]);
                        }
                        connection.Close();
                        return IDUser != -1 ? true : false;
                    }
                }
            }
        }      
        public int GetCountUser()
        {
            int res = 0;
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"SELECT COUNT(*) AS res_count FROM Users";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res = Convert.ToInt32(reader["res_count"]);
                        }
                        connection.Close();
                        return res;
                    }
                }
            }
        }
        public void AddUser(string UserEmail, string UserPassword, out int IDUser)
        {
            IDUser = GetCountUser() + 1;
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO Users (ID, Login, Password) VALUES ({IDUser}, '{UserEmail}', '{UserPassword}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void AddMessageInDB(string RecipientAdress, string Subject, string Text, string typeMessage, int IDUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO UserMessages (RecipientAdress, SubjectLetter, TextLetter, IDSender, TypeMessage) VALUES ('{RecipientAdress}','{Subject}','{Text}',{IDUser},'{typeMessage}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void AddMessageInDB(string RecipientAdress, string Subject, string Text, string typeMessage, string IDMessage, int IDUser, string IsSeen)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO UserMessages (RecipientAdress, SubjectLetter, TextLetter, IDSender, TypeMessage, MessageID, Seen) VALUES ('{RecipientAdress}','{Subject}','{Text}',{IDUser},'{typeMessage}','{IDMessage}', '{IsSeen}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void EditMessageInDB(string RecipientAdress, string Subject, string Text, string typeMessage, int IDUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"UPDATE UserMessages SET TypeMessage=\"{typeMessage}\" WHERE RecipientAdress = '{RecipientAdress}' AND SubjectLetter='{Subject}' AND TextLetter='{Text}' AND IDSender = {IDUser};";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void DeleteMessageInDB(string RecipientAdress, string Subject, string Text, int IDUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"DELETE FROM UserMessages WHERE RecipientAdress = '{RecipientAdress}' AND SubjectLetter='{Subject}' AND TextLetter='{Text}' AND IDSender = {IDUser} AND TypeMessage = 'DEL';";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void DeleteAllMessageByTypeInDB(string TypeMessage, int IDUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"DELETE FROM UserMessages WHERE IDSender = {IDUser} AND TypeMessage = '{TypeMessage}';";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void GetMessage(int IDUser, string typeMessage, out List<Message> messages)
        {
            messages = new List<Message>();
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"SELECT * FROM UserMessages WHERE IDSender = {IDUser} AND TypeMessage = \"{typeMessage}\"";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message.RecipientAdress = Convert.ToString(reader["RecipientAdress"]);
                            message.Subject = Convert.ToString(reader["SubjectLetter"]);
                            message.Text = Convert.ToString(reader["TextLetter"]);
                            message.Seen = Convert.ToString(reader["Seen"]);
                            messages.Add(message);
                        }
                        connection.Close();
                    }
                }
            }
        }
        public void GetMailServers(out List<string> NameServers)
        {
            NameServers = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"SELECT NameServer FROM MailServers";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NameServers.Add(Convert.ToString(reader["NameServer"]));
                        }
                        connection.Close();
                    }
                }
            }
        }
        public void AddMailServer(string imapAdress, string pop3Adress, string smtpAdress, int imapPort, int pop3Port, int smtpPort)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    int NumMailServers = 0;
                    connection.Open();
                    command.CommandText = $"SELECT COUNT(NameServer) AS res FROM MailServers";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NumMailServers = Convert.ToInt32(reader["res"]);
                        }
                    }
                    command.CommandText = $"INSERT INTO MailServers (ID, IMAPAdress, POP3Adress, SMTPAdress, IMAPPort, POP3Port, SMTPPort) " +
                        $"VALUES ('{NumMailServers}','{imapAdress}','{pop3Adress}','{smtpAdress}','{imapPort}','{pop3Port}','{smtpPort}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
