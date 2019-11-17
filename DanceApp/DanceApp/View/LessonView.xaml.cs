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
    public partial class LessonView : ContentPage
    {
        public LessonView(int key)
        {
           InitializeComponent();
           BindingContext = new ViewModels.LessonViewModel(key);
        }

        private void Return_To_Main(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Sound_Check_Box_ImageButton(object sender, EventArgs e)
        {
            Console.WriteLine("Pressed");
        }
    }
}