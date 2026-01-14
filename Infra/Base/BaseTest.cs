using Allure.Net.Commons;
using Allure.NUnit;
using automationexerciseTests.Pages;
using Infra.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DotNetEnv;

namespace Infra.Base
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver? driver;
        protected WebDriverWait? wait;
        protected string? baseUrl;
        protected MainConfig? config;
        protected string? username;
        protected string? password;
        protected string? invalidUsername;
        protected string? invalidPassword;

        protected virtual bool DoDefaultLogin => true;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless=new");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Env.TraversePath().Load();
            var json = File.ReadAllText("Config/MainConfig.json");
            config = JsonConvert.DeserializeObject<MainConfig>(json);

            baseUrl = config.url;
            username = Environment.GetEnvironmentVariable("LOGIN_USERNAME");
            password = Environment.GetEnvironmentVariable("LOGIN_PASSWORD");
            invalidUsername = Environment.GetEnvironmentVariable("INVALID_USERNAME");
            invalidPassword = Environment.GetEnvironmentVariable("INVALID_PASSWORD");

            var loginPage = new LoginPage(driver, wait);
            loginPage.NavigateToHome(baseUrl);

            if (DoDefaultLogin)
            {
                loginPage.Login(username, password);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var bytes = screenshot.AsByteArray;

                AllureApi.AddAttachment(
                    "Screenshot",
                    "image/png",
                    bytes
                );
            }

            driver.Quit();
            driver.Dispose();
        }
    }
}
