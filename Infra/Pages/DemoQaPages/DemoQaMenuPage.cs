using CSharpAutomationSelenium.Infra.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpAutomationSelenium.Pages.DemoQaPages
{
    public class DemoQaMenuPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _menuItems = By.CssSelector(".card.mt-4.top-card");
        private readonly By _bookStoreCard = By.XPath("//h5[text()='Book Store Application']/ancestor::div[contains(@class, 'top-card')]");

        public DemoQaMenuPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _bot = new ActionBot(driver, wait);
        }

        public void WaitForMenuToLoad()
        {
            _bot.WaitForPresenceOfAllElements(_menuItems);
        }

        public void ClickBookStoreCard()
        {
            _bot.ScrollToElement(_bookStoreCard);
            _bot.JSClick(_bookStoreCard);
        }
    }
}