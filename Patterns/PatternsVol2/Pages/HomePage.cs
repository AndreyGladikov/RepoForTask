using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PatternsVol2.Pages
{
    class HomePage
    {
        public const string UName = "Test Auto";

        [FindsBy(How = How.XPath, Using = "//span[@class='uname']")]
        private IWebElement UserName;
        [FindsBy(How = How.XPath, Using = "//a[@class='button wide auth__reg']")]
        private IWebElement LogOutBTN;
       
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void LogOut()
        {
            UserName.Click();
            LogOutBTN.Click();
        }

        public string getTextOfUserName()
        {
            return UserName.Text;
        }
    }
}
