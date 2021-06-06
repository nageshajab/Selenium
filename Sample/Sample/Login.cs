using NUnit.Framework;
using System;

namespace SmokeTests
{
    public class Login
    {
        public static void PerformLogin(string username, string password)
        {
            try
            {
                // Enter UserName
                Selenium.WaitUntilElementIsVisibleById("UserName");
                Selenium.FindElementById("UserName").SendKeys(username);

                // Enter Password
                Selenium.WaitUntilElementIsVisibleById("Password");
                Selenium.FindElementById("Password").SendKeys(password);

                //Click Sign In button
                Selenium.WaitUntilElementIsVisibleById("loginButton");
                Selenium.FindElementById("loginButton").Click();
                

                //Verify successfull login
                string usernametext = Selenium.FindElementByXpath("//div[@class='userInfo']/a/label").Text;
                Assert.AreEqual(usernametext, username);

                Logger.Info("PerformLogin", "PASS", "Login tested Successfully");            
            }
            catch (Exception e)
            {
                Logger.Error("PerformLogin", "FAIL", "Login Successfully?: NO", e.Message);
            }
        }
    }
}
