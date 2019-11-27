using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DanceApp.Views;
using System.Threading.Tasks;

namespace DanceApp.ViewModels
{
    public class MainPageViewModel
    {
        // Initialize the command to be used in the Binding Context
        public ICommand ToLessonView { protected set; get; }

        public MainPageViewModel()
        {
            // This command calls to the ToNextPage method when triggered to open a lesson view for the passed argument.
            ToLessonView = new Command<string>(async (key) => await ToNextPage(Int32.Parse(key)));
        }

        // This method takes in the key parameter to create a lesson view per that key and push it to the view stack.
        public async Task ToNextPage(int key) {
            await Application.Current.MainPage.Navigation.PushAsync(new LessonView(key));
        }
    }
}
