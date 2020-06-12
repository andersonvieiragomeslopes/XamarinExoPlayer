using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinExoPlayer.Controls
{
    public class ExoPlayerControls:View
    {
        public static readonly BindableProperty SourceProperty =
           BindableProperty.Create(nameof(Source), typeof(string), typeof(ExoPlayerControls), null);

        public string Source {
            set { SetValue(SourceProperty, value); }
            get { return (string)GetValue(SourceProperty); }
        }
        public static readonly BindableProperty AutoPlayProperty =
           BindableProperty.Create(nameof(AutoPlay), typeof(bool), typeof(ExoPlayerControls), null);

        public bool AutoPlay {
            set { SetValue(AutoPlayProperty, value); }
            get { return (bool)GetValue(AutoPlayProperty); }
        }
        public static readonly BindableProperty LoopProperty =
   BindableProperty.Create(nameof(Loop), typeof(bool), typeof(ExoPlayerControls), null);

        public bool Loop {
            set { SetValue(LoopProperty, value); }
            get { return (bool)GetValue(LoopProperty); }
        }
    }
}
