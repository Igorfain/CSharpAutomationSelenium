using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class DemoQaMenuSteps
    {
        private readonly DemoQaMenuPage _menuPage;

        public DemoQaMenuSteps(IWebDriver driver, WebDriverWait wait)
        {
            _menuPage = new DemoQaMenuPage(driver, wait);
        }

        [AllureStep("Wait for DemoQa menu to load")]
        public DemoQaMenuSteps WaitForMenuLoad()
        {
            LoggerUtils.LogStep("Waiting for DemoQa menu items to load");
            _menuPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("DemoQa menu has loaded successfully");
            return this;
        }

        [AllureStep("Click Book Store card")]
        public DemoQaMenuSteps ClickBookStoreCard()
        {
            LoggerUtils.LogStep("Clicking on Book Store Application card");
            _menuPage.ClickBookStoreCard();
            LoggerUtils.LogStep("Book Store card clicked successfully");
            return this;
        }

        [AllureStep("Verify menu is loaded")]
        public DemoQaMenuSteps VerifyMenuIsLoaded()
        {
            LoggerUtils.LogStep("Verifying that DemoQa menu is loaded");
            _menuPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("Menu verification completed successfully");
            return this;
        }
    }
}