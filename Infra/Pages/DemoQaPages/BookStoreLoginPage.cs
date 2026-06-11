using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class BookStoreLoginPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _userForm = By.Id("userForm");
        private readonly By _usernameField = By.Id("userName");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login");
        private readonly By _newUserButton = By.Id("newUser");
        private readonly By _loginMenuItem = By.CssSelector(".left-pannel #item-0");

        public BookStoreLoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _bot = new ActionBot(driver, wait);
        }

        public bool IsLoginPageDisplayed()
        {
            return _bot.IsElementDisplayed(_userForm);
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

        public void ClickNewUserButton()
        {
            _bot.Click(_newUserButton);
        }

        public void ClickLoginMenuItem()
        {
            _bot.Click(_loginMenuItem);
            _bot.WaitForUrlContains("login");
        }
    }
}