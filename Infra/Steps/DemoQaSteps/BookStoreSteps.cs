using Allure.NUnit.Attributes;
using CSharpAutomationSelenium.Pages.DemoQaPages;
using Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Steps.DemoQaSteps
{
    public class BookStoreSteps
    {
        private readonly BookStorePage _bookStorePage;
        private readonly DemoQaLandingPage _landingPage;

        public BookStoreSteps(IWebDriver driver, WebDriverWait wait)
        {
            _bookStorePage = new BookStorePage(driver, wait);
            _landingPage = new DemoQaLandingPage(driver, wait);
        }

        [AllureStep("Clicking on Login menu item")]
        public BookStoreSteps PerformLoginMenuItemClick()
        {
            LoggerUtils.LogStep("Clicking on Login menu item");
            _bookStorePage.ClickLoginButton();
            LoggerUtils.LogStep("Login menu item clicked successfully");
            return this;
        }

    }
}