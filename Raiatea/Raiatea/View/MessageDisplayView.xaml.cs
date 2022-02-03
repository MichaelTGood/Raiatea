using MimeKit;
using Raiatea.EmailLogic.Models;
using Raiatea.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raiatea.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageDisplayView : ContentView
    {
        //private MimeMessage message;
        public MimeMessage Message { get; set; }
        //public MimeMessage Message
        //{
        //    get
        //    {
        //        return (MimeMessage)GetValue(MessageProperty);
        //    }
        //    set
        //    {
        //        SetValue(MessageProperty, value);
        //        BodyHtmlViewSource.Html = Message.HtmlBody;
        //    }
        //}
        
        //public BindableProperty MessageProperty = 
        //    BindableProperty.Create(nameof(Message), typeof(MimeMessage), typeof(MessageDisplayView));

        public HtmlWebViewSource BodyHtmlViewSource { get; set; }

        public MessageDisplayView()
        {
            InitializeComponent();
            
        }
    }
}