using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Infra.Utils;
using System.Collections.Generic;

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
        public LandingPageSteps VerifyNavigationContainsItems(params string[] expectedItems)
        {
            LoggerUtils.LogStep($"Verifying navigation bar contains {expectedItems.Length} expected items");
            var actualNavigationBarItems = _landingPage.GetNavigationBarItems();

            foreach (var expectedNavigationBarItem in expectedItems)
            {
                bool navigationBarItemFound = false;
                foreach (var actualNavigationBarItem in actualNavigationBarItems)
                {
                    if (actualNavigationBarItem.Contains(expectedNavigationBarItem))
                    {
                        navigationBarItemFound = true;
                        break;
                    }
                }

                Assert.That(navigationBarItemFound, Is.True,
                    $"Navigation bar item containing '{expectedNavigationBarItem}' was not found. Actual navigation bar items: {string.Join(" | ", actualNavigationBarItems)}");
            }

            LoggerUtils.LogStep("Navigation bar verification completed successfully");
            return this;
        }

        public LandingPageSteps VerifyNavigationContainsItems(IEnumerable<string> expectedItems)
        {
            var expectedNavigationBarItemsArray = new List<string>();
            foreach (var expectedNavigationBarItem in expectedItems)
            {
                expectedNavigationBarItemsArray.Add(expectedNavigationBarItem);
            }
            return VerifyNavigationContainsItems(expectedNavigationBarItemsArray.ToArray());
        }
    }
}
