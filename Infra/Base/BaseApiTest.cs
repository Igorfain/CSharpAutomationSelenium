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
        protected RestRequest request;

        [SetUp]
        public void Setup()
        {
            client = PetStoreClientProvider.Client;

            request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

        }

        protected void SetRequest(Method method, string resource)
        {
            request.Method = method;
            request.Resource = resource;
        }
    }
}
