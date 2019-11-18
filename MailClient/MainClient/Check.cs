using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MainClient
{
    class Check
    {
        public bool IsValidEmail(string email)
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

        public bool IsInternetConnected()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsMailServerKnown(string NameServer)
        {
            int index = -1;
            List<string> MailServers;
            WorkWithDatabase workWithDatabase = new WorkWithDatabase();
            workWithDatabase.GetMailServers(out MailServers);
            index = MailServers.IndexOf(NameServer);
            if (index == -1)
                return false;
            else
                return true;
        }
    }
}
