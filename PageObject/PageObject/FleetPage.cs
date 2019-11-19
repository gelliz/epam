using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObject
{
    public class FleetPage
    {
        public FleetPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'sx-gc-txt']")]
        private IWebElement listOfCountries { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'sx-gc-txt']/optgroup/option[@value = 'RO']")]
        private IWebElement desireCountry { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id = 'sx-fleet-desktop-suv']/p[@value = 'suv']")]
        private IWebElement categorySuv { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@id = 'sx-fleet-filter-result-success']/span[@id = 'sx-js-nog']")]
        public IWebElement textAboutCategoriesReceived { get; set; }

        public FleetPage SelectDesireCharacteristics(IWebDriver webDriver)
        {
            listOfCountries.Click();
            desireCountry.Click();
            categorySuv.Click();
            return this;
        }

    }
}
