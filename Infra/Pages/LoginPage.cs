using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using automationexerciseTests.Infra.Utils;

namespace automationexerciseTests.Pages
{
    public class LoginPage
    {
        private readonly ActionBot _bot;

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _bot = new ActionBot(driver, wait);
        }

        private readonly By _emailInput = By.CssSelector("[data-qa='login-email']");
        private readonly By _passwordInput = By.CssSelector("[data-qa='login-password']");
        private readonly By _loginButton = By.CssSelector("[data-qa='login-button']");
        private readonly By _loggedInUsername = By.CssSelector("li a b");
        private readonly By _errorMessage = By.CssSelector("p[style*='color: red']");
        private readonly By _signUpNameField = By.CssSelector("[data-qa='signup-name']");
        private readonly By _signUpEmailField = By.CssSelector("[data-qa='signup-email']");
        private readonly By _signUpButton = By.CssSelector("[data-qa='signup-button']");

        public void NavigateToHome(string baseUrl)
        {
            _bot.Navigate(baseUrl);
        }

        public void Login(string email, string password)
        {
            _bot.Type(_emailInput, email);
            _bot.Type(_passwordInput, password);
            _bot.Click(_loginButton);
        }

        public string GetLoggedInUsername()
        {
            return _bot.GetText(_loggedInUsername);
        }

        public string GetErrorMessage()
        {
            return _bot.GetText(_errorMessage);
        }

        public void SignUp(string name, string email)
        {
            _bot.Type(_signUpNameField, name);
            _bot.Type(_signUpEmailField, email);
            _bot.Click(_signUpButton);
        }

        public string GetSignUpErrorMessage()
        {
            return _bot.GetText(_errorMessage);
        }

        public string GetEmailValidationMessage()
        {
            return _bot.GetAttribute(_emailInput, "validationMessage");
        }

        public string GetPasswordValidationMessage()
        {
            return _bot.GetAttribute(_passwordInput, "validationMessage");
        }
    }
}