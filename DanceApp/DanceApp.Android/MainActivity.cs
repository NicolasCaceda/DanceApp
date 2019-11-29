using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DanceApp.Models;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Content.Res;
using System.Reflection;

namespace DanceApp.Droid
{
    [Activity(Label = "DanceApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static LessonCollection ListOfLessons = new LessonCollection();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            //var assembly = Assembly.GetExecutingAssembly();
            //Stream stream = assembly.GetManifestResourceStream("DanceApp.Droid.lessonsR.json");
            //using (StreamReader r = new StreamReader(stream))
            AssetManager assets = this.Assets;
            using (StreamReader r = new StreamReader(assets.Open("lessons.json")))
            {
                var json = r.ReadToEnd();
                ListOfLessons = JsonConvert.DeserializeObject<LessonCollection>(json);
            }

            LoadApplication(new App(ListOfLessons));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}