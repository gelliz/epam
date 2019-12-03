using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class StartPage
    {
        public StartPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@class = 't3-js-main-navi-item t3-main-navi-item t3-main-navi-hd-menu']/div[@class = 't3-main-navi-hd']/span")]
        private IWebElement menuButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 't3-mainmenu']/li[3]/a[@href = '/fleet/']")]
        private IWebElement fleetItem;

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

        [FindsBy(How = How.XPath, Using = "//label[@for = 'sx-res-filter-age']/span[@class = 'sx-js-age-filter-data']")]
        public IWebElement listAge;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 'offerselect__filter__dropdown__list offerselect__filter__dropdown__list--age offerselect__filter__dropdown__list--open']/li")]
        public IWebElement selectingAge;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'age-hint display-hint']/p")]
        public IWebElement errorMessageAboutForbiddenAge;

        public StartPage GoToTabFleet(IWebDriver webDriver)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(menuButton).Click().Build().Perform();
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(fleetItem));
            fleetItem.Click();
            return this;
        }
        public StartPage FillInLocationFields(string location)
        {
            uncheckDroppOffLocation.Click();
            pickUpLocationBox.Click();
            pickUpLocationBox.SendKeys(location);
            pickUpLocation.Click();
            returnLocationBox.Click();
            returnLocationBox.SendKeys(location);
            returnLocation.Click();
            return this;
        }
        public StartPage ClickGetQuoteButton()
        {
            getQuoteButton.Click();
            return this;
        }

        public StartPage SelectAgeLessThanTwentyOne()
        {
            listAge.Click();
            selectingAge.Click();
            return this;
        }
    }
}
