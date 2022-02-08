using MimeKit;
using Raiatea.Models;
using Raiatea.ViewModel;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace Raiatea.View
{
    public partial class MessageDisplayView : ContentView, INotifyPropertyChanged
    {
        public string FromName { get; set; }

        public string ToName
        {
            get
            {
                return (string)GetValue(ToNameProperty);
                //return Message.To.ToString();
            }
            set
            {
                SetValue(ToNameProperty, value);
                OnPropertyChanged(nameof(ToName));
            }
        }

        public static BindableProperty ToNameProperty =
            BindableProperty.Create(nameof(ToName), typeof(string), typeof(MessageDisplayView), "Default To Field",
                BindingMode.TwoWay);


        public MimeMessage Message
        {
            get
            {
                return (MimeMessage)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }

        public static BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(MimeMessage), typeof(MessageDisplayView), new MimeMessage(),
                BindingMode.TwoWay);

        public new event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName == MessageProperty.PropertyName)
            {
                if(Message != null)
                {
                    FromName = Message.From[0].ToString();
                    ToName = Message.To[0].Name;
                    OnPropertyChanged(nameof(ToName));
                    OnPropertyChanged(nameof(FromName));
                    //BadUIUpdate();
                }
            }
        }

        private HtmlWebViewSource bodyHtmlViewSource = new HtmlWebViewSource();
        public HtmlWebViewSource BodyHtmlViewSource
        {
            get
            {
                //bodyHtmlViewSource.Html = message.HtmlBody;
                return bodyHtmlViewSource;
            }
        }

        private void BadUIUpdate()
        {
            if(Message.To.Count > 0)
            {
                var toName = Message.To[0].Name;
                var toAddress = (Message.To[0] as MailboxAddress).Address;
                if (toAddress != null)
                {
                    if (!string.IsNullOrEmpty(toName))
                    {
                        ToNameDisplay.Text = toName;
                        ToAddressDisplay.Text = toAddress;
                        ToAddressDisplay.IsVisible = true;
                    }
                    else
                    {
                        ToNameDisplay.Text = toAddress;
                        ToAddressDisplay.IsVisible = false;

                    }
                }
                else
                {
                    ToNameDisplay.IsVisible = false;
                    ToAddressDisplay.IsVisible = false;
                }
            }
            else
            {
                ToNameDisplay.Text = "No Receiver Info";
            }

            var fromName = Message.From[0].Name;
            var fromAddress = (Message.From[0] as MailboxAddress).Address;
            if(fromAddress != null)
            {
                if(!string.IsNullOrEmpty(fromName))
                {
                    FromNameDisplay.Text = fromName;
                    FromAddressDisplay.Text = fromAddress;
                    FromAddressDisplay.IsVisible = true;
                }
                else
                {
                    FromNameDisplay.Text = fromAddress;
                    FromAddressDisplay.IsVisible = false;
                    
                }
            }

            SubjectLine.Text = Message.Subject;
            DateDisplay.Text = Message.Date.ToLocalTime().ToString("f", CultureInfo.GetCultureInfo("en-US"));
            bodyHtmlViewSource.Html = Message.HtmlBody;
            BodyDisplay.Source = BodyHtmlViewSource;
        }

        public MessageDisplayView()
        {
            InitializeComponent();
            //BindingContext = this;

            bodyHtmlViewSource.Html = "";
            ToName = "This is a test name";
        }

    }
}