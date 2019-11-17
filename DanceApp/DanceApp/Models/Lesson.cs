using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Models
{
    public class Lesson
    {
        public int Key { get; set; }
        public string DanceName { get; set; }
        public string TotalDancePath { get; set; }
        public string LegsViewPath { get; set; }
        public string ManFirstPath { get; set; }
        public string WomanFirstPath { get; set; }
        public string DetailsViewPath { get; set; }
        public string ManSecondPath { get; set; }
        public string WomanSecondPath { get; set; }
    }
}
