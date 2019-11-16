using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DanceApp.View;
using System.Threading.Tasks;

namespace DanceApp.ViewModels
{
    public class MainPageViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand ToLessonView { protected set; get; }
        public string text { get; set; } = "Click Me";

        public MainPageViewModel()
        { 
        }

        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ToLessonView = new Command<int>(async (key) => await ToNextPage(key));
        }

        public async Task ToNextPage(int key) {
            Console.WriteLine(key);
            await Navigation.PushAsync(new LessonView());
        }
    }
}
