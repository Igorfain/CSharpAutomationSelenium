using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Infra.Utils;

namespace Infra.Steps
{
    public class LoginSteps
    {
        private readonly LoginPage loginPage;

        public LoginSteps(IWebDriver driver, WebDriverWait wait)
        {
            loginPage = new LoginPage(driver, wait);
        }

        [AllureStep("Verify logged in user is {0}")]
        public LoginSteps VerifyLoggedInUser(string expectedUsername)
        {
            LoggerUtils.LogStep($"Verifying if logged in username is: '{expectedUsername}'");
            string actualUser = loginPage.GetLoggedInUsername();
            Assert.That(actualUser, Is.EqualTo(expectedUsername), "User login mismatch");
            return this;
        }

        [AllureStep("Login with invalid credentials")]
        public LoginSteps LoginWithInvalidCredentials(string email, string password)
        {
            LoggerUtils.LogStep($"Attempting login with invalid credentials. Email: '{email}'");
            loginPage.Login(email, password);

            string errorMessage = loginPage.GetErrorMessage();
            LoggerUtils.LogStep($"Checking server error message. Actual: '{errorMessage}'");

            Assert.That(errorMessage, Is.EqualTo("Your email or password is incorrect!"),
                "Error message mismatch");

            return this;
        }

        [AllureStep("Sign up with name {name} and email {email}")]
        public LoginSteps SignUpExistingEmail(string name, string email)
        {
            LoggerUtils.LogStep($"Signing up with existing email. Name: '{name}', Email: '{email}'");
            loginPage.SignUp(name, email);
            return this;
        }

        [AllureStep("Verify sign up error message")]
        public LoginSteps VerifySignUpErrorMessage(string expectedErrorMessage)
        {
            LoggerUtils.LogStep($"Verifying signup error. Expected: '{expectedErrorMessage}'");
            var actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), "Sign up error message mismatch");
            return this;
        }

        [AllureStep("Perform login action")]
        public LoginSteps ExecuteLogin(string email, string password)
        {
            LoggerUtils.LogStep($"Executing login action only for Email: '{email}'");
            loginPage.Login(email, password);
            return this;
        }

        [AllureStep("Verify browser validation message")]
        public LoginSteps VerifyBrowserEmailValidation(string expectedMessage)
        {
            string actualMessage = loginPage.GetEmailValidationMessage();
            LoggerUtils.LogStep($"Browser Email Validation - Expected: '{expectedMessage}', Actual: '{actualMessage}'");

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Email validation message mismatch");
            return this;
        }

        [AllureStep("Verify browser validation message for password")]
        public LoginSteps VerifyBrowserPasswordValidation(string expectedMessage)
        {
            string actualMessage = loginPage.GetPasswordValidationMessage();
            LoggerUtils.LogStep($"Browser Password Validation - Expected: '{expectedMessage}', Actual: '{actualMessage}'");

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Password validation message mismatch");
            return this;
        }
    }
}