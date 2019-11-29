using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Media;
using DanceApp.Renderers.VideoPlayerRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonView : ContentPage
    {
        // Constructor, takes the key paramenter and constructs the lesson view for the corresponing lesson.
        public LessonView(int key)
        {
           InitializeComponent();
           BindingContext = new ViewModels.LessonViewModel(key);
        }

        /* Method called when user presses the "Back to main menu" button. 
         * Pops off the lesson view to review the main screen. */
        private void Return_To_Main(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        /* Method called when the user pressed the mute button. 
         * Toggles the device's mute and changes the icon accordingly. */
        private void Sound_Check_Box_ImageButton(object sender, EventArgs e)
        {
            App.videoSound.ToggleVolumeMute();
            SoundBox.Source = (App.videoSound.IsMuted()) ? "soundOFF.png" : "soundON.png";
        }
    }
}