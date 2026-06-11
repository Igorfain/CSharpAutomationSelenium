using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class BookStoreMenuPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _menuItems = By.CssSelector(".card.mt-4.top-card");
        private readonly By _menuCardTitles = By.CssSelector(".card.mt-4.top-card h5");
        private readonly By _bookStoreApplicationCard = By.CssSelector("a[href='/books']");
        private readonly By _loginMenuItem = By.CssSelector("a[href='/login']");

        public BookStoreMenuPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _bot = new ActionBot(driver, wait);
        }

        public void WaitForMenuToLoad()
        {
            _bot.WaitForPresenceOfAllElements(_menuItems);
        }

        public List<string> GetMenuCardTitles()
        {
            var menuCardTitleElements = _bot.FindElements(_menuCardTitles);
            var menuCardTitles = new List<string>();

            foreach (var menuCardTitleElement in menuCardTitleElements)
            {
                menuCardTitles.Add(menuCardTitleElement.Text.Trim());
            }

            return menuCardTitles;
        }

        public void ClickBookStoreApplicationButton()
        {
            _bot.ScrollToElement(_bookStoreApplicationCard);
            _bot.JSClick(_bookStoreApplicationCard);
            _bot.WaitForUrlContains("books");
        }

        public void ClickLoginButton()
        {
            _bot.ScrollToElement(_loginMenuItem);
            _bot.JSClick(_loginMenuItem);
            _bot.WaitForUrlContains("login");
        }
    }
}
