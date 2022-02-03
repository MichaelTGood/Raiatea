using MimeKit;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raiatea.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageDisplayView : ContentView
    {
        //private MimeMessage message = new MimeMessage();
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

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == MessageProperty.PropertyName)
            {
                if(Message != null)
                {
                    FromDisplay.Text = Message.From[0].ToString();
                    ToDisplay.Text = Message.To.ToString();
                    SubjectLine.Text = Message.Subject;
                    bodyHtmlViewSource.Html = Message.HtmlBody;
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

        

        public MessageDisplayView()
        {
            InitializeComponent();

            bodyHtmlViewSource.Html = "";

        }
    }
}