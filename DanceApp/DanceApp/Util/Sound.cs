using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Util
{
    // A class used to control the device's Mute.
    public sealed class Sound
    {
        // Class Variables
        private bool isMuted;
        public AudioManager audioManager;

        // Constructor
        public Sound()
        {
            // Creates an object that references the device's AudioService
            this.audioManager = (AudioManager)Application.Context.GetSystemService(Context.AudioService);
            // Assigns the device's mute property to class variable.
            this.isMuted = IsMuted();
        }

        // Method used to get mute property.
        public bool IsMuted()
        {
            return this.audioManager.IsStreamMute(Stream.Music);
        }

        // Method for toggling the device's mute and updates the boolean variable.
        public void ToggleVolumeMute() {
            audioManager.AdjustVolume(Adjust.ToggleMute, VolumeNotificationFlags.ShowUi);
            this.isMuted = IsMuted();
        }
    }
}