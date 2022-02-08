using MimeKit;
using Raiatea.Databases;
using Raiatea.EmailLogic;
using Raiatea.EmailLogic.Models;
using Raiatea.Models;
using Raiatea.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
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


            private MimeMessage currentEmail;
            public MimeMessage CurrentEmail
            {
                get => currentEmail;
                set
                {
                    SetProperty(ref currentEmail, value, nameof(CurrentEmail));
                    OnPropertyChanged(nameof(DisplayReadingPane));
                }
            }

        public static BindableProperty CurrentEmailProperty =
            BindableProperty.Create(nameof(CurrentEmail), typeof(MimeMessage), typeof(MainPageViewModel), new MimeMessage(), BindingMode.TwoWay);

            public bool DisplayReadingPane
            {
                get
                {
                    if(CurrentEmail == null)
                        return false;

                    return true;
                }
            }


            public ICommand OnRefreshBoxList { get; }
            public ICommand BoxList_SelectionChanged { get; }
            public ICommand ProducePopup { get; }


        #endregion


        public MainPageViewModel()
        {
            // Remove This
            webViewSource.Html = "";

            BoxList_SelectionChanged = new Command<MimeMessage>(LoadMessageDisplay);
            OnRefreshBoxList = new AsyncCommand(RetrieveEmailAsync);
            ProducePopup = new Command(TestDatabase);

            //RetrieveEmail();
            
        }


        public void RetrieveEmail()
        {
            if (currentBox == null)
                currentBox = new ObservableCollection<MimeMessage>();

            foreach (var email in Retrieve.RetrieveInbox())
            {
                if (currentBox.Contains(email))
                    continue;

                currentBox.Insert(0, email);
            }
        }

        public async Task RetrieveEmailAsync()
        {
            if (currentBox == null)
                currentBox = new ObservableCollection<MimeMessage>();

            var db = DatabaseAccess.GetOrCreateDatabase(Accounts.EmailAccounts[Resources.Private.AccountHosts.NJ].ShortName);

            foreach (var email in await Retrieve.RetrieveInboxAsync())
            {
                if (currentBox.Contains(email))
                {
                    continue;
                }
                else
                {
                    currentBox.Insert(0, email);
                }

                var someInt = await db.AddToTableAsync<Email>(new Email(email));
                string filler = null;
            }
        }

        private void LoadMessageDisplay(MimeMessage message)
        {
            CurrentEmail = message;
            WebViewSource.Html = CurrentEmail.HtmlBody;
        }

        private void TestDatabase()
        {
            var db = DatabaseAccess.GetOrCreateDatabase(Accounts.EmailAccounts[Resources.Private.AccountHosts.NJ].ShortName);
            //db.AddToTableAsync<MimeMessage>();
        }
    }
}
