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
        // Class Variables
        private int Key;
        public Lesson CurrentLesson { get; set; }
        private VideoSource displayURL;

        // Event Handler for detecting changes to the Video Player's source url.
        public event PropertyChangedEventHandler PropertyChanged;

        // Command for changing the video player's source.
        public ICommand ChangeMainDisplay { protected set; get; }

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

                    /* Checks the event handler for changes, and call to update the 
                     * video player of the newly changed video source, "displayURL" */
                    if(PropertyChanged != null)
                    {
                        Console.WriteLine($"Prop CHanged");
                        PropertyChanged(this, new PropertyChangedEventArgs("DisplayURL"));
                    }
                }
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
            // Construct a Lesson object that corresponds to the passed Key argument.
            CurrentLesson = new Lesson
            {
                Key = Key,
                DanceName = "Dance App",
                /* Path variables below are used for connecting the buttons at the bottom on the lesson screen 
                 * to the corresponding lesson video path. */
                TotalDancePath = "M" + Key + "1.mp4",
                LegsViewPath = "M" + Key + "2.mp4",
                ManFirstPath = "M" + Key + "3.mp4",
                WomanFirstPath = "M" + Key + "4.mp4",
                DetailsViewPath = "M" + Key + "5.mp4",
                ManSecondPath = "M" + Key + "6.mp4",
                WomanSecondPath = "M" + Key + "7.mp4"
            };

            // Assigns the default video "total dance path" of the lesson to the Video Player's source.
            DisplayURL = (VideoSource)new VideoSourceConverter().ConvertFromInvariantString(CurrentLesson.TotalDancePath);

            // Command that runs a script to change the video player's source url when triggered from the lesson view.
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
