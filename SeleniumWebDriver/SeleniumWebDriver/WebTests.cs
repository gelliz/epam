using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class WebTests : BrowserBaseFunction
    {
        //Отмена бронирования
        //Шаги: зайти на сайт http://www.sixt.global, залогиниться, перейти на вкладку MENU -> "Customer Service", 
        //выбрать "Cancel", нажать кнопку "Reservation cancellation".
        //Ожидаемый результат: пользователь отменил бронирование и увидел подтверждение.
        [Test]
        public void CarReservationCancellation()
        {
            var loginTab = GetWebElementByXPath("//li[@class = 't3-main-navi-item t3-main-navi-hd-login']/a");
            loginTab.Click();

            var userName = GetWebElementByXPath("//input[@name = 'UserName']");
            userName.SendKeys("33086490");

            var password = GetWebElementByXPath("//input[@name = 'Password']");
            password.SendKeys("golubliza");

            var loginButton = GetWebElementByXPath("//a[@class = 'sx-gc-button-cta sx-gc-button-cta-green modal__content__button--modifier']");
            loginButton.Click();

            var menuTab = GetWebElementByXPath("//div[@class = 't3-main-navi-hd']");
            menuTab.Click();

            var customerService = GetWebElementByXPath("//div[@class = 't3-main-navi-content']/ul/li[5]/a");
            customerService.Click();

            var cancelButton = GetWebElementByXPath("//a[@class = 'sx-gc-iconlink sx-gc-display-block sx-gc-normal-weight action-cancel']");
            cancelButton.Click();

            var ReservationCancellationButton = GetWebElementByXPath("//p[@class = 'sx-gc-button-normal-red sx-gc-button-normal sx-gc-button-normal-green']");
            ReservationCancellationButton.Click();

            var confirmMessage = GetWebElementByXPath("//div[@class = 'sx-gc-message-text']");
            Assert.AreEqual("Your reservation has been cancelled successfully", confirmMessage.Text);
        }

        //Аренда автомобиля без ввода личных данных
        //Шаги: зайти на сайт http://www.sixt.global, заполнить поля PICK-UP LOCATION & DROP-OFF, PICK-UP TIME и DROP-OFF TIME, 
        //выбрать автомобиль, в заявке оставить все поля пустыми, нажать кнопку "Book now".
        //Ожидаемый результат: все поля выделяются красным и предлагаются подсказки.
        [Test]
        public void RentCarWithoutEnteringPersonalData()
        {
            var e = GetWebElementByXPath("//div[@class = 'ibe-button-par ibe-button-par-pickup']");
            e.Click();

            var pickUpLocationBox = GetWebElementByXPath("//div[@id = 'sx-js-res-pu-location']/span/input");
            pickUpLocationBox.Click();
            pickUpLocationBox.SendKeys("Minsk National Airport");
            var pickUpLocation = GetWebElementByXPath("//ul[@id = 'sx-js-res-pu-list']/li[1]/ul/li");
            pickUpLocation.Click();

            var returnLocationBox = GetWebElementByXPath("//div[@id = 'sx-js-res-ret-location']/span/input");
            returnLocationBox.Click();
            returnLocationBox.SendKeys("Minsk National Airport");
            var returnLocation = GetWebElementByXPath("//ul[@id = 'sx-js-res-ret-list']/li[1]/ul/li");
            returnLocation.Click();

            var getQuoteButton = GetWebElementByXPath("//p[@class = 'ibe-button']");
            getQuoteButton.Click();

            var payLaterButton = GetWebElementByXPath("//p[@class = 'price-section__button  sx-res-js-select-offer sx-gc-button-cta sx-gc-button-cta-list sx-gc-button-cta-green']");
            payLaterButton.Click();

            var acceptRateAndExtrasButton = GetWebElementByXPath("//button[@id = 'sx-js-res-booking-button']");
            acceptRateAndExtrasButton.Click();

            var bookNowButton = GetWebElementByXPath("//button[@id = 'sx-js-res-booking-button']");
            bookNowButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@class = 'sx-gc-error']");
            Assert.AreEqual("Please check the red marked entries.", errorMessage.Text);
        }
    }
}
