using DanceApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Create components on the page.
            InitializeComponent();

            //Connect Bindings from View to the ViewModel where they are defined.
            BindingContext = new MainPageViewModel();
        }
    }
}
