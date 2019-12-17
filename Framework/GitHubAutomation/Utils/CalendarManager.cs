using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GitHubAutomation.Utils
{
    class CalendarManager
    {
        public static void SetDateCalendar(IWebElement calendar, int days)
        {
            var keys = days > 0 ? Keys.ArrowRight : Keys.ArrowLeft;

            for (int i = 0; i < Math.Abs(days); i++)
                calendar.SendKeys(keys);
        }
    }
}
