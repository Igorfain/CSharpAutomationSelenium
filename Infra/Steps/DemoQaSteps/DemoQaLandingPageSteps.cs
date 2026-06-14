using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Steps;
using Infra.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class DemoQaLandingPageSteps
    {

        private readonly DemoQaLandingPage _landingPage;

        public DemoQaLandingPageSteps(IWebDriver driver, WebDriverWait wait)
        {
            _landingPage = new DemoQaLandingPage(driver, wait);
        }

        [AllureStep("Perform DemoQa menu load")]
        public DemoQaLandingPageSteps PerformMenuLoad()
        {
            LoggerUtils.LogStep("Loading DemoQa menu items");
            _landingPage.WaitForMenuToLoad();
            return this;
        }

        [AllureStep("Perform Book Store card click")]
        public DemoQaLandingPageSteps PerformBookStoreAppllicationCardClick()
        {
            LoggerUtils.LogStep("Clicking on Book Store Application card");
            _landingPage.ClickBookStoreApplicationButton();
            return this;
        }

        [AllureStep("Verify menu is loaded")]
        public DemoQaLandingPageSteps VerifyMenuIsLoaded()
        {
            LoggerUtils.LogStep("Verifying DemoQa menu is loaded");
            _landingPage.WaitForMenuToLoad();
            return this;
        }


        [AllureStep("Get menu cards titles")]
        public DemoQaLandingPageSteps GetMenuCardsTitles()
        {
            LoggerUtils.LogStep($"Getting menu card titles: {string.Join(", ", _landingPage.GetMenuCardTitles())}");
            var menuCardTitles = _landingPage.GetMenuCardTitles();
            return this;

        }

        [AllureStep("Verify menu cards titles are correct")]
        public DemoQaLandingPageSteps VerifyMenuCardsTitlesAreCorrect()
        {
            LoggerUtils.LogStep("Verifying menu card titles match expected values");
            var menuCardTitles = _landingPage.GetMenuCardTitles();
            Assert.That(menuCardTitles, Is.EquivalentTo(demoQaDataLists.MenuCardTitlesReferenceList()));
            return this;
        }
    }
}
