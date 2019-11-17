using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using DanceApp.Models;
using Xamarin.Forms;


namespace DanceApp.ViewModels
{
    class LessonViewModel : INotifyPropertyChanged
    {
        private int Key;

        public event PropertyChangedEventHandler PropertyChanged;

        public Lesson CurrentLesson { get; set; }
        public ICommand ChangeMainDisplay { protected set; get; }

        private string displayURL = "tempimage.png";

        public string DisplayURL
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
                DanceName = "Yea",
                DetailsViewPath = "stuff",
                LegsViewPath = "legs",
                ManFirstPath = "men",
                ManSecondPath = "men2",
                TotalDancePath = "all",
                WomanFirstPath = "women",
                WomanSecondPath = "women2"
            };

            //TODO removex with {CurrentLesson.Key}
            ChangeMainDisplay = new Command<string>((ButtonValue) =>
            {
                DisplayURL = $"Mx{ButtonValue}.png";
            });

        }

    }
}
