using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumProject
{
    [TestFixture]
    public class SampleTests
    {
        private IWebDriver driver;
        public static IEnumerable<object[]> TestData => ExcelReader.ReadExcel(Constants.OrangeHRMExcelPath);

        [SetUp]
        public void Setup()
        {
            driver = WebDriverSingleton.GetWebDriver();
        }


        [Test]
        public void LoginWithValidCredentials()
        {
            driver.Navigate().GoToUrl(Constants.OrageHRMBaseUrl);
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUsername(Constants.Credentials.Username);
            loginPage.SetPassword(Constants.Credentials.Password);
            loginPage.ClickLogin();
            Assert.That(driver.Url.Contains("dashboard"), $"The text '{"dashboard"}' was not found on the page.");
            Assert.That(driver.Title.Contains(Constants.OrangeHRM_Title));
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void LoginWithExcelSheetTestData(string ExcelUsername, string ExcelPassword)
        {
            driver.Navigate().GoToUrl(Constants.OrageHRMBaseUrl);
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUsername(ExcelUsername);
            loginPage.SetPassword(ExcelPassword);
            loginPage.ClickLogin();
            Assert.That(driver.Url.Contains("dashboard"), $"The text '{"dashboard"}' was not found on the page.");
            Assert.That(driver.Title.Contains(Constants.OrangeHRM_Title));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            driver.Navigate().GoToUrl(Constants.OrageHRMBaseUrl);
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUsername(Constants.Credentials.Username);
            loginPage.SetPassword(Constants.Credentials.InvalidPassword);
            loginPage.ClickLogin();
            bool isMessageVisible =  loginPage.InvalidCredentialDisplayed();
            Assert.That(isMessageVisible, "The 'Invalid credentials' message should be visible.");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
