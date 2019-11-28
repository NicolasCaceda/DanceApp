using DanceApp.Models;
using Xamarin.Forms;

namespace DanceApp
{
    public partial class App : Application
    {
        public static LessonCollection ListOfLessons;



        public App(LessonCollection lessonList)
        {
            InitializeComponent();

            ListOfLessons = lessonList;

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
