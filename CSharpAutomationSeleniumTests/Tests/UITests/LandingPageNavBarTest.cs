using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps;
using Infra.Utils;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class LandingPageNavBarTest : BaseTest
    {
        protected override bool DoDefaultLogin => false;

        private LandingPageSteps _landingPageSteps = null!;

        [SetUp]
        public void Setup()
        {
            _landingPageSteps = new LandingPageSteps(driver, wait);
        }

        [Test]  
        [AllureTag("navigation")]
        [AllureSuite("Navigation")]
        public void NavigationBarItemsExistTest()
        {
            var expectedItems = LandingPageNavigationData.GetLandingPageNavItems();
            _landingPageSteps.VerifyNavigationContainsItems(expectedItems);
        }
    }
}
