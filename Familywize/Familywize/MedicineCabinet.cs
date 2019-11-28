using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
namespace Familywize
{
    class MedicineCabinet
    {
        IWebDriver driver;
        string chromedriverpath;
        string siteurl;
        WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            chromedriverpath = ConfigurationManager.AppSettings["chrome_driver_exe_path"];
            siteurl = ConfigurationManager.AppSettings["site_url"];

            driver = new ChromeDriver(chromedriverpath,new ChromeOptions() {  },TimeSpan.FromMinutes(2));
            //_ = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver,TimeSpan.FromMinutes(2));
            //            new WebDriverWait(driver,TimeSpan.FromMinutes(2)).Until(
            //d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [Test]
        public void Test()
        {            
            driver.Url = siteurl;
            IWebElement SignInElement  = driver.FindElement(By.LinkText("Sign In"));            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SignInElement)).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
