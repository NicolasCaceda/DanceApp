using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Models
{
    public class Lesson
    {
        // Lesson Number
        public int Key { get; set; }
        // Dance Name
        public string DanceName { get; set; }
        // Is it Viewed
        public List<Boolean> IsLessonViewed { get; set; }
    }
}
