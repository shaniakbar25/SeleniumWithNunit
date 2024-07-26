******Selenium WebDriver with C# - Project******
This project demonstrates the use of Selenium WebDriver with C# for automated browser testing. It incorporates several best practices and design patterns to ensure clean, maintainable, and scalable test code.

****Key Features****
**1. Selenium WebDriver with C#**

- Utilize Selenium WebDriver to interact with web browsers for automated testing.

**2. Singleton Design Pattern**

- Implement a Singleton pattern to initialize and manage a single instance of the WebDriver, ensuring efficient resource utilization and consistent browser interactions.
  
**3. Page Object Model (POM)**

- Apply the Page Object Model design pattern to separate page-specific logic and element locators from test logic, promoting reusability and maintainability.

**4. NUnit Framework**

- Use NUnit for test execution and reporting, providing a structured approach to writing and running tests.
  
**Project Structure**
- Drivers: Contains the WebDriverSingleton.cs file for managing the WebDriver instance.
- Pages: Includes page object classes that encapsulate interactions with specific web pages.
- Tests: Contains test classes implementing test scenarios using NUnit.
- Utilities: Includes helper classes and constants used throughout the project.

**Getting Started**

**1. Clone the Repository**

git clone <repository-url>

**2. Install Dependencies**

- Open the solution in Visual Studio.
- Restore NuGet packages.

**3. Run Tests**

- Use Test Explorer in Visual Studio to run the tests and view results.
  
**Configuration**
- WebDriver Initialization: Configured using the Singleton pattern to ensure only one instance of the WebDriver is created.
- Page Objects: Implemented for each page to streamline interactions and maintain clean test code.
