using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Steps.DemoQaSteps;
using Infra.Base;

namespace CSharpAutomationSelenium.Tests.DemoQaTests
{
    [TestFixture]
    [AllureTag("DemoQa")]
    [AllureSuite("DemoQa Menu Tests")]
    public class DemoQaGeneralTests : BaseTest
    {
        private BookStoreSteps _bookStoreSteps = null!;
        private BookStoreLoginSteps _loginSteps = null!;
        private DemoQaLandingPageSteps _landingPageSteps = null!;

        protected override bool DoDefaultLogin => false;
        protected override string StartUrl => config.demoqaUrl;

        [SetUp]
        public void TestSetup()
        {
            _bookStoreSteps = new BookStoreSteps(driver, wait);
            _loginSteps = new BookStoreLoginSteps(driver, wait);
            _landingPageSteps = new DemoQaLandingPageSteps(driver, wait);
        }

        [Test]
        [AllureTag("Menu is loaded successfully")]
        [AllureSuite("DemoQaMenuTests")]
        public void VerifyDemoQaMenuLoadsSuccessfullyTest()
        {
            _landingPageSteps.VerifyMenuIsLoaded();
        }

        [Test]
        [AllureTag("Login Book Store application")]
        [AllureSuite("DemoQaMenuTests")]
        public void VerifyDemoQaMenuLoginBookStoreLoadsSuccessfullyTest()
        {
            _landingPageSteps.VerifyMenuIsLoaded()
            .PerformBookStoreAppllicationCardClick();
            _bookStoreSteps.PerformLoginMenuItemClick();
            _loginSteps.VerifyLoginPageIsDisplayed();
        }

        [Test]
        [AllureTag("Get menu cards titles")]
        [AllureSuite("DemoQaMenuTests")]
        public void GetMenuCardsTitlesTest()
        {
            _landingPageSteps.VerifyMenuIsLoaded()
            .GetMenuCardsTitles()
            .VerifyMenuCardsTitlesAreCorrect();
        }

    }
}
