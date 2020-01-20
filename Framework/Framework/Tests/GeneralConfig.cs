using System;
using System.IO;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using Framework.Driver;
using Framework.Services;

namespace Framework.Tests
{
    public class GeneralConfig : Logger
    {
        static private ILog Log = LogManager.GetLogger(typeof(Logger));

        protected IWebDriver Driver;

        [SetUp]
        public void SetDriver()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("http://www.sixt.global");
        }

        protected void TakeScreenshotWhenTestFailed(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                var screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                Log.Error("Test_Failure");
            }
        }

        [TearDown]
        public void QuitDriver()
        {
            Log.Info("Test_Successfully");
            DriverSingleton.CloseDriver();
        }
    }
}
