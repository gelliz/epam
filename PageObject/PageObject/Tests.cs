using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("http://www.sixt.global");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void CarRentalForPeriodExceedingPossible()
        {
            StartPage startPage = new StartPage(webDriver)
                .FillInLocationFields("Minsk National Airport")
                .ClickGetQuoteButton()
                .SelectYourAge();
            Assert.AreEqual("Minimum age of driver: 21 years", startPage.errorAge.Text);
        }

        [Test]
        public void FindCarWithDesiredCharacteristics()
        {
            StartPage startPage = new StartPage(webDriver).GoToTabFleet(webDriver);
            FleetPage fleetPage = new FleetPage(webDriver).SelectDesireCharacteristics(webDriver);
            Assert.AreEqual("6", fleetPage.textAboutCategoriesReceived.Text);
        }
    }
}
