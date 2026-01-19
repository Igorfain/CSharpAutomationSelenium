using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace automationexerciseTests.Infra.Utils
{
    public class ActionBot
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ActionBot(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        /// <summary>
        /// Navigates the browser to the specified URL.
        /// </summary>
        /// <param name="url">The full URL of the page to load.</param>
        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Waits until the element is clickable and then performs a click.
        /// </summary>
        /// <param name="locator">The locator for the element to click.</param>
        public void Click(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        /// <summary>
        /// Waits for the element to be visible, clears its content, and types the specified text.
        /// </summary>
        /// <param name="locator">The locator for the target input field.</param>
        /// <param name="text">The text string to enter.</param>
        public void Type(By locator, string text)
        {
            var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Waits for the element to be visible and retrieves its text.
        /// </summary>
        /// <param name="locator">The locator for the element.</param>
        /// <returns>The inner text of the element.</returns>
        public string GetText(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
        }

        /// <summary>
        /// Waits for the element to exist and retrieves a specific attribute value.
        /// </summary>
        /// <param name="locator">The locator for the element.</param>
        /// <param name="attributeName">The name of the attribute (e.g., "value", "class").</param>
        /// <returns>The value of the attribute.</returns>
        public string GetAttribute(By locator, string attributeName)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator)).GetAttribute(attributeName)!;
        }

        /// <summary>
        /// Scrolls the specified element into view using JavaScript.
        /// </summary>
        /// <param name="locator">The locator for the element to scroll to.</param>
        public void ScrollToElement(By locator)
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(locator));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Performs a click using JavaScript to bypass potential UI overlays or ads.
        /// </summary>
        /// <param name="locator">The locator for the element to click.</param>
        public void JSClick(By locator)
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(locator));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}