using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
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
        //[Test]
        //public void RentCarWithoutEnteringPersonalData()
        //{
        //    TakeScreenshotWhenTestFailed(() =>
        //    {
        //        MainPage mainPage = new MainPage(Driver)
        //            .FillInFieldsPickUpAndReturnLocation(CreatingOrder.WithFilledFields())
        //            .ClickGetQuoteButton()
        //            .ClickPayLaterButton()
        //            .ClickAcceptRateAndExtrasButton()
        //            .ClickBookNowButton();
        //        Assert.AreEqual("Please check the red marked entries.", mainPage.errorMessage.Text);
        //    });
        //}

        [Test]
        public void FindCarWithDesiredCharacteristics()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                FleetPage mainPage = new MainPage(Driver).GoToTabFleet()
                .SelectDesireCountries().SelectCategorySuv();
                Assert.AreEqual("6", mainPage.textAboutCategoriesReceived.Text);
            });
        }
    }
}
