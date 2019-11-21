using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DanceApp.Util;

namespace DanceApp
{
    public partial class App : Application
    {
        public static Sound videoSound;

        public App()
        {
            InitializeComponent();
            videoSound = new Sound();
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
