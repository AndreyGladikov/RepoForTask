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
        private static IWebDriver driver;

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
            loginPage.Login("AutoTest92","Inq2020327");
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.getText().Contains(HomePage.UName), "You did not logged in ");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogOut()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("AutoTest92", "Inq2020327");
            HomePage homePage = new HomePage(driver);
            homePage.LogOut();
            Assert.IsTrue(loginPage.Check(), "You are not looged out");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
