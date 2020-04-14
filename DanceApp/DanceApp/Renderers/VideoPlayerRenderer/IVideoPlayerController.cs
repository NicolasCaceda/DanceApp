using System;
using System.Collections.Generic;
using System.Text;

namespace DanceApp.Renderers.VideoPlayerRenderer
{
    public interface IVideoPlayerController
    {
        VideoStatus status { get; set; }
        TimeSpan Duration { get; set; }
    }
}
