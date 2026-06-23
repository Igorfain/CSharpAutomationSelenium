using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using DotNetEnv;
using Infra.Pages.automationexercisePages;
using Infra.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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

        // When true: login is performed via HTTP (no browser), session cookies are injected into the driver
        protected virtual bool DoApiLogin => false;

        // When true: uses Selenium Grid remote browser instead of local ChromeDriver.
        //Make sure it false before pushing to avoid CI/CD issues if Selenium Grid is not available.
        protected virtual bool DoRemoteGrid => false;

        protected virtual string StartUrl => baseUrl;

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

            if (DoRemoteGrid)
            {
                driver = new RemoteWebDriver(new Uri(config.seleniumGridUrl), options.ToCapabilities());
            }
            else
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                driver = new ChromeDriver(options);
            }

            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Env.TraversePath().Load();
            baseUrl = config.url ?? string.Empty;
            username = Environment.GetEnvironmentVariable("LOGIN_USERNAME") ?? string.Empty;
            password = Environment.GetEnvironmentVariable("LOGIN_PASSWORD") ?? string.Empty;
            invalidUsername = Environment.GetEnvironmentVariable("INVALID_USERNAME") ?? string.Empty;
            invalidPassword = Environment.GetEnvironmentVariable("INVALID_PASSWORD") ?? string.Empty;

            var loginPage = new LoginPage(driver, wait);
            loginPage.NavigateToHome(StartUrl);
            RemoveAds();

            if (DoApiLogin)
            {
                // Get session cookies via HTTP POST (skips browser login UI entirely)
                var sessionCookies = ApiLoginHelper.GetSessionCookies(baseUrl, username, password);

                // Browser must already be on the domain before cookies can be added (done above via NavigateToHome)
                foreach (var sessionCookie in sessionCookies)
                {
                    driver.Manage().Cookies.AddCookie(new Cookie(
                        sessionCookie.Name,
                        sessionCookie.Value,
                        sessionCookie.Domain,
                        sessionCookie.Path,
                        null
                    ));
                }

                // Refresh so the browser picks up the injected session and loads the authenticated state
                driver.Navigate().Refresh();
                RemoveAds();
            }
            else if (DoDefaultLogin)
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