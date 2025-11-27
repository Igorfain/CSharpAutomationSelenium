using Allure.NUnit.Attributes;
using Infra.Api;
using Infra.Base;
using Newtonsoft.Json;
using RestSharp;

namespace CSharpAutomationSelenium.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    public class PetStoreTestsApi : BaseApiTest
    {
        private const long PetId = 77701;

        [Test]
        [Order(1)]
        [AllureStory("Create Pet")]
        public void CreatePet()
        {
            var pet = new
            {
                Id = PetId,
                Name = "FreeWindPet",
                Status = "available"
            };

            var request = new RestRequest(PetStoreEndpoints.CREATE_PET, Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(pet);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null);
        }

        [Test]
        [Order(2)]
        [AllureStory("Get Pet")]
        public void GetPet()
        {
            var request = new RestRequest(PetStoreEndpoints.GET_PET + PetId, Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null);

            dynamic pet = JsonConvert.DeserializeObject(response.Content);
            Assert.That((string)pet.name, Is.EqualTo("FreeWindPet"));
        }

        [Test]
        [Order(3)]
        [AllureStory("Delete Pet")]
        public void DeletePet()
        {
            var request = new RestRequest(PetStoreEndpoints.DELETE_PET + PetId, Method.Delete);
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }


    }
}
