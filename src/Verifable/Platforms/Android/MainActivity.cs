using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Views;


namespace Verifable
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity: MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            /*var mediaPlayer = MediaPlayer.Create(this, Resource.Raw.audiologo);
            if(mediaPlayer != null)
            {
                mediaPlayer.Start();
                mediaPlayer.Completion += (sender, e) =>
                {
                    mediaPlayer.Release();
                };
            }*/

            AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);
            base.OnCreate(savedInstanceState);
            if(Build.VERSION.SdkInt >= BuildVersionCodes.P)
            {
                Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.Default;
            }

            // If you want to get a good look at the icon to check it. Don't forget remove from production code
            //System.Threading.Thread.Sleep(1000);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.activity_main);
        }
    }
}
