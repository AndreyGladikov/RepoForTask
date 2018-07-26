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
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.clickOnLoginPopUp();
            login.enterUserName("AutoTest92");
            login.enterPassword("Inq2020327");
            login.clickOnLoginButton();
            HomePage home = new HomePage(driver);
            string CurText = home.UserName.Text;
            Assert.IsTrue(CurText.Contains(HomePage.UName), "You did not log in ");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogOut()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.clickOnLoginPopUp();
            login.enterUserName("AutoTest92");
            login.enterPassword("Inq2020327");
            login.clickOnLoginButton();
            HomePage home = new HomePage(driver);
            home.clickOnUserName();
            home.clickOnLogOutBTN();
            Assert.IsTrue(login.LoginPopUp.Displayed);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
