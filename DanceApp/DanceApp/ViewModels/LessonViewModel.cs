using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
            this.Key = key;
            Console.WriteLine(key);
            CurrentLesson = new Lesson
            {
                Key = Key,
                DanceName = "",
                TotalDancePath = "M" + Key + "1.mp4",
                LegsViewPath = "M" + Key + "2.mp4",
                ManFirstPath = "M" + Key + "3.mp4",
                WomanFirstPath = "M" + Key + "4.mp4",
                DetailsViewPath = "M" + Key + "5.mp4",
                ManSecondPath = "M" + Key + "6.mp4",
                WomanSecondPath = "M" + Key + "7.mp4"
            };
            DisplayURL = (VideoSource)new VideoSourceConverter().ConvertFromInvariantString(CurrentLesson.TotalDancePath);

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
