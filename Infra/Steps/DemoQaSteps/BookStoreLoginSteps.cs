using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class BookStoreLoginSteps
    {
        private readonly BookStoreLoginPage _loginPage;

        public BookStoreLoginSteps(IWebDriver driver, WebDriverWait wait)
        {
            _loginPage = new BookStoreLoginPage(driver, wait);
        }

        [AllureStep("Verify DemoQa login page is displayed")]
        public BookStoreLoginSteps VerifyLoginPageIsDisplayed()
        {
            LoggerUtils.LogStep("Verifying DemoQa login page is displayed");
            Assert.That(_loginPage.IsLoginPageDisplayed(), Is.True, "DemoQa login page should be displayed");
            LoggerUtils.LogStep("DemoQa login page is displayed successfully");
            return this;
        }

        [AllureStep("Perform DemoQa login with credentials")]
        public BookStoreLoginSteps PerformLogin(string username, string password)
        {
            LoggerUtils.LogStep($"Filling username field with: {username}");
            _loginPage.FillUsernameField(username);

            LoggerUtils.LogStep("Filling password field with provided password");
            _loginPage.FillPasswordField(password);

            LoggerUtils.LogStep("Clicking login button");
            _loginPage.ClickLoginButton();

            LoggerUtils.LogStep("DemoQa login completed successfully");
            return this;
        }

        [AllureStep("Click New User button")]
        public BookStoreLoginSteps ClickNewUserButton()
        {
            LoggerUtils.LogStep("Clicking New User button");
            _loginPage.ClickNewUserButton();
            LoggerUtils.LogStep("New User button clicked successfully");
            return this;
        }

      
    }
}