using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps;
using Infra.TestData;
using Infra.Utils;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class RegistrationUserTest : BaseTest
    {
        private LoginSteps _loginSteps;
        protected override bool DoDefaultLogin => false;

        [SetUp]
        public void Setup()
        {
            _loginSteps = new LoginSteps(driver,wait);
        }

        [Test]
        [AllureTag("registration")]
        public void RegisterNewUserFullFlowTest()
        {
            string name = DataGeneratorUtils.GenerateRandomName();
            string email = DataGeneratorUtils.GenerateRandomEmail();
            string password = DataGeneratorUtils.GenerateRandomPassword();

            var signUpSteps = new SignUpSteps(driver, wait);

            _loginSteps.SignUpExistingEmail(name, email);
            RemoveAds();

            signUpSteps.CompleteRegistration(password, RegistrationData.GetDefaultUser());

            Assert.That(driver.Url, Does.Contain("account_created"),
                "User was not redirected to Account Created page after registration.");
        }
    }
}
