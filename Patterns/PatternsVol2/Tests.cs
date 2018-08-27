using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PatternsVol2.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace PatternsVol2
{
    [TestClass]
    public class PatternTests
    {
        public const string MailURL = "https://www.tut.by/";
        public const string MailLog = "AutoTest92";
        public const string MailPWD = "Inq2020327";
        public const string UName = "Test Auto";

        private IWebDriver driver;

        [TestInitialize]
        public void initialize()
        {
            driver = new ChromeDriver(@"..\..\..\PatternsVol2\Drivers\"); 
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(MailURL,MailLog,MailPWD);
            HomePage homePage = new HomePage(driver);
            Assert.AreEqual(homePage.getTextOfUserName(),UName, "You did not logged in ");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogOut()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(MailURL, MailLog, MailPWD);
            HomePage homePage = new HomePage(driver);
            homePage.LogOut();
            Assert.IsTrue(loginPage.isDisplayed(), "You are not looged out");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
