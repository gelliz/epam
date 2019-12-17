﻿using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using GitHubAutomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        const string CheckPageUrl = "https://www.sixt.global/es/";
        const string StationPageUrl = "https://www.sixt.global/php/stationfinder/default";

        [Test]
        public void RentCarWithoutEnteringPersonalData()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInFieldsPickUpAndReturnLocation(OrderCreater.WithFilledFields())
                    .ClickGetQuoteButton()
                    .ClickPayLaterButton()
                    .ClickAcceptRateAndExtrasButton()
                    .ClickBookNowButton();
                Assert.AreEqual("Please check the red marked entries.", mainPage.errorMessageWithoutPersonalData.Text);
            });
        }

        [Test]
        public void FindCarWithDesiredCharacteristics()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                FleetPage mainPage = new MainPage(Driver)
                    .GoToTabFleet()
                    .SelectDesireCountries()
                    .SelectCategorySuv();
                Assert.AreEqual("6", mainPage.textAboutCategoriesReceived.Text);
            });
        }

        [Test]
        public void CarRentalByDriverUnderTwentyOne()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                .FillInFieldsPickUpAndReturnLocation(OrderCreater.WithFilledFields())
                .ClickGetQuoteButton()
                .SelectAgeLessThanTwentyOne();
                Assert.AreEqual("Minimum age of driver: 21 years", mainPage.errorMessageAboutForbiddenAge.Text);
            });
        }

        [Test]
        public void EnteringInvalidPhoneNumber()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInFieldsPickUpAndReturnLocation(OrderCreater.WithFilledFields())
                    .ClickGetQuoteButton()
                    .ClickPayLaterButton()
                    .InputInvalidPhoneNumber(OrderCreater.WithInvalidPhoneNumber())
                    .ClickBookNowButton();
                Assert.AreEqual("Your reservation number: ", mainPage.messageReservationNumber.Text);
            });
        }

        [Test]
        public void ChangeOfLanguageOnSite()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .ClickLanguageButtonAndSelectLanguage();
                Assert.AreEqual(CheckPageUrl, mainPage.GetUrlOfMainPageInSpanish());
            });
        }

        [Test]
        public void CarReservationCancellation()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .LogIn(OrderCreater.WithLogIn())
                    .CancelReservation();
                Assert.AreEqual("Your reservation has been cancelled successfully", mainPage.confirmMessage.Text);
            });
            
        }

        [Test]
        public void SearchForCarInInaccessibleLocation()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StationsPage mainPage = new MainPage(Driver)
                   .LogIn(OrderCreater.WithLogIn())
                   .GoToTabStations()
                   .InputAndFindInaccessibleLocation(InputInaccessibleLocation.WithInaccessibleLocation());
                Assert.AreEqual(StationPageUrl, mainPage.GetUrlOfStationsPageAfterSearch());
            });
        }

        [Test]
        public void ProofOfRentalCar()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .LogIn(OrderCreater.WithLogIn())
                    .FillInFieldsPickUpAndReturnLocation(OrderCreater.WithFilledFields())
                    .ClickGetQuoteButton()
                    .ClickPayLaterButton()
                    .ClickAcceptRateAndExtrasButton()
                    .ClickBookNowButton();
                Assert.IsTrue(mainPage.IsLinkToDownloadFile());
            });

        }

        [Test]
        public void CarRentalForPeriodExceedingPossible()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                    .FillInFieldsPickUpAndReturnLocation(OrderCreater.WithFilledFields())
                    .FillInFieldReturnDate(8)
                    .ClickGetQuoteButton();
                Assert.AreEqual("Please note the maximum rental period of 180 days!", mainPage.errorMessageAboutMaxRentalPeriod.Text);
            });
        }

        [Test]
        public void TruckRentalWithoutInputLocation()
        {
            Driver.Manage().Window.Maximize();
            TakeScreenshotWhenTestFailed(() =>
            {
                MainPage mainPage = new MainPage(Driver)
                        .RentTruckWithoutInputLocation();
                Assert.AreEqual("Please select a pick-up location.", mainPage.errorMessageAboutRentalTruck.Text);
            });
        }
    }
}
