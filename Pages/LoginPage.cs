using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    public class LoginPage
    {
        private IWebDriver driver;

        // Define locators
        private By usernameField = By.XPath("//input[@name='username']");
        private By passwordField = By.XPath("//input[@name='password']");
        private By loginButton = By.XPath("//button[@type='submit']");
        private By InvalidCredential = By.XPath("//div[@role='alert']//p[text()='Invalid credentials']");
        

        // Constructor
        public LoginPage(IWebDriver driver)
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

        public bool InvalidCredentialDisplayed()
        {
            return driver.FindElement(InvalidCredential).Displayed;
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }
    }
}
