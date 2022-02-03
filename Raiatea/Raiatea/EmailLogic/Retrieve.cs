using MailKit.Net.Imap;
using MimeKit;
using System.Collections.Generic;

namespace Raiatea.EmailLogic
{
    public class Retrieve
    {
        private static ImapClient client;
        public static IEnumerable<MimeMessage> RetrieveInbox()
        {
            var messages = new List<MimeMessage>();

            var account = Accounts.EmailAccounts[Resources.Private.AccountHosts.NJ];

            client = new ImapClient();
            
            using(client)
            {
                client.Connect(account.ImapConfig.Host, account.ImapConfig.Port, account.ImapConfig.UseSsl);

                if (!string.IsNullOrEmpty(account.AuthenticationInfo.Email))
                    client.Authenticate(account.AuthenticationInfo.Email, account.AuthenticationInfo.Password);

                client.Inbox.Open(MailKit.FolderAccess.ReadOnly);

                 var uids = client.Inbox.Search(MailKit.Search.SearchQuery.All);

                foreach(var uid in uids)
                {
                    messages.Add(client.Inbox.GetMessage(uid));
                }

                client.Disconnect(true);

            }

            return messages;
        }
    }
}
