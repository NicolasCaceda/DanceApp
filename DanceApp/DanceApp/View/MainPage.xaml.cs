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
    public partial class MainPage : ContentPage
    {
        int show_grid = 1;
        private bool _FirstGridShow = true;
        private bool _SecondGridShow, _ThirdGridShow = false;

        public MainPage()
        {
            BindingContext = new MainPageViewModel(Navigation);
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LessonView());
        }

        private void SwipeRight(object sender, SwipedEventArgs e)
        {
            if (show_grid == 1)
                return;
            show_grid--;

            ToggleGrid(sender);
        }

        private void SwipeLeft(object sender, SwipedEventArgs e)
        {
            if (show_grid == 3)
                return;
            show_grid++;

            ToggleGrid(sender);
        }

        private void ToggleGrid(object sender)
        {
            var grid = (StackLayout)sender;

            switch (show_grid)
            {
                case 1:
                    first_grid.IsVisible = true;
                    second_grid.IsVisible = false;
                    third_grid.IsVisible = false;
                    break;
                case 2:
                    first_grid.IsVisible = false;
                    second_grid.IsVisible = true;
                    third_grid.IsVisible = false;
                    break;
                case 3:
                    first_grid.IsVisible = false;
                    second_grid.IsVisible = false;
                    third_grid.IsVisible = true;
                    break;
                default: break;


            }
        }
    }
}