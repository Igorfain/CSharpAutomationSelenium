using Infra.Steps;
using Allure.NUnit.Attributes;
using Infra.Base;

namespace CSharpAutomationSelenium.Tests.UITests
{
    [AllureSuite("Login")]
    public class NegativeLoginTest : BaseTest
    {
        protected override bool DoDefaultLogin => false;

        [Test]
        [AllureTag("login")]
        public void LoginWithWrongCredentials()
        {
            var loginSteps = new LoginSteps(driver, wait);
            loginSteps.LoginWithInvalidCredentials(invalidUsername, invalidPassword)
                      .VerifySignUpErrorMessage("Your email or password is incorrect!");
        }

        [Test]
        [AllureTag("login")]
        [TestCase("invalidUser@email.com", "invalidPass")]
        [TestCase("wrong@test.com", "12345")]
        public void LoginWithWrongCredentialsParametrized(string email, string password)
        {
            var loginSteps = new LoginSteps(driver, wait);
            loginSteps.LoginWithInvalidCredentials(email, password);
        }

        [Test]
        [AllureTag("login")]
        [TestCase("", "password123", "Please fill out this field.")]
        public void LoginWithEmptyEmailTest(string email, string password, string expectedMessage)
        {
            var loginSteps = new LoginSteps(driver, wait);

            loginSteps
                .ExecuteLogin(email, password)
                .VerifyBrowserEmailValidation(expectedMessage);
        }

        [Test]
        [AllureTag("login")]
        [TestCase("valid-user@email.com", "", "Please fill out this field.")]
        public void LoginWithEmptyPasswordTest(string email, string password, string expectedMessage)
        {
            var loginSteps = new LoginSteps(driver, wait);

            loginSteps
                .ExecuteLogin(email, password)
                .VerifyBrowserPasswordValidation(expectedMessage);
        }
    }

}