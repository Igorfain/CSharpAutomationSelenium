using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps.automationexerciseSteps;
using NUnit.Framework;

namespace CSharpAutomationSelenium.Tests.Tests.UITests.automationexerciseTests
{
    [AllureSuite("API Login")]
    public class ApiLoginTest : BaseTest
    {
        private LoginSteps _loginSteps = null!;

        // Skip browser UI login — session cookies are injected via HTTP instead
        protected override bool DoDefaultLogin => false;
        protected override bool DoApiLogin => true;
        //protected override bool DoRemoteGrid => true;

        [SetUp]
        public void Setup()
        {
            _loginSteps = new LoginSteps(driver, wait);
        }

        [Test]
        [AllureTag("api-login")]
        [AllureSuite("API Login")]
        public void ApiLoginAndVerifyLandingPageTest()
        {
            var expectedUsername = "TestUser";
            _loginSteps
                .VerifyLoggedInUser(expectedUsername);
        }
    }
}
