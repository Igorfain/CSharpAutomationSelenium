using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class DemoQaBookStorePage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _loginLink = By.XPath("//a[contains(text(), 'Login')]");
        private readonly By _bookStoreHeading = By.XPath("//h1[contains(text(), 'Book Store')]");

        public DemoQaBookStorePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _bot = new ActionBot(driver, wait);
        }

        public void WaitForBookStorePageToLoad()
        {
            _bot.WaitForPresenceOfAllElements(_bookStoreHeading);
        }

        public void ClickLoginLink()
        {
            _bot.Click(_loginLink);
        }

        public bool IsBookStorePageLoaded()
        {
            try
            {
                var element = _wait.Until(driver => driver.FindElements(_bookStoreHeading).Count > 0);
                return element;
            }
            catch
            {
                return false;
            }
        }
    }
}
