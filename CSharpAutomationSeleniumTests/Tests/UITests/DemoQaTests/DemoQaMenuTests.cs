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
        private DemoQaMenuSteps _menuSteps = null!;

        protected override bool DoDefaultLogin => false;

        protected override string StartUrl => config.demoqaUrl;

        [SetUp]
        public void TestSetup()
        {
            _menuSteps = new DemoQaMenuSteps(driver, wait);
        }

        [Test]
        [AllureTag("Menu")]
        public void VerifyDemoQaMenuLoadsSuccessfullyTest()
        {
            _menuSteps.VerifyMenuIsLoaded();
        }
    }
}