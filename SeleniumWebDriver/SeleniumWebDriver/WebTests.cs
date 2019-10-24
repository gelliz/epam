using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class WebTests 
    {
        public IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("http://www.sixt.global");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }
        
        [Test]
        public void CarReservationCancellation()
        {
            var loginTab = webDriver.FindElement(By.XPath("//li[@class = 't3-main-navi-item t3-main-navi-hd-login']/a"));
            loginTab.Click();

            var userName = webDriver.FindElement(By.XPath("//input[@name = 'UserName']"));
            userName.SendKeys("33086490");

            var password = webDriver.FindElement(By.XPath("//input[@name = 'Password']"));
            password.SendKeys("golubliza");

            var loginButton = webDriver.FindElement(By.XPath("//a[@class = 'sx-gc-button-cta sx-gc-button-cta-green modal__content__button--modifier']"));
            loginButton.Click();

            var menuTab = webDriver.FindElement(By.XPath("//div[@class = 't3-main-navi-hd']"));
            menuTab.Click();

            var customerService = webDriver.FindElement(By.XPath("//div[@class = 't3-main-navi-content']/ul/li[5]/a"));
            customerService.Click();

            var cancelButton = webDriver.FindElement(By.XPath("//a[@class = 'sx-gc-iconlink sx-gc-display-block sx-gc-normal-weight action-cancel']"));
            cancelButton.Click();

            var ReservationCancellationButton = webDriver.FindElement(By.XPath("//p[@class = 'sx-gc-button-normal-red sx-gc-button-normal sx-gc-button-normal-green']"));
            ReservationCancellationButton.Click();

            var confirmMessage = webDriver.FindElement(By.XPath("//div[@class = 'sx-gc-message-text']"));
            Assert.AreEqual("Your reservation has been cancelled successfully", confirmMessage.Text);
        }
        
        [Test]
        public void RentCarWithoutEnteringPersonalData()
        {
            var uncheckDroppOffLocation = webDriver.FindElement(By.XPath("//div[@class = 'ibe-button-par ibe-button-par-pickup']"));
            uncheckDroppOffLocation.Click();

            var pickUpLocationBox = webDriver.FindElement(By.XPath("//div[@id = 'sx-js-res-pu-location']/span/input"));
            pickUpLocationBox.Click();
            pickUpLocationBox.SendKeys("Minsk National Airport");
            var pickUpLocation = webDriver.FindElement(By.XPath("//ul[@id = 'sx-js-res-pu-list']/li[1]/ul/li"));
            pickUpLocation.Click();

            var returnLocationBox = webDriver.FindElement(By.XPath("//div[@id = 'sx-js-res-ret-location']/span/input"));
            returnLocationBox.Click();
            returnLocationBox.SendKeys("Minsk National Airport");
            var returnLocation = webDriver.FindElement(By.XPath("//ul[@id = 'sx-js-res-ret-list']/li[1]/ul/li"));
            returnLocation.Click();

            var getQuoteButton = webDriver.FindElement(By.XPath("//p[@class = 'ibe-button']"));
            getQuoteButton.Click();

            var payLaterButton = webDriver.FindElement(By.XPath("//p[@class = 'price-section__button  sx-res-js-select-offer sx-gc-button-cta sx-gc-button-cta-list sx-gc-button-cta-green']"));
            payLaterButton.Click();

            var acceptRateAndExtrasButton = webDriver.FindElement(By.XPath("//button[@id = 'sx-js-res-booking-button']"));
            acceptRateAndExtrasButton.Click();

            var bookNowButton = webDriver.FindElement(By.XPath("//button[@id = 'sx-js-res-booking-button']"));
            bookNowButton.Click();

            var errorMessage = webDriver.FindElement(By.XPath("//div[@class = 'sx-gc-error']"));
            Assert.AreEqual("Please check the red marked entries.", errorMessage.Text);
        }
    }
}
