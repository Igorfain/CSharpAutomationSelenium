using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CSharpAutomationSelenium.Infra.Utils;

namespace CSharpAutomationSelenium.Pages
{
    public class LandingPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _navigationBarItems = By.CssSelector("ul.nav.navbar-nav li");
        private readonly By _brandsBarItems = By.CssSelector(".brands-name .nav.nav-pills.nav-stacked li");

        public LandingPage(IWebDriver driver, WebDriverWait wait)
        {
            _bot = new ActionBot(driver, wait);
            _driver = driver;
            _wait = wait;
        }

        public List<string> GetNavigationBarItems()
        {
            _bot.WaitForPresenceOfAllElements(_navigationBarItems);
            var navigationBarItems = _driver.FindElements(_navigationBarItems);
            var navigationBarItemTexts = new List<string>();

            foreach (var navigationBarElement in navigationBarItems)
            {
                navigationBarItemTexts.Add(navigationBarElement.Text.Trim());
            }

            return navigationBarItemTexts;
        }

        public List<string> GetBrandsBarItems()
        {
            _bot.WaitForPresenceOfAllElements(_brandsBarItems);
            var brandsBarItems = _driver.FindElements(_brandsBarItems);
            var brandsBarItemTexts = new List<string>();
            foreach (var brandsBarElement in brandsBarItems)
            {
                brandsBarItemTexts.Add(brandsBarElement.Text.Trim());
            }
            return brandsBarItemTexts;

        }
    }
}
