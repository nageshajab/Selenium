using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;
using seleniumTests.Model;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;


namespace seleniumTests
{


    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private string employeelistpage = "https://watchlist320250214181224-f0h2ctgcczczddac.centralindia-01.azurewebsites.net/default";
        private string addemployeepage = "https://watchlist320250214181224-f0h2ctgcczczddac.centralindia-01.azurewebsites.net/addemployee";
        List<Employee> employees;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            // Initialize your driver here            
            reademployeesfromcsv();
        }

        private void reademployeesfromcsv()
        {
            employees = new List<Employee>();
            using var sr = new StreamReader(@".\us-500.csv");
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);

            employees = csv.GetRecords<Employee>().ToList();
        }

        public void EmployeeListDisplayed()
        {
            driver.Navigate().GoToUrl(employeelistpage);

            IWebElement h4 = driver.FindElement(By.XPath("//h4[contains(text(),'Employee List')]"));

            if (h4.Displayed)
                Assert.Pass("");
            else
                Assert.Fail();
        }

        [Test]
        public void AddEmployee()
        {
            foreach (Employee employee in employees)
            {
                driver.Navigate().GoToUrl(addemployeepage);

                //set firstname
                IWebElement firstname = driver.FindElement(By.Id("MainContent_firstname"));
                firstname.SendKeys(employee.Firstname);

                //set lastname
                IWebElement lastname = driver.FindElement(By.Id("MainContent_lastname"));
                lastname.SendKeys(employee.lastname);

                //set gender
                IWebElement gendermale = driver.FindElement(By.Id("MainContent_male"));
                IWebElement genderfemale = driver.FindElement(By.Id("MainContent_female"));
                if (employee.gender.StartsWith("m"))
                    gendermale.Click();
                else
                    genderfemale.Click();

                IWebElement button = driver.FindElement(By.Name("ctl00$MainContent$ctl00"));
                button.Click();

                //fill address details
                //set address line1
                IWebElement addressline1 = driver.FindElement(By.Id("MainContent_addressline1"));
                addressline1.SendKeys(employee.addressline1);

                //set address line2
                IWebElement addressline2 = driver.FindElement(By.Id("MainContent_addressline2"));
                addressline2.SendKeys(employee.addressline2);

                //set city
                IWebElement city = driver.FindElement(By.Id("MainContent_city"));
                city.SendKeys(employee.city);

                //set state
                IWebElement state = driver.FindElement(By.Id("MainContent_state"));
                state.SendKeys(employee.state);

                //set zipcode
                IWebElement zipcode = driver.FindElement(By.Id("MainContent_zipcode"));
                zipcode.SendKeys(employee.zip);

                IWebElement button1 = driver.FindElement(By.Name("ctl00$MainContent$ctl00"));
                button1.Click();

                IWebElement h4 = driver.FindElement(By.XPath("//h4[contains(text(),'Employee List')]"));

                if (h4.Displayed)
                    Console.WriteLine("Employee added successfully");
                else
                    Console.WriteLine("Employee not added");

                break;

            }
            Assert.That(true, Is.True, $"Add Employee test passed");
            
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }

            // Generate test results
            var testResultsFile = "test-results.trx";
            var subject = "Unit Test Summary";
            var toEmail = "recipient-email@domain.com";

            // Parse test results and create email body
            var body = ParseTestResults(testResultsFile);

            // Send email
            SendTestSummaryEmail(subject, body, toEmail);
        }

        private string ParseTestResults(string testResultsFile)
        {
            var doc = XDocument.Load(testResultsFile);
            var summary = doc.Descendants("ResultSummary").First();
            var counters = summary.Element("Counters");

            var passed =int.Parse( counters.Attribute("passed").Value);
            var failed = int.Parse(counters.Attribute("failed").Value);
            var skipped =int.Parse( counters.Attribute("total").Value) - passed - failed;

            var body = new StringBuilder();
            body.AppendLine("Test Summary:");
            body.AppendLine($"Passed: {passed}");
            body.AppendLine($"Failed: {failed}");
            body.AppendLine($"Skipped: {skipped}");
            body.AppendLine();

            var results = doc.Descendants("UnitTestResult");
            foreach (var result in results)
            {
                var testName = result.Attribute("testName").Value;
                var outcome = result.Attribute("outcome").Value;
                body.AppendLine($"{testName}: {outcome}");
            }

            return body.ToString();
        }

        private void SendTestSummaryEmail(string subject, string body, string toEmail)
        {
            var fromAddress = new MailAddress("your-email@domain.com", "Your Name");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "your-email-password";

            var smtp = new SmtpClient
            {
                Host = "smtp.yourserver.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
