using Allure.NUnit.Attributes;
using Infra.Api.Factories;
using Infra.Api.Helpers;
using Infra.Base;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace CSharpAutomationSelenium.Tests.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    // Allows individual test methods in this class to run at the same time
    [Parallelizable(ParallelScope.Children)]
    public class PetStoreTestsApi : BaseApiTest
    {
        [Test]
        [AllureStory("Create Pet")]
        public async Task CreatePet()
        {
            var (request, id, name) = PetFactory.CreatePetRequest();
            var response = await client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [AllureStory("Get Pet")]
        public async Task GetPet()
        {
            var (createRequest, id, name) = PetFactory.CreatePetRequest();
            await client.ExecuteAsync(createRequest);

            var request = CreateRequest(Method.Get, $"pet/{id}");
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var pet = JsonConvert.DeserializeObject<PetModel>(response.Content);
            PetValidator.ValidateCreatedPet(pet, id, name);
        }

        [Test]
        [AllureStory("Delete Pet")]
        public async Task DeletePet()
        {
            var (createRequest, id, name) = PetFactory.CreatePetRequest();
            await client.ExecuteAsync(createRequest);

            var request = CreateRequest(Method.Delete, $"pet/{id}");
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}