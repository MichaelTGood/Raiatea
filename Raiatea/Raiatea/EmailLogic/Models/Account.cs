using MailKit.Net.Imap;
using MailKit.Net.Smtp;

namespace Raiatea.EmailLogic.Models
{
    public class Account
    {
        public string Name { get; set; }

        public AuthenticationInfo AuthenticationInfo { get; set; }
        public ImapConfiguration ImapConfig { get; set; }

        public SmtpConfiguration SmtpConfig { get; set; }

        public Account() { }
        public Account(string name, AuthenticationInfo authenticationInfo, ImapConfiguration imapConfig, SmtpConfiguration smtpConfig)
        {
            Name = name;
            AuthenticationInfo = authenticationInfo;
            ImapConfig = imapConfig;
            SmtpConfig = smtpConfig;
        }
    }
}
