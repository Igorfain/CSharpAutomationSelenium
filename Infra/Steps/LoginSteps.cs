using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            string actualUser = loginPage.GetLoggedInUsername();
            Assert.That(actualUser, Is.EqualTo(expectedUsername), "User login mismatch");
            return this;
        }

        [AllureStep("Login with invalid credentials")]
        public LoginSteps LoginWithInvalidCredentials(string email, string password)
        {
            loginPage.Login(email, password);
            string errorMessage = loginPage.GetErrorMessage();

            Assert.That(errorMessage, Is.EqualTo("Your email or password is incorrect!"),
                "Error message mismatch");

            return this;
        }

        [AllureStep("Sign up with name {name} and email {email}")]
        public LoginSteps SignUpExitingEmail(string name, string email)
        {
            loginPage.SignUp(name, email);
            return this;
        }

        [AllureStep("Verify sign up error message")]
        public LoginSteps VerifySignUpErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), "Sign up error message mismatch");
            return this;
        }
    }
}
