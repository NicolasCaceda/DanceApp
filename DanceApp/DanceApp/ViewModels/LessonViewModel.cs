using System;
using System.ComponentModel;
using System.Windows.Input;
using DanceApp.Models;
using Xamarin.Forms;
using DanceApp.Renderers.VideoPlayerRenderer;

namespace DanceApp.ViewModels
{
    class LessonViewModel : INotifyPropertyChanged
    {
        // Class Variables
        private int Key;
        public Lesson CurrentLesson { get; set; }
        private VideoSource displayURL;

        // Event Handler for detecting changes to the Video Player's source url.
        public event PropertyChangedEventHandler PropertyChanged;

        // Command for changing the video player's source.
        public ICommand ChangeMainDisplay { protected set; get; }
        public ICommand ChangeRememberance { protected set; get; }
        private ImageSource checkBoxImage;

        public VideoSource DisplayURL
        {
            // When called to get value, return the displayURL;
            get { return displayURL; }

            /* When setting a value to the object, 
             * if the value is not already stored in displayURL, set it displayURL to value.*/
            set
            {
                if (displayURL != value)
                {
                    displayURL = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayURL"));
                }
            }
        }

        // Returns the checkBoxImage source or sets the checkBoxImage to the passed argument and update.
        public ImageSource CheckBoxStatusImage {
            get { return checkBoxImage; }
            set
            {
                checkBoxImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckBoxStatusImage"));
            }
        }
        
        // Method for checking the mute status and updating the icons accordingly.
        public ImageSource GetSoundCheckBoxStatus
        {
            get
            {
                return (App.videoSound.IsMuted()) ? "soundOFF.png" : "soundON.png";

            }
        }

        public LessonViewModel()
        {
        }

        // Constructor
        public LessonViewModel(int key)
        {
            this.Key = key;

            CurrentLesson = App.ListOfLessons.Lessons[Key];
            CurrentLesson.Key = key;


            DisplayURL = (VideoSource)new VideoSourceConverter().ConvertFromInvariantString($"M{Key}1.mp4");
            CheckBoxStatusImage = (CurrentLesson.IsLessonViewed) ? "CheckBoxON.png" : "CheckBoxOFF.png";

            ChangeMainDisplay = new Command<string>((ButtonValue) =>
            {
                string videoPath = $"M{Key}{ButtonValue}.mp4";
                VideoSourceConverter vsourceCon = new VideoSourceConverter();
                VideoSource vsourceMichaelHere = (VideoSource)(vsourceCon.ConvertFromInvariantString(videoPath));
                DisplayURL = vsourceMichaelHere;
            });
            
            ChangeRememberance = new Command( () =>
            {
                // Toggle between True and False;
                CurrentLesson.IsLessonViewed = !CurrentLesson.IsLessonViewed;
                // Adjust the imagesource of the checkbox according to IsLessonViewed
                CheckBoxStatusImage = (CurrentLesson.IsLessonViewed) ? "CheckBoxON.png" : "CheckBoxOFF.png";
                // Write to the json file....haven't gotten a method of doing this yet.
            });
        }
    }
}
