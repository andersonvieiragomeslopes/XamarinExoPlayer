using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Offline;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Source.Hls;
using Com.Google.Android.Exoplayer2.Source.Smoothstreaming;
using Com.Google.Android.Exoplayer2.Source.Smoothstreaming.Manifest;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinExoPlayer.Controls;
using XamarinExoPlayer.Droid.Renderers;
using ARelativeLayout = Android.Widget.RelativeLayout;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ExoPlayerControls), typeof(ExoPlayerRenderer))]

namespace XamarinExoPlayer.Droid.Renderers
{
    [Preserve(AllMembers = true)]

    public class ExoPlayerRenderer : ViewRenderer<ExoPlayerControls, ARelativeLayout>, View.IOnClickListener, IPlayerEventListener,
        PlayerControlView.IVisibilityListener
    {
        PlayerView VideoPlayer;
        Context context;
        ARelativeLayout relativeLayout;
        SimpleExoPlayer ExoPlayer;
        ViewGroup mainpage;

        public ExoPlayerRenderer(Context context) : base(context)
        {
            this.context = context;
            this.VideoPlayer = new PlayerView(this.context);

        }
        protected override void OnElementChanged(ElementChangedEventArgs<ExoPlayerControls> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                if (Control == null)
                {
                    InitializePlayer();
                    relativeLayout = new ARelativeLayout(Context);
                     VideoPlayer.SetShowShuffleButton(true);
                    VideoPlayer.ControllerAutoShow = false;
                    ARelativeLayout.LayoutParams layoutParams =
                     new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    layoutParams.AddRule(LayoutRules.CenterInParent);
                    VideoPlayer.LayoutParameters = layoutParams;
                    VideoPlayer.ControllerAutoShow = true;
                    relativeLayout.AddView(VideoPlayer);
                    SetNativeControl(relativeLayout);
                    mainpage = ((ViewGroup)VideoPlayer.Parent);

                }
                SetSource();
            }
        }
        void SetSource()
        {
            DefaultHttpDataSourceFactory httpDataSourceFactory = new DefaultHttpDataSourceFactory("1");
            IMediaSource MediaSource = null;
            string uri = Element.Source;
            bool autoplay = Element.AutoPlay;
            bool loop = Element.Loop;
            if (!string.IsNullOrWhiteSpace(uri))
                {
                MediaSource = new HlsMediaSource.Factory(httpDataSourceFactory)
                        .CreateMediaSource(Android.Net.Uri.Parse(uri));
                }

            if (MediaSource != null)
            {
                ExoPlayer.Prepare(MediaSource);
                ExoPlayer.PlayWhenReady = autoplay;
            }
        }


        private void InitializePlayer()
        {

            ExoPlayer = ExoPlayerFactory.NewSimpleInstance(context, new DefaultTrackSelector());
            VideoPlayer = new PlayerView(context) { Player = ExoPlayer };            
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GC.Collect();
        }

        public void OnVisibilityChange(int p0)
        {
            throw new NotImplementedException();
        }

        public void OnClick(View v)
        {
            throw new NotImplementedException();
        }
    }
}