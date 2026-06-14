using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Infra.Utils;


namespace Infra.Steps
{
    public class LandingPageSteps
    {
        private readonly LandingPage _landingPage;

        public LandingPageSteps(IWebDriver driver, WebDriverWait wait)
        {
            _landingPage = new LandingPage(driver, wait);
        }

        [AllureStep("Verify navigation bar contains items")]
        public LandingPageSteps VerifyNavigationContainsItems(List<string> expectedItems)
        {
            LoggerUtils.LogStep($"Verifying navigation bar contains {expectedItems.Count} expected items");

            var actualNavigationBarItems = _landingPage.GetNavigationBarItems();

            foreach (var expectedItem in expectedItems)
            {
                bool navigationBarItemFound = false;
                foreach (var actualItem in actualNavigationBarItems)
                {
                    if (actualItem.Contains(expectedItem))
                    {
                        navigationBarItemFound = true;
                        break;
                    }
                }

                Assert.That(navigationBarItemFound, Is.True,
                    $"Navigation bar item containing '{expectedItem}' was not found. Actual navigation bar items: {string.Join(" | ", actualNavigationBarItems)}");
            }

            return this;
        }

        [AllureStep("Verify brands bar contains items")]
        public LandingPageSteps VerifyBrandsBarContainsItems(List<string> expectedItems)
        {
            LoggerUtils.LogStep($"Verifying brands bar contains {expectedItems.Count} expected items");

            var actualBrandsBarItems = _landingPage.GetBrandsBarItems();

            foreach (var expectedItem in expectedItems)
            {
                bool brandsBarItemFound = false;
                foreach (var actualItem in actualBrandsBarItems)
                {
                    if (actualItem.Contains(expectedItem))
                    {
                        brandsBarItemFound = true;
                        break;
                    }
                }

                Assert.That(brandsBarItemFound, Is.True,
                    $"Brands bar item containing '{expectedItem}' was not found. Actual brands bar items: {string.Join(" | ", actualBrandsBarItems)}");
            }

            return this;
        }
    }
}
