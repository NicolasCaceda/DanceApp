using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Models
{
    public class Lesson
    {
        // Lesson files are structured M(LESSON NUMBER)(VIEW NUMBER)
        // Example Lesson Number 2 + Legs View = M23.mp4 
        // Lesson Number
        public int Key { get; set; }
        // Dance Name
        public string DanceName { get; set; }
        // 1
        public string TotalDancePath { get; set; }
        // 2
        public string LegsViewPath { get; set; }
        // 3
        public string ManFirstPath { get; set; }
        // 4
        public string WomanFirstPath { get; set; }
        // 5
        public string DetailsViewPath { get; set; }
        // 6
        public string ManSecondPath { get; set; }
        // 7
        public string WomanSecondPath { get; set; }
    }
}
