using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Util
{
    // sealed means the class can not be extended.
    public sealed class Sound
    {
        private bool isMuted;
        public AudioManager audioManager;

        public Sound()
        {
            this.audioManager = (AudioManager)Application.Context.GetSystemService(Context.AudioService);
            this.isMuted = IsMuted();
        }

        public bool IsMuted()
        {
            return this.audioManager.IsStreamMute(Stream.Music);
        }

        public void ToggleVolumeMute() {

            audioManager.AdjustVolume(Adjust.ToggleMute, VolumeNotificationFlags.ShowUi);

            this.isMuted = audioManager.IsStreamMute(Stream.Music);
        }
    }
}