using System;
using System.Collections.Generic;
using System.Text;
using DanceApp.Models;

namespace DanceApp.ViewModels
{
    class LessonViewModel
    {
        private int Key;
        public Lesson CurrentLesson{ get; set; }

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
        }

    }
}
