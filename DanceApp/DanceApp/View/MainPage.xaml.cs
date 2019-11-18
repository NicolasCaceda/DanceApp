using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanceApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanceApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CarouselPage
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
