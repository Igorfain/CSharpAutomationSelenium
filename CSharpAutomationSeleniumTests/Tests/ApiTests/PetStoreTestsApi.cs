using Allure.NUnit.Attributes;
using Infra.Api.Factories;
using Infra.Api.Helpers;
using Infra.Base;
using Infra.Utils;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace CSharpAutomationSelenium.Tests.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    [Parallelizable(ParallelScope.Children)]
    public class PetStoreTestsApi : BaseApiTest
    {
        [Test]
        [AllureStory("Create Pet")]
        public async Task CreatePet()
        {
            LoggerUtils.LogStep("API-Create Pet");
            var (request, id, name) = PetFactory.CreatePetRequest();
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [AllureStory("Get Pet")]
        public async Task GetPet()
        {
            LoggerUtils.LogStep("API-GET Pet");
            // 1. Validate setup (creation)
            var (createRequest, id, name) = PetFactory.CreatePetRequest();
            var createResponse = await client.ExecuteAsync(createRequest);
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Setup: Failed to create pet");

            // 2. Execute GET
            var request = CreateRequest(Method.Get, $"pet/{id}");
            var response = await client.ExecuteAsync(request);

            // 3. Null safety and validation
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty, "Response content is empty");

            var pet = JsonConvert.DeserializeObject<PetModel>(response.Content);
            Assert.That(pet, Is.Not.Null, "Failed to deserialize PetModel");

            PetValidator.ValidateCreatedPet(pet, id, name);
        }

        [Test]
        [AllureStory("Delete Pet")]
        public async Task DeletePet()
        {
            LoggerUtils.LogStep("API-Delete Pet");
            // 1. Validate setup (creation)
            var (createRequest, id, name) = PetFactory.CreatePetRequest();
            var createResponse = await client.ExecuteAsync(createRequest);
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Setup: Failed to create pet");

            // 2. Execute DELETE
            var request = CreateRequest(Method.Delete, $"pet/{id}");
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}