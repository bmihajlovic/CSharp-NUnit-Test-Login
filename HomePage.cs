using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EryceTestAssignment.PageObjectModel
{
    class HomePage
    {
        private readonly static string pageURL = "https://website.eryce.com/qa-test/"; //deklaracija polja ukljucuje modifikator koji je samo za citanje
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement TxtEmail
        {
            get
            {
                return driver.FindElement(By.Id("qaEmail"));
            }
        }

        private IWebElement TxtPassword
        {
            get
            {
                return driver.FindElement(By.Id("qaPassword"));
            }
        }

         private IWebElement BtnLogin
        {
            get
            {
                return driver.FindElement(By.ClassName("login_btn"));
            }
        }
        
        public IWebElement txtGreetingMessage
        {
            get
            {
                return driver.FindElement(By.ClassName("welcome_message"));
            }
        }

        private IWebElement BtnBackToLogin
        {
            get
            {
                return driver.FindElement(By.ClassName("back_to_login_btn"));
            }
        }
        private IWebElement BtnEyePassword
        {
            get
            {
                return driver.FindElement(By.ClassName("fa-eye-slash"));
            }
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(pageURL);
        }

        public void Login(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }

        public void BackToLogin() 
        {
            BtnBackToLogin.Click();
        }
    }
}
