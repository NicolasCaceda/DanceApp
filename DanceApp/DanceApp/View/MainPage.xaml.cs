using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanceApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CarouselPage
    {
        int show_grid = 1;
        private bool _FirstGridShow = true;
        private bool _SecondGridShow, _ThirdGridShow = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string lessonNumber = (sender as Button).Text;
            await Navigation.PushAsync(new LessonView(lessonNumber));
        }
    }
}