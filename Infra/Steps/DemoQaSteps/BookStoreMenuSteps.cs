using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class BookStoreMenuSteps
    {
        private readonly BookStoreMenuPage _menuPage;

        public BookStoreMenuSteps(IWebDriver driver, WebDriverWait wait)
        {
            _menuPage = new BookStoreMenuPage(driver, wait);
        }

        [AllureStep("Perform DemoQa menu load")]
        public BookStoreMenuSteps PerformMenuLoad()
        {
            LoggerUtils.LogStep("Waiting for DemoQa menu items to load");
            _menuPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("DemoQa menu has loaded successfully");
            return this;
        }

        [AllureStep("Perform Book Store card click")]
        public BookStoreMenuSteps PerformBookStoreCardClick()
        {
            LoggerUtils.LogStep("Clicking on Book Store Application card");
            _menuPage.ClickBookStoreApplicationButton();
            LoggerUtils.LogStep("Book Store card clicked successfully");
            return this;
        }

        [AllureStep("Verify menu is loaded")]
        public BookStoreMenuSteps VerifyMenuIsLoaded()
        {
            LoggerUtils.LogStep("Verifying that DemoQa menu is loaded");
            _menuPage.WaitForMenuToLoad();
            LoggerUtils.LogStep("Menu verification completed successfully");
            return this;
        }

        [AllureStep("Clicking on Login menu item")]
        public BookStoreMenuSteps PerformLoginMenuItemClick()
        {
            LoggerUtils.LogStep("Clicking on Login menu item");
            _menuPage.ClickLoginButton();
            LoggerUtils.LogStep("Login menu item clicked successfully");
            return this;
        }

    }
}