using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class DemoQaLoginSteps
    {
        private readonly DemoQaLoginPage _loginPage;

        public DemoQaLoginSteps(IWebDriver driver, WebDriverWait wait)
        {
            _loginPage = new DemoQaLoginPage(driver, wait);
        }

        [AllureStep("Perform DemoQa login")]
        public DemoQaLoginSteps PerformLogin(string username, string password)
        {
            LoggerUtils.LogStep($"Filling username field with: {username}");
            _loginPage.FillUsernameField(username);

            LoggerUtils.LogStep($"Filling password field with provided password");
            _loginPage.FillPasswordField(password);

            LoggerUtils.LogStep("Clicking login button");
            _loginPage.ClickLoginButton();

            LoggerUtils.LogStep("DemoQa login completed successfully");
            return this;
        }
    }
}