using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps;
using Infra.Utils;

namespace CSharpAutomationSelenium.Tests.UITests
{
    public class LandingPageNavBarTest : BaseTest
    {

        private LandingPageSteps _landingPageSteps = null!;

        [SetUp]
        public void Setup()
        {
            _landingPageSteps = new LandingPageSteps(driver, wait);
        }

        [Test]
        [AllureTag("navigation")]
        [AllureSuite("LandingPage")]
        public void NavigationBarItemsExistTest()
        {
            var expectedItems = LandingPageItemsListData.NavTopBarItemsReferenceList();
            _landingPageSteps.VerifyNavigationContainsItems(expectedItems);
        }

        [Test]
        [AllureTag("category")]
        [AllureSuite("LandingPage")]
        public void BrandsBarItemsExistTest()
        {
            var expectedItems = LandingPageItemsListData.BrandsBarItemsReferenceList();
            _landingPageSteps.VerifyBrandsBarContainsItems(expectedItems);

        }
    }
}
