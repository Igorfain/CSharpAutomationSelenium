using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using automationexerciseTests.Infra.Utils;

namespace automationexerciseTests.Pages
{
    public class SignUpPage
    {
        private readonly ActionBot _bot;

        public SignUpPage(IWebDriver driver, WebDriverWait wait)
        {
            _bot = new ActionBot(driver, wait);
        }

        private readonly By _passwordField = By.Id("password");
        private readonly By _firstNameField = By.Id("first_name");
        private readonly By _lastNameField = By.Id("last_name");
        private readonly By _addressField = By.Id("address1");
        private readonly By _stateField = By.Id("state");
        private readonly By _cityField = By.Id("city");
        private readonly By _zipcodeField = By.Id("zipcode");
        private readonly By _mobileNumberField = By.Id("mobile_number");
        private readonly By _createAccountButton = By.CssSelector("button[data-qa='create-account']");

        public void FillRegistrationDetails(string password, string firstName, string lastName, string address, string state, string city, string zipcode, string mobile)
        {
            _bot.ScrollToElement(_passwordField);
            _bot.Type(_passwordField, password);
            _bot.Type(_firstNameField, firstName);
            _bot.Type(_lastNameField, lastName);
            _bot.Type(_addressField, address);
            _bot.Type(_stateField, state);
            _bot.Type(_cityField, city);
            _bot.Type(_zipcodeField, zipcode);
            _bot.Type(_mobileNumberField, mobile);
            _bot.JSClick(_createAccountButton);
        }
    }
}