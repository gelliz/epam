using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageObjects
{
    public class FleetPage
    {
        private IWebDriver driver;

        public FleetPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'sx-gc-txt']")]
        private IWebElement listOfCountries;

        [FindsBy(How = How.XPath, Using = "//select[@class = 'sx-gc-txt']/optgroup/option[@value = 'RO']")]
        private IWebElement desireCountry;

        [FindsBy(How = How.XPath, Using = "//li[@id = 'sx-fleet-desktop-suv']/p[@value = 'suv']")]
        private IWebElement categorySuv;

        [FindsBy(How = How.XPath, Using = "//p[@id = 'sx-fleet-filter-result-success']/span[@id = 'sx-js-nog']")]
        public IWebElement textAboutCategoriesReceived;

        public FleetPage SelectDesireCountries()
        {
            listOfCountries.Click();
            desireCountry.Click();
            return this;
        }
        public FleetPage SelectCategorySuv()
        {
            categorySuv.Click();
            return this;
        }
    }
}
