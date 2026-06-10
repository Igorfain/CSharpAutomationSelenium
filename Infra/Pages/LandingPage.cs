using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using automationexerciseTests.Infra.Utils;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;

namespace automationexerciseTests.Pages
{
    public class LandingPage
    {
        private readonly ActionBot _bot;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _navigationBarItems = By.CssSelector("ul.nav.navbar-nav li");

        public LandingPage(IWebDriver driver, WebDriverWait wait)
        {
            _bot = new ActionBot(driver, wait);
            _driver = driver;
            _wait = wait;
        }

        public List<string> GetNavigationBarItems()
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_navigationBarItems));
            var navigationBarItems = _driver.FindElements(_navigationBarItems);
            var navigationBarItemTexts = new List<string>();

            foreach (var navigationBarElement in navigationBarItems)
            {
                navigationBarItemTexts.Add(navigationBarElement.Text.Trim());
            }

            return navigationBarItemTexts;
        }
    }
}
