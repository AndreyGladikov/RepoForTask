using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PatternsVol2.Pages
{
    class LoginPage
    {
        public const string MailURL = "https://www.tut.by/";
        public const string MailLog = "AutoTest92";
        public const string MailPWD = "Inq2020327";

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@data-target-popup='authorize-form']")]
        private IWebElement LoginPopUp;
        [FindsBy(How = How.XPath, Using = "//div[@class='i-holder']//input[@type='text']")]
        private IWebElement LoginField;
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement PasswordField;
        [FindsBy(How = How.XPath, Using = "//input[@value='Войти']")]
        private IWebElement LoginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(MailURL);
            LoginPopUp.Click();
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public bool CheckVisibility()
        {
            return LoginPopUp.Displayed;
        }
    }
}

