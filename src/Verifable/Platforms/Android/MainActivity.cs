using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Views;


namespace Verifable.Platforms.Android
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity: MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var mediaPlayer = MediaPlayer.Create(this, Resource.Raw.audiologo);
            if(mediaPlayer != null)
            {
                mediaPlayer.Start();
                Thread.Sleep(mediaPlayer.Duration / 2);
                mediaPlayer.Completion += (sender, e) =>
                {
                    mediaPlayer.Release();
                };
            }

            AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);
            if(Build.VERSION.SdkInt >= BuildVersionCodes.P)
            {
                Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.Default;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
