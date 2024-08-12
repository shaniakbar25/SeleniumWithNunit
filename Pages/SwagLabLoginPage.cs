using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    public class SwagLabLoginPage
    {
        private IWebDriver driver;

        // Define locators
        private By usernameField = By.Id("user-name");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By InventoryContainer = By.Id("inventory_container");
        private By ErrorOnLogin = By.CssSelector("[data-test='error']");

        // Constructor
        public SwagLabLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Page actions
        public void SetUsername(string username)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void SetPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public bool InventoryContainerDisplayed()
        {
            return driver.FindElement(InventoryContainer).Displayed;
        }

        public bool ErrorMessageDisplayed()
        {
            return driver.FindElement(ErrorOnLogin).Displayed;
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }
    }
}
