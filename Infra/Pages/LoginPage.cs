using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace automationexerciseTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        private IWebElement EmailInput => driver.FindElement(By.CssSelector("[data-qa='login-email']"));
        private IWebElement PasswordInput => driver.FindElement(By.CssSelector("[data-qa='login-password']"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("[data-qa='login-button']"));
        private IWebElement LoggedInUsername => driver.FindElement(By.CssSelector("li a b"));
        private By ErrorMessageBy => By.CssSelector("p[style*='color: red']");
        private By SignupErrorMessageBy => By.CssSelector("p[style*='color: red']");
        private IWebElement SignUpNameField => driver.FindElement(By.CssSelector("[data-qa='signup-name']"));
        private IWebElement SignUpEmailField => driver.FindElement(By.CssSelector("[data-qa='signup-email']"));
        private IWebElement SignUpButton => driver.FindElement(By.CssSelector("[data-qa='signup-button']"));
        private By LoggedInUsernameBy => By.CssSelector("li a b");


        public void NavigateToHome(string baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }

        public string GetLoggedInUsername()
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(LoggedInUsernameBy));
            return element.Text;
        }

        public string GetErrorMessage()
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessageBy));
            return element.Text;
        }

        public void SignUp(string name, string email)
        {
            SignUpNameField.SendKeys(name);
            SignUpEmailField.SendKeys(email);
            SignUpButton.Click();
        }

        public string GetSignUpErrorMessage()
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(SignupErrorMessageBy));
            return element.Text;
        }
    }
}
