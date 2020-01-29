using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EryceTestAssignment
{
    public static class DriverProvider
    {
        public static IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(Directory.GetCurrentDirectory());
        }

        public static IWebDriver GetFireFoxDriver()
        {
            return new FirefoxDriver(Directory.GetCurrentDirectory());
        }
    }
}

