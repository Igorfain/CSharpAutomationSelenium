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
        public SignUpSteps CompleteRegistration(string password, dynamic data)
        {
            LoggerUtils.LogStep($"Filling registration for: {data.FirstName}{data.LastName}");

            signUpPage.FillRegistrationDetails(
                password,
                data.FirstName,
                data.LastName,
                data.Address,
                data.State,
                data.City,
                data.Zip,
                data.Mobile
            );
            return this;
        }
    }
}