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

            // Using parameters from TestCase attributes
            loginSteps.LoginWithInvalidCredentials(email, password);
        }
    }

}