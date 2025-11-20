using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class LoginTest : BaseTest
    {
        private LoginSteps loginSteps;

        [SetUp]
        public void Setup()
        {
            loginSteps = new LoginSteps(driver,wait);
        }

        [Test]
        [AllureTag("login")]
        [AllureSuite("Login")]
        public void SuccessfulLoginTest()
        {
            var username = "TestUser";
            loginSteps
                .VerifyLoggedInUser(username);
        }


    }
}
