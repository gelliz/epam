using System;
using OpenQA.Selenium;

namespace Framework.Tests
{
    public class CalendarManager
    {
        public static void SetDateCalendar(IWebElement calendar, int days)
        {
            var keys = days > 0 ? Keys.ArrowRight : Keys.ArrowLeft;

            for (int i = 0; i < Math.Abs(days); i++)
                calendar.SendKeys(keys);
        }
    }
}
