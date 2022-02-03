using MimeKit;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raiatea
{
    public partial class App : Application
    {
        public MimeMessage CurrentGlobalMessage;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
