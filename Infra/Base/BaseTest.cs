using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using automationexerciseTests.Pages;
using DotNetEnv;
using Infra.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]

namespace Infra.Base
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("UI Tests")]
    public class BaseTest
    {
        protected IWebDriver driver = null!;
        protected WebDriverWait wait = null!;
        protected string baseUrl = string.Empty;
        protected MainConfig config = null!;
        protected string username = string.Empty;
        protected string password = string.Empty;
        protected string invalidUsername = string.Empty;
        protected string invalidPassword = string.Empty;

        protected virtual bool DoDefaultLogin => true;

        [SetUp]
        public void SetUp()
        {
            var json = File.ReadAllText("Config/MainConfig.json");
            config = JsonConvert.DeserializeObject<MainConfig>(json)
                     ?? throw new InvalidOperationException("Failed to deserialize MainConfig.json");

            var options = new ChromeOptions();
            if (config.chromeArguments != null)
            {
                foreach (var argument in config.chromeArguments)
                {
                    options.AddArgument(argument);
                }
            }

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalChromeOption("useAutomationExtension", false);

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Env.TraversePath().Load();
            baseUrl = config.url ?? string.Empty;
            username = Environment.GetEnvironmentVariable("LOGIN_USERNAME") ?? string.Empty;
            password = Environment.GetEnvironmentVariable("LOGIN_PASSWORD") ?? string.Empty;
            invalidUsername = Environment.GetEnvironmentVariable("INVALID_USERNAME") ?? string.Empty;
            invalidPassword = Environment.GetEnvironmentVariable("INVALID_PASSWORD") ?? string.Empty;

            var loginPage = new LoginPage(driver, wait);
            loginPage.NavigateToHome(baseUrl);
            RemoveAds();

            if (DoDefaultLogin)
            {
                loginPage.Login(username, password);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && driver != null)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var bytes = screenshot.AsByteArray;

                AllureApi.AddAttachment(
                    "Screenshot",
                    "image/png",
                    bytes
                );
            }

            driver?.Quit();
            driver?.Dispose();
        }

        // Method to nuking ads from the DOM
        public void RemoveAds()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string script = @"
            const selectors = [
                'iframe[id^=""aswift""]', 
                'iframe[name^=""aswift""]', 
                'ins.adsbygoogle', 
                '#google_esf', 
                '.google-anno-placement',
                '#ad_iframe',
                'div[id^=""google_ads""]'
            ];
            selectors.forEach(selector => {
                document.querySelectorAll(selector).forEach(el => el.remove());
            });
            document.body.classList.remove('google-vignette-added');
            document.documentElement.style.overflow = 'auto';
        ";
                js.ExecuteScript(script);
            }
            catch { /* Ignore */ }
        }
    }
}