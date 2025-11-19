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
            var loginSteps = new LoginSteps(driver);
            loginSteps.LoginWithInvalidCredentials(config.invalidUsername, config.invalidPassword);
            loginSteps.VerifySignUpErrorMessage("Your email or password is incorrect!");
        }
    }
}
