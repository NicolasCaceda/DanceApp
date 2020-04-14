using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Fixed it :)
        bool FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY = false;
        public void PausePlayVideo(object sender, EventArgs e) {
            if (FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY)
            {
                LessonVideoPlayer.Play();
                FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY = !FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY;
            }
            else { 
                LessonVideoPlayer.Pause();
                FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY = !FLIPPITY_FLOPPITY_WERE_DOING_A_SWAPPITY;

            }
        }
    }
}