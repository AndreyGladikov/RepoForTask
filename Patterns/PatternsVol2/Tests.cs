using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PatternsVol2.Pages;
using OpenQA.Selenium.Support.PageObjects;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Remote;

namespace PatternsVol2
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestClass]
    public class PatternTests
    {
        public const string MailURL = "https://www.tut.by/";
        public const string MailLog = "AutoTest92";
        public const string MailPWD = "Inq2020327";
        public const string UName = "Test Auto";

        private IWebDriver driver;
        private ICapabilities capabilities;

        [TestInitialize]
        [SetUp]
        public void initialize()
        {
            driver = new ChromeDriver(@"..\..\..\PatternsVol2\Drivers\");
            capabilities = ((RemoteWebDriver)driver).Capabilities;
        }

        [Test(Description = "Test of login")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.trivial)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Gladikov")]
        [AllureSuite("PassedSuite")]
        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(MailURL,MailLog,MailPWD);
            HomePage homePage = new HomePage(driver);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(homePage.getTextOfUserName(),UName, "You did not logged in ");
        }

       [Test(Description = "Test of logout")]
       [AllureTag("Regression")]
       [AllureSeverity(SeverityLevel.minor)]
       [AllureIssue("ISSUE-2")]
       [AllureOwner("Borisik")]
       [AllureSuite("PassedSuite")]
       [TestMethod]
       [TestCategory("Chrome")]
       public void MailLogOut()
       {
           LoginPage loginPage = new LoginPage(driver);
           loginPage.Login(MailURL, MailLog, MailPWD);
           HomePage homePage = new HomePage(driver);
           homePage.LogOut();
           Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(loginPage.isDisplayed(), "You are not looged out");
       }

        [TestCleanup]
        [TearDown]
        public void CleanUp()
        {
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"D:\Screen\pic4a.png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment(@"D:\Screen\pic4a.png", "FailedScreen");
                Console.WriteLine(string.Format(@"Browser name = {0} Browser version = {1}" , capabilities.BrowserName, capabilities.Version));
            }
            driver.Quit();
        }
    }
}