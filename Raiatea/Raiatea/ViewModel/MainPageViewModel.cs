using MimeKit;
using Raiatea.EmailLogic;
using Raiatea.Helpers;
using Raiatea.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raiatea.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MainPageViewModel : ObservableObject
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
                get => currentMessage;
                set
                {
                    SetProperty(ref currentMessage, value, nameof(CurrentMessage));
                }
            }


            public ICommand OnRefreshBoxList { get; }
            public ICommand BoxList_SelectionChanged { get; }

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
            CurrentMessage = message;
            WebViewSource.Html = CurrentMessage.HtmlBody;
        }

        private void LoadWebViewSource(MimeMessage message)
        {
            webViewSource.Html = message.HtmlBody;
        }
    }
}
