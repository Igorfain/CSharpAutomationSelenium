using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace automationexerciseTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement EmailInput => driver.FindElement(By.CssSelector("[data-qa='login-email']"));
        private IWebElement PasswordInput => driver.FindElement(By.CssSelector("[data-qa='login-password']"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("[data-qa='login-button']"));
        private IWebElement LoggedInUsername => driver.FindElement(By.CssSelector("li a b"));
        private By ErrorMessageBy => By.CssSelector("p[style*='color: red']");
        private IWebElement SignUpNameField => driver.FindElement(By.CssSelector("[data-qa='signup-name']"));
        private IWebElement SignUpEmailField => driver.FindElement(By.CssSelector("[data-qa='signup-email']"));
        private IWebElement SignUpButton => driver.FindElement(By.CssSelector("[data-qa='signup-button']"));
        private By SignupErrorMessageBy => By.CssSelector("p[style*='color: red']");
        private IWebElement SignupErrorMessage => driver.FindElement(SignupErrorMessageBy);

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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return (LoggedInUsername).Text;
        }

        public string GetErrorMessage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(SignupErrorMessageBy));
            return SignupErrorMessage.Text;
        }

    }
}
