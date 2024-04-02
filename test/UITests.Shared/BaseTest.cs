using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UITests
{
    public abstract class BaseTest
    {
        protected static AppiumDriver App => AppiumSetup.App;

        // This could also be an extension method to AppiumDriver if you prefer
        protected static AppiumElement FindUIElement(string id)
        {
            if(App is WindowsDriver)
            {
                return App.FindElement(MobileBy.AccessibilityId(id));
            }

            var x = App.FindElement(MobileBy.Id(id));
            return x;
        }
    }
}