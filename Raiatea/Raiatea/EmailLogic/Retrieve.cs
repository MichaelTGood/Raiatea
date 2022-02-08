using MailKit.Net.Imap;
using MimeKit;
using Newtonsoft.Json;
using Raiatea.Databases;
using Raiatea.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raiatea.EmailLogic
{
    public class Retrieve
    {
        private static ImapClient client;
        public static IEnumerable<MimeMessage> RetrieveInbox()
        {
            var emails = new List<MimeMessage>();

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
                    emails.Add((MimeMessage)client.Inbox.GetMessage(uid));
                }

                client.Disconnect(true);

            }

            return emails;
        }
        
        public static async Task<IEnumerable<MimeMessage>> RetrieveInboxAsync()
        {
            var emails = new List<MimeMessage>();

            var account = Accounts.EmailAccounts[Resources.Private.AccountHosts.NJ];

            client = new ImapClient();
            
            using(client)
            {
                await client.ConnectAsync(account.ImapConfig.Host, account.ImapConfig.Port, account.ImapConfig.UseSsl);

                if (!string.IsNullOrEmpty(account.AuthenticationInfo.Email))
                    await client.AuthenticateAsync(account.AuthenticationInfo.Email, account.AuthenticationInfo.Password);

                await client.Inbox.OpenAsync(MailKit.FolderAccess.ReadOnly);

                 var uids = await client.Inbox.SearchAsync(MailKit.Search.SearchQuery.All);

                foreach(var uid in uids)
                {
                    var email = client.Inbox.GetMessage(uid);
                    emails.Add(email);
                }

                client.Disconnect(true);

            }

            return emails;
        }
    }
}
