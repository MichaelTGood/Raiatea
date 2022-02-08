using MimeKit;
using SQLite;
using System;

namespace Raiatea.EmailLogic.Models
{
    public class Email
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string GUID { get; set; }
        public string ToName { get; set; }
        public string ToAddress { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Body { get; set; }
        public MimeMessage Message { get; set; }

        public Email() { }
        public Email(MimeMessage newEmail)
        {
            GUID = newEmail.MessageId;
            ToName = newEmail.To[0].Name;
            ToAddress = (newEmail.To[0] as MailboxAddress).Address;
            FromName = newEmail.From[0].Name;
            FromAddress = (newEmail.From[0] as MailboxAddress).Address;
            Date = newEmail.Date;
            Body = newEmail.HtmlBody;
            Message = newEmail;
        }
    }
}
