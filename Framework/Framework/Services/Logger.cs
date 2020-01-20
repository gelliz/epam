using System;
using System.IO;
using log4net;
using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObjects;
using Framework.Driver;

namespace Framework.Services
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger(typeof(Logger));
        public static ILog Log
        {
            get { return log; }
        }
    }
}
