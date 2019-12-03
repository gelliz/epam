using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ibe-button-par ibe-button-par-pickup']")]
        private IWebElement uncheckDroppOffLocation;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'sx-js-res-pu-location']/span/input")]
        private IWebElement pickUpLocationBox;

        [FindsBy(How = How.XPath, Using = "//ul[@id = 'sx-js-res-pu-list']/li[1]/ul/li")]
        private IWebElement pickUpLocation;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'sx-js-res-ret-location']/span/input")]
        private IWebElement returnLocationBox;

        [FindsBy(How = How.XPath, Using = "//ul[@id = 'sx-js-res-ret-list']/li[1]/ul/li")]
        private IWebElement returnLocation;

        [FindsBy(How = How.XPath, Using = "//p[@class = 'ibe-button']")]
        private IWebElement getQuoteButton;

        [FindsBy(How = How.XPath, Using = "//p[@class = 'price-section__button  sx-res-js-select-offer sx-gc-button-cta sx-gc-button-cta-list sx-gc-button-cta-green']")]
        private IWebElement payLaterButton;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'sx-js-res-booking-button']")]
        private IWebElement acceptRateAndExtrasButton;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'sx-js-res-booking-button']")]
        private IWebElement bookNowButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'sx-gc-error']")]
        public IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "//li[@class = 't3-js-main-navi-item t3-main-navi-item t3-main-navi-hd-menu']/div[@class = 't3-main-navi-hd']/span")]
        private IWebElement menuButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 't3-mainmenu']/li[3]/a[@href = '/fleet/']")]
        private IWebElement fleetItem;

        public FleetPage GoToTabFleet()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(menuButton).Click().Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(fleetItem));
            fleetItem.Click();
            return new FleetPage(driver);
        }
        public MainPage FillInFieldsPickUpAndReturnLocation(Location location)
        {
            uncheckDroppOffLocation.Click();
            pickUpLocationBox.Click();
            pickUpLocationBox.SendKeys(location.PickUpLocation);
            pickUpLocation.Click();
            returnLocationBox.Click();
            returnLocationBox.SendKeys(location.ReturnLocation);
            returnLocation.Click();
            return this;
        }
        public MainPage ClickGetQuoteButton()
        {
            getQuoteButton.Click();
            return this;
        }

        public MainPage ClickPayLaterButton()
        {
            payLaterButton.Click();
            return this;
        }
        public MainPage ClickAcceptRateAndExtrasButton()
        {
            acceptRateAndExtrasButton.Click();
            return this;
        }

        public MainPage ClickBookNowButton()
        {
            bookNowButton.Click();
            return this;
        }
    }
}
