using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Raiatea.ViewModel
{
    public class MessageDisplayViewModel 
    {
        public static readonly BindableProperty BodyViewSourceProperty =
            BindableProperty.Create(nameof(BodyViewSource), typeof(HtmlWebViewSource), typeof(MessageDisplayViewModel), null);
        public HtmlWebViewSource BodyViewSource { get; set; }

        public string TestString { get; set; }

        public MimeMessage VMMessage { get; set; }
    }
}
