using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace automationexerciseTests.Pages
{
    public class SignUpPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SignUpPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement FirstNameField => driver.FindElement(By.Id("first_name"));
        private IWebElement LastNameField => driver.FindElement(By.Id("last_name"));
        private IWebElement AddressField => driver.FindElement(By.Id("address1"));
        private IWebElement StateField => driver.FindElement(By.Id("state"));
        private IWebElement CityField => driver.FindElement(By.Id("city"));
        private IWebElement ZipcodeField => driver.FindElement(By.Id("zipcode"));
        private IWebElement MobileNumberField => driver.FindElement(By.Id("mobile_number"));
        private IWebElement CreateAccountButton => driver.FindElement(By.CssSelector("button[data-qa='create-account']"));

        public void FillRegistrationDetails(string password, string firstName, string lastName, string address, string state, string city, string zipcode, string mobile)
        {
            // Scroll to the top field first
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", PasswordField);

            PasswordField.SendKeys(password);
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            AddressField.SendKeys(address);
            StateField.SendKeys(state);
            CityField.SendKeys(city);
            ZipcodeField.SendKeys(zipcode);
            MobileNumberField.SendKeys(mobile);

            // JavaScript click to bypass any overlapping ads/banners
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", CreateAccountButton);
        }
    }


}