using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using EryceTestAssignment.PageObjectModel;
using System.IO;
using System.Diagnostics;

namespace EryceTestAssignment.Test
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        private HomePage homePage;
        private const string loginMsg = "Thank you for logging in!";

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(base.driver);
            homePage.GoToPage();
        }

        [Test]
        [TestCase(TestName = "Valid credentials test - both credentials are correct",
          Description = "Given user has correct both credentials, when he tries to login, he enters the system")]
        public void UserLoginWithValidCredentials_UserIsLoggedIn()
        {
            homePage.Login("admin@eryce.com", "Asdasd12#");
            
            var greetingmsg = homePage.txtGreetingMessage;
            Assert.IsTrue(greetingmsg.Text.Equals(loginMsg));

            driver.FindElement(By.ClassName("back_to_login_btn")).Click();         
        }


        [Test]
        [TestCase(TestName = "Invalid credentials test - both credentials are incorrect",
                  Description = "Given user has incorrect both credentials, when he tries to login, then he is not able to login")]
        public void UserLoginWithInvalidCredentials_UserIsNotLoggedIn()
        {
            homePage.Login("wrong@email.com", "Password");

            var EmailOrPasswordAreWrong = driver.FindElement(By.Id("qaEmail"));
            var EmailOrPasswordAreWrong_1 = driver.FindElement(By.Id("qaPassword"));
            Assert.IsTrue(EmailOrPasswordAreWrong.Text.Equals("Email or password are not correct, please check!"));
            Assert.IsTrue(EmailOrPasswordAreWrong_1.Text.Equals("Email or password are not correct, please check!"));
        }


        [Test]
        [TestCase(TestName = "Invalid credentials test - incorrect password",
                  Description = "Given user has incorrect password, when he tries to login, then he is not able to login")]
        public void UserLoginWithInvalidPassword_UserIsNotLoggedIn()
        {
            homePage.Login("admin@eryce.com", "pAssWoRD");

            var EmailOrPasswordAreWrong = driver.FindElement(By.Id("qaEmail"));
            var EmailOrPasswordAreWrong_1 = driver.FindElement(By.Id("qaPassword"));
            Assert.IsTrue(EmailOrPasswordAreWrong.Text.Equals("Email or password are not correct, please check!"));
            Assert.IsTrue(EmailOrPasswordAreWrong_1.Text.Equals("Email or password are not correct, please check!"));
        }


        [Test]
        [TestCase(TestName = "Invalid credentials test - incorrect email",
                  Description = "Given user has incorrect email, when he tries to login, then he is not able to login")]
        public void UserLoginWithInvalidEmail_UserIsNotLoggedIn()
        {
            homePage.Login("eryce@email.com", "Asdasd12#");
            
            var EmailOrPasswordAreWrong = driver.FindElement(By.Id("qaEmail"));
            var EmailOrPasswordAreWrong_1 = driver.FindElement(By.Id("qaPassword"));
            Assert.IsTrue(EmailOrPasswordAreWrong.Text.Equals("Email or password are not correct, please check!"));
            Assert.IsTrue(EmailOrPasswordAreWrong_1.Text.Equals("Email or password are not correct, please check!"));
        }


        [Test]
        [TestCase(TestName = "Without credentials test",
                  Description = "Given user has blank both fields, when he tries to login, then he is not able to login")]
        public void UserLoginWithoutCredentials_UserIsNotLoggedIn()
        {
            homePage.Login(" ", " ");

            var EmailOrPasswordAreWrong = driver.FindElement(By.Id("qaEmail"));
            var EmailOrPasswordAreWrong_1 = driver.FindElement(By.Id("qaPassword"));
            Assert.IsTrue(EmailOrPasswordAreWrong.Text.Equals("Email or password are not correct, please check!"));
            Assert.IsTrue(EmailOrPasswordAreWrong_1.Text.Equals("Email or password are not correct, please check!"));
        }
    }
}
