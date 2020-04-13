using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//found here:
// https://forums.xamarin.com/discussion/21462/looping-video-in-videoview

namespace DanceApp.Droid
{
    class VideoLoop : Java.Lang.Object, Android.Media.MediaPlayer.IOnPreparedListener
    {
        public void OnPrepared(MediaPlayer mp)
        {
            mp.Looping = true;
        }
    }
}