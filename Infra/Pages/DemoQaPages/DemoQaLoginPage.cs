using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class DemoQaLoginPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _usernameField = By.Id("userName");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login");

        public DemoQaLoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _bot = new ActionBot(driver, wait);
        }

        public void FillUsernameField(string username)
        {
            _bot.Type(_usernameField, username);
        }

        public void FillPasswordField(string password)
        {
            _bot.Type(_passwordField, password);
        }

        public void ClickLoginButton()
        {
            _bot.Click(_loginButton);
        }
    }
}