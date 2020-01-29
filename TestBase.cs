using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace EryceTestAssignment
{
    public class TestBase
    {
        public IWebDriver driver { get; set; } 

        [SetUp]
        public void BaseSetUp()
        {
            driver = DriverProvider.GetChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        } 

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}