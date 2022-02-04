using Raiatea.ViewModel;
using Xamarin.Forms;

namespace Raiatea
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            
        }


    }
}
