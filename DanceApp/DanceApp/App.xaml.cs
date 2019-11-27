using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DanceApp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace DanceApp
{
    public partial class App : Application
    {
        public static LessonCollection ListOfLessons;

        public App()
        {
            InitializeComponent();
            ListOfLessons = JsonConvert.DeserializeObject<LessonCollection>("lessons.json");

            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
