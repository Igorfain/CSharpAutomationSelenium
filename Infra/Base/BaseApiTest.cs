using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using RestSharp;

namespace Infra.Base
{

    [AllureNUnit]
    [AllureEpic("API Tests")]
    [Category("API")]
    public class BaseApiTest
    {
        protected RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://petstore.swagger.io/v2");
        }

        [TearDown]
        public void TearDown()
        {
            client?.Dispose();
        }
    }
}
