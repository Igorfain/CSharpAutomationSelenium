using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Steps.DemoQaSteps;
using Infra.Base;
using NUnit.Framework;

namespace CSharpAutomationSelenium.Tests.DemoQaTests
{
    [TestFixture]
    [AllureTag("DemoQa")]
    [AllureSuite("DemoQa Menu Tests")]
    public class DemoQaMenuTests : BaseTest
    {
        private BookStoreMenuSteps _menuSteps = null!;
        private BookStoreLoginSteps _loginSteps = null!;

        protected override bool DoDefaultLogin => false;

        protected override string StartUrl => config.demoqaUrl;

        [SetUp]
        public void TestSetup()
        {
            _menuSteps = new BookStoreMenuSteps(driver, wait);
            _loginSteps = new BookStoreLoginSteps(driver, wait);
        }

        [Test]
        [AllureTag("Menu is loaded successfully")]
        public void VerifyDemoQaMenuLoadsSuccessfullyTest()
        {
            _menuSteps.VerifyMenuIsLoaded();
        }

        [Test]
        [AllureTag("Login Book Store application")]
        public void VerifyDemoQaMenuLoginBookStoreLoadsSuccessfullyTest()
        {
            _menuSteps.VerifyMenuIsLoaded()
            .PerformBookStoreCardClick()
            .PerformLoginMenuItemClick(); 
            _loginSteps.VerifyLoginPageIsDisplayed();
        }
    }
}