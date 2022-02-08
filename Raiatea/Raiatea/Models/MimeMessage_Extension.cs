using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiatea.Models
{
    public class MimeMessage_Extension : MimeMessage
    {
        public bool Equals(MimeMessage x, MimeMessage y)
        {
            if (x.MessageId == x.MessageId)
                return true;

            return false;
        }
    }
}
