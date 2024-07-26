// Path: SeleniumProject/Drivers/WebDriverSingleton.cs

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumProject
{
    public class WebDriverSingleton
    {
        private static IWebDriver driver;

        // Private constructor to prevent instantiation
        private WebDriverSingleton() { }

        // Public method to get the instance of WebDriver
        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return driver;
        }

        // Method to quit the WebDriver instance
        public static void QuitWebDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
