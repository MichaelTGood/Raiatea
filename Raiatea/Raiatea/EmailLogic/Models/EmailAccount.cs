using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System.Linq;

namespace Raiatea.EmailLogic.Models
{
    public class EmailAccount
    {
        public string Name { get; set; }
        private string shortName = "";
        public string ShortName 
        {
            get => shortName;
            set
            {
                shortName = string.Concat(value.Where(c => !char.IsWhiteSpace(c)));
            }
        }
        public AuthenticationInfo AuthenticationInfo { get; set; }
        public ImapConfiguration ImapConfig { get; set; }

        public SmtpConfiguration SmtpConfig { get; set; }

        public EmailAccount() { }

        public EmailAccount(string name, string shortName, AuthenticationInfo authenticationInfo, ImapConfiguration imapConfig, SmtpConfiguration smtpConfig)
        {
            Name = name;
            ShortName = shortName;
            AuthenticationInfo = authenticationInfo;
            ImapConfig = imapConfig;
            SmtpConfig = smtpConfig;
        }
    }
}
