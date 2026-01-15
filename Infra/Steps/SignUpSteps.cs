using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Infra.Steps
{
    public class SignUpSteps
    {
        private readonly SignUpPage signUpPage;

        public SignUpSteps(IWebDriver driver, WebDriverWait wait)
        {
            signUpPage = new SignUpPage(driver, wait);
        }

        [AllureStep("Fill account details and create account")]
        public SignUpSteps CompleteRegistration(string password, string firstName, string lastName, string address, string state, string city, string zipcode, string mobile)
        {
            LoggerUtils.LogStep($"Filling registration details for: {firstName} {lastName}");
            signUpPage.FillRegistrationDetails(password, firstName, lastName, address, state, city, zipcode, mobile);
            return this;
        }
    }
}