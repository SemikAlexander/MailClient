using System;
using System.Collections.Generic;
using System.Text;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Limilabs.Mail.MIME;
using System.IO;


namespace MailClientTest
{
    class Program
    {
        private const string _server = "imap.gmail.com";
        private const string _user = "alexander.semik.99@gmail.com";
        private const string _password = "Alex_Semik_9";
        static void Main(string[] args)
        {
            using (Imap imap = new Imap())
            {
                imap.Connect(_server);                              // Use overloads or ConnectSSL if you need to specify different port or SSL.
                imap.Login(_user, _password);                       // You can also use: LoginPLAIN, LoginCRAM, LoginDIGEST, LoginOAUTH methods,
                                                                    // or use UseBestLogin method if you want Mail.dll to choose for you.

                imap.SelectInbox();                                 // You can select other folders, e.g. Sent folder: imap.Select("Sent");

                List<long> uids = imap.Search(Flag.All);     // Find all unseen messages.

                Console.WriteLine("Number of unseen messages is: " + uids.Count);

                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder().CreateFromEml(  // Download and parse each message.
                        imap.GetMessageByUID(uid));
                    ProcessMessage(email);                          // Display email data, save attachments.
                }
                imap.Close();
                Console.ReadKey();
            }
        }
        private static void ProcessMessage(IMail email)
        {
            using(FileStream fs = new FileStream("C:\\Users\\Admin\\Desktop\\MyFile.txt",FileMode.OpenOrCreate))
            {
                using(StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Subject: " + email.Subject);
                    writer.WriteLine("From: " + JoinAddresses(email.From));
                    writer.WriteLine("To: " + JoinAddresses(email.To));
                    writer.WriteLine("Cc: " + JoinAddresses(email.Cc));
                    writer.WriteLine("Bcc: " + JoinAddresses(email.Bcc));

                    writer.WriteLine("Text: " + email.Text);

                    writer.WriteLine("Attachments: ");
                    foreach (MimeData attachment in email.Attachments)
                    {
                        writer.WriteLine(attachment.FileName);
                        attachment.Save(@"c:\" + attachment.SafeFileName);
                    }
                }
            }
        }

        private static string JoinAddresses(IList<MailBox> mailboxes)
        {
            return string.Join(",",
                new List<MailBox>(mailboxes).ConvertAll(m => string.Format("{0} <{1}>", m.Name, m.Address))
                .ToArray());
        }

        private static string JoinAddresses(IList<MailAddress> addresses)
        {
            StringBuilder builder = new StringBuilder();

            foreach (MailAddress address in addresses)
            {
                if (address is MailGroup)
                {
                    MailGroup group = (MailGroup)address;
                    builder.AppendFormat("{0}: {1};, ", group.Name, JoinAddresses(group.Addresses));
                }
                if (address is MailBox)
                {
                    MailBox mailbox = (MailBox)address;
                    builder.AppendFormat("{0} <{1}>, ", mailbox.Name, mailbox.Address);
                }
            }
            return builder.ToString();
        }
    }
}