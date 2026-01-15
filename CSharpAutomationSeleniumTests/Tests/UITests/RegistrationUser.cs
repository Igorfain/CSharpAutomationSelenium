using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps;
using Infra.Utils;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class RegistrationUser : BaseTest
    {
        private LoginSteps loginSteps;
        protected override bool DoDefaultLogin => false;

        [SetUp]
        public void Setup()
        {
            loginSteps = new LoginSteps(driver,wait);
        }

        [Test]
        [AllureTag("registration")]
        public void RegisterNewUserFullFlowTest()
        {
            string name = DataGeneratorUtils.GenerateRandomName();
            string email = DataGeneratorUtils.GenerateRandomEmail();
            string password = DataGeneratorUtils.GenerateRandomPassword();

            var signUpSteps = new SignUpSteps(driver, wait);

            loginSteps.SignUpExistingEmail(name, email);
            RemoveAds();

            signUpSteps.CompleteRegistration(
                password,
                "FirstName",
                "LastName",
                "Street 123",
                "California",
                "Los Angeles",
                "90210",
                "5550123"
            );

            Assert.That(driver.Url, Does.Contain("account_created"),
                "User was not redirected to Account Created page after registration.");
        }
    }
}
