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

        private VideoSource displayURL;

        public VideoSource DisplayURL
        {
            get { return displayURL; }
            set
            {
                if (displayURL != value)
                {
                    displayURL = value;

                    if(PropertyChanged != null)
                    {
                        Console.WriteLine($"Prop CHanged");
                        PropertyChanged(this, new PropertyChangedEventArgs("DisplayURL"));
                    }
                }
            }
        }


        public LessonViewModel()
        {
        }

        public LessonViewModel(int key)
        {
            this.Key = key - 1;
            CurrentLesson = App.ListOfLessons.Lessons[Key];
            //CurrentLesson = new Lesson
            //{
            //    Key = Key,
            //    DanceName = App,
            //    IsLessonViewed = true
            //};

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`");
            Console.WriteLine(App.ListOfLessons.Lessons.ToString());



            DisplayURL = (VideoSource)new VideoSourceConverter().ConvertFromInvariantString($"M{CurrentLesson.Key}1.mp4");

            //TODO removex with {CurrentLesson.Key}
            ChangeMainDisplay = new Command<string>((ButtonValue) =>
            {
                string videoPath = $"M{CurrentLesson.Key}{ButtonValue}.mp4";
                VideoSourceConverter vsourceCon = new VideoSourceConverter();
                VideoSource vsourceMichaelHere = (VideoSource)(vsourceCon.ConvertFromInvariantString(videoPath));

                DisplayURL = vsourceMichaelHere;
            });

        }

    }
}
