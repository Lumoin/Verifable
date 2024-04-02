#if ANDROID
using MaterialColorUtilities.Maui;
#endif


using Microsoft.Maui.LifecycleEvents;
using System.Reactive;
using System.Reactive.Concurrency;
using Verifable.General;

#if WINDOWS
using Verifable.Platforms.Windows;
#endif

namespace Verifable;

public static class MauiProgram
{
    public static List<Tuple<Type, Type>> SingletonServices { get; set; } = new List<Tuple<Type, Type>>();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if ANDROID
        //builder.UseMaterialColors();
#endif

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS10_0_17763_0_OR_GREATER
            /*events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    //window.TryMicaOrAcrylic();
                });
            });*/
#endif
        });

        SingletonServices.ForEach(s => _ = builder.Services.AddSingleton(s.Item1, s.Item2));

        _ = builder.Services.AddSingleton(new RealNumberGenerator(DefaultScheduler.Instance));
        _ = builder.Services.AddSingleton(DefaultScheduler.Instance);
        _ = builder.Services.AddSingleton<Engine>();

        _ = builder.Services.AddTransient<MainPageViewModel>();
        _ = builder.Services.AddSingleton<LoginPage>();

        _ = builder.Services.AddTransient<AboutPageViewModel>();
        _ = builder.Services.AddSingleton<AboutPage>();

        _ = builder.Services.AddTransient<LoginPageViewModel>();
        _ = builder.Services.AddSingleton<LoginPage>();

        return builder.Build();
    }
}
