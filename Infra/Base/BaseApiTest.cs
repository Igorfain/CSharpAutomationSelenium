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
    [Parallelizable(ParallelScope.Fixtures)]

    public class BaseApiTest
    {
        protected RestClient? client;

        [SetUp]
        public void Setup()
        {
            client = PetStoreClientProvider.Client;
        }

        protected RestRequest CreateRequest(Method method, string resource)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            return request;
        }
    }
}