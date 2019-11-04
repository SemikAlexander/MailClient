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
        public bool GetUser(string UserEmail, string UserPassword)
        {
            int res = 0;
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"SELECT COUNT(*) AS res_count FROM Users WHERE Login = '{UserEmail}' AND Password = '{UserPassword}'";
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res = Convert.ToInt32(reader["res_count"]);
                        }
                        connection.Close();
                        return res > 0 ? true : false;
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

        public bool AddUser(string UserEmail, string UserPassword)
        {
            int countUser = GetCountUser();
            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=MailClientDB.db"))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO Users (ID, Login, Password) VALUES ({countUser + 1}, '{UserEmail}', '{UserPassword}');";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }
    }
}
