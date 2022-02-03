using MimeKit;
using Raiatea.EmailLogic;
using Raiatea.EmailLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Raiatea.ViewModel
{
    public class MainPageViewModel
    {
        #region Variables

            private ObservableCollection<MimeMessage> currentBox;
            public ObservableCollection<MimeMessage> CurrentBox
            {
                get
                {
                    if (currentBox == null)
                        currentBox = new ObservableCollection<MimeMessage>();
                    return currentBox;
                }
            }

            private HtmlWebViewSource webViewSource = new HtmlWebViewSource();
            public HtmlWebViewSource WebViewSource
            {
                get
                {
                    if (webViewSource == null)
                    {
                        webViewSource = new HtmlWebViewSource();
                        webViewSource.Html = "";
                        webViewSource.BaseUrl = "";
                    }
                    return webViewSource;
                }
            }

            private MimeMessage currentMessage;
            public MimeMessage CurrentMessage
            {
                get { return currentMessage; }
            }

            public ICommand OnRefreshBoxList { get; }
            public ICommand BoxList_SelectionChanged { get; }

        public MessageDisplayViewModel MessageDisplayVM { get; set; }

        #endregion

        public MainPageViewModel()
        {
            // Remove This
            webViewSource.Html = "";
            
            

            BoxList_SelectionChanged = new Command<MimeMessage>(LoadMessageDisplay);
            OnRefreshBoxList = new Command(RetrieveEmail);
        }


        public void RetrieveEmail()
        {
            if (currentBox == null)
                currentBox = new ObservableCollection<MimeMessage>();

            foreach (var message in Retrieve.RetrieveInbox())
            {
                if (currentBox.Contains(message))
                    continue;

                currentBox.Insert(0, message);
            }
        }

        private void LoadMessageDisplay(MimeMessage message)
        {
            currentMessage = message;
        }

        private void LoadWebViewSource(MimeMessage message)
        {
            webViewSource.Html = message.HtmlBody;
        }
    }
}
