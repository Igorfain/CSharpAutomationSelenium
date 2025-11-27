using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using RestSharp;
using Infra.Api;

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
            client = PetStoreClientProvider.Client;
        }

    
    }
}
