using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class StationsPage
    {
        private IWebDriver driver;

        public StationsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'adr']")]
        private IWebElement locationSearchBar;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'clearfix']/input[@value = 'Search for this location']")]
        private IWebElement searchButton;

        public StationsPage InputAndFindInaccessibleLocation(InaccessibleLocation inaccessibleLocation)
        {
            locationSearchBar.SendKeys(inaccessibleLocation.InaccessibleStation);
            searchButton.Click();
            return this;
        }

        public string GetUrlOfStationsPageAfterSearch()
        {
            return this.driver.Url;
        }
    }
}
