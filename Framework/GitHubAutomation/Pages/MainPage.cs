using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

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
        public IWebElement errorMessageWithoutPersonalData;

        [FindsBy(How = How.XPath, Using = "//li[@class = 't3-js-main-navi-item t3-main-navi-item t3-main-navi-hd-menu']/div[@class = 't3-main-navi-hd']/span")]
        private IWebElement menuButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 't3-mainmenu']/li[3]/a[@href = '/fleet/']")]
        private IWebElement fleetItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 't3-mainmenu']/li[3]/a[@href = '/car-rental/']")]
        private IWebElement stationsItem;

        [FindsBy(How = How.XPath, Using = "//label[@for = 'sx-res-filter-age']/span[@class = 'sx-js-age-filter-data']")]
        private IWebElement listAge;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 'offerselect__filter__dropdown__list offerselect__filter__dropdown__list--age offerselect__filter__dropdown__list--open']/li")]
        private IWebElement ageUnderTwentyOne;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'age-hint display-hint']/p")]
        public IWebElement errorMessageAboutForbiddenAge;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'tel']")]
        private IWebElement phoneNumber;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'sx-res-bookingconfirmation-header']/h1")]
        public IWebElement messageReservationNumber;

        [FindsBy(How = How.XPath, Using = "//li[@data-content = 't3-js-language-select']/div[@class = 't3-main-navi-hd']")]
        private IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//div[@id = 't3-js-language-select']/li[2]/a[@data-language = 'es_ES']")]
        private IWebElement listLanguages;

        [FindsBy(How = How.XPath, Using = "//li[@class = 't3-main-navi-item t3-main-navi-hd-login']/a")]
        private IWebElement loginTab;
       
        [FindsBy(How = How.XPath, Using = "//input[@name = 'UserName']")]
        private IWebElement userName;
        
        [FindsBy(How = How.XPath, Using = "//input[@name = 'Password']")]
        private IWebElement password;
        
        [FindsBy(How = How.XPath, Using = "//a[@class = 'sx-gc-button-cta sx-gc-button-cta-green modal__content__button--modifier']")]
        private IWebElement loginButton;
        
        [FindsBy(How = How.XPath, Using = "//ul[@class = 't3-mainmenu']/li[5]/a[@href = '/mysixt/']")]
        private IWebElement customerService;
        
        [FindsBy(How = How.XPath, Using = "//a[@class = 'sx-gc-iconlink sx-gc-display-block sx-gc-normal-weight action-cancel']")]
        private IWebElement cancelButton;
        
        [FindsBy(How = How.XPath, Using = "//p[@class = 'sx-gc-button-normal-red sx-gc-button-normal sx-gc-button-normal-green']")]
        private IWebElement reservationCancellationButton;
        
        [FindsBy(How = How.XPath, Using = "//div[@class = 'sx-gc-message-text']")]
        public IWebElement confirmMessage;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 'sx-res-bookingconfirmation-header info']/li/a[@href = '/php/reservation/showpdf?tab_identifier=1576554471']")]
        private IWebElement fileDownloadLink;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'sx-js-res-ret-date']")]
        private IWebElement returnDate;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'sx-js-res-error']")]
        public IWebElement errorMessageAboutMaxRentalPeriod;

        [FindsBy(How = How.XPath, Using = "//li[@class = 't3-main-navi-item t3-main-navi-hd-res']/span/a[@href = '/rent-a-truck/']")]
        private IWebElement rentATruckButton;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'sx-js-res-error']/p[1]")]
        public IWebElement errorMessageAboutRentalTruck;

        public FleetPage GoToTabFleet()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(menuButton).Click().Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(fleetItem));
            fleetItem.Click();
            return new FleetPage(driver);
        }
        public StationsPage GoToTabStations()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(menuButton).Click().Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(stationsItem));
            stationsItem.Click();
            return new StationsPage(driver);
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
        public MainPage SelectAgeLessThanTwentyOne()
        {
            listAge.Click();
            ageUnderTwentyOne.Click();
            return this;
        }
        public MainPage InputInvalidPhoneNumber(InvalidPhoneNumber phone)
        {
            phoneNumber.SendKeys(phone.PhoneNumber);
            return this;
        }
        public MainPage ClickLanguageButtonAndSelectLanguage()
        {
            languageButton.Click();
            listLanguages.Click();
            return this;
        }
        public string GetUrlOfMainPageInSpanish()
        {
            return this.driver.Url;
        }
        public MainPage LogIn(UserData userData)
        {
            loginTab.Click();
            userName.SendKeys(userData.UserName);
            password.SendKeys(userData.Password);
            loginButton.Click();
            return this;
        }
        public MainPage CancelReservation()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(menuButton).Click().Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(customerService)).Click();
            cancelButton.Click();
            reservationCancellationButton.Click();
            return this;
        }
        public bool IsLinkToDownloadFile()
        {
            return fileDownloadLink.Displayed;
        }
        public MainPage FillInFieldReturnDate(int countDays)
        {
            CalendarManager.SetDateCalendar(returnDate, countDays);
            return this;
        }
        public MainPage RentTruckWithoutInputLocation()
        {
            rentATruckButton.Click();
            getQuoteButton.Click();
            return this;
        }
    }
}
