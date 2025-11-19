using Allure.NUnit.Attributes;
using Infra.Steps;
using Infra.Base;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class RegistrationUser : BaseTest
    {
        private LoginSteps loginSteps;
        protected override bool DoDefaultLogin => false;

        [SetUp]
        public void Setup()
        {
            loginSteps = new LoginSteps(driver);
        }

        [Test]
        [AllureTag("login")]
        public void SignUpWithWrongCredentials()
        {
            string username = "TestUser";
            string email = "igiayehu@gmail.com";
            loginSteps.SignUpExitingEmail(username,email);
            
        }
    }
}
