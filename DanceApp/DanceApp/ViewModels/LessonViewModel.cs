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
        private int Key;

        public event PropertyChangedEventHandler PropertyChanged;

        public Lesson CurrentLesson { get; set; }
        public ICommand ChangeMainDisplay { protected set; get; }
        public ICommand ChangeRememberance { protected set; get; }
        private ImageSource checkBoxImage;

        private VideoSource displayURL;

        public VideoSource DisplayURL
        {
            get { return displayURL; }
            set
            {
                if (displayURL != value)
                {
                    displayURL = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayURL"));
                    
                }
            }
        }

        public ImageSource CheckBoxStatusImage {
            get { return checkBoxImage; }
            set
            {
                checkBoxImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckBoxStatusImage"));
            }
        }

        public LessonViewModel()
        {
        }

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
                
                // Write to the json file?
                

            });

        }

    }
}
