#if ANDROID
using MaterialColorUtilities.Maui;
#endif

namespace Verifable;

public partial class App: Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

#if ANDROID
        //IMaterialColorService.Current.Initialize(this.Resources);
#endif
        var loginPage = serviceProvider.GetService(typeof(LoginPage)) as LoginPage;
        MainPage = new NavigationPage(loginPage);
        //MainPage = new AppShell();

        try
        {
            if(Current?.Resources.MergedDictionaries is { } mergedDictionaries)
            {
                //mergedDictionaries.Clear();
                //mergedDictionaries.Add(new Resources.Styles.Platform.PlatformStyles());
            }
        }
        catch(Exception ex)
        {
            //ignore
        }
    }
}
