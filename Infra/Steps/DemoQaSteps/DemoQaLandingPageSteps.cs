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
            LoggerUtils.LogStep("Waiting for DemoQa menu items to load");
            _landingPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("DemoQa menu has loaded successfully");
            return this;
        }

        [AllureStep("Perform Book Store card click")]
        public DemoQaLandingPageSteps PerformBookStoreAppllicationCardClick()
        {
            LoggerUtils.LogStep("Clicking on Book Store Application card");
            _landingPage.ClickBookStoreApplicationButton();
            LoggerUtils.LogStep("Book Store card clicked successfully");
            return this;
        }

        [AllureStep("Verify menu is loaded")]
        public DemoQaLandingPageSteps VerifyMenuIsLoaded()
        {
            LoggerUtils.LogStep("Verifying that DemoQa menu is loaded");
            _landingPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("Menu verification completed successfully");
            return this;
        }


        [AllureStep("Get menu cards titles")]
        public DemoQaLandingPageSteps GetMenuCardsTitles()
        {
            LoggerUtils.LogStep("Getting menu card titles");
            var menuCardTitles = _landingPage.GetMenuCardTitles();
            LoggerUtils.LogStep($"Menu card titles: {string.Join(", ", menuCardTitles)}");
            return this;

        }

        [AllureStep("Verify menu cards titles are correct")]
        public DemoQaLandingPageSteps VerifyMenuCardsTitlesAreCorrect()
        {
            LoggerUtils.LogStep("Verifying that menu card titles are correct");
            var menuCardTitles = _landingPage.GetMenuCardTitles();
            Assert.That(menuCardTitles, Is.EquivalentTo(demoQaDataLists.MenuCardTitlesReferenceList()));
            LoggerUtils.LogStep("Menu card titles verification completed successfully");
            return this;
        }
    }
}
