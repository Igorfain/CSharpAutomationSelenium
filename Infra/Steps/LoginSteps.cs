using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Infra.Steps
{
    public class LoginSteps
    {
        private readonly LoginPage loginPage;

        public LoginSteps(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
        }

        [AllureStep("Verify logged in user is {0}")]
        public void VerifyLoggedInUser(string expectedUsername)
        {
            Thread.Sleep(2000); // Wait for the page to load and display the username
            string actualUser = loginPage.GetLoggedInUsername();
            Assert.That(actualUser, Is.EqualTo(expectedUsername), "User login mismatch");
        }

        [AllureStep("Login with invalid credentials")]
        public void LoginWithInvalidCredentials(string email, string password)
        {
            loginPage.Login(email, password);
            string errorMessage = loginPage.GetErrorMessage();

            Assert.That(errorMessage, Is.EqualTo("Your email or password is incorrect!"),
                "Error message mismatch");
        }

        [AllureStep("Sign up with name {0} and email {1}")]
        public void SignUpExitingEmail(string name, string email)
        {
            loginPage.SignUp(name, email);

        }

        [AllureStep("Verify sign up error message")]
        public void VerifySignUpErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = loginPage.GetSignUpErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), "Sign up error message mismatch");
        }
    }
}