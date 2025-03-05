using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Configuration;

namespace MapsNavigationTestSuite.Main.Drivers
{
    public class AppiumDriverSetup
    {
        private AndroidDriver _driver;

        public AndroidDriver InitializeDriver()
        {
            var options = new AppiumOptions();
            options.PlatformName = ConfigurationManager.AppSettings["PlatformName"] ?? "Android";
            options.PlatformVersion = ConfigurationManager.AppSettings["PlatformVersion"] ?? "13.0";
            options.DeviceName = ConfigurationManager.AppSettings["DeviceName"] ?? "Pixel_6";
            options.AutomationName = ConfigurationManager.AppSettings["AutomationName"] ?? "UiAutomator2";
            options.AddAdditionalAppiumOption("appPackage", ConfigurationManager.AppSettings["AppPackage"] ?? "com.google.android.apps.maps");
            options.AddAdditionalAppiumOption("appActivity", ConfigurationManager.AppSettings["AppActivity"] ?? "com.google.android.maps.MapsActivity");

            string appiumServer = ConfigurationManager.AppSettings["AppiumServer"] ?? "http://localhost:4723/wd/hub";
            if (string.IsNullOrEmpty(appiumServer))
            {
                throw new InvalidOperationException("AppiumServer URL is not configured in App.config.");
            }

            _driver = new AndroidDriver(
                new Uri(appiumServer),
                options);
            return _driver;
        }

        public void QuitDriver()
        {
            _driver?.Quit();
        }
    }
}