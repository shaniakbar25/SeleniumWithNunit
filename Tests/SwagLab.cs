using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumProject
{
    [TestFixture]
    public class SwagLab
    {
        private IWebDriver driver;
        public static IEnumerable<object[]> TestData => ExcelReader.ReadExcel(Constants.SwagLabExcelPath);

        [SetUp]
        public void Setup()
        {
            driver = WebDriverSingleton.GetWebDriver();
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void LoginWithExcelSheetTestData(string ExcelUsername, string ExcelPassword)
        {
            driver.Navigate().GoToUrl(Constants.SwagLabBaseUrl);
            driver.Manage().Window.Maximize();
            SwagLabLoginPage loginPage = new SwagLabLoginPage(driver);
            loginPage.SetUsername(ExcelUsername);
            loginPage.SetPassword(ExcelPassword);
            loginPage.ClickLogin();

            try
            {
                
                Assert.That(loginPage.InventoryContainerDisplayed);
            }
            catch (NoSuchElementException)
            {
                Assert.That(loginPage.ErrorMessageDisplayed);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
