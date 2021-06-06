using NUnit.Framework;
using System;

namespace SmokeTests
{
    public class Home
    {
        public static void VerifyHomePage()
        {
            try
            {
                //Verfiy Home Menu
                Selenium.WaitUntilElementIsVisibleByXpath("//ul[@id='TopNavMenu']/li/a");
                string HomeText = Selenium.FindElementByXpath("//ul[@id='TopNavMenu']/li/a").Text;
                Assert.AreEqual(HomeText, "Home");

                //Verfiy User Menu
                Selenium.WaitUntilElementIsVisibleByXpath("//ul[@id='TopNavMenu']/li[5]/span");
                string UserText = Selenium.FindElementByXpath("//ul[@id='TopNavMenu']/li[5]/span").Text;
                Assert.AreEqual(UserText, "User");

                //Verfiy Configuration Menu
                Selenium.WaitUntilElementIsVisibleByXpath("//ul[@id='TopNavMenu']/li[6]/span");
                string ConfigText = Selenium.FindElementByXpath("//ul[@id='TopNavMenu']/li[6]/span").Text;
                Assert.AreEqual(ConfigText, "Configuration");
                               
                Logger.Info("VerifyHomePage", "PASS", "Home Page Verified true");
            }
            catch (Exception e)
            {                
                Logger.Error("VerifyHomePage", "FAIL", "Home Page Verified False", e.Message);
            }
        }
    }
}
