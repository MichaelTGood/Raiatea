using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Raiatea.EmailLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiatea.EmailLogic
{
    public static class Accounts
    {
        private static Dictionary<Resources.Private.AccountHosts, Account> emailAccounts;

        public static Dictionary<Resources.Private.AccountHosts, Account> EmailAccounts 
        { 
            get
            {
                if(emailAccounts == null)
                    emailAccounts = Resources.Private.EmailAccounts.PrePopulateEmailAccounts();
                return emailAccounts;
            }
        }

    }


}
