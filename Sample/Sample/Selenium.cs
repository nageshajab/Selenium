using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SmokeTests
{
    public class Selenium
    {
        static WebDriverWait wait = null;
        static IWebDriver driver = null;
        static Actions action = null;

        public static void LaunchUrl(string url)
        {
            driver = new ChromeDriver(".");
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);
            WebDriverwait(120, 5);
        }

        public static void Quit()
        {
            driver.Quit();
        }

        public static void WaitUntilElementIsVisibleByXpath(string xpath)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public static void WaitUntilElementIsVisibleById(string id)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public static IWebElement FindElementByXpath(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public static IWebElement FindElementById(string id)
        {
            return driver.FindElement(By.Id(id));
        }

        public static void WebDriverwait(int fromseconds, int pollingIntervalSeconds)
        {
            wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(fromseconds))
            {
                PollingInterval = TimeSpan.FromSeconds(pollingIntervalSeconds),
            };
        }
        public static void MoveToElementByXpath(string xpath)
        {
            action = new Actions(driver);
            action.MoveToElement(FindElementByXpath(xpath)).Perform();
        }
     
    }
}
