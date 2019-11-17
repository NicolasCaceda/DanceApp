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
        public ICommand ToLessonView { protected set; get; }
        public string Text { get; set; } = "Click Me";

        public MainPageViewModel()
        {
            ToLessonView = new Command<string>(async (key) => await ToNextPage(Int32.Parse(key)));
        }

        public async Task ToNextPage(int key) {
            await Application.Current.MainPage.Navigation.PushAsync(new LessonView(key));
        }
    }
}
