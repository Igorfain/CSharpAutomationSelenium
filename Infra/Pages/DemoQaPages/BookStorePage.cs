using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class BookStorePage
    {
        private readonly ActionBot _bot;

        private readonly By _loginLink = By.XPath("//a[contains(text(), 'Login')]");
        private readonly By _bookStoreHeading = By.XPath("//h1[contains(text(), 'Book Store')]");
        private readonly By _menuItems = By.CssSelector(".card.mt-4.top-card");
        private readonly By _loginMenuItem = By.CssSelector("a[href='/login']");

        public BookStorePage(IWebDriver driver, WebDriverWait wait)
        {
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
                _bot.WaitForPresenceOfAllElements(_bookStoreHeading);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void WaitForMenuToLoad()
        {
            _bot.WaitForPresenceOfAllElements(_menuItems);
        }

        public void ClickLoginButton()
        {
            _bot.ScrollToElement(_loginMenuItem);
            _bot.JSClick(_loginMenuItem);
            _bot.WaitForUrlContains("login");
        }
    }
}
