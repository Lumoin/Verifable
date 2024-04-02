using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UITests
{
    [TestClass]
    public class AppiumSetup
    {
        private static AppiumDriver? driver;

        public static AppiumDriver App => driver ?? throw new NullReferenceException("AppiumDriver is null");


        [AssemblyInitialize]
        public static void RunBeforeAnyTests(TestContext context)
        {
            AppiumOptions windowsOptions = new()
            {
                // Specify windows as the driver, typically don't need to change this
                AutomationName = "windows",
                // Always Windows for Windows
                PlatformName = "Windows",

                //The deployed application identifier. This can be found in Verifable/Platforms/Windows/Package.appxmanifest.
                //under Packaging tab in "Package family name" field.
                //See more at https://learn.microsoft.com/en-us/windows/win32/shell/appids and
                //https://learn.microsoft.com/en-us/windows/configuration/store/find-aumid?tabs=ps.
                App = "com.lumoin.verifable_9zz4h110yvjzm!App",
            };

            // Note there are many more options that you can use to influence the app under test according to your needs

            driver = new WindowsDriver(windowsOptions);
        }


        [AssemblyCleanup]
        public static void RunAfterAnyTests()
        {
            driver?.Quit();
        }
    }
}