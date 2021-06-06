using System.Configuration;

namespace SmokeTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            string username = ConfigurationManager.AppSettings.Get("username");
            string password = ConfigurationManager.AppSettings.Get("password");

            try
            {
                Selenium.LaunchUrl(url);
                Login.PerformLogin(username, password);

                Logger.Info("Main method", "PASS", "login worked");
            }
            catch (System.Exception ex)
            {
                Logger.Error("Main method", "FAIL", "exception in main method", ex.Message);
            }

            Selenium.Quit();
            System.Environment.Exit(0);
        }
    }
}
